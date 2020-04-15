Imports System.Windows.Forms.DataVisualization.Charting
Imports FontAwesome.Sharp

Public Class Form1
    'Fields'
    Private currentBtn As IconButton
    Private leftBorderBtn As Panel
    Private currentChildForm As Form
    Private hide As Boolean = True


    'Constructor'
    Public Sub New()
        ' This call is required by the designer.'
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.'
        leftBorderBtn = New Panel()
        leftBorderBtn.Size = New Size(7, 45)
        PanelSideMenu.Controls.Add(leftBorderBtn)
        'Form'
        Me.Text = String.Empty
        'Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim listx As New List(Of String)
        listx.Add("Jean")
        listx.Add("Josue")
        listx.Add("Coco")

        Dim listY As New List(Of Integer)
        listY.Add(10)
        listY.Add(15)
        listY.Add(50)
        Chart2.Series(0).Points.DataBindXY(listx, listY)


        hideSubMenu()
        Dim firstDay As Date = DateSerial(Year(Now), Month(Now), 1)
        Dim lastDat As Date = firstDay.AddMonths(1).AddDays(-1)
        graficosDates(firstDay, lastDat)
    End Sub
    Dim _month As Integer = Date.Now.Month
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        _month += 1


        Dim firstDay As Date = DateSerial(Year(Now), _month, 1)
        Dim lastDat As Date = firstDay.AddMonths(1).AddDays(-1)
        graficosDates(firstDay, lastDat)
        Label1.Text = firstDay.ToString("MM-yyyy")

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        _month -= 1


        Dim firstDay As Date = DateSerial(Year(Now), _month, 1)
        Dim lastDat As Date = firstDay.AddMonths(1).AddDays(-1)
        graficosDates(firstDay, lastDat)

        Label1.Text = firstDay.ToString("MM-yyyy")
    End Sub
    Sub graficosDates(firstDay As Date, lastDat As Date)




        Chart1.ChartAreas(0).AxisY.Minimum = firstDay.ToOADate
        Chart1.ChartAreas(0).AxisY.Maximum = lastDat.ToOADate
        Chart1.ChartAreas(0).AxisY.Interval = 1
        Chart1.ChartAreas(0).AxisY.IntervalType = DateTimeIntervalType.Days
        Chart1.ChartAreas(0).AxisY.IntervalOffset = 1
        Chart1.ChartAreas(0).AxisY.LabelStyle.Format = "dd"



        Chart1.ChartAreas(0).AxisX.Minimum = 0
        Chart1.ChartAreas(0).AxisX.Maximum = 10
        Chart1.ChartAreas(0).AxisX.Interval = 1


        ' Chart1.ChartAreas(0).AxisY.LabelStyle.Format = "dd"

        Chart1.Series(0).XValueType = ChartValueType.String




        Dim listY As New List(Of String)
        listY.Add("Jean")
        listY.Add("Coco")



        Dim listD As New List(Of Date)
        listD.Add(Date.Now)
        listD.Add(DateSerial(Year(Now), Month(Now), 15))
        listD.Add(Date.Now)
        listD.Add(DateSerial(Year(Now), Month(Now), 20))

        Dim taskx As New Task
        taskx.name = "Nombre"
        taskx.firstdate = DateSerial(Year(Now), Month(Now), 15)
        taskx.lastDate = DateSerial(Year(Now), Month(Now), 20)

        Dim task2 As New Task
        task2.name = "Nombre"
        task2.firstdate = DateSerial(Year(Now), Month(Now), 15)
        task2.lastDate = DateSerial(Year(Now), Month(Now), 20)


        Chart1.Series(0).Points.AddXY(taskx.name, taskx.firstdate, taskx.lastDate)

        Chart1.Series(0).Points.AddXY(task2.name, task2.firstdate, task2.lastDate)
        Chart1.Series(0).Points(0).Color = Color.Red


        '        chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
        'chart.ChartAreas[0].AxisX.IntervalOffset = 1;

        'Chart1.ChartAreas[0].AxisY.Minimum = minDate.ToOADate()
        '    Chart1.ChartAreas[0].AxisY.Maximum = maxDate.ToOADate()

        'Series s = New Series();
        '    s.ChartType = SeriesChartType.RangeBar;

        '    DateTime d = New DateTime(2013, 1, 1, 13, 30, 0);
        '    DateTime f = d.AddHours(2);

        '    Chart1.Series.Clear();
        '    Chart1.Legends.Clear();

        '    s.Points.AddXY("max", d);
        '    s.Points.AddXY("carl", f);
        '    //s.Points.AddXY("frank", d, f);

        '    Chart1.Series.Add(s);

        '    Chart1.Series[0].YValueType = ChartValueType.DateTime;
        '    Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "HH:mm";
        '    Chart1.ChartAreas[0].AxisY.Interval = 1;
        '    Chart1.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Hours;
        '    Chart1.ChartAreas[0].AxisY.IntervalOffset = 0;

        '    DateTime minDate = New DateTime(2013, 1, 1, 0, 0, 0);
        '    DateTime maxDate = New DateTime(2013, 1, 1, 23, 59, 59); // Or DateTime.Now;
        '    Chart1.ChartAreas[0].AxisY.Minimum = minDate.ToOADate();
        '    Chart1.ChartAreas[0].AxisY.Maximum = maxDate.ToOADate();
    End Sub

    Private Sub hideSubMenu()
        Panel1.Visible = False
        Panel3.Visible = False
        Panel4.Height = MinimumSize.Height
        ' Panel5.Visible = False

    End Sub

    Private Sub showSubMenu(subMenu As Panel, buttonMenu As IconButton)


        If subMenu.Visible = False Then
            hideSubMenu()
            subMenu.Visible = True
            'buttonMenu.BackColor = Color.FromArgb(RGB(89, 93, 107))
            ' buttonMenu.IconColor = Color.Purple


        Else
            subMenu.Visible = False
            ' buttonMenu.IconColor = Color.Gainsboro

            ' buttonMenu.BackColor = Color.FromArgb(RGB(28, 33, 53))
            'buttonMenu.IconColor = Color.Gainsboro
        End If
        'If buttonMenu.IconColor = Color.Gainsboro Then
        '    buttonMenu.IconColor = Color.Purple
        'Else
        '    buttonMenu.IconColor = Color.Gainsboro
        'End If

    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        showSubMenu(Panel1, IconButton1)
        ActivateButton(sender, RGBColors.color1)
        OpenChildForm(Form2)

    End Sub

    Private Sub IconButton5_Click(sender As Object, e As EventArgs) Handles IconButton5.Click

    End Sub

    Private Sub IconButton6_Click(sender As Object, e As EventArgs) Handles IconButton6.Click
        showSubMenu(Panel3, IconButton6)
        ActivateButton(sender, RGBColors.color2)
        OpenChildForm(Form3)
    End Sub

    Private Sub IconButton11_Click(sender As Object, e As EventArgs) Handles IconButton11.Click
        Timer1.Start()
        'showSubMenu(Panel4, IconButton11)
        ActivateButton(sender, RGBColors.color3)
    End Sub

    'Private Sub IconButton16_Click(sender As Object, e As EventArgs)
    '    showSubMenu(Panel5, IconButton16)
    '    ActivateButton(sender, RGBColors.color4)
    'End Sub

    'Private Sub IconButton17_Click(sender As Object, e As EventArgs)
    '    showSubMenu(Panel5, IconButton17)
    '    ActivateButton(sender, RGBColors.color5)
    '    OpenChildForm(Form3)
    'End Sub


    'Methods'
    Private Sub ActivateButton(senderBtn As Object, customColor As Color)
        If senderBtn IsNot Nothing Then
            DisableButton()
            'Button'
            currentBtn = CType(senderBtn, IconButton)
            currentBtn.BackColor = Color.FromArgb(37, 36, 81)
            currentBtn.ForeColor = customColor
            currentBtn.IconColor = customColor
            currentBtn.TextAlign = ContentAlignment.MiddleCenter
            currentBtn.ImageAlign = ContentAlignment.MiddleRight
            currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage
            'Left Border'
            leftBorderBtn.BackColor = customColor
            leftBorderBtn.Location = New Point(0, currentBtn.Location.Y)
            leftBorderBtn.Visible = True
            leftBorderBtn.BringToFront()
            'current Form icon'
            IconPictureBox1.IconChar = currentBtn.IconChar
            IconPictureBox1.IconColor = customColor
        End If
    End Sub

    Private Sub DisableButton()
        If currentBtn IsNot Nothing Then
            currentBtn.BackColor = Color.FromArgb(28, 33, 53)
            currentBtn.ForeColor = Color.Gainsboro
            currentBtn.IconColor = Color.Gainsboro
            currentBtn.TextAlign = ContentAlignment.MiddleLeft
            currentBtn.ImageAlign = ContentAlignment.MiddleLeft
            currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        End If
    End Sub


    Private Sub OpenChildForm(childForm As Form)
        'Open only form'
        'If currentChildForm IsNot Nothing Then
        '    currentChildForm.Close()
        'End If
        currentChildForm = childForm
        'end'
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        PanelDesktop.Controls.Add(childForm)
        PanelDesktop.Tag = childForm
        childForm.BringToFront()
        childForm.Show()

        Dim label As New Label
        label.Text = childForm.Text
        label.ForeColor = Color.Gainsboro
        ' label.Dock = DockStyle.Left

        Panel2.Controls.Add(label)


        'Lbltitle.Text = childForm.Text
    End Sub

    Dim desplegado As Boolean = False
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not desplegado Then
            Panel4.Height += 10

            If Panel4.Size = Panel4.MaximumSize Then
                desplegado = True
                Timer1.Stop()
            End If
        End If

        If desplegado Then
            Panel4.Height -= 10

            If Panel4.Size = Panel4.MinimumSize Then
                desplegado = False
                Timer1.Stop()

            End If
        End If
    End Sub


End Class
Public Structure RGBColors
    Public Shared color1 As Color = Color.FromArgb(172, 126, 241)
    Public Shared color2 As Color = Color.FromArgb(249, 118, 176)
    Public Shared color3 As Color = Color.FromArgb(253, 138, 114)
    Public Shared color4 As Color = Color.FromArgb(95, 77, 221)
    Public Shared color5 As Color = Color.FromArgb(249, 88, 155)
    Public Shared color6 As Color = Color.FromArgb(24, 161, 251)
End Structure

Public Class Task

    Public Property name As String
    Public Property firstdate As Date
    Public Property lastDate As Date

End Class
