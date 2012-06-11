Imports System.Windows.Forms
Imports SetupTv

Namespace SetupTv.Sections

    Partial Class RecordedSeriesManagerConfig
        Inherits SectionSettings

        'Wird vom Windows Form-Designer benötigt.
        Private components As System.ComponentModel.IContainer

        'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
        'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
        'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecordedSeriesManagerConfig))
            Me.TvLogosList = New System.Windows.Forms.ImageList(Me.components)
            Me.tbSeriesFormatingRule = New System.Windows.Forms.TextBox
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.Panel3 = New System.Windows.Forms.Panel
            Me.tbSample = New System.Windows.Forms.TextBox
            Me.Label3 = New System.Windows.Forms.Label
            Me.Panel2 = New System.Windows.Forms.Panel
            Me.Label2 = New System.Windows.Forms.Label
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.TabControl1 = New System.Windows.Forms.TabControl
            Me.TabPage1 = New System.Windows.Forms.TabPage
            Me.Panel11 = New System.Windows.Forms.Panel
            Me.CheckTestMode = New System.Windows.Forms.CheckBox
            Me.Panel6 = New System.Windows.Forms.Panel
            Me.Panel7 = New System.Windows.Forms.Panel
            Me.GroupBox2 = New System.Windows.Forms.GroupBox
            Me.Panel4 = New System.Windows.Forms.Panel
            Me.Label1 = New System.Windows.Forms.Label
            Me.NumInterval = New System.Windows.Forms.NumericUpDown
            Me.Label4 = New System.Windows.Forms.Label
            Me.Panel8 = New System.Windows.Forms.Panel
            Me.GroupBox3 = New System.Windows.Forms.GroupBox
            Me.Panel5 = New System.Windows.Forms.Panel
            Me.tbRecPath = New System.Windows.Forms.TextBox
            Me.Label5 = New System.Windows.Forms.Label
            Me.TabPage2 = New System.Windows.Forms.TabPage
            Me.Panel16 = New System.Windows.Forms.Panel
            Me.CheckKeepDataInDb = New System.Windows.Forms.CheckBox
            Me.Panel13 = New System.Windows.Forms.Panel
            Me.GBoxGreaterThanPercentage = New System.Windows.Forms.GroupBox
            Me.Panel14 = New System.Windows.Forms.Panel
            Me.GBoxGreaterMoveFolder = New System.Windows.Forms.GroupBox
            Me.Panel15 = New System.Windows.Forms.Panel
            Me.TbGreaterThanPercentageFolder = New System.Windows.Forms.TextBox
            Me.Label6 = New System.Windows.Forms.Label
            Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
            Me.RbGreaterNone = New System.Windows.Forms.RadioButton
            Me.RbGreaterFolder = New System.Windows.Forms.RadioButton
            Me.RbGreaterDelete = New System.Windows.Forms.RadioButton
            Me.Panel12 = New System.Windows.Forms.Panel
            Me.GBoxLessThanPercentage = New System.Windows.Forms.GroupBox
            Me.Panel9 = New System.Windows.Forms.Panel
            Me.GBoxLessMoveFolder = New System.Windows.Forms.GroupBox
            Me.Panel17 = New System.Windows.Forms.Panel
            Me.TbLessThanPercentageFolder = New System.Windows.Forms.TextBox
            Me.Label9 = New System.Windows.Forms.Label
            Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
            Me.RbLessNone = New System.Windows.Forms.RadioButton
            Me.RbLessFolder = New System.Windows.Forms.RadioButton
            Me.RbLessDelete = New System.Windows.Forms.RadioButton
            Me.Panel10 = New System.Windows.Forms.Panel
            Me.Label8 = New System.Windows.Forms.Label
            Me.NumPercentage = New System.Windows.Forms.NumericUpDown
            Me.Label7 = New System.Windows.Forms.Label
            Me.ToolStrip = New System.Windows.Forms.ToolStrip
            Me.TPBTSave = New System.Windows.Forms.ToolStripButton
            Me.TPBtScan = New System.Windows.Forms.ToolStripButton
            Me.TPLabelVersion = New System.Windows.Forms.ToolStripLabel
            Me.TPLabelTestMode = New System.Windows.Forms.ToolStripLabel
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.GroupBox1.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.Panel11.SuspendLayout()
            Me.Panel6.SuspendLayout()
            Me.Panel7.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.Panel4.SuspendLayout()
            CType(Me.NumInterval, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel8.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.Panel5.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            Me.Panel16.SuspendLayout()
            Me.Panel13.SuspendLayout()
            Me.GBoxGreaterThanPercentage.SuspendLayout()
            Me.Panel14.SuspendLayout()
            Me.GBoxGreaterMoveFolder.SuspendLayout()
            Me.Panel15.SuspendLayout()
            Me.FlowLayoutPanel2.SuspendLayout()
            Me.Panel12.SuspendLayout()
            Me.GBoxLessThanPercentage.SuspendLayout()
            Me.Panel9.SuspendLayout()
            Me.GBoxLessMoveFolder.SuspendLayout()
            Me.Panel17.SuspendLayout()
            Me.FlowLayoutPanel1.SuspendLayout()
            Me.Panel10.SuspendLayout()
            CType(Me.NumPercentage, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ToolStrip.SuspendLayout()
            Me.SuspendLayout()
            '
            'TvLogosList
            '
            Me.TvLogosList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
            Me.TvLogosList.ImageSize = New System.Drawing.Size(60, 40)
            Me.TvLogosList.TransparentColor = System.Drawing.Color.Transparent
            '
            'tbSeriesFormatingRule
            '
            Me.tbSeriesFormatingRule.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbSeriesFormatingRule.Location = New System.Drawing.Point(59, 10)
            Me.tbSeriesFormatingRule.Name = "tbSeriesFormatingRule"
            Me.tbSeriesFormatingRule.ReadOnly = True
            Me.tbSeriesFormatingRule.Size = New System.Drawing.Size(341, 20)
            Me.tbSeriesFormatingRule.TabIndex = 1
            Me.ToolTip1.SetToolTip(Me.tbSeriesFormatingRule, "Config your series formating rule under Recording -> Tab: custom path and filenam" & _
                    "e")
            '
            'GroupBox1
            '
            Me.GroupBox1.AutoSize = True
            Me.GroupBox1.Controls.Add(Me.Panel3)
            Me.GroupBox1.Controls.Add(Me.Panel2)
            Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5)
            Me.GroupBox1.Size = New System.Drawing.Size(420, 101)
            Me.GroupBox1.TabIndex = 3
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "series formating rule"
            '
            'Panel3
            '
            Me.Panel3.Controls.Add(Me.tbSample)
            Me.Panel3.Controls.Add(Me.Label3)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel3.Location = New System.Drawing.Point(5, 58)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Padding = New System.Windows.Forms.Padding(10)
            Me.Panel3.Size = New System.Drawing.Size(410, 40)
            Me.Panel3.TabIndex = 7
            '
            'tbSample
            '
            Me.tbSample.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbSample.Location = New System.Drawing.Point(60, 10)
            Me.tbSample.Name = "tbSample"
            Me.tbSample.ReadOnly = True
            Me.tbSample.Size = New System.Drawing.Size(340, 20)
            Me.tbSample.TabIndex = 5
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label3.Location = New System.Drawing.Point(10, 10)
            Me.Label3.Name = "Label3"
            Me.Label3.Padding = New System.Windows.Forms.Padding(0, 3, 8, 0)
            Me.Label3.Size = New System.Drawing.Size(50, 16)
            Me.Label3.TabIndex = 6
            Me.Label3.Text = "Sample"
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.tbSeriesFormatingRule)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel2.Location = New System.Drawing.Point(5, 18)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Padding = New System.Windows.Forms.Padding(10)
            Me.Panel2.Size = New System.Drawing.Size(410, 40)
            Me.Panel2.TabIndex = 4
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label2.Location = New System.Drawing.Point(10, 10)
            Me.Label2.Name = "Label2"
            Me.Label2.Padding = New System.Windows.Forms.Padding(0, 3, 10, 0)
            Me.Label2.Size = New System.Drawing.Size(49, 16)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "Format"
            '
            'Panel1
            '
            Me.Panel1.AutoScroll = True
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.TabControl1)
            Me.Panel1.Controls.Add(Me.ToolStrip)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(10)
            Me.Panel1.Size = New System.Drawing.Size(476, 420)
            Me.Panel1.TabIndex = 4
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControl1.Location = New System.Drawing.Point(10, 10)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(456, 367)
            Me.TabControl1.TabIndex = 15
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.Panel11)
            Me.TabPage1.Controls.Add(Me.Panel6)
            Me.TabPage1.Controls.Add(Me.Panel7)
            Me.TabPage1.Controls.Add(Me.Panel8)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(10)
            Me.TabPage1.Size = New System.Drawing.Size(448, 341)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "settings"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'Panel11
            '
            Me.Panel11.Controls.Add(Me.CheckTestMode)
            Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel11.Location = New System.Drawing.Point(10, 261)
            Me.Panel11.Name = "Panel11"
            Me.Panel11.Padding = New System.Windows.Forms.Padding(10)
            Me.Panel11.Size = New System.Drawing.Size(428, 39)
            Me.Panel11.TabIndex = 10
            '
            'CheckTestMode
            '
            Me.CheckTestMode.AutoSize = True
            Me.CheckTestMode.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CheckTestMode.Location = New System.Drawing.Point(10, 10)
            Me.CheckTestMode.Name = "CheckTestMode"
            Me.CheckTestMode.Size = New System.Drawing.Size(408, 19)
            Me.CheckTestMode.TabIndex = 0
            Me.CheckTestMode.Text = "test mode"
            Me.ToolTip1.SetToolTip(Me.CheckTestMode, resources.GetString("CheckTestMode.ToolTip"))
            Me.CheckTestMode.UseVisualStyleBackColor = True
            '
            'Panel6
            '
            Me.Panel6.Controls.Add(Me.GroupBox1)
            Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel6.Location = New System.Drawing.Point(10, 152)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Padding = New System.Windows.Forms.Padding(4)
            Me.Panel6.Size = New System.Drawing.Size(428, 109)
            Me.Panel6.TabIndex = 7
            '
            'Panel7
            '
            Me.Panel7.Controls.Add(Me.GroupBox2)
            Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel7.Location = New System.Drawing.Point(10, 81)
            Me.Panel7.Name = "Panel7"
            Me.Panel7.Padding = New System.Windows.Forms.Padding(4)
            Me.Panel7.Size = New System.Drawing.Size(428, 71)
            Me.Panel7.TabIndex = 8
            '
            'GroupBox2
            '
            Me.GroupBox2.AutoSize = True
            Me.GroupBox2.Controls.Add(Me.Panel4)
            Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox2.Location = New System.Drawing.Point(4, 4)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Padding = New System.Windows.Forms.Padding(5)
            Me.GroupBox2.Size = New System.Drawing.Size(420, 63)
            Me.GroupBox2.TabIndex = 5
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Scan"
            '
            'Panel4
            '
            Me.Panel4.Controls.Add(Me.Label1)
            Me.Panel4.Controls.Add(Me.NumInterval)
            Me.Panel4.Controls.Add(Me.Label4)
            Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel4.Location = New System.Drawing.Point(5, 18)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Padding = New System.Windows.Forms.Padding(10)
            Me.Panel4.Size = New System.Drawing.Size(410, 40)
            Me.Panel4.TabIndex = 7
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label1.Location = New System.Drawing.Point(137, 10)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(10, 3, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(57, 16)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "seconds"
            '
            'NumInterval
            '
            Me.NumInterval.Dock = System.Windows.Forms.DockStyle.Left
            Me.NumInterval.Location = New System.Drawing.Point(62, 10)
            Me.NumInterval.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
            Me.NumInterval.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
            Me.NumInterval.Name = "NumInterval"
            Me.NumInterval.Size = New System.Drawing.Size(75, 20)
            Me.NumInterval.TabIndex = 4
            Me.NumInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.ToolTip1.SetToolTip(Me.NumInterval, "Time interval to check, if recordings with series and episodenr. changed in datab" & _
                    "ase. If it's true, a new scan will initialize." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Changes of scan interval will ta" & _
                    "ke effect after restarting tvserver!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
            Me.NumInterval.Value = New Decimal(New Integer() {30, 0, 0, 0})
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label4.Location = New System.Drawing.Point(10, 10)
            Me.Label4.Name = "Label4"
            Me.Label4.Padding = New System.Windows.Forms.Padding(0, 3, 10, 0)
            Me.Label4.Size = New System.Drawing.Size(52, 16)
            Me.Label4.TabIndex = 6
            Me.Label4.Text = "Interval"
            '
            'Panel8
            '
            Me.Panel8.AutoSize = True
            Me.Panel8.Controls.Add(Me.GroupBox3)
            Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel8.Location = New System.Drawing.Point(10, 10)
            Me.Panel8.Name = "Panel8"
            Me.Panel8.Padding = New System.Windows.Forms.Padding(4)
            Me.Panel8.Size = New System.Drawing.Size(428, 71)
            Me.Panel8.TabIndex = 9
            '
            'GroupBox3
            '
            Me.GroupBox3.AutoSize = True
            Me.GroupBox3.Controls.Add(Me.Panel5)
            Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox3.Location = New System.Drawing.Point(4, 4)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Padding = New System.Windows.Forms.Padding(5)
            Me.GroupBox3.Size = New System.Drawing.Size(420, 63)
            Me.GroupBox3.TabIndex = 6
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Recording folder"
            '
            'Panel5
            '
            Me.Panel5.Controls.Add(Me.tbRecPath)
            Me.Panel5.Controls.Add(Me.Label5)
            Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel5.Location = New System.Drawing.Point(5, 18)
            Me.Panel5.Name = "Panel5"
            Me.Panel5.Padding = New System.Windows.Forms.Padding(10)
            Me.Panel5.Size = New System.Drawing.Size(410, 40)
            Me.Panel5.TabIndex = 2
            '
            'tbRecPath
            '
            Me.tbRecPath.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbRecPath.Location = New System.Drawing.Point(49, 10)
            Me.tbRecPath.Name = "tbRecPath"
            Me.tbRecPath.ReadOnly = True
            Me.tbRecPath.Size = New System.Drawing.Size(351, 20)
            Me.tbRecPath.TabIndex = 0
            Me.ToolTip1.SetToolTip(Me.tbRecPath, "specfiy the recording path (look at Recordings -> Tab:  Folders)")
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label5.Location = New System.Drawing.Point(10, 10)
            Me.Label5.Name = "Label5"
            Me.Label5.Padding = New System.Windows.Forms.Padding(0, 3, 10, 0)
            Me.Label5.Size = New System.Drawing.Size(39, 16)
            Me.Label5.TabIndex = 1
            Me.Label5.Text = "Path"
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.Panel16)
            Me.TabPage2.Controls.Add(Me.Panel13)
            Me.TabPage2.Controls.Add(Me.Panel12)
            Me.TabPage2.Controls.Add(Me.Panel10)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(10)
            Me.TabPage2.Size = New System.Drawing.Size(448, 341)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "existing file handler"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'Panel16
            '
            Me.Panel16.Controls.Add(Me.CheckKeepDataInDb)
            Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel16.Location = New System.Drawing.Point(10, 307)
            Me.Panel16.Name = "Panel16"
            Me.Panel16.Padding = New System.Windows.Forms.Padding(10)
            Me.Panel16.Size = New System.Drawing.Size(428, 35)
            Me.Panel16.TabIndex = 4
            '
            'CheckKeepDataInDb
            '
            Me.CheckKeepDataInDb.AutoSize = True
            Me.CheckKeepDataInDb.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CheckKeepDataInDb.Location = New System.Drawing.Point(10, 10)
            Me.CheckKeepDataInDb.Name = "CheckKeepDataInDb"
            Me.CheckKeepDataInDb.Size = New System.Drawing.Size(408, 15)
            Me.CheckKeepDataInDb.TabIndex = 0
            Me.CheckKeepDataInDb.Text = "keep moved files in TvServer records database"
            Me.ToolTip1.SetToolTip(Me.CheckKeepDataInDb, "Attention:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If activated and your saved recording with correct series formating r" & _
                    "ules will be deleted, the plugin will take the moved file to save this again wit" & _
                    "h correct series formating rule.")
            Me.CheckKeepDataInDb.UseVisualStyleBackColor = True
            '
            'Panel13
            '
            Me.Panel13.Controls.Add(Me.GBoxGreaterThanPercentage)
            Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel13.Location = New System.Drawing.Point(10, 178)
            Me.Panel13.Name = "Panel13"
            Me.Panel13.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.Panel13.Size = New System.Drawing.Size(428, 129)
            Me.Panel13.TabIndex = 17
            '
            'GBoxGreaterThanPercentage
            '
            Me.GBoxGreaterThanPercentage.AutoSize = True
            Me.GBoxGreaterThanPercentage.Controls.Add(Me.Panel14)
            Me.GBoxGreaterThanPercentage.Controls.Add(Me.FlowLayoutPanel2)
            Me.GBoxGreaterThanPercentage.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GBoxGreaterThanPercentage.Location = New System.Drawing.Point(0, 5)
            Me.GBoxGreaterThanPercentage.Name = "GBoxGreaterThanPercentage"
            Me.GBoxGreaterThanPercentage.Padding = New System.Windows.Forms.Padding(5)
            Me.GBoxGreaterThanPercentage.Size = New System.Drawing.Size(428, 124)
            Me.GBoxGreaterThanPercentage.TabIndex = 17
            Me.GBoxGreaterThanPercentage.TabStop = False
            Me.GBoxGreaterThanPercentage.Text = "#GreaterThanPercentage"
            '
            'Panel14
            '
            Me.Panel14.Controls.Add(Me.GBoxGreaterMoveFolder)
            Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel14.Location = New System.Drawing.Point(5, 58)
            Me.Panel14.Name = "Panel14"
            Me.Panel14.Size = New System.Drawing.Size(418, 63)
            Me.Panel14.TabIndex = 22
            '
            'GBoxGreaterMoveFolder
            '
            Me.GBoxGreaterMoveFolder.AutoSize = True
            Me.GBoxGreaterMoveFolder.Controls.Add(Me.Panel15)
            Me.GBoxGreaterMoveFolder.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GBoxGreaterMoveFolder.Enabled = False
            Me.GBoxGreaterMoveFolder.Location = New System.Drawing.Point(0, 0)
            Me.GBoxGreaterMoveFolder.Name = "GBoxGreaterMoveFolder"
            Me.GBoxGreaterMoveFolder.Padding = New System.Windows.Forms.Padding(5)
            Me.GBoxGreaterMoveFolder.Size = New System.Drawing.Size(418, 63)
            Me.GBoxGreaterMoveFolder.TabIndex = 18
            Me.GBoxGreaterMoveFolder.TabStop = False
            Me.GBoxGreaterMoveFolder.Text = "folder"
            '
            'Panel15
            '
            Me.Panel15.Controls.Add(Me.TbGreaterThanPercentageFolder)
            Me.Panel15.Controls.Add(Me.Label6)
            Me.Panel15.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel15.Location = New System.Drawing.Point(5, 18)
            Me.Panel15.Name = "Panel15"
            Me.Panel15.Padding = New System.Windows.Forms.Padding(10)
            Me.Panel15.Size = New System.Drawing.Size(408, 40)
            Me.Panel15.TabIndex = 3
            '
            'TbGreaterThanPercentageFolder
            '
            Me.TbGreaterThanPercentageFolder.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TbGreaterThanPercentageFolder.Location = New System.Drawing.Point(49, 10)
            Me.TbGreaterThanPercentageFolder.Name = "TbGreaterThanPercentageFolder"
            Me.TbGreaterThanPercentageFolder.Size = New System.Drawing.Size(349, 20)
            Me.TbGreaterThanPercentageFolder.TabIndex = 0
            Me.ToolTip1.SetToolTip(Me.TbGreaterThanPercentageFolder, "Attention!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If you have server client configuration, you must set up the network " & _
                    "path !" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If this is a subfolder of you records folder, then the tvserver will fin" & _
                    "d these files again by a manual scan !")
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label6.Location = New System.Drawing.Point(10, 10)
            Me.Label6.Name = "Label6"
            Me.Label6.Padding = New System.Windows.Forms.Padding(0, 3, 10, 0)
            Me.Label6.Size = New System.Drawing.Size(39, 16)
            Me.Label6.TabIndex = 1
            Me.Label6.Text = "Path"
            '
            'FlowLayoutPanel2
            '
            Me.FlowLayoutPanel2.Controls.Add(Me.RbGreaterNone)
            Me.FlowLayoutPanel2.Controls.Add(Me.RbGreaterFolder)
            Me.FlowLayoutPanel2.Controls.Add(Me.RbGreaterDelete)
            Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
            Me.FlowLayoutPanel2.Location = New System.Drawing.Point(5, 18)
            Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
            Me.FlowLayoutPanel2.Padding = New System.Windows.Forms.Padding(5)
            Me.FlowLayoutPanel2.Size = New System.Drawing.Size(418, 40)
            Me.FlowLayoutPanel2.TabIndex = 21
            '
            'RbGreaterNone
            '
            Me.RbGreaterNone.AutoSize = True
            Me.RbGreaterNone.Dock = System.Windows.Forms.DockStyle.Left
            Me.RbGreaterNone.Location = New System.Drawing.Point(8, 8)
            Me.RbGreaterNone.Name = "RbGreaterNone"
            Me.RbGreaterNone.Padding = New System.Windows.Forms.Padding(0, 5, 10, 0)
            Me.RbGreaterNone.Size = New System.Drawing.Size(59, 22)
            Me.RbGreaterNone.TabIndex = 19
            Me.RbGreaterNone.TabStop = True
            Me.RbGreaterNone.Text = "none"
            Me.RbGreaterNone.UseVisualStyleBackColor = True
            '
            'RbGreaterFolder
            '
            Me.RbGreaterFolder.AutoSize = True
            Me.RbGreaterFolder.Dock = System.Windows.Forms.DockStyle.Left
            Me.RbGreaterFolder.Location = New System.Drawing.Point(73, 8)
            Me.RbGreaterFolder.Name = "RbGreaterFolder"
            Me.RbGreaterFolder.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
            Me.RbGreaterFolder.Size = New System.Drawing.Size(112, 22)
            Me.RbGreaterFolder.TabIndex = 20
            Me.RbGreaterFolder.TabStop = True
            Me.RbGreaterFolder.Text = "move to folder"
            Me.RbGreaterFolder.UseVisualStyleBackColor = True
            '
            'RbGreaterDelete
            '
            Me.RbGreaterDelete.AutoSize = True
            Me.RbGreaterDelete.Dock = System.Windows.Forms.DockStyle.Left
            Me.RbGreaterDelete.Location = New System.Drawing.Point(191, 8)
            Me.RbGreaterDelete.Name = "RbGreaterDelete"
            Me.RbGreaterDelete.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
            Me.RbGreaterDelete.Size = New System.Drawing.Size(74, 22)
            Me.RbGreaterDelete.TabIndex = 18
            Me.RbGreaterDelete.TabStop = True
            Me.RbGreaterDelete.Text = "delete"
            Me.RbGreaterDelete.UseVisualStyleBackColor = True
            '
            'Panel12
            '
            Me.Panel12.Controls.Add(Me.GBoxLessThanPercentage)
            Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel12.Location = New System.Drawing.Point(10, 50)
            Me.Panel12.Name = "Panel12"
            Me.Panel12.Size = New System.Drawing.Size(428, 128)
            Me.Panel12.TabIndex = 17
            '
            'GBoxLessThanPercentage
            '
            Me.GBoxLessThanPercentage.AutoSize = True
            Me.GBoxLessThanPercentage.Controls.Add(Me.Panel9)
            Me.GBoxLessThanPercentage.Controls.Add(Me.FlowLayoutPanel1)
            Me.GBoxLessThanPercentage.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GBoxLessThanPercentage.Location = New System.Drawing.Point(0, 0)
            Me.GBoxLessThanPercentage.Name = "GBoxLessThanPercentage"
            Me.GBoxLessThanPercentage.Padding = New System.Windows.Forms.Padding(5)
            Me.GBoxLessThanPercentage.Size = New System.Drawing.Size(428, 128)
            Me.GBoxLessThanPercentage.TabIndex = 16
            Me.GBoxLessThanPercentage.TabStop = False
            Me.GBoxLessThanPercentage.Text = "#lessThanPercentage"
            '
            'Panel9
            '
            Me.Panel9.Controls.Add(Me.GBoxLessMoveFolder)
            Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel9.Location = New System.Drawing.Point(5, 58)
            Me.Panel9.Name = "Panel9"
            Me.Panel9.Size = New System.Drawing.Size(418, 65)
            Me.Panel9.TabIndex = 19
            '
            'GBoxLessMoveFolder
            '
            Me.GBoxLessMoveFolder.AutoSize = True
            Me.GBoxLessMoveFolder.Controls.Add(Me.Panel17)
            Me.GBoxLessMoveFolder.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GBoxLessMoveFolder.Enabled = False
            Me.GBoxLessMoveFolder.Location = New System.Drawing.Point(0, 0)
            Me.GBoxLessMoveFolder.Name = "GBoxLessMoveFolder"
            Me.GBoxLessMoveFolder.Padding = New System.Windows.Forms.Padding(5)
            Me.GBoxLessMoveFolder.Size = New System.Drawing.Size(418, 65)
            Me.GBoxLessMoveFolder.TabIndex = 18
            Me.GBoxLessMoveFolder.TabStop = False
            Me.GBoxLessMoveFolder.Text = "folder"
            '
            'Panel17
            '
            Me.Panel17.Controls.Add(Me.TbLessThanPercentageFolder)
            Me.Panel17.Controls.Add(Me.Label9)
            Me.Panel17.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel17.Location = New System.Drawing.Point(5, 18)
            Me.Panel17.Name = "Panel17"
            Me.Panel17.Padding = New System.Windows.Forms.Padding(10)
            Me.Panel17.Size = New System.Drawing.Size(408, 40)
            Me.Panel17.TabIndex = 3
            '
            'TbLessThanPercentageFolder
            '
            Me.TbLessThanPercentageFolder.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TbLessThanPercentageFolder.Location = New System.Drawing.Point(49, 10)
            Me.TbLessThanPercentageFolder.Name = "TbLessThanPercentageFolder"
            Me.TbLessThanPercentageFolder.Size = New System.Drawing.Size(349, 20)
            Me.TbLessThanPercentageFolder.TabIndex = 0
            Me.ToolTip1.SetToolTip(Me.TbLessThanPercentageFolder, "Attention!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If you have server client configuration, you must set up the network " & _
                    "path !" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If this is a subfolder of you records folder, then the tvserver will fin" & _
                    "d these files again by a manual scan !")
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label9.Location = New System.Drawing.Point(10, 10)
            Me.Label9.Name = "Label9"
            Me.Label9.Padding = New System.Windows.Forms.Padding(0, 3, 10, 0)
            Me.Label9.Size = New System.Drawing.Size(39, 16)
            Me.Label9.TabIndex = 1
            Me.Label9.Text = "Path"
            '
            'FlowLayoutPanel1
            '
            Me.FlowLayoutPanel1.Controls.Add(Me.RbLessNone)
            Me.FlowLayoutPanel1.Controls.Add(Me.RbLessFolder)
            Me.FlowLayoutPanel1.Controls.Add(Me.RbLessDelete)
            Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.FlowLayoutPanel1.Location = New System.Drawing.Point(5, 18)
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(5)
            Me.FlowLayoutPanel1.Size = New System.Drawing.Size(418, 40)
            Me.FlowLayoutPanel1.TabIndex = 15
            '
            'RbLessNone
            '
            Me.RbLessNone.AutoSize = True
            Me.RbLessNone.Location = New System.Drawing.Point(8, 8)
            Me.RbLessNone.Name = "RbLessNone"
            Me.RbLessNone.Padding = New System.Windows.Forms.Padding(0, 5, 10, 0)
            Me.RbLessNone.Size = New System.Drawing.Size(59, 22)
            Me.RbLessNone.TabIndex = 0
            Me.RbLessNone.TabStop = True
            Me.RbLessNone.Text = "none"
            Me.RbLessNone.UseVisualStyleBackColor = True
            '
            'RbLessFolder
            '
            Me.RbLessFolder.AutoSize = True
            Me.RbLessFolder.Location = New System.Drawing.Point(73, 8)
            Me.RbLessFolder.Name = "RbLessFolder"
            Me.RbLessFolder.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
            Me.RbLessFolder.Size = New System.Drawing.Size(112, 22)
            Me.RbLessFolder.TabIndex = 1
            Me.RbLessFolder.TabStop = True
            Me.RbLessFolder.Text = "move to folder"
            Me.RbLessFolder.UseVisualStyleBackColor = True
            '
            'RbLessDelete
            '
            Me.RbLessDelete.AutoSize = True
            Me.RbLessDelete.Location = New System.Drawing.Point(191, 8)
            Me.RbLessDelete.Name = "RbLessDelete"
            Me.RbLessDelete.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
            Me.RbLessDelete.Size = New System.Drawing.Size(74, 22)
            Me.RbLessDelete.TabIndex = 2
            Me.RbLessDelete.TabStop = True
            Me.RbLessDelete.Text = "delete"
            Me.RbLessDelete.UseVisualStyleBackColor = True
            '
            'Panel10
            '
            Me.Panel10.Controls.Add(Me.Label8)
            Me.Panel10.Controls.Add(Me.NumPercentage)
            Me.Panel10.Controls.Add(Me.Label7)
            Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel10.Location = New System.Drawing.Point(10, 10)
            Me.Panel10.Name = "Panel10"
            Me.Panel10.Padding = New System.Windows.Forms.Padding(2, 10, 2, 2)
            Me.Panel10.Size = New System.Drawing.Size(428, 40)
            Me.Panel10.TabIndex = 15
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label8.Location = New System.Drawing.Point(323, 10)
            Me.Label8.Name = "Label8"
            Me.Label8.Padding = New System.Windows.Forms.Padding(2, 3, 0, 0)
            Me.Label8.Size = New System.Drawing.Size(17, 16)
            Me.Label8.TabIndex = 4
            Me.Label8.Text = "%"
            '
            'NumPercentage
            '
            Me.NumPercentage.Dock = System.Windows.Forms.DockStyle.Left
            Me.NumPercentage.Location = New System.Drawing.Point(258, 10)
            Me.NumPercentage.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
            Me.NumPercentage.Name = "NumPercentage"
            Me.NumPercentage.Size = New System.Drawing.Size(65, 20)
            Me.NumPercentage.TabIndex = 2
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label7.Location = New System.Drawing.Point(2, 10)
            Me.Label7.Name = "Label7"
            Me.Label7.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label7.Size = New System.Drawing.Size(256, 16)
            Me.Label7.TabIndex = 3
            Me.Label7.Text = "file size difference between existing and new file   +/-"
            '
            'ToolStrip
            '
            Me.ToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
            Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
            Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TPBTSave, Me.TPBtScan, Me.TPLabelVersion, Me.TPLabelTestMode})
            Me.ToolStrip.Location = New System.Drawing.Point(10, 377)
            Me.ToolStrip.Name = "ToolStrip"
            Me.ToolStrip.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
            Me.ToolStrip.Size = New System.Drawing.Size(456, 33)
            Me.ToolStrip.TabIndex = 13
            Me.ToolStrip.Text = "ToolStrip1"
            '
            'TPBTSave
            '
            Me.TPBTSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.TPBTSave.AutoSize = False
            Me.TPBTSave.Image = CType(resources.GetObject("TPBTSave.Image"), System.Drawing.Image)
            Me.TPBTSave.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TPBTSave.Name = "TPBTSave"
            Me.TPBTSave.Size = New System.Drawing.Size(60, 30)
            Me.TPBTSave.Text = "save"
            Me.TPBTSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'TPBtScan
            '
            Me.TPBtScan.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.TPBtScan.AutoSize = False
            Me.TPBtScan.Image = CType(resources.GetObject("TPBtScan.Image"), System.Drawing.Image)
            Me.TPBtScan.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TPBtScan.Name = "TPBtScan"
            Me.TPBtScan.Size = New System.Drawing.Size(60, 30)
            Me.TPBtScan.Text = "scan"
            Me.TPBtScan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'TPLabelVersion
            '
            Me.TPLabelVersion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TPLabelVersion.Name = "TPLabelVersion"
            Me.TPLabelVersion.Size = New System.Drawing.Size(51, 30)
            Me.TPLabelVersion.Text = "#version"
            '
            'TPLabelTestMode
            '
            Me.TPLabelTestMode.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.TPLabelTestMode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TPLabelTestMode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.TPLabelTestMode.Name = "TPLabelTestMode"
            Me.TPLabelTestMode.Padding = New System.Windows.Forms.Padding(0, 0, 20, 0)
            Me.TPLabelTestMode.Size = New System.Drawing.Size(144, 30)
            Me.TPLabelTestMode.Text = "test mode is activated !"
            Me.TPLabelTestMode.Visible = False
            '
            'ToolTip1
            '
            Me.ToolTip1.AutoPopDelay = 5000
            Me.ToolTip1.InitialDelay = 100
            Me.ToolTip1.ReshowDelay = 100
            Me.ToolTip1.ShowAlways = True
            Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
            Me.ToolTip1.UseAnimation = False
            Me.ToolTip1.UseFading = False
            '
            'RecordedSeriesManagerConfig
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.Panel1)
            Me.Name = "RecordedSeriesManagerConfig"
            Me.Size = New System.Drawing.Size(476, 420)
            Me.GroupBox1.ResumeLayout(False)
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage1.PerformLayout()
            Me.Panel11.ResumeLayout(False)
            Me.Panel11.PerformLayout()
            Me.Panel6.ResumeLayout(False)
            Me.Panel6.PerformLayout()
            Me.Panel7.ResumeLayout(False)
            Me.Panel7.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            CType(Me.NumInterval, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel8.ResumeLayout(False)
            Me.Panel8.PerformLayout()
            Me.GroupBox3.ResumeLayout(False)
            Me.Panel5.ResumeLayout(False)
            Me.Panel5.PerformLayout()
            Me.TabPage2.ResumeLayout(False)
            Me.Panel16.ResumeLayout(False)
            Me.Panel16.PerformLayout()
            Me.Panel13.ResumeLayout(False)
            Me.Panel13.PerformLayout()
            Me.GBoxGreaterThanPercentage.ResumeLayout(False)
            Me.Panel14.ResumeLayout(False)
            Me.Panel14.PerformLayout()
            Me.GBoxGreaterMoveFolder.ResumeLayout(False)
            Me.Panel15.ResumeLayout(False)
            Me.Panel15.PerformLayout()
            Me.FlowLayoutPanel2.ResumeLayout(False)
            Me.FlowLayoutPanel2.PerformLayout()
            Me.Panel12.ResumeLayout(False)
            Me.Panel12.PerformLayout()
            Me.GBoxLessThanPercentage.ResumeLayout(False)
            Me.Panel9.ResumeLayout(False)
            Me.Panel9.PerformLayout()
            Me.GBoxLessMoveFolder.ResumeLayout(False)
            Me.Panel17.ResumeLayout(False)
            Me.Panel17.PerformLayout()
            Me.FlowLayoutPanel1.ResumeLayout(False)
            Me.FlowLayoutPanel1.PerformLayout()
            Me.Panel10.ResumeLayout(False)
            Me.Panel10.PerformLayout()
            CType(Me.NumPercentage, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ToolStrip.ResumeLayout(False)
            Me.ToolStrip.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TvLogosList As System.Windows.Forms.ImageList
        Friend WithEvents tbSeriesFormatingRule As System.Windows.Forms.TextBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents tbSample As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents NumInterval As System.Windows.Forms.NumericUpDown
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents tbRecPath As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Panel5 As System.Windows.Forms.Panel
        Friend WithEvents Panel6 As System.Windows.Forms.Panel
        Friend WithEvents Panel7 As System.Windows.Forms.Panel
        Friend WithEvents Panel8 As System.Windows.Forms.Panel
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
        Friend WithEvents TPBTSave As System.Windows.Forms.ToolStripButton
        Friend WithEvents TPBtScan As System.Windows.Forms.ToolStripButton
        Friend WithEvents TPLabelVersion As System.Windows.Forms.ToolStripLabel
        Friend WithEvents GBoxLessThanPercentage As System.Windows.Forms.GroupBox
        Friend WithEvents GBoxGreaterThanPercentage As System.Windows.Forms.GroupBox
        Friend WithEvents Panel12 As System.Windows.Forms.Panel
        Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents RbLessNone As System.Windows.Forms.RadioButton
        Friend WithEvents RbLessFolder As System.Windows.Forms.RadioButton
        Friend WithEvents RbLessDelete As System.Windows.Forms.RadioButton
        Friend WithEvents RbGreaterDelete As System.Windows.Forms.RadioButton
        Friend WithEvents RbGreaterNone As System.Windows.Forms.RadioButton
        Friend WithEvents RbGreaterFolder As System.Windows.Forms.RadioButton
        Friend WithEvents Panel13 As System.Windows.Forms.Panel
        Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents Panel10 As System.Windows.Forms.Panel
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents NumPercentage As System.Windows.Forms.NumericUpDown
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Panel9 As System.Windows.Forms.Panel
        Friend WithEvents GBoxLessMoveFolder As System.Windows.Forms.GroupBox
        Friend WithEvents Panel17 As System.Windows.Forms.Panel
        Friend WithEvents TbLessThanPercentageFolder As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Panel16 As System.Windows.Forms.Panel
        Friend WithEvents CheckKeepDataInDb As System.Windows.Forms.CheckBox
        Friend WithEvents Panel14 As System.Windows.Forms.Panel
        Friend WithEvents GBoxGreaterMoveFolder As System.Windows.Forms.GroupBox
        Friend WithEvents Panel15 As System.Windows.Forms.Panel
        Friend WithEvents TbGreaterThanPercentageFolder As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Panel11 As System.Windows.Forms.Panel
        Friend WithEvents CheckTestMode As System.Windows.Forms.CheckBox
        Friend WithEvents TPLabelTestMode As System.Windows.Forms.ToolStripLabel
    End Class
End Namespace
