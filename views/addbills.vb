Imports MySql.Data.MySqlClient
Public Class addbills
    Public Event DataAdded As EventHandler
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        clearAndExit()
    End Sub

    Private Sub cancelbtn_Click(sender As Object, e As EventArgs) Handles cancelbtn.Click
        clearAndExit()
    End Sub

    Private Sub clearAndExit()
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
        'refresh the dashboard
        currentPanel = "billtable"
        dashboard.Show()

    End Sub

    Private Function generateRandomInt()
        Dim random As New Random()
        Dim result As String = ""
        For i As Integer = 1 To 10
            result += random.Next(0, 10).ToString()
        Next

        Return result
    End Function

    Private Sub addbillbtn_Click(sender As Object, e As EventArgs) Handles addbillbtn.Click
        'if one of the fields are empty
        If billname.Text = "" Or billamount.Text = "" Then
            errorform.errorlabel.Text = "All Fields aare Required"
            errorform.Show()
            Return
        End If

        'check if amount input is a valid number
        Dim amountint As Integer
        If Not Integer.TryParse(billamount.Text, amountint) Then
            errorform.errorlabel.Text = "Provide a valid numeric amount"
            errorform.Show()
            billamount.Focus()
            Return
        End If

        'append to the database
        Try
            If getConn().state = ConnectionState.Closed Then
                connect()
            End If
            Dim id As String = generateRandomInt()
            Dim sql As String = "INSERT INTO bills (BillId, BillName, Amount, Status, Archive, DatePaid) VALUES (@id, @billname, @amount, @status, @archive, @datapaid);"
            Dim cmd As New MySqlCommand(sql, getConn)
            cmd.Parameters.AddWithValue("@id", id)
            cmd.Parameters.AddWithValue("@billname", billname.Text)
            cmd.Parameters.AddWithValue("@amount", billamount.Text)
            cmd.Parameters.AddWithValue("@status", "Pending")
            cmd.Parameters.AddWithValue("@archive", 0)
            cmd.Parameters.AddWithValue("@datapaid", "")
            cmd.ExecuteNonQuery()

            ' Call stored procedure to create payers
            Dim sp As String = "CALL create_new_payers(@billid, @amount, NOW());"
            Dim spCmd As New MySqlCommand(sp, getConn())
            spCmd.Parameters.AddWithValue("@billid", id)
            spCmd.Parameters.AddWithValue("@amount", billamount.Text)
            spCmd.ExecuteNonQuery()

        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
            Return
        End Try
        CloseConn()
        RaiseEvent DataAdded(Me, EventArgs.Empty)
        Dim dash As New dashboard
        dashboard.populateChartBill()
        dashboard.getallbillspending()
        clearAndExit()

    End Sub

End Class