Imports MySql.Data.MySqlClient
Public Class updateform
    Dim hash As New Hash
    Private Sub cancel_Click(sender As Object, e As EventArgs) Handles cancel.Click
        Me.Close()
        StudentView.Show()
    End Sub

    Private Sub updateform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fullname.Text = getCurrentUser()
        password.UseSystemPasswordChar = True
        cpass.UseSystemPasswordChar = True
    End Sub

    Private Sub commit_Click(sender As Object, e As EventArgs) Handles commit.Click
        If fullname.Text = "" Or fullname.TextLength <= 5 Then
            errorform.errorlabel.Text = "Fullname must be 6 characters and above"
            errorform.Show()
            fullname.Focus()
            Return
        End If

        If password.Text <> "" AndAlso password.TextLength <= 5 Then
            errorform.errorlabel.Text = "Password must be 6 characters and above"
            errorform.Show()
            password.Focus()
            Return
        End If

        If password.Text = "" AndAlso cpass.Text <> "" Then
            errorform.errorlabel.Text = "Password don't matched"
            errorform.Show()
            password.Focus()
            Return
        End If

        If password.Text <> "" AndAlso password.TextLength >= 6 AndAlso password.Text <> cpass.Text Then
            errorform.errorlabel.Text = "Password don't matched"
            errorform.Show()
            password.Focus()
            Return
        End If

        If password.Text = "" AndAlso fullname.TextLength >= 6 Then
            Try
                If getConn().state = ConnectionState.Closed Then
                    Connect()
                End If

                Dim result As DialogResult = MessageBox.Show("Confirm Name Modification?", "Confirmation", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    Dim query = "Update users Set FullName = @fname Where FullName = @name"
                    Dim cmd As New MySqlCommand(query, getConn())
                    cmd.Parameters.AddWithValue("@fname", fullname.Text)
                    cmd.Parameters.AddWithValue("@name", getCurrentUser())
                    cmd.ExecuteNonQuery()
                    setCurrentUser(fullname.Text)
                    Me.Close()
                    StudentView.Show()
                    With StudentView
                        StudentView.Label2.Text = "@" + getCurrentUser()
                    End With
                End If
                CloseConn()
            Catch ex As Exception
                errorform.errorlabel.Text = ex.Message
                errorform.Show()
            End Try
        End If

        If password.TextLength >= 6 And fullname.TextLength >= 6 AndAlso password.Text = cpass.Text Then
            Try
                If getConn().state = ConnectionState.Closed Then
                    Connect()
                End If

                Dim result As DialogResult = MessageBox.Show("Confirm Name Modification?", "Confirmation", MessageBoxButtons.YesNo)
                Dim hashedpass = hash.SHA1Hash(password.Text)
                If result = DialogResult.Yes Then
                    Dim query = "Update users set FullName = @fname, Password = @pass Where FullName = @name"
                    Dim cmd As New MySqlCommand(query, getConn())
                    cmd.Parameters.AddWithValue("@fname", fullname.Text)
                    cmd.Parameters.AddWithValue("@pass", hashedpass)
                    cmd.Parameters.AddWithValue("@name", getCurrentUser())
                    cmd.ExecuteNonQuery()
                    setCurrentUser(fullname.Text)
                    Me.Close()
                    StudentView.Show()
                    With StudentView
                        StudentView.Label2.Text = "@" + getCurrentUser()
                    End With
                End If
                CloseConn()
            Catch ex As Exception
                errorform.errorlabel.Text = ex.Message
                errorform.Show()
            End Try
        End If
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

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        If cpass.UseSystemPasswordChar = True Then
            cpass.UseSystemPasswordChar = False
            Label4.Text = "Hide"
        Else
            cpass.UseSystemPasswordChar = True
            Label4.Text = "Show"
        End If
    End Sub
End Class