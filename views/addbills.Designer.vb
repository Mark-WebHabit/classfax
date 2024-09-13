<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addbills
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(addbills))
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.billname = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.billamount = New System.Windows.Forms.TextBox()
        Me.addbillbtn = New System.Windows.Forms.Button()
        Me.cancelbtn = New System.Windows.Forms.Button()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox6.Image = Global.CFaX.My.Resources.Resources.cancel
        Me.PictureBox6.Location = New System.Drawing.Point(748, 15)
        Me.PictureBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(48, 34)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 48
        Me.PictureBox6.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.CFaX.My.Resources.Resources.bill
        Me.PictureBox1.Location = New System.Drawing.Point(111, 66)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(232, 201)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 49
        Me.PictureBox1.TabStop = False
        '
        'billname
        '
        Me.billname.BackColor = System.Drawing.Color.White
        Me.billname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.billname.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.billname.Location = New System.Drawing.Point(373, 94)
        Me.billname.Margin = New System.Windows.Forms.Padding(4)
        Me.billname.Name = "billname"
        Me.billname.Size = New System.Drawing.Size(278, 33)
        Me.billname.TabIndex = 50
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(368, 65)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 25)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Bill Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(368, 144)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 25)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Amount"
        '
        'billamount
        '
        Me.billamount.BackColor = System.Drawing.Color.White
        Me.billamount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.billamount.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.billamount.Location = New System.Drawing.Point(373, 172)
        Me.billamount.Margin = New System.Windows.Forms.Padding(4)
        Me.billamount.Name = "billamount"
        Me.billamount.Size = New System.Drawing.Size(278, 33)
        Me.billamount.TabIndex = 53
        '
        'addbillbtn
        '
        Me.addbillbtn.BackColor = System.Drawing.Color.Lime
        Me.addbillbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.addbillbtn.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.addbillbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addbillbtn.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addbillbtn.ForeColor = System.Drawing.Color.Black
        Me.addbillbtn.Location = New System.Drawing.Point(373, 224)
        Me.addbillbtn.Margin = New System.Windows.Forms.Padding(4)
        Me.addbillbtn.Name = "addbillbtn"
        Me.addbillbtn.Size = New System.Drawing.Size(119, 39)
        Me.addbillbtn.TabIndex = 54
        Me.addbillbtn.Text = "Done"
        Me.addbillbtn.UseVisualStyleBackColor = False
        '
        'cancelbtn
        '
        Me.cancelbtn.BackColor = System.Drawing.Color.Red
        Me.cancelbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cancelbtn.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelbtn.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelbtn.ForeColor = System.Drawing.Color.White
        Me.cancelbtn.Location = New System.Drawing.Point(533, 224)
        Me.cancelbtn.Margin = New System.Windows.Forms.Padding(4)
        Me.cancelbtn.Name = "cancelbtn"
        Me.cancelbtn.Size = New System.Drawing.Size(119, 39)
        Me.cancelbtn.TabIndex = 56
        Me.cancelbtn.Text = "Cancel"
        Me.cancelbtn.UseVisualStyleBackColor = False
        '
        'addbills
        '
        Me.AcceptButton = Me.addbillbtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.CFaX.My.Resources.Resources.registration
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(812, 347)
        Me.Controls.Add(Me.cancelbtn)
        Me.Controls.Add(Me.addbillbtn)
        Me.Controls.Add(Me.billamount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.billname)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox6)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "addbills"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Bill"
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents billname As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents billamount As TextBox
    Friend WithEvents addbillbtn As Button
    Friend WithEvents cancelbtn As Button
End Class
