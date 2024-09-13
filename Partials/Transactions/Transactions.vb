Imports MySql.Data.MySqlClient
Public Class Transactions
    Dim result As New List(Of Tuple(Of String, String))
    Private Function getFirstBill(ByVal billidparam As String)
        'return the first row of bill in the database
        If getConn().State = ConnectionState.Closed Then
            Connect()
        End If
        Dim query As String
        Try
            If billidparam IsNot Nothing Then
                query = "SELECT * FROM bills WHERE BillId = " + billidparam + ";"
            Else
                query = "SELECT * FROM bills LIMIT 1;"
            End If
            Dim cmd As New MySqlCommand(query, getConn())
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                reader.Read()
                Dim billid As String = reader.GetString(reader.GetOrdinal("BillId"))
                Dim billname As String = reader.GetString(reader.GetOrdinal("BillName"))
                result.Add(New Tuple(Of String, String)(billid, billname))
            End If
            reader.Close()
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        Finally
            CloseConn()
        End Try
        Return result.ToArray()
    End Function
    Public Function getFirstBillName(Optional ByVal billidparam As String = Nothing)
        'get the first name returned from the db and assign it to the label
        Dim billname As Tuple(Of String, String)() = getFirstBill(billidparam)
        Dim name As String = ""
        For Each userData As Tuple(Of String, String) In billname
            name = userData.Item2
            ' Do something with the id and name values
        Next
        If name = "" Then
            name = "No Current Bill"
        End If
        Return name.ToUpper
    End Function
    Public Function getFirstBillId(Optional ByVal billidparam As String = Nothing)
        'get the first bill to fetch in the data grid as default value
        'get the first name returned from the db and assign it to the label
        Dim billid As Tuple(Of String, String)() = getFirstBill(billidparam)
        Dim id As String = ""
        For Each userData As Tuple(Of String, String) In billid
            id = userData.Item1
            ' Do something with the id and name values
        Next
        If id = "" Then
            id = Nothing
        End If
        Return id
    End Function
    Public Sub fetchDefaultTransaction(ByVal payergridview As DataGridView, Optional ByVal billidparam As String = Nothing)
        Dim billid = getFirstBillId(billidparam)
        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If
            'if bill table is currentempty
            If billid Is Nothing Then
                Return
            End If
            Dim cmd As New MySqlCommand("SELECT * FROM payers WHERE BillId = @billid", getConn())
            cmd.Parameters.AddWithValue("@billid", billid)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            'bind to the payergrid
            payergridview.DataSource = dt

            'handle stylings of datagrid for transaction list
            payergridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            payergridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            payergridview.Font = New Font("Tahoma", 12)
            payergridview.ForeColor = Color.Black

            'handle stylings of datagrid for student list
            payergridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            payergridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            ' Customize column header appearance
            payergridview.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Bold)
            payergridview.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
            ' Set column properties
            payergridview.Columns("PayerId").Visible = False
            payergridview.Columns("Fullname").HeaderText = "Fullname"
            payergridview.Columns("BillId").HeaderText = "Bill ID"
            payergridview.Columns("BillId").Visible = False
            payergridview.Columns("Status").HeaderText = "Payment Status"
            payergridview.Columns("Price").HeaderText = "Distributed Price"
            payergridview.Columns("DatePaid").HeaderText = "Date Paid"


        Catch ex As Exception
            errorform.errorlabel.Text = "An error occurred while fetching data: " + ex.Message
            errorform.Show()
            Return
        Finally
            CloseConn()
        End Try
    End Sub

    Public Sub summarize(ByVal billid As String, ByVal label1 As Label, ByVal label2 As Label, ByVal label3 As Label, ByVal label4 As Label)
        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If
            Dim cmd As New MySqlCommand("SELECT * FROM bills WHERE BillId = @billid LIMIT 1;", getConn())
            cmd.Parameters.AddWithValue("@billid", billid)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Dim billname As String = Nothing
            While reader.Read()
                label1.Text = reader("BillName").ToString().ToUpper()
            End While
            reader.Close()

            'count of total rows
            Dim count As Integer = countRows(billid)

            'number of student whose paid
            Dim paidquantityint As String = getPaids(billid)
            Dim paidquantitystring As String = paidquantityint.ToString().ToUpper()

            'number of student whose not paid
            Dim notpaidcountint As Integer = countRows(billid) - getPaids(billid)
            Dim notpaidcountstring As String = notpaidcountint.ToString()

            'accumulated fund
            Dim fundint As Integer = getPaids(billid) * getPrice(billid)
            Dim fundstring As String = fundint.ToString()
            Dim formattedstring As String
            If fundstring.Length = 1 Then
                formattedstring = "₱0" + fundstring + ".00"
            Else
                formattedstring = "₱" + fundstring + ".00"
            End If

            'set the summary label
            label2.Text = paidquantitystring + " Student(s)"
            label3.Text = notpaidcountstring + " Student(s)"
            label4.Text = formattedstring

        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        End Try
    End Sub

    Private Function countRows(ByVal billid As String)
        Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM payers WHERE BillId = @billid;", getConn())
        cmd.Parameters.AddWithValue("@billid", billid)
        Dim count As Integer = CInt(cmd.ExecuteScalar())
        Return count
    End Function

    Private Function getPaids(ByVal billid As String)
        Dim cmd As New MySqlCommand("select COUNT(*) from payers where billid = @billid and DatePaid != @datepaid", getConn())
        cmd.Parameters.AddWithValue("@billid", billid)
        cmd.Parameters.AddWithValue("@datepaid", "Not Paid")
        Dim count As Integer = CInt(cmd.ExecuteScalar())
        Return count
    End Function

    Private Function getPrice(ByVal billid As String)
        Dim cmd As New MySqlCommand("select Price from payers where billid = @billid LIMIT 1", getConn())
        cmd.Parameters.AddWithValue("@billid", billid)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        Dim price As Integer
        If reader.Read() Then
            price = Convert.ToInt32(reader("Price"))
        End If
        reader.Close()
        Return price
    End Function

    Public Sub addbalance(ByVal billid As String, ByVal studentname As String)
        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If

            Dim query As String = "Select Price from payers where BillId = @billid And FullName = @fname"
            Dim cmd As New MySqlCommand(query, getConn)
            cmd.Parameters.AddWithValue("@billid", billid)
            cmd.Parameters.AddWithValue("fname", studentname)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            Dim price As Integer

            If Not reader.HasRows Then
                Return
            End If
            reader.Read()
            price = reader.GetInt32("Price")
            reader.Close()

            If price <> Nothing And price > 0 Then
                Dim query2 = "insert into balance (balance) values (@balance);"
                Dim cmd2 As New MySqlCommand(query2, getConn())
                cmd2.Parameters.AddWithValue("@balance", price)
                cmd2.ExecuteNonQuery()
            End If

        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        End Try
    End Sub
End Class
