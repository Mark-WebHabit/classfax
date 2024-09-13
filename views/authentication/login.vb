Imports MySql.Data.MySqlClient
Imports System.Configuration
Public Class Login
    Dim hash As New Hash
    Dim type As String
    Dim user As String
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        'clear all the field value before closing the application
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).Clear()
            ElseIf TypeOf ctrl Is GroupBox Then
                For Each innerCtrl As Control In ctrl.Controls
                    If TypeOf innerCtrl Is RadioButton Then
                        DirectCast(innerCtrl, RadioButton).Checked = False
                    End If
                Next
            End If
        Next


        Application.Exit()
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        password.UseSystemPasswordChar = True
        If My.Settings.firststart Then
            ' Prompt the user for their credentials
            Dim mysqlcredentials As New mysqlcredentials()
            mysqlcredentials.ShowDialog()

            Dim userName As String = mysqlcredentials.uid.Text
            Dim password As String = mysqlcredentials.password.Text

            ' Try to establish a connection with the user's credentials
            Dim connectionString As String = "server=127.0.0.1;user=" & userName & ";password=" & password & ";database=test;"
            Dim connection As New MySqlConnection(connectionString)

            Try
                connection.Open()

                ' Modify the connection string in the app.config file
                Dim configFile As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
                configFile.ConnectionStrings.ConnectionStrings("connection_string").ConnectionString = connectionString
                configFile.Save(ConfigurationSaveMode.Modified)

                ' Set the FirstStart setting to False so this code block doesn't run again
                My.Settings.firststart = False
                My.Settings.Save()
                connection.Close()
            Catch ex As MySqlException
                If userName = "" Or password = "" Then
                    Application.Exit()
                End If
                MessageBox.Show("User ID or Password Incorrect, Please Restart the Application and try again")
                Application.Exit()
            End Try
        End If


    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If (password.UseSystemPasswordChar) Then
            password.UseSystemPasswordChar = False
            Label2.Text = "Hide"
        Else
            password.UseSystemPasswordChar = True
            Label2.Text = "Show"
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        'clear all the fields
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).Clear()
            ElseIf TypeOf ctrl Is GroupBox Then
                For Each innerCtrl As Control In ctrl.Controls
                    If TypeOf innerCtrl Is RadioButton Then
                        DirectCast(innerCtrl, RadioButton).Checked = False
                    End If
                Next
            End If
        Next


        'redirect to login
        Me.Hide()
        With register
            register.password.UseSystemPasswordChar = True
            register.cpassword.UseSystemPasswordChar = True
            register.password_toggle.Text = "Show"
            register.cpass_toggle.Text = "Show"
        End With
        register.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (fullname.Text = "" And password.Text = "") Then
            errorform.errorlabel.Text = "Fields are Empty!"
            errorform.Show()
            fullname.Focus()
            Return
        ElseIf (fullname.Text = "") Then
            emailError.Visible = True
            fullname.Focus()
            Return
        ElseIf (password.Text = "") Then
            passwordError.Visible = True
            password.Focus()
            Return
        End If

        Try
            'refreshing the connection if it was leave open just in case
            If (getConn().State = ConnectionState.Open) Then
                CloseConn()
            End If
            'if there is a connection, retrieve data
            connect()
            If (getConn().State = ConnectionState.Open) Then
                'using prepared statement for security preference
                Dim query As String = "SELECT * FROM users WHERE Fullname = @fullname AND password = @Password AND isApproved = 1;"
                Dim cmd As New MySqlCommand(query, getConn())
                Dim hashedPass As String = hash.SHA1Hash(password.Text)
                cmd.Parameters.AddWithValue("@fullname", fullname.Text)
                cmd.Parameters.AddWithValue("@password", hashedPass)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    user = reader.GetString("FullName")
                    type = reader.GetString("type")
                Else
                    errorform.errorlabel.Text = "Wrong Email or Password"
                    errorform.Show()
                    fullname.Focus()
                    Return
                End If

                reader.Close()
                CloseConn()
            End If
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
            fullname.Focus()
            Return
        End Try

        setCurrentUser(user)
        setUserType(type)

        'clear all the field value before closing the application
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).Clear()
            ElseIf TypeOf ctrl Is GroupBox Then
                For Each innerCtrl As Control In ctrl.Controls
                    If TypeOf innerCtrl Is RadioButton Then
                        DirectCast(innerCtrl, RadioButton).Checked = False
                    End If
                Next
            End If
        Next

        If (getCurrentUser() = "") Then
            Return
        End If
        password.UseSystemPasswordChar = True
        Label2.Text = "Show"
        Me.Hide()
        If type = "Admin" Then
            Dim utils As New Utilities()
            With dashboard
                currentPanel = "balancepanel"
                utils.redirectPage(currentPanel, dashboard.balancepanel, dashboard.billtable, dashboard.studentpanel, dashboard.transactionpanel)
            End With
            dashboard.Show()
        Else

            StudentView.Show()
        End If


    End Sub

    Private Sub password_TextChanged(sender As Object, e As EventArgs) Handles password.TextChanged
        passwordError.Visible = False
    End Sub
End Class