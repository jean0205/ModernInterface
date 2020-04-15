Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        _month += 1

        Dim dataA = New dataAccess

        Dim month As Date = DateSerial(Year(Now), _month, 1)

        DataGridView1.DataSource = dataA.GetMonthTask(month)
        Label1.Text = month.ToString("MM-yyyy")

        Dim firstDay As Date = DateSerial(Year(Now), _month, 1)
        Dim lastDat As Date = firstDay.AddMonths(1).AddDays(-1)

        graficosDates(firstDay, lastDat)

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        _month -= 1

        Dim dataA = New dataAccess

        Dim month As Date = DateSerial(Year(Now), _month, 1)

        DataGridView1.DataSource = dataA.GetMonthTask(month)
        Label1.Text = month.ToString("MM-yyyy")

        Dim firstDay As Date = DateSerial(Year(Now), _month, 1)
        Dim lastDat As Date = firstDay.AddMonths(1).AddDays(-1)

        graficosDates(firstDay, lastDat)
    End Sub
    Sub graficosDates(firstDay As Date, lastDat As Date)

        Chart1.Series(0).Points.Clear()


        Chart1.ChartAreas(0).AxisY.Minimum = firstDay.ToOADate
        Chart1.ChartAreas(0).AxisY.Maximum = lastDat.ToOADate + 1
        Chart1.ChartAreas(0).AxisY.Interval = 1
        Chart1.ChartAreas(0).AxisY.IntervalType = DateTimeIntervalType.Days
        Chart1.ChartAreas(0).AxisY.IntervalOffset = 1
        Chart1.ChartAreas(0).AxisY.LabelStyle.Format = "dd"


        Chart1.ChartAreas(0).AxisX.Minimum = 0
        Chart1.ChartAreas(0).AxisX.Maximum = 10
        Chart1.ChartAreas(0).AxisX.Interval = 1

        Chart1.ChartAreas(0).AxisX.IntervalOffset = 1





        Dim dataA = New dataAccess
        Dim listTask As New List(Of Tarea)

        Dim month As Date = DateSerial(Year(Now), _month, 1)

        listTask = dataA.GetMonthTask(month)
        'If (listTask.Count > 0) Then
        '    Chart1.Series(0).Points.Clear()
        'End If

        For Each t As Tarea In listTask

            Chart1.Series(0).Points.AddXY(t.Name, t.FirstDay, t.LastDay)
            If t.Priority = 2 Then
                Chart1.Series(0).Points.Last.Color = Color.Red
            End If
        Next



    End Sub

    'Private Sub CreateChartArea(firstDay As Date, lastDat As Date)
    '    'Clear ChartAreas if found:  
    '    Chart1.ChartAreas.Clear()
    '    'Create new ChartArea  
    '    Dim MyChartArea As New ChartArea()
    '    'Add ChartArea:  
    '    Chart1.ChartAreas.Add("MyChartArea")

    '    Chart1.ChartAreas(0).AxisY.Minimum = firstDay.ToOADate
    '    Chart1.ChartAreas(0).AxisY.Maximum = lastDat.ToOADate
    '    Chart1.ChartAreas(0).AxisY.Interval = 1
    '    Chart1.ChartAreas(0).AxisY.IntervalType = DateTimeIntervalType.Days
    '    Chart1.ChartAreas(0).AxisY.IntervalOffset = 1
    '    Chart1.ChartAreas(0).AxisY.LabelStyle.Format = "dd"


    '    Chart1.ChartAreas(0).AxisX.Minimum = 0
    '    Chart1.ChartAreas(0).AxisX.Maximum = 10
    '    Chart1.ChartAreas(0).AxisX.Interval = 1
    '    'Chart1.ChartAreas(0).AxisX.IntervalType = ChartValueType.
    '    Chart1.ChartAreas(0).AxisX.IntervalOffset = 1

    '    'Set BackColor to Chart and Graph area:  
    '    Chart1.BackColor = Color.LightGray

    '    'Hide vertical lines:  
    '    Chart1.ChartAreas("MyChartArea").AxisX.MajorGrid.Enabled = False
    '    'Set horizontal lines to Dash style:  
    '    Chart1.ChartAreas("MyChartArea").AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
    '    'Set X-Axis to four Series:  
    '    'Chart1.ChartAreas("MyChartArea").AxisX.Maximum = 5
    '    'Remove default Labels from X-Axis:  
    '    Chart1.ChartAreas("MyChartArea").AxisX.LabelStyle.IsEndLabelVisible = False
    '    'Display X-Axis labels with 30 degree:  
    '    ' Chart1.ChartAreas("MyChartArea").AxisX.LabelStyle.Angle = 30
    '    'Set X-Axis labels font:  
    '    'Chart1.ChartAreas("MyChartArea").AxisX.LabelStyle.Font = New Font("Arial", 10, FontStyle.Bold)
    '    'Set X-Axis labels color to blue:  
    '    Chart1.ChartAreas("MyChartArea").AxisX.LabelStyle.ForeColor = Color.Blue
    '    'Set Y-Axis title:  
    '    ' Chart1.ChartAreas("MyChartArea").AxisY.Title = "Number of students"
    '    'Set Y-Axis title font:  
    '    ' Chart1.ChartAreas("MyChartArea").AxisY.TitleFont = New Font("Arial", 10, FontStyle.Bold)
    '    'Set Y-Axis title color:  
    '    ' Chart1.ChartAreas("MyChartArea").AxisY.TitleForeColor = Color.Blue

    '    'You can use ChartAreas index instead ChartAreas name:  
    '    'Example: MyChart.ChartAreas(0).BackColor = Color.Lavender  
    'End Sub
    Dim _month As Integer = Date.Now.Month
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _month = Date.Now.Month
        Dim firstDay As Date = DateSerial(Year(Now), _month, 1)
        Dim lastDat As Date = firstDay.AddMonths(1).AddDays(-1)
        graficosDates(firstDay, lastDat)

        Dim dataA = New dataAccess

        Dim month As Date = DateSerial(Year(Now), _month, 1)

        DataGridView1.DataSource = dataA.GetMonthTask(month)
        Label1.Text = month.ToString("MM-yyyy")
    End Sub



    Private Sub Chart1_GetToolTipText(sender As Object, e As ToolTipEventArgs) Handles Chart1.GetToolTipText
        ' Check selected chart element and set tooltip text for it
        Select Case e.HitTestResult.ChartElementType
            Case ChartElementType.DataPoint
                e.Text = "Right to delete the task"
                Exit Select
        End Select
    End Sub

    Private Sub Chart1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Chart1.MouseDoubleClick
        Dim HTR As HitTestResult
        Dim SelectDataPoint As DataPoint

        HTR = Chart1.HitTest(e.X, e.Y)
        If HTR.PointIndex <> -1 Then


            SelectDataPoint = Chart1.Series(0).Points(HTR.PointIndex)

            Dim name As String = SelectDataPoint.AxisLabel
            Dim baseDate As Date = Convert.ToDateTime("12/30/1899")
            Dim starDate As Date = baseDate.AddDays(SelectDataPoint.YValues(0))
            Dim endDate As Date = baseDate.AddDays(SelectDataPoint.YValues(1))

            Dim data As New dataAccess

            Dim task = New Tarea

            task = data.GetTaskByClick(starDate, endDate, name).First

            Dim newTak As New NewTask(task.Id, task.Name, task.FirstDay, task.LastDay, task.Priority, task.Done, task.Description, task.CreatedBy, True)
            newTak.ShowDialog()

            ' MessageBox.Show(name & "  " & starDate.ToShortDateString.ToString & "  " & endDate.ToShortDateString.ToString)



        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim form3 As New NewTask
        form3.Show()
    End Sub

    Private Sub Chart1_MouseClick(sender As Object, e As MouseEventArgs) Handles Chart1.MouseClick
        If e.Button = MouseButtons.Right Then


            Dim message As String = "Do you want to delete this task?"
            Dim title As String = "Delete Task"
            Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo
            Dim result As DialogResult = MessageBox.Show(message, title, buttons)
            If result = DialogResult.Yes Then


            End If

        End If
    End Sub






    'Private Sub chart1_GetToolTipText(sender As Object, e As ToolTipEventArgs) Handles Chart1.GetToolTipText
    '    ' Check selected chart element and set tooltip text for it
    '    Select Case e.HitTestResult.ChartElementType
    '        Case ChartElementType.DataPoint
    '            Dim dataPoint = e.HitTestResult.Series.Points(e.HitTestResult.PointIndex)
    '            e.Text = dataPoint.YValues(0).ToString
    '            Exit Select
    '    End Select
    'End Sub
End Class