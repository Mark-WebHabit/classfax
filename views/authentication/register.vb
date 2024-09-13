Imports MySql.Data.MySqlClient

Public Class register
    Dim hash As New Hash
    Dim utils As New Utilities()

    Dim studentname As String
    Dim id As Integer
    Dim studentnum As String
    Dim type As String


    Private Sub register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        password.UseSystemPasswordChar = True
        cpassword.UseSystemPasswordChar = True
        Connect()
    End Sub
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

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
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


        Me.Hide()
        With Login
            Login.password.UseSystemPasswordChar = True
            Login.Label2.Text = "Show"
        End With
        Login.Show()
    End Sub

    Public Function getStudentType()
        Dim selectedRadio As String = ""
        ' Loop through each control in the group box
        For Each ctrl As Control In types.Controls
            ' Check if the control is a radio button and is checked
            If TypeOf ctrl Is RadioButton AndAlso CType(ctrl, RadioButton).Checked Then
                ' Get the value of the selected radio button
                selectedRadio = CType(ctrl, RadioButton).Text
                Exit For ' Exit the loop after finding the selected radio button
            End If
        Next

        ' Use the selected value for further processing
        If Not String.IsNullOrEmpty(selectedRadio) Then
            ' return the selected radio
            Return selectedRadio
        End If
        Return ""
    End Function

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles password_toggle.Click
        If password.UseSystemPasswordChar = True Then
            password.UseSystemPasswordChar = False
            password_toggle.Text = "Hide"
        Else
            password.UseSystemPasswordChar = True
            password_toggle.Text = "Show"
        End If
    End Sub

    Private Sub cpass_toggle_Click(sender As Object, e As EventArgs) Handles cpass_toggle.Click
        If cpassword.UseSystemPasswordChar = True Then
            cpassword.UseSystemPasswordChar = False
            cpass_toggle.Text = "Hide"
        Else
            cpassword.UseSystemPasswordChar = True
            cpass_toggle.Text = "Show"
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        'error initializer
        Dim hasError As Boolean = False
        Dim hasUnChecked As Boolean = True

        ' check if all fields are answered
        'for textboxs
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                Dim txtBox As TextBox = CType(ctrl, TextBox)
                If (txtBox.Text = "") Then
                    hasError = True
                End If
            End If
        Next

        'for radio buttons
        For Each ctrl As Control In types.Controls
            If TypeOf ctrl Is RadioButton Then
                Dim radioButton As RadioButton = CType(ctrl, RadioButton)
                If radioButton.Checked Then
                    hasUnChecked = False
                    Exit For ' Exit the loop since we found a checked radio button
                End If
            End If
        Next

        'check if there are missing fields
        If hasError Or hasUnChecked Then
            errorform.errorlabel.Text = "All Fields are Required!"
            errorform.Show()
            Return
        End If

        'check if password is lessthan 6 chars
        If password.Text.Length <= 6 Then
            errorform.errorlabel.Text = "Password must be greater than 6 characters"
            errorform.Show()
            password.Focus()
            Return
        End If
        'check if password and password confirmation were mismatched
        If password.Text <> cpassword.Text Then
            errorform.errorlabel.Text = "The Password and Confirm Password does not matched"
            errorform.Show()
            cpassword.Focus()
            Return
        End If

        Name = lname.Text + " " + fname.Text
        studentname = Name.Replace(",", "").Replace(".", "")
        type = getStudentType()
        studentnum = studentno.Text
        'hased the password if it is valid
        Dim hashedPass As String = hash.SHA1Hash(password.Text)

        Try
            ' Restart connection if open
            If (getConn().State = ConnectionState.Open) Then
                CloseConn()
            End If
            Connect()

            ' Create the SQL select statement with a placeholder for the student number parameter
            Dim sql As String = "SELECT COUNT(*) FROM users WHERE StudentNo = @studentnumber"

            ' Create a MySqlCommand object with the SQL statement and the MySqlConnection object
            Dim cmd As New MySqlCommand(sql, getConn())
            ' Add a parameter to the command object for the student number value to search for
            cmd.Parameters.AddWithValue("@studentnumber", studentnum)

            ' Execute the command and get the number of matching records
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            ' Check if a record with the given student number already exists in the table
            If count > 0 Then
                Throw New Exception("A student with student number " + studentnum + " already exists in the database.")
            End If

        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
            Return
        Finally
            ' Close the database connection
            CloseConn()
        End Try


        Try
            'restart connection if open
            If (getConn().State = ConnectionState.Open) Then
                CloseConn()
            End If
            Connect()

            Dim stmt As String = "INSERT INTO users (FullName, StudentNo, Type, Password, isApproved) VALUES (@studentname, @studentnumber, @type, @password, @val);"
            Dim cmd As New MySqlCommand(stmt, getConn())
            cmd.Parameters.AddWithValue("@studentname", studentname)
            cmd.Parameters.AddWithValue("@studentnumber", studentnum)
            cmd.Parameters.AddWithValue("@type", type)
            cmd.Parameters.AddWithValue("@password", hashedPass)
            If type = "Admin" Then
                cmd.Parameters.AddWithValue("@val", 0)
            Else
                cmd.Parameters.AddWithValue("@val", 1)
            End If

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
            Return
        Finally
            CloseConn()
        End Try

        If type = "Admin" Then
            MessageBox.Show("Please wait for the student incharge to approve your registration before you can login")
        End If

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
        password.UseSystemPasswordChar = True
        cpassword.UseSystemPasswordChar = True
        password_toggle.Text = "Show"
        cpass_toggle.Text = "Show"
        Me.Close()
        login.Show()
    End Sub
End Class