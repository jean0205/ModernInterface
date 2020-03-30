Imports FontAwesome.Sharp

Public Class Form1
    'Fields'
    Private currentBtn As IconButton
    Private leftBorderBtn As Panel
    Private currentChildForm As Form
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
        hideSubMenu()
    End Sub


    Private Sub hideSubMenu()
        Panel1.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False

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

    End Sub

    Private Sub IconButton6_Click(sender As Object, e As EventArgs) Handles IconButton6.Click
        showSubMenu(Panel3, IconButton6)
        ActivateButton(sender, RGBColors.color2)
    End Sub

    Private Sub IconButton11_Click(sender As Object, e As EventArgs) Handles IconButton11.Click
        showSubMenu(Panel4, IconButton11)
        ActivateButton(sender, RGBColors.color3)
    End Sub

    Private Sub IconButton16_Click(sender As Object, e As EventArgs) Handles IconButton16.Click
        showSubMenu(Panel5, IconButton16)
        ActivateButton(sender, RGBColors.color4)
    End Sub

    Private Sub IconButton17_Click(sender As Object, e As EventArgs) Handles IconButton17.Click
        showSubMenu(Panel5, IconButton17)
        ActivateButton(sender, RGBColors.color5)
    End Sub


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


End Class
Public Structure RGBColors
    Public Shared color1 As Color = Color.FromArgb(172, 126, 241)
    Public Shared color2 As Color = Color.FromArgb(249, 118, 176)
    Public Shared color3 As Color = Color.FromArgb(253, 138, 114)
    Public Shared color4 As Color = Color.FromArgb(95, 77, 221)
    Public Shared color5 As Color = Color.FromArgb(249, 88, 155)
    Public Shared color6 As Color = Color.FromArgb(24, 161, 251)
End Structure