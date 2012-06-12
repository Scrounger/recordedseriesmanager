Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Security.Cryptography
Imports System.Text
Imports System.Reflection
Imports System.Threading
Imports System.Windows.Forms
Imports System.IO

Imports SetupTv
Imports TvControl
Imports TvEngine
Imports TvEngine.Events
Imports TvLibrary.Interfaces
Imports TvEngine.PowerScheduler.Interfaces
Imports System.Timers
Imports Gentle.Framework
Imports Gentle.Common
Imports TvDatabase

Namespace TvEngine

    <CLSCompliant(False)> _
    Public Class RecordedSeriesManagerSetup

        Implements ITvServerPlugin
        Implements ITvServerPluginStartedAll

#Region "Members"
        Private _stateTimer As System.Timers.Timer
        Private _isImporting As Boolean = False
        Private _counter As Integer = 0
        Private _lastNum As String = String.Empty

        'Private Const _timerIntervall As Long = 30000

#End Region


#Region "Properties"

        ''' <summary>
        ''' returns the name of the plugin
        ''' </summary>
        Public ReadOnly Property Name() As String Implements ITvServerPlugin.Name
            Get
                Return "RecordedSeriesManager"
            End Get
        End Property

        ''' <summary>
        ''' returns the version of the plugin
        ''' </summary>
        Public ReadOnly Property Version() As String Implements ITvServerPlugin.Version
            Get
                Return "0.7.1.7"
            End Get
        End Property

        ''' <summary>
        ''' returns the author of the plugin
        ''' </summary>
        Public ReadOnly Property Author() As String Implements ITvServerPlugin.Author
            Get
                Return "Scrounger"
            End Get
        End Property

        ''' <summary>
        ''' returns if the plugin should only run on the master server
        ''' or also on slave servers
        ''' </summary>
        Public ReadOnly Property MasterOnly() As Boolean Implements ITvServerPlugin.MasterOnly
            Get
                Return True
            End Get
        End Property
#End Region

#Region "Methods"
        ''' <summary>
        ''' Starts the plugin
        ''' </summary>
        Public Sub Start(ByVal controller As TvControl.IController) Implements ITvServerPlugin.Start
            StartStopTimer(True)
            MyLog.Debug("background timer started")
        End Sub

        Public Sub StartedAll() Implements ITvServerPluginStartedAll.StartedAll
            RegisterForEPGSchedule()
        End Sub

        ''' <summary>
        ''' Stops the plugin
        ''' </summary>
        Public Sub [Stop]() Implements ITvServerPlugin.Stop

            If _stateTimer IsNot Nothing Then
                StartStopTimer(False)
                _stateTimer.Dispose()
            End If

        End Sub

        ''' <summary>
        ''' returns the setup sections for display in SetupTv
        ''' </summary>
        Public ReadOnly Property Setup() As SectionSettings Implements ITvServerPlugin.Setup
            Get
                Return New SetupTv.Sections.RecordedSeriesManagerConfig
            End Get
        End Property
#End Region

#Region "Functions"
        Private Sub StartStopTimer(ByVal startNow As Boolean)
            Dim _layer As New TvBusinessLayer

            If startNow Then
                If _stateTimer Is Nothing Then
                    _stateTimer = New System.Timers.Timer()
                    AddHandler _stateTimer.Elapsed, New ElapsedEventHandler(AddressOf CheckRecordingNeedsScan)
                    _stateTimer.Interval = CLng(_layer.GetSetting("RecordedSeriesManagerScanInterval", "30000").Value)
                    _stateTimer.AutoReset = True

                    GC.KeepAlive(_stateTimer)
                End If
                _stateTimer.Start()
                _stateTimer.Enabled = True

            Else
                _stateTimer.Enabled = False
                _stateTimer.[Stop]()
                MyLog.Debug("background timer stopped")
            End If
        End Sub

        Friend Sub CheckRecordingNeedsScan()
            Try

                If _isImporting = False Then

                    Dim _layer As New TvBusinessLayer

                    _counter = 0

                    _lastNum = _layer.GetSetting("RecordedSeriesManagerLastNum", "0").Value

                    'alle recordings mit Serien & EpisodenNr. laden, die nicht gerade aufgenommen werden
                    Dim sbRecording As New SqlBuilder(Gentle.Framework.StatementType.Select, GetType(Recording))
                    sbRecording.AddConstraint([Operator].GreaterThan, "seriesNum", "")
                    sbRecording.AddConstraint([Operator].GreaterThan, "episodeNum", "")
                    sbRecording.AddConstraint([Operator].Equals, "isRecording", 0)
                    Dim stmtRecording As SqlStatement = sbRecording.GetStatement(True)
                    Dim _SeriesFound As IList(Of Recording) = ObjectFactory.GetCollection(GetType(Recording), stmtRecording.Execute())

                    'Prüfen ob ein neuer Scan laufen muss
                    If Not _SeriesFound.Count = CInt(_lastNum) Then

                        _isImporting = True

                        MyLog.Debug("")

                        Helper.TestMode = CBool(_layer.GetSetting("RecordedSeriesManagerTestMode", "true").Value)

                        If Helper.TestMode = False Then
                            MyLog.Debug("********** Start Scan **********")
                        Else
                            MyLog.Debug("********** Start Scan **********")
                            MyLog.Debug("********** Test Mode! **********")
                        End If

                        MyLog.Debug("changes in recording found ({0} / {1})", _SeriesFound.Count, _lastNum)
                        MyLog.Debug("recording folder: {0}", Helper.RecordingFolder)
                        MyLog.Debug("scan interval: {0}s", CInt(_layer.GetSetting("RecordedSeriesManagerScanInterval", "30000").Value) / 1000)
                        MyLog.Debug("series formating rule: {0}", _layer.GetSetting("seriesformat").Value)
                        MyLog.Debug("existing file handler - percentage: {0} %", _layer.GetSetting("RecordedSeriesManagerPercentage", "20").Value)
                        MyLog.Debug("existing file handler - keep moved files in TvServer records database: {0}", CBool(_layer.GetSetting("RecordedSeriesManagerKeepDataForMovedFiles", "false").Value))

                        If _layer.GetSetting("RecordedSeriesManagerLessThanPercentage", "none").Value = "folder" Then
                            MyLog.Debug("existing file handler - less than percentage: {0} - {1}", _layer.GetSetting("RecordedSeriesManagerLessThanPercentage", "none").Value, _layer.GetSetting("RecordedSeriesManagerLessThanPercentageFolder", "").Value)
                        Else
                            MyLog.Debug("existing file handler - less than percentage: {0}", _layer.GetSetting("RecordedSeriesManagerLessThanPercentage", "none").Value)
                        End If
                        If _layer.GetSetting("RecordedSeriesManagerGreaterThanPercentage", "none").Value = "folder" Then
                            MyLog.Debug("existing file handler - Greater than percentage: {0} - {1}", _layer.GetSetting("RecordedSeriesManagerGreaterThanPercentage", "none").Value, _layer.GetSetting("RecordedSeriesManagerGreaterThanPercentageFolder", "").Value)
                        Else
                            MyLog.Debug("existing file handler - Greater than percentage: {0}", _layer.GetSetting("RecordedSeriesManagerGreaterThanPercentage", "none").Value)
                        End If

                        _lastNum = _SeriesFound.Count

                        SetStandbyAllowed(False)

                        ScanRecordings(_SeriesFound)

                        If _counter > 0 Then
                            MyLog.Debug("")
                            MyLog.Debug("Scan completly - {0} files moved", _counter)
                        Else
                            MyLog.Debug("")
                            MyLog.Debug("Scan completly")
                        End If

                        'Standby erlauben & Trigger RecordedSeriesManagerLastNum speichern
                        SetStandbyAllowed(True)

                        Dim _setting As Setting = _layer.GetSetting("RecordedSeriesManagerLastNum", "0")
                        _setting.Value = _lastNum
                        _setting.Persist()

                        _isImporting = False

                        MyLog.Debug("")
                    Else
                        MyLog.Debug("no changes in recording found")
                    End If
                Else
                    MyLog.Debug("Scan still in progress....")
                End If

            Catch ex As Exception
                MyLog.Error("error {0}, stack {1}", ex.Message, ex.StackTrace)
            End Try

        End Sub

        Private Sub ScanRecordings(ByVal recordingList As IList(Of Recording))

            Dim _layer As New TvBusinessLayer

            For i = 0 To recordingList.Count - 1

                '!!!!!!!! Replace muss raus !!!!
                Dim _filenameDB As String = recordingList(i).FileName


                If InStr(_filenameDB, Replace(Replace(Replace(Replace(_layer.GetSetting("seriesformat").Value, _
                                            "%title%", recordingList(i).Title), _
                                            "%series%", recordingList(i).SeriesNum), _
                                            "%episode%", recordingList(i).EpisodeNum), _
                                            "%name%", recordingList(i).EpisodeName) & IO.Path.GetExtension(_filenameDB)) = 0 Then

                    MyLog.Debug("")
                    MyLog.Debug("wrong formating rule identified...")
                    MyLog.Debug("title: {0} - S{1}E{2}", recordingList(i).Title)
                    MyLog.Debug("filename: {0}", _filenameDB)


                    Dim _directory As String = Path.GetDirectoryName(_filenameDB)
                    Dim _recordsDirectory As String = Helper.RecordingFolder

                    If IO.Directory.Exists(_directory) = True Then

                        Dim _newTsFilename As String = _recordsDirectory & "\" & Replace(Replace(Replace(Replace(_layer.GetSetting("seriesformat").Value, _
                                            "%title%", recordingList(i).Title), _
                                            "%series%", recordingList(i).SeriesNum), _
                                            "%episode%", recordingList(i).EpisodeNum), _
                                            "%name%", recordingList(i).EpisodeName) & IO.Path.GetExtension(_filenameDB)

                        MyLog.Debug("corrected filename: {0}", _newTsFilename)

                        'prüfen ob korrekter dateiname schon vorhanden
                        If File.Exists(_newTsFilename) = False Then

                            'Dim _saveRecording As Boolean = False
                            Try
                                Helper.MoveRecording(_filenameDB, _newTsFilename, recordingList(i), True)

                            Catch exMoveTsFile As Exception
                                MyLog.Error("error: {0}, stack: {1}", exMoveTsFile.Message, exMoveTsFile.StackTrace)
                                MyLog.Error("try later again({0})", _newTsFilename)
                                _lastNum = "999999"
                                Continue For
                            End Try

                        Else
                            MyLog.Debug("found existing file...")

                            Dim _filnameDBinfo = New FileInfo(_filenameDB)
                            Dim _newTsFilenameInfo = New FileInfo(_newTsFilename)
                            Dim _percentage As Long = (_filnameDBinfo.Length / _newTsFilenameInfo.Length - 1) * 100

                            MyLog.Debug("existing *.ts file size: {0}, new *.ts file size: {1}, size difference {2} %", GetFileSize(_newTsFilename), GetFileSize(_filenameDB), Format(_percentage, "0.00"))
                            'MyLog.Debug("existing *.ts file {0}", _newTsFilename)

                            Dim _MoveFolder As String = String.Empty
                            Dim _handle As String = String.Empty


                            If _percentage >= -1 * CInt(_layer.GetSetting("RecordedSeriesManagerPercentage", "20").Value) And _percentage <= CInt(_layer.GetSetting("RecordedSeriesManagerPercentage", "20").Value) Then
                                'less than +/- percantage value
                                MyLog.Debug("existing file handler: difference {0} % less than +/- {1} %", Format(_percentage, "0.00"), _layer.GetSetting("RecordedSeriesManagerPercentage", "20").Value)

                                _handle = _layer.GetSetting("RecordedSeriesManagerLessThanPercentage", "none").Value
                                _MoveFolder = _layer.GetSetting("RecordedSeriesManagerLessThanPercentageFolder", "none").Value
                            Else
                                'greater than +/- percantage value

                                MyLog.Debug("existing file handler: difference {0} % greater than +/- {1} %", Format(_percentage, "0.00"), _layer.GetSetting("RecordedSeriesManagerPercentage", "20").Value)

                                _handle = _layer.GetSetting("RecordedSeriesManagerGreaterThanPercentage", "none").Value
                                _MoveFolder = _layer.GetSetting("RecordedSeriesManagerGreaterThanPercentageFolder", "none").Value
                            End If

                            If _handle = "folder" Then
                                MyLog.Debug("existing file handler: atcion: {0} -> {1}", _handle, _MoveFolder)
                            Else
                                MyLog.Debug("existing file handler: atcion: {0}", _handle)
                            End If

                            Select Case (_handle)
                                Case Is = "none"
                                    Continue For
                                Case Is = "folder"

                                    Dim _newMoveTsFilename As String = _MoveFolder & "\" & Replace(Replace(Replace(Replace(_layer.GetSetting("seriesformat").Value, _
                                            "%title%", recordingList(i).Title), _
                                            "%series%", recordingList(i).SeriesNum), _
                                            "%episode%", recordingList(i).EpisodeNum), _
                                            "%name%", recordingList(i).EpisodeName) & IO.Path.GetExtension(_filenameDB)

                                    If File.Exists(_newMoveTsFilename) = True Then

                                        MyLog.Debug("existing file handler: existing *.ts file in folder found -> detecting suffix...")
                                        For d = 1 To 50

                                            Dim _testFilename As String = _MoveFolder & "\" & Replace(Replace(Replace(Replace(_layer.GetSetting("seriesformat").Value, _
                                                                            "%title%", recordingList(i).Title), _
                                                                            "%series%", recordingList(i).SeriesNum), _
                                                                            "%episode%", recordingList(i).EpisodeNum), _
                                                                            "%name%", recordingList(i).EpisodeName) & _
                                                                            "_" & d & IO.Path.GetExtension(_filenameDB)

                                            If File.Exists(_testFilename) = True Then
                                                Continue For
                                            Else
                                                _newMoveTsFilename = _testFilename
                                                Exit For
                                            End If
                                        Next

                                    End If

                                    Try
                                        Helper.MoveRecording(_filenameDB, _newMoveTsFilename, recordingList(i), CBool(_layer.GetSetting("RecordedSeriesManagerKeepDataForMovedFiles", "false").Value), "existing file handler: ")
                                    Catch exMoveTsFile As Exception
                                        MyLog.Error("existing file handler: error: {0}, stack: {1}", exMoveTsFile.Message, exMoveTsFile.StackTrace)
                                        MyLog.Error("existing file handler: try later again({0})", _newMoveTsFilename)
                                        _lastNum = "999999"
                                        Continue For
                                    End Try

                                Case Is = "delete"
                                    Try
                                        Helper.DeleteRecording(_filenameDB, recordingList(i))
                                    Catch exDeleteTsFile As Exception
                                        MyLog.Error("existing file handler: error: {0}, stack: {1}", exDeleteTsFile.Message, exDeleteTsFile.StackTrace)
                                        _lastNum = "999999"
                                        Continue For
                                    End Try

                            End Select
                        End If
                    Else
                        MyLog.Error("directory not found: {0}", _directory)
                    End If

                End If
            Next


        End Sub

        Public Shared Function GetFileSize(ByVal path As String) As String
            Dim myFile As FileInfo
            Dim mySize As Single

            Try
                myFile = New FileInfo(path)

                If Not myFile.Exists Then
                    mySize = 0
                Else
                    mySize = myFile.Length
                End If

                Select Case mySize
                    Case 0 To 1023
                        Return mySize & " Bytes"
                    Case 1024 To 1048575
                        Return Format(mySize / 1024, "###0.00") & " KB"
                    Case 1048576 To 1043741824
                        Return Format(mySize / 1024 ^ 2, "###0.00") & " MB"
                    Case Is > 1043741824
                        Return Format(mySize / 1024 ^ 3, "###0.00") & " GB"
                End Select

                Return "0 bytes"

            Catch ex As Exception
                Return "0 bytes"
            End Try
        End Function


#End Region

#Region "Powerscheduler handling"

        Private Sub SetStandbyAllowed(ByVal allowed As Boolean)
            If GlobalServiceProvider.Instance.IsRegistered(Of IEpgHandler)() Then
                GlobalServiceProvider.Instance.[Get](Of IEpgHandler)().SetStandbyAllowed(Me, allowed, 1800)
                If Not allowed Then
                    MyLog.Debug("Telling PowerScheduler standby is allowed: {0}, timeout is 30 minutes", allowed)
                Else
                    MyLog.Debug("Telling PowerScheduler standby is allowed: {0}", allowed)
                End If
            End If
        End Sub

        Private Sub RegisterForEPGSchedule()
            ' Register with the EPGScheduleDue event so we are informed when
            ' the EPG wakeup schedule is due.
            If GlobalServiceProvider.Instance.IsRegistered(Of IEpgHandler)() Then
                Dim handler As IEpgHandler = GlobalServiceProvider.Instance.[Get](Of IEpgHandler)()
                If handler IsNot Nothing Then
                    AddHandler handler.EPGScheduleDue, New EPGScheduleHandler(AddressOf EPGScheduleDue)
                    MyLog.Debug("registered with PowerScheduler EPG handler")
                    Return
                End If
            End If
            MyLog.Debug("NOT registered with PowerScheduler EPG handler")
        End Sub

        Private Sub EPGScheduleDue()
            CheckRecordingNeedsScan()
        End Sub

#End Region

    End Class
End Namespace

