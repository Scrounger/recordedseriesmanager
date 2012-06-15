Imports System.Collections
Imports System.Collections.Generic
Imports System.Configuration
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml

Imports TvControl
Imports MediaPortal.UserInterface.Controls
Imports MediaPortal.Configuration
Imports TvEngine
Imports TvEngine.Events
Imports SetupTv
Imports System.Threading
Imports TvDatabase
Imports Gentle.Framework
Imports Gentle.Common
Imports TvLibrary.Interfaces
Imports TvLibrary.Log
Imports System.Deployment.Application


Imports MediaPortal.Utils
Imports MediaPortal.Util
Imports RecordedSeriesManager.TvEngine.RecordedSeriesManagerSetup



Namespace SetupTv.Sections

    <CLSCompliant(False)> _
    Public Class RecordedSeriesManagerConfig

        Inherits SectionSettings

        'define window functions
        <DllImport("User32.dll")> _
        Public Shared Function SetForegroundWindow(ByVal hWnd As Integer) As Int32
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
        End Function

#Region "Members"
        Private Declare Function ExtractIcon Lib "shell32.dll" Alias "ExtractIconA" _
            (ByVal hInst As IntPtr, ByVal lpszExeFileName As String, ByVal nIconIndex As Integer) As IntPtr
        Private settingsSavedSuccesfully As Boolean = False

#End Region

#Region "Constructor"

        Public Sub New()
            InitializeComponent()
        End Sub
#End Region

#Region "SetupTv.SectionSettings"

        Public Overrides Sub OnSectionActivated()
            MyBase.OnSectionActivated()

        End Sub

        Public Overrides Sub OnSectionDeActivated()
            MyBase.OnSectionDeActivated()
        End Sub
#End Region

        Private Sub RecordedSeriesManagerConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            MyLog.Debug("")
            MyLog.Debug("********** Configuration open **********")

            Dim _plugin As New TvEngine.RecordedSeriesManagerSetup
            Dim _layer As New TvBusinessLayer

            tbSeriesFormatingRule.Text = _layer.GetSetting("seriesformat").Value
            tbSample.Text = Replace(Replace(Replace(Replace(_layer.GetSetting("seriesformat").Value, _
                                                    "%title%", "Friends"), _
                                                    "%series%", "4"), "%episode%", "32"), _
                                                    "%name%", "Joey's Birthday") & ".ts"

            TPLabelVersion.Text = "Version: " & _plugin.Version

            NumInterval.Value = CInt(_layer.GetSetting("RecordedSeriesManagerScanInterval", "30000").Value) / 1000
            tbRecPath.Text = Helper.RecordingFolder


            Dim hIcon As IntPtr
            hIcon = ExtractIcon(Me.Handle, "%SystemRoot%\System32\shell32.dll", 6)
            If hIcon <> 0 And hIcon <> 1 Then
                Dim ic As Icon = Icon.FromHandle(hIcon)
                TPBTSave.Image = ic.ToBitmap
            End If

            hIcon = ExtractIcon(Me.Handle, "%SystemRoot%\System32\imageres.dll", 168)
            If hIcon <> 0 And hIcon <> 1 Then
                Dim ic As Icon = Icon.FromHandle(hIcon)
                TPBtScan.Image = ic.ToBitmap
            End If

            hIcon = ExtractIcon(Me.Handle, "%SystemRoot%\System32\imageres.dll", 76)
            If hIcon <> 0 And hIcon <> 1 Then
                Dim ic As Icon = Icon.FromHandle(hIcon)
                PicInfo.BackgroundImage = ic.ToBitmap
            End If

            Select Case (_layer.GetSetting("RecordedSeriesManagerLessThanPercentage", "none").Value)
                Case Is = "none"
                    RbLessNone.Checked = True
                Case Is = "folder"
                    RbLessFolder.Checked = True
                    GBoxLessMoveFolder.Enabled = True
                Case Is = "delete"
                    RbLessDelete.Checked = True
            End Select

            Select Case (_layer.GetSetting("RecordedSeriesManagerGreaterThanPercentage", "none").Value)
                Case Is = "none"
                    RbGreaterNone.Checked = True
                Case Is = "folder"
                    RbGreaterFolder.Checked = True
                    GBoxGreaterMoveFolder.Enabled = True
                Case Is = "delete"
                    RbGreaterDelete.Checked = True
            End Select

            NumPercentage.Value = CInt(_layer.GetSetting("RecordedSeriesManagerPercentage", "20").Value)
            TbLessThanPercentageFolder.Text = _layer.GetSetting("RecordedSeriesManagerLessThanPercentageFolder", "").Value
            TbGreaterThanPercentageFolder.Text = _layer.GetSetting("RecordedSeriesManagerGreaterThanPercentageFolder", "").Value

            GBoxLessThanPercentage.Text = "action if file size difference is less than + / - " & NumPercentage.Value & " %"
            GBoxGreaterThanPercentage.Text = "action if file size difference is Greater than + / - " & NumPercentage.Value & " %"

            CheckKeepDataInDb.Checked = CBool(_layer.GetSetting("RecordedSeriesManagerKeepDataForMovedFiles", "false").Value)
            CheckTestMode.Checked = CBool(_layer.GetSetting("RecordedSeriesManagerTestMode", "true").Value)
            TPLabelTestMode.Visible = CBool(_layer.GetSetting("RecordedSeriesManagerTestMode", "true").Value)

            MyLog.Debug("")
            MyLog.Debug("Load settings...")
            MyLog.Debug("recording folder: {0}", Helper.RecordingFolder)
            MyLog.Debug("scan interval: {0}s", CInt(_layer.GetSetting("RecordedSeriesManagerScanInterval", "30000").Value) / 1000)
            MyLog.Debug("series formating rule: {0}", _layer.GetSetting("seriesformat").Value)
            MyLog.Debug("existing file handler - percentage: {0}", NumPercentage.Value & " %")
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

        End Sub

        Private Sub BtSaveSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            storeSettings()
        End Sub
        Private Sub storeSettings()

            settingsSavedSuccesfully = False

            If RbLessFolder.Checked = True And String.IsNullOrEmpty(TbLessThanPercentageFolder.Text) = True Then
                MsgBox("'move to folder is activated and no folder specified!", MsgBoxStyle.Critical, "Warning ...")
                Exit Sub
            End If

            If RbGreaterFolder.Checked = True And String.IsNullOrEmpty(TbGreaterThanPercentageFolder.Text) = True Then
                MsgBox("'move to folder' is activated and no folder is specified!", MsgBoxStyle.Critical, "Warning ...")
                Exit Sub
            End If

            MyLog.Debug("")
            MyLog.Debug("save settings...")
            Dim _layer As New TvBusinessLayer

            Dim _plugin As New TvEngine.RecordedSeriesManagerSetup

            Dim _setting As Setting = _layer.GetSetting("RecordedSeriesManagerScanInterval", "30000")
            _setting.Value = CStr(NumInterval.Value * 1000)
            _setting.Persist()

            _setting = _layer.GetSetting("RecordedSeriesManagerPercentage", "20")
            _setting.Value = CStr(NumPercentage.Value)
            _setting.Persist()


            _setting = _layer.GetSetting("RecordedSeriesManagerLessThanPercentageFolder", "")
            _setting.Value = TbLessThanPercentageFolder.Text
            _setting.Persist()

            _setting = _layer.GetSetting("RecordedSeriesManagerGreaterThanPercentageFolder", "")
            _setting.Value = TbGreaterThanPercentageFolder.Text
            _setting.Persist()



            MyLog.Debug("recording folder: {0}", Helper.RecordingFolder)
            MyLog.Debug("scan interval: {0}s", CInt(_layer.GetSetting("RecordedSeriesManagerScanInterval", "30000").Value) / 1000)
            MyLog.Debug("series formating rule: {0}", _layer.GetSetting("seriesformat").Value)
            MyLog.Debug("existing file handler - percentage: {0}", NumPercentage.Value & " %")
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

            settingsSavedSuccesfully = True

        End Sub

        Private Sub TPBTSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TPBTSave.Click
            storeSettings()
        End Sub

        Private Sub TPBtScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TPBtScan.Click
            Dim _layer As New TvBusinessLayer

            MyLog.Debug("")
            MyLog.Debug("********** manual scan **********")
            storeSettings()

            If settingsSavedSuccesfully = True Then
                Dim _setting As Setting = _layer.GetSetting("RecordedSeriesManagerLastNum", "0")
                _setting.Value = "999999"
                _setting.Persist()

                Dim _scan As New TvEngine.RecordedSeriesManagerSetup

                Dim _thread As New Thread(AddressOf _scan.CheckRecordingNeedsScan)
                _thread.Start()
            Else
                MyLog.Error("could not save settings !")
            End If

        End Sub

#Region "Change Events"
        Private Sub RbLessNone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbLessNone.CheckedChanged
            Dim _layer As New TvBusinessLayer
            Dim _setting As Setting = _layer.GetSetting("RecordedSeriesManagerLessThanPercentage", "none")
            _setting.Value = "none"
            _setting.Persist()

            GBoxLessMoveFolder.Enabled = RbLessFolder.Checked
        End Sub
        Private Sub RbLessFolder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbLessFolder.CheckedChanged
            Dim _layer As New TvBusinessLayer
            Dim _setting As Setting = _layer.GetSetting("RecordedSeriesManagerLessThanPercentage", "none")
            _setting.Value = "folder"
            _setting.Persist()

            GBoxLessMoveFolder.Enabled = RbLessFolder.Checked
        End Sub
        Private Sub RbLessDelete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbLessDelete.CheckedChanged
            Dim _layer As New TvBusinessLayer
            Dim _setting As Setting = _layer.GetSetting("RecordedSeriesManagerLessThanPercentage", "none")
            _setting.Value = "delete"
            _setting.Persist()

            GBoxLessMoveFolder.Enabled = RbLessFolder.Checked
        End Sub
        Private Sub RbGreaterNone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbGreaterNone.CheckedChanged
            Dim _layer As New TvBusinessLayer
            Dim _setting As Setting = _layer.GetSetting("RecordedSeriesManagerGreaterThanPercentage", "none")
            _setting.Value = "none"
            _setting.Persist()

            GBoxGreaterMoveFolder.Enabled = RbGreaterFolder.Checked
        End Sub
        Private Sub RbGreaterFolder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbGreaterFolder.CheckedChanged
            Dim _layer As New TvBusinessLayer
            Dim _setting As Setting = _layer.GetSetting("RecordedSeriesManagerGreaterThanPercentage", "none")
            _setting.Value = "folder"
            _setting.Persist()

            GBoxGreaterMoveFolder.Enabled = RbGreaterFolder.Checked
        End Sub
        Private Sub RbGreaterDelete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbGreaterDelete.CheckedChanged
            Dim _layer As New TvBusinessLayer
            Dim _setting As Setting = _layer.GetSetting("RecordedSeriesManagerGreaterThanPercentage", "none")
            _setting.Value = "delete"
            _setting.Persist()

            GBoxGreaterMoveFolder.Enabled = RbGreaterFolder.Checked
        End Sub
#End Region


        Private Sub NumPercentage_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumPercentage.ValueChanged
            GBoxLessThanPercentage.Text = "action if file size difference is less than + / - " & NumPercentage.Value & " %"
            GBoxGreaterThanPercentage.Text = "action if file size difference is Greater than + / - " & NumPercentage.Value & " %"
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim _rec As Recording = Recording.Retrieve(798)

            _rec.Delete()

        End Sub

        Private Sub CheckKeepDataInDb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckKeepDataInDb.CheckedChanged
            Dim _layer As New TvBusinessLayer
            Dim _setting As Setting = _layer.GetSetting("RecordedSeriesManagerKeepDataForMovedFiles", "false")
            _setting.Value = CStr(CheckKeepDataInDb.Checked)
            _setting.Persist()
        End Sub

        Private Sub CheckTestMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckTestMode.CheckedChanged
            Dim _layer As New TvBusinessLayer
            Dim _setting As Setting = _layer.GetSetting("RecordedSeriesManagerTestMode", "false")
            _setting.Value = CStr(CheckTestMode.Checked)
            _setting.Persist()

            TPLabelTestMode.Visible = CheckTestMode.Checked
        End Sub

        Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim bla2 As IList(Of Card) = Card.ListAll

            'Dim bla As New TvServer
            'MsgBox(bla.IsAnyCardRecordingOrTimeshifting(bla.GetUserForCard(0), True, True))


        End Sub
    End Class
End Namespace

