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

Public Class Helper
#Region "Members"
    Friend Shared TestMode As Boolean = True

#End Region

    Shared ReadOnly Property RecordingFolder() As String
        Get
            '!!!!!!!! Replace muss raus !!!!
            Dim _folder As IList(Of Card) = Card.ListAll
            Return _folder(0).RecordingFolder

        End Get
    End Property

    Friend Shared Sub MoveRecording(ByVal sourceFilename As String, ByVal filename As String, ByVal rec As Recording, Optional ByVal updateRecordingEntry As Boolean = False, Optional ByVal LogPrefix As String = "")

        Dim _layer As New TvBusinessLayer

        Dim _directory As String = IO.Path.GetDirectoryName(sourceFilename)
        Dim _recordsDirectory As String = Helper.RecordingFolder

        If Directory.Exists(IO.Path.GetDirectoryName(filename)) = False Then
            Directory.CreateDirectory(IO.Path.GetDirectoryName(filename))
        End If

        'ts file verschieben, fehler -> Continue, try later, _lastNum reset
        MyLog.Debug("{0}move video file... ({1} -> {2})", LogPrefix, sourceFilename, filename)

        If Helper.TestMode = False Then
            File.Move(sourceFilename, filename)
        End If

        If updateRecordingEntry = True Then

            'recording database path updaten
            If Helper.TestMode = False Then
                rec.FileName = filename
                rec.Persist()
            End If
            MyLog.Debug("{0}recording table updated...", LogPrefix)
        Else

            'delete recording database entry
            If Helper.TestMode = False Then
                rec.Delete()
            End If
            MyLog.Debug("{0}delete recording database entry...", LogPrefix)
        End If

        'alle weiteren dateien kopieren z.B. *.xml, *.jpg, comskip files
        For Each Datei As String In My.Computer.FileSystem.GetFiles(_directory, FileIO.SearchOption.SearchTopLevelOnly, IO.Path.GetFileNameWithoutExtension(sourceFilename) & ".*")

            Dim _newFilename As String = Path.GetDirectoryName(filename) & "\" & Path.GetFileNameWithoutExtension(filename) & IO.Path.GetExtension(Datei)

            Try
                If Not Path.GetExtension(Datei) = ".ts" Then
                    MyLog.Debug("{0}move {1} file... ({2} -> {3})", LogPrefix, IO.Path.GetExtension(Datei), Datei, _newFilename)
                    If Helper.TestMode = False Then
                        File.Move(Datei, _newFilename)
                    End If
                End If
            Catch exMoveOtherFiles As Exception
                MyLog.Error("{0}error: {1}, stack: {2}", LogPrefix, exMoveOtherFiles.Message, exMoveOtherFiles.StackTrace)
                Continue For
            End Try
        Next

    End Sub

    Friend Shared Sub DeleteRecording(ByVal filename As String, ByVal rec As Recording)
        'ts file löschen, fehler -> Continue, try later, _lastNum reset

        Dim _directory As String = IO.Path.GetDirectoryName(filename)

        MyLog.Debug("existing file handler: delete video file... ({0})", filename)
        If Helper.TestMode = False Then
            File.Delete(filename)
        End If

        'delete recording database entry
        If Helper.TestMode = False Then
            rec.Delete()
        End If

        MyLog.Debug("existing file handler: delete recording database entry...")

        'alle weiteren dateien kopieren z.B. *.xml, *.jpg, comskip files
        For Each Datei As String In My.Computer.FileSystem.GetFiles(_directory, FileIO.SearchOption.SearchTopLevelOnly, Path.GetFileNameWithoutExtension(filename) & ".*")

            Try
                If Not Path.GetExtension(Datei) = ".ts" Then
                    MyLog.Debug("existing file handler: delete {0} file... ({1})", Path.GetExtension(Datei), Datei)
                    If Helper.TestMode = False Then
                        File.Delete(Datei)
                    End If
                End If
            Catch exDeleteOtherFiles As Exception
                MyLog.Error("existing file handler: error: {0}, stack: {1}", exDeleteOtherFiles.Message, exDeleteOtherFiles.StackTrace)
                Continue For
            End Try
        Next
    End Sub

End Class
