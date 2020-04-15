Public Class NewTask
    Dim updating As Boolean = False
    Dim id As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim name As String = TextBox1.Text
        Dim firstDay As Date = DateTimePicker1.Value.Date
        Dim lastDay As Date = DateTimePicker2.Value.Date.AddDays(1)
        Dim priority As Integer = ComboBox1.SelectedIndex + 1
        Dim done As Boolean = CheckBox1.Checked
        Dim description As String = TextBox2.Text
        Dim createdBy As String = TextBox3.Text

        Dim data As New dataAccess

        If Not updating Then
            data.NewTask(name, firstDay, lastDay, createdBy, done, priority, description)
            MessageBox.Show("New Task Done!")
        Else
            data.UpdateTask(id, name, firstDay, lastDay, createdBy, done, priority, description)
            MessageBox.Show("Update Task Done!")
            updating = False

        End If




    End Sub

    Private Sub NewTask_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub New(id As Integer, name As String, firstDay As Date, lastDay As Date, priority As Integer, done As Boolean, description As String, createdBy As String, updating As Boolean)
        InitializeComponent()

        Me.updating = updating
        Me.id = id

        TextBox1.Text = name
        DateTimePicker1.Value = New Date(firstDay.Year, firstDay.Month, firstDay.Day)
        DateTimePicker2.Value = New Date(lastDay.Year, lastDay.Month, lastDay.Day - 1)
        ComboBox1.SelectedIndex = priority - 1
        CheckBox1.Checked = done
        TextBox2.Text = description
        TextBox3.Text = createdBy


        ' This call is required by the designer.

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

End Class