Imports MySql.Data.MySqlClient
Public Class Bills
    Dim utils As New Utilities
    Public Sub loadbills(ByVal billpanel As Panel, ByVal recentbill As Panel, ByVal billcpanel_click As EventHandler, ByVal recentcpanel_click As EventHandler, ByVal isAsc As Boolean, ByVal isPaidAsc As Boolean)
        ' clear any existing controls from the billpanel.
        billpanel.Controls.Clear()
        recentbill.Controls.Clear()
        ' set flowlayoutpanel properties

        Try
            If getConn().state = ConnectionState.Closed Then
                Connect()
            End If

            Dim count As Integer = 0
            Dim bill_id As New List(Of String)()
            Dim bill_name As New List(Of String)()
            Dim bill_date As New List(Of DateTime)()
            Dim bill_amount As New List(Of Decimal)()
            Dim bill_status As New List(Of String)()
            Dim bill_date_paid As New List(Of String)()

            Dim cmd As MySqlCommand

            If isAsc = True Then
                cmd = New MySqlCommand("select * from bills WHERE ARCHIVE = False ORDER BY BillName ASC;", getConn())
            Else
                cmd = New MySqlCommand("select * from bills WHERE ARCHIVE = False ORDER BY BillName DESC;", getConn())
            End If
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                bill_id.Add(reader.GetString("BillId"))
                bill_name.Add(reader.GetString("billname"))
                bill_date.Add(reader.GetDateTime("date"))
                bill_amount.Add(reader.GetDecimal("amount"))
                bill_status.Add(reader.GetString("status"))
                bill_date_paid.Add(reader.GetString("datepaid"))

                count += 1
            End While

            reader.Close()
            Dim bill_id_arr As String() = bill_id.ToArray()
            Dim bill_name_arr As String() = bill_name.ToArray()
            Dim bill_date_arr As DateTime() = bill_date.ToArray()
            Dim bill_amount_arr As Decimal() = bill_amount.ToArray()
            Dim bill_status_arr As String() = bill_status.ToArray()
            Dim bill_date_paid_arr As String() = bill_date_paid.ToArray()

            Dim x As Integer = 10
            Dim y As Integer = 10
            Dim k As Integer = 10
            Dim j As Integer = 10

            Dim containerwidth As Integer = billpanel.Width
            Dim recentcontainer As Integer = recentbill.Width


            For i As Integer = 0 To count - 1
                'initiate initial controls
                Dim namelabel = New Label()
                Dim amountlabel As New Label()
                Dim statuslabel As New Label()
                Dim datelabel As New Label()
                Dim datepaidlabel As New Label()

                ' create a new panel for the bill related panels.
                If bill_status_arr(i) = "Pending" Then
                    Dim billcpanel As New Panel()

                    ' set panels properties.
                    billcpanel.BorderStyle = BorderStyle.Fixed3D
                    billcpanel.BackColor = Color.White
                    billcpanel.Width = 200
                    billcpanel.Height = 150
                    billcpanel.Margin = New Padding(10)
                    billcpanel.Padding = New Padding(10)
                    billcpanel.Cursor = Cursors.Hand
                    billcpanel.Name = bill_id_arr(i)

                    ' create a label to display the related bill name.
                    namelabel.Text = bill_name_arr(i)
                    namelabel.Dock = DockStyle.Top
                    namelabel.TextAlign = ContentAlignment.MiddleCenter
                    namelabel.BackColor = Color.Turquoise
                    namelabel.Font = New Font(namelabel.Font, FontStyle.Bold)
                    namelabel.ForeColor = Color.Black

                    ' create a label to display the bill amount.
                    amountlabel.Text = "₱" & bill_amount_arr(i).ToString("n2")
                    amountlabel.Dock = DockStyle.Fill
                    amountlabel.TextAlign = ContentAlignment.MiddleCenter
                    amountlabel.Font = New Font(namelabel.Font, FontStyle.Bold)

                    ' create a label to display the bill status.
                    statuslabel.Text = bill_status_arr(i)
                    statuslabel.Dock = DockStyle.Bottom
                    statuslabel.TextAlign = ContentAlignment.MiddleCenter
                    statuslabel.Font = New Font(namelabel.Font, FontStyle.Bold)
                    statuslabel.AutoSize = False

                    ' create a label to display the bill date.
                    datelabel.Text = "Planned since: " + bill_date_arr(i).ToString("MM/dd/yyyy hh:mm")
                    datelabel.Dock = DockStyle.Bottom
                    datelabel.TextAlign = ContentAlignment.MiddleCenter
                    datelabel.Font = New Font(namelabel.Font, FontStyle.Bold)

                    'add the controls to the created related bill panel
                    billcpanel.Controls.Add(namelabel)
                    billcpanel.Controls.Add(amountlabel)
                    billcpanel.Controls.Add(statuslabel)
                    billcpanel.Controls.Add(datelabel)

                    'add the created panel to the main panel
                    billpanel.Controls.Add(billcpanel)

                    ' set the location of the related bill panel.
                    If x + billcpanel.Width > containerwidth Then
                        x = 10
                        y += billcpanel.Height + 10 ' add some padding between the panels
                    End If

                    billcpanel.Location = New Point(x, 10)
                    utils.AddClickHandlerToChildControls(billcpanel, billcpanel_click)
                    AddHandler billcpanel.Click, billcpanel_click

                    ' add some padding between the panels
                    x += billcpanel.Width + 10
                Else
                    Dim recentcpanel As New Panel()
                    ' set panels properties.
                    recentcpanel.BorderStyle = BorderStyle.Fixed3D
                    recentcpanel.BackColor = Color.White
                    recentcpanel.Width = 200
                    recentcpanel.Height = 170
                    recentcpanel.Margin = New Padding(10)
                    recentcpanel.Padding = New Padding(10)
                    recentcpanel.Cursor = Cursors.Hand
                    recentcpanel.Name = bill_id_arr(i)

                    ' customize a label to display the related bill status.
                    statuslabel.Text = bill_status_arr(i)
                    statuslabel.Dock = DockStyle.Bottom
                    statuslabel.TextAlign = ContentAlignment.MiddleCenter
                    statuslabel.Font = New Font(namelabel.Font, FontStyle.Bold)
                    statuslabel.AutoSize = False

                    ' customize a label to display the related bill name.
                    namelabel.Text = bill_name_arr(i)
                    namelabel.Dock = DockStyle.Top
                    namelabel.TextAlign = ContentAlignment.MiddleCenter
                    namelabel.BackColor = Color.FromArgb(255, 51, 51)
                    namelabel.Font = New Font(namelabel.Font, FontStyle.Bold)
                    namelabel.ForeColor = Color.White

                    ' customize a label to display the bill amount.
                    amountlabel.Text = "₱" & bill_amount_arr(i).ToString("n2")
                    amountlabel.Dock = DockStyle.Fill
                    amountlabel.TextAlign = ContentAlignment.MiddleCenter
                    amountlabel.Font = New Font(namelabel.Font, FontStyle.Bold)

                    ' customize a label to display the bill date.
                    datelabel.Text = "Planned since: " + bill_date_arr(i).ToString("MM/dd/yyyy hh:mm")
                    datelabel.Dock = DockStyle.Bottom
                    datelabel.TextAlign = ContentAlignment.MiddleCenter
                    datelabel.Font = New Font(namelabel.Font, FontStyle.Bold)

                    datepaidlabel.Text = "Paid Since: " + bill_date_paid_arr(i)
                    datepaidlabel.Dock = DockStyle.Bottom
                    datepaidlabel.TextAlign = ContentAlignment.MiddleCenter
                    datepaidlabel.Font = New Font(namelabel.Font, FontStyle.Bold)

                    ' add the labels to the related bill panel.
                    recentcpanel.Controls.Add(namelabel)
                    recentcpanel.Controls.Add(amountlabel)
                    recentcpanel.Controls.Add(statuslabel)
                    recentcpanel.Controls.Add(datelabel)
                    recentcpanel.Controls.Add(datepaidlabel)

                    ' add the bill panel to the billpanel container and recentbill.
                    recentbill.Controls.Add(recentcpanel)

                    ' set the location of the related bill panel.
                    If x + recentcpanel.Width > recentcontainer Then
                        k = 10
                        j += recentcpanel.Height + 10 ' add some padding between the panels
                    End If

                    recentcpanel.Location = New Point(y, 10)
                    utils.AddClickHandlerToChildControls(recentcpanel, recentcpanel_click)
                    AddHandler recentcpanel.Click, recentcpanel_click

                    ' add some padding between the panels
                    y += recentcpanel.Width + 10
                End If
            Next
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        Finally
            CloseConn()
        End Try
    End Sub

    Public Function getSelectedPendingBill(ByVal selectedValue As String)
        Try
            If getConn.State = ConnectionState.Closed Then
                Connect()
            End If
            'fetch the bill thru its name
            Dim cmd As New MySqlCommand("SELECT * FROM bills WHERE BillId = @selectedValue LIMIT 1;", getConn())
            cmd.Parameters.AddWithValue("@selectedValue", selectedValue)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                Dim billname = reader.GetString("BillName")
                Dim amount = reader.GetInt32("Amount")
                Dim status = reader.GetString("Status")
                Dim privateid = reader.GetString("BillId")
                reader.Close()
                'store in an array berfore returning
                Dim billData(3) As Object
                billData(0) = billname
                billData(1) = amount
                billData(2) = status

                unknownInt = privateid

                Return billData
            Else
                errorform.errorlabel.Text = "Conflict with bills, a bill with this name does not exist"
                errorform.Show()
                Return 0
            End If
        Catch ex As Exception
            errorform.errorlabel.Text = "A complication happens when extracting bills, please restart the app"
            errorform.Show()
        Finally
            CloseConn()
        End Try
        Return ""
    End Function

    Public Sub updateBill(ByVal billname As String, ByVal amount As Integer)
        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If

            Dim cmd As New MySqlCommand("UPDATE bills SET BillName = @billname, Amount = @amount WHERE BillName = @billname OR Amount = @amount AND BillId = @id;", getConn())
            cmd.Parameters.AddWithValue("@billname", billname)
            cmd.Parameters.AddWithValue("@amount", amount)
            cmd.Parameters.AddWithValue("@id", unknownInt)

            Dim row As Integer = cmd.ExecuteNonQuery()

            If Not row > 0 Then
                Throw New Exception("Bill Not Found, Please restart the app")
            End If
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        Finally
            CloseConn()
        End Try
    End Sub


    Public Function getSelectedPaidBill(ByVal selectedValue As String)
        Try
            If getConn.State = ConnectionState.Closed Then
                Connect()
            End If
            'fetch the bill thru its name
            Dim cmd As New MySqlCommand("SELECT * FROM bills WHERE BillId = @selectedValue LIMIT 1;", getConn())
            cmd.Parameters.AddWithValue("@selectedValue", selectedValue)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                Dim billname = reader.GetString("BillName")
                Dim amount = reader.GetInt32("Amount")
                Dim status = reader.GetString("Status")
                Dim privateid = reader.GetString("BillId")
                reader.Close()
                'store in an array berfore returning
                Dim billData(3) As Object
                billData(0) = billname
                billData(1) = amount
                billData(2) = status

                unknownInt = privateid

                Return billData
            Else
                errorform.errorlabel.Text = "Confilct with bills, a bill with this name does not exist"
                errorform.Show()
                Return 0
            End If
        Catch ex As Exception
            errorform.errorlabel.Text = "A complication happens when extracting bills, please restart the app"
            errorform.Show()
        Finally
            CloseConn()
        End Try
        Return ""
    End Function

    Public Function getBillAmount(billid As String)
        Dim amount As Integer = 0
        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If

            Dim cmd As New MySqlCommand("SELECT Amount FROM bills WHERE BillId = @billid;", getConn())
            cmd.Parameters.AddWithValue("@billid", billid)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                amount = reader.GetInt32("Amount")
            End While
            reader.Close()
        Catch ex As Exception
            errorform.errorlabel.Text = "Conflict with bills, a bill with this name does not exist"
            errorform.Show()
        End Try

        Return amount
    End Function
End Class
