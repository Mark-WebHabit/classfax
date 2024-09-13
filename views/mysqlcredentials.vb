Public Class mysqlcredentials
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub mysqlcredentials_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        password.UseSystemPasswordChar = True
        Label2.Text = "Show"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If uid.Text = "" AndAlso password.Text = "" Then
            uiderror.Visible = True
            passwordError.Visible = True
            Return
        ElseIf uid.Text = "" Then
            uiderror.Visible = True
            passwordError.Visible = False
            Return
        ElseIf password.Text = "" Then
            passwordError.Visible = True
            uiderror.Visible = False
            Return
        Else
            uiderror.Visible = False
            passwordError.Visible = False
        End If

        Me.Close()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If password.UseSystemPasswordChar = True Then
            password.UseSystemPasswordChar = False
            Label2.Text = "Hide"
        Else
            password.UseSystemPasswordChar = True
            Label2.Text = "Show"
        End If
    End Sub
End Class