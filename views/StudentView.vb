Imports MySql.Data.MySqlClient
Public Class StudentView
    Dim balance As New balance()
    Private Sub StudentView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "@" + getCurrentUser()
        fundlabel.Text = "Class's Current Balance as of " + getcurrentdate()
        fund.Text = "PHP " + balance.getFund().ToString() + ".00"

        'display paid and recent bills
        displaybills(ListView1, "Pending")
        displaybills(ListView2, "Paid")
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Application.Exit()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        setCurrentUser("")
        setUserType("")
        Me.Close()
        login.Show()
        With login
            login.fullname.Focus()
        End With
    End Sub

    Private Function getcurrentdate()
        Dim currentdate As DateTime = DateTime.Now
        Return currentdate.ToString("MM/dd/yy")
    End Function

    Private Sub displaybills(ByVal listview As ListView, ByVal condition As String)
        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If
            Dim query As String = "SELECT Payers.Price, Payers.DatePaid, Bills.BillName, Bills.Amount FROM Payers INNER JOIN Bills ON Payers.BillId = Bills.BillId WHERE Payers.FullName = @fname AND payers.Status = @stat"
            Dim cmd As New MySqlCommand(query, getConn())
            cmd.Parameters.AddWithValue("@fname", getCurrentUser())
            cmd.Parameters.AddWithValue("@stat", condition)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim price As Integer = reader.GetInt32(reader.GetOrdinal("Price"))
                Dim datePaid As String = reader.GetString(reader.GetOrdinal("DatePaid"))
                Dim billName As String = reader.GetString(reader.GetOrdinal("BillName"))
                Dim amount As Integer = reader.GetInt32(reader.GetOrdinal("Amount"))
                Dim sentence As String
                Dim newbillamount = amount.ToString()
                Dim newpayerprice = price.ToString()

                If datePaid <> "Not Paid" Then
                    Dim newdate As String = datePaid.Split(" "c)(0)
                    sentence = billName.ToUpper() + " worth " + " ₱" + newbillamount + ". contribution:  " + "₱" + newpayerprice + " since " + newdate
                Else
                    sentence = billName.ToUpper() + " worth " + " ₱" + newbillamount + ". contribution: " + "₱" + newpayerprice
                End If

                Dim item As New ListViewItem(sentence)
                item.Font = New Font("Arial", 11, FontStyle.Regular)

                listview.Items.Add(item)
            End While

            reader.Close()
            CloseConn()

        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Hide()
        updateform.Show()
    End Sub
End Class