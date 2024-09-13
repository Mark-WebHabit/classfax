<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mysqlcredentials
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mysqlcredentials))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.passwordError = New System.Windows.Forms.Label()
        Me.uiderror = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.password = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.uid = New System.Windows.Forms.TextBox()
        Me.user = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-26, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(634, 48)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MYSQL USER CREDENTIALS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'passwordError
        '
        Me.passwordError.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.passwordError.AutoSize = True
        Me.passwordError.BackColor = System.Drawing.Color.Transparent
        Me.passwordError.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordError.ForeColor = System.Drawing.Color.Red
        Me.passwordError.Location = New System.Drawing.Point(257, 310)
        Me.passwordError.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.passwordError.Name = "passwordError"
        Me.passwordError.Size = New System.Drawing.Size(105, 19)
        Me.passwordError.TabIndex = 58
        Me.passwordError.Text = "Field Required"
        Me.passwordError.Visible = False
        '
        'uiderror
        '
        Me.uiderror.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uiderror.AutoSize = True
        Me.uiderror.BackColor = System.Drawing.Color.Transparent
        Me.uiderror.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uiderror.ForeColor = System.Drawing.Color.Red
        Me.uiderror.Location = New System.Drawing.Point(261, 206)
        Me.uiderror.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.uiderror.Name = "uiderror"
        Me.uiderror.Size = New System.Drawing.Size(105, 19)
        Me.uiderror.TabIndex = 57
        Me.uiderror.Text = "Field Required"
        Me.uiderror.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.CFaX.My.Resources.Resources.lock
        Me.PictureBox4.InitialImage = Global.CFaX.My.Resources.Resources.email
        Me.PictureBox4.Location = New System.Drawing.Point(37, 245)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(89, 64)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 56
        Me.PictureBox4.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(134, 245)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 29)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Password"
        '
        'password
        '
        Me.password.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password.Location = New System.Drawing.Point(134, 277)
        Me.password.Margin = New System.Windows.Forms.Padding(4)
        Me.password.Name = "password"
        Me.password.Size = New System.Drawing.Size(387, 30)
        Me.password.TabIndex = 54
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.White
        Me.PictureBox2.Image = Global.CFaX.My.Resources.Resources.name
        Me.PictureBox2.InitialImage = Global.CFaX.My.Resources.Resources.email
        Me.PictureBox2.Location = New System.Drawing.Point(58, 142)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(68, 64)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 53
        Me.PictureBox2.TabStop = False
        '
        'uid
        '
        Me.uid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uid.Location = New System.Drawing.Point(134, 174)
        Me.uid.Margin = New System.Windows.Forms.Padding(4)
        Me.uid.Name = "uid"
        Me.uid.Size = New System.Drawing.Size(387, 30)
        Me.uid.TabIndex = 52
        '
        'user
        '
        Me.user.AutoSize = True
        Me.user.BackColor = System.Drawing.Color.Transparent
        Me.user.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.user.Location = New System.Drawing.Point(134, 142)
        Me.user.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.user.Name = "user"
        Me.user.Size = New System.Drawing.Size(225, 29)
        Me.user.TabIndex = 51
        Me.user.Text = "USERNAME / UID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(466, 285)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Show"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Green
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Location = New System.Drawing.Point(99, 378)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(396, 50)
        Me.Button1.TabIndex = 60
        Me.Button1.Text = "Login"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox6.Image = Global.CFaX.My.Resources.Resources.cancel
        Me.PictureBox6.Location = New System.Drawing.Point(519, 11)
        Me.PictureBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(48, 34)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 61
        Me.PictureBox6.TabStop = False
        '
        'mysqlcredentials
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.CFaX.My.Resources.Resources.registration
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(580, 514)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.passwordError)
        Me.Controls.Add(Me.uiderror)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.password)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.uid)
        Me.Controls.Add(Me.user)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "mysqlcredentials"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "mysqlcredentials"
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents passwordError As Label
    Friend WithEvents uiderror As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents password As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents uid As TextBox
    Friend WithEvents user As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox6 As PictureBox
End Class
