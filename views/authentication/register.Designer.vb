<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class register
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(register))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lname = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.fname = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.types = New System.Windows.Forms.GroupBox()
        Me.admin = New System.Windows.Forms.RadioButton()
        Me.student = New System.Windows.Forms.RadioButton()
        Me.password_toggle = New System.Windows.Forms.Label()
        Me.password = New System.Windows.Forms.TextBox()
        Me.cpass_toggle = New System.Windows.Forms.Label()
        Me.cpassword = New System.Windows.Forms.TextBox()
        Me.studentno = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.types.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 69)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(658, 72)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Student Registration"
        '
        'lname
        '
        Me.lname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lname.Location = New System.Drawing.Point(212, 203)
        Me.lname.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lname.Name = "lname"
        Me.lname.Size = New System.Drawing.Size(161, 30)
        Me.lname.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(216, 177)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Last Name"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.CFaX.My.Resources.Resources.name
        Me.PictureBox1.Location = New System.Drawing.Point(143, 171)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'fname
        '
        Me.fname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fname.Location = New System.Drawing.Point(383, 203)
        Me.fname.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fname.Name = "fname"
        Me.fname.Size = New System.Drawing.Size(217, 30)
        Me.fname.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(211, 345)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 29)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Password"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(211, 426)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(219, 29)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Retype Password"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.CFaX.My.Resources.Resources.lock
        Me.PictureBox4.InitialImage = Global.CFaX.My.Resources.Resources.email
        Me.PictureBox4.Location = New System.Drawing.Point(121, 345)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(89, 64)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 20
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.CFaX.My.Resources.Resources.lock
        Me.PictureBox5.InitialImage = Global.CFaX.My.Resources.Resources.email
        Me.PictureBox5.Location = New System.Drawing.Point(121, 426)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(89, 64)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 21
        Me.PictureBox5.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(316, 686)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(166, 17)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Already have an Account"
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox6.Image = Global.CFaX.My.Resources.Resources.cancel
        Me.PictureBox6.Location = New System.Drawing.Point(717, 15)
        Me.PictureBox6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(48, 34)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 25
        Me.PictureBox6.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(379, 177)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 23)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = " First Name"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(211, 523)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(156, 29)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "Student No."
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.CFaX.My.Resources.Resources.studentNo
        Me.PictureBox3.InitialImage = Global.CFaX.My.Resources.Resources.email
        Me.PictureBox3.Location = New System.Drawing.Point(121, 523)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(89, 64)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 53
        Me.PictureBox3.TabStop = False
        '
        'types
        '
        Me.types.BackColor = System.Drawing.Color.Transparent
        Me.types.Controls.Add(Me.admin)
        Me.types.Controls.Add(Me.student)
        Me.types.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.types.Location = New System.Drawing.Point(251, 250)
        Me.types.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.types.Name = "types"
        Me.types.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.types.Size = New System.Drawing.Size(281, 80)
        Me.types.TabIndex = 54
        Me.types.TabStop = False
        Me.types.Text = "Types"
        '
        'admin
        '
        Me.admin.AutoSize = True
        Me.admin.BackColor = System.Drawing.Color.Transparent
        Me.admin.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin.Location = New System.Drawing.Point(12, 33)
        Me.admin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.admin.Name = "admin"
        Me.admin.Size = New System.Drawing.Size(96, 28)
        Me.admin.TabIndex = 9
        Me.admin.TabStop = True
        Me.admin.Text = "Admin"
        Me.admin.UseVisualStyleBackColor = False
        '
        'student
        '
        Me.student.AutoSize = True
        Me.student.BackColor = System.Drawing.Color.Transparent
        Me.student.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.student.Location = New System.Drawing.Point(132, 36)
        Me.student.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.student.Name = "student"
        Me.student.Size = New System.Drawing.Size(111, 28)
        Me.student.TabIndex = 10
        Me.student.TabStop = True
        Me.student.Text = "Student"
        Me.student.UseVisualStyleBackColor = False
        '
        'password_toggle
        '
        Me.password_toggle.AutoSize = True
        Me.password_toggle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.password_toggle.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password_toggle.ForeColor = System.Drawing.Color.Blue
        Me.password_toggle.Location = New System.Drawing.Point(551, 386)
        Me.password_toggle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.password_toggle.Name = "password_toggle"
        Me.password_toggle.Size = New System.Drawing.Size(42, 14)
        Me.password_toggle.TabIndex = 49
        Me.password_toggle.Text = "Show"
        '
        'password
        '
        Me.password.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password.Location = New System.Drawing.Point(216, 377)
        Me.password.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.password.Name = "password"
        Me.password.Size = New System.Drawing.Size(387, 30)
        Me.password.TabIndex = 56
        '
        'cpass_toggle
        '
        Me.cpass_toggle.AutoSize = True
        Me.cpass_toggle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cpass_toggle.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpass_toggle.ForeColor = System.Drawing.Color.Blue
        Me.cpass_toggle.Location = New System.Drawing.Point(552, 468)
        Me.cpass_toggle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.cpass_toggle.Name = "cpass_toggle"
        Me.cpass_toggle.Size = New System.Drawing.Size(42, 14)
        Me.cpass_toggle.TabIndex = 58
        Me.cpass_toggle.Text = "Show"
        '
        'cpassword
        '
        Me.cpassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpassword.Location = New System.Drawing.Point(215, 458)
        Me.cpassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cpassword.Name = "cpassword"
        Me.cpassword.Size = New System.Drawing.Size(385, 30)
        Me.cpassword.TabIndex = 57
        '
        'studentno
        '
        Me.studentno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.studentno.Location = New System.Drawing.Point(215, 555)
        Me.studentno.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.studentno.Name = "studentno"
        Me.studentno.Size = New System.Drawing.Size(160, 30)
        Me.studentno.TabIndex = 59
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Green
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Location = New System.Drawing.Point(193, 614)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(396, 50)
        Me.Button1.TabIndex = 60
        Me.Button1.Text = "Register"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'register
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.CFaX.My.Resources.Resources.registration
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(781, 756)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.studentno)
        Me.Controls.Add(Me.cpass_toggle)
        Me.Controls.Add(Me.cpassword)
        Me.Controls.Add(Me.types)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.password_toggle)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.fname)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lname)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.password)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "register"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "register"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.types.ResumeLayout(False)
        Me.types.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lname As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents fname As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents types As GroupBox
    Friend WithEvents admin As RadioButton
    Friend WithEvents student As RadioButton
    Friend WithEvents password_toggle As Label
    Friend WithEvents password As TextBox
    Friend WithEvents cpass_toggle As Label
    Friend WithEvents cpassword As TextBox
    Friend WithEvents studentno As TextBox
    Friend WithEvents Button1 As Button
End Class
