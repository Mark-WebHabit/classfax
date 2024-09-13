Imports MySql.Data.MySqlClient
Public Class dashboard
    Inherits Form
    Private utils As New Utilities()
    Private bills As New Bills()
    Private students As New Students()
    Private transactions As New Transactions()
    Private balances As New balance()

    Dim studentCount As Integer
    Dim isPendingAsc As Boolean = True
    Dim isPaidAsc As Boolean = True

    'what happens when form load for the fist time
    Private Sub dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (getCurrentUser() = "") Then
            Application.Exit()
        End If

        If (getUserType() <> "Admin") Then
            Application.Exit()
        End If
        username.Text = getCurrentUser()

        'setting the panels as child of the parent container and initializng the visibility to false except for the first child
        panelContainer.Controls.Add(balancepanel)
        panelContainer.Controls.Add(billtable)
        panelContainer.Controls.Add(transactionpanel)
        panelContainer.Controls.Add(studentpanel)
        'panelContainer.Controls.Add(addbillpanel)
        balancepanel.Visible = True
        billtable.Visible = False
        transactionpanel.Visible = False
        studentpanel.Visible = False

        'hanldle hover and click event styles
        utils.ChangePanelStyle(Panel2, balancepanel, currentPanel)
        utils.ChangePanelStyle(Panel6, billtable, currentPanel)
        utils.ChangePanelStyle(Panel7, transactionpanel, currentPanel)
        utils.ChangePanelStyle(Panel11, studentpanel, currentPanel)

        'set controls of parent panel to its child, inherits the action given to the container
        utils.AddClickHandlerToChildControls(closePanel, AddressOf Panel10_Click)
        utils.AddClickHandlerToChildControls(Panel2, AddressOf Panel2_Click)
        utils.AddClickHandlerToChildControls(Panel6, AddressOf Panel6_Click)
        utils.AddClickHandlerToChildControls(Panel7, AddressOf Panel7_Click)
        utils.AddClickHandlerToChildControls(Panel11, AddressOf Panel11_Click)

        'handle page redirection
        utils.redirectPage(currentPanel, balancepanel, billtable, studentpanel, transactionpanel)

        students.fetch(student_list_grid, studentCount, student_count)
        'handle the styles of student list
        bills.loadbills(billpanel, recentbill, AddressOf billcpanel_click, AddressOf recentcpanel_click, isPendingAsc, isPaidAsc)

        billnamelabel.Text = transactions.getFirstBillName()
        transactions.fetchDefaultTransaction(payergridview)
        transactions.summarize(transactions.getFirstBillId(), billnamesummary, billsummarypaid, billsummarynotpaid, billsumurayfund)

        handleStyles_StudentList()
        populateChartBill()
        'set the opacity of the balance bg
        Panel34.BackColor = Color.FromArgb(200, Color.Gray)
        clockscreen.BackColor = Color.FromArgb(200, Color.White)
        'initiate the class fund
        balances.displayfund(classfund)
        'count the raw and Paid bills
        getallbillspending()
        getallbillspaid()
        showarchive()
        ColumnHeader1.Width = ListView1.Width - 10
    End Sub

    'close the app
    Private Sub Panel10_Click(sender As Object, e As EventArgs) Handles closePanel.Click
        utils.closeApp()
    End Sub

    'setting the page selection

    Private Sub Panel2_Click(sender As Object, e As EventArgs)
        currentPanel = balancepanel.Name
        utils.redirectPage(currentPanel, balancepanel, billtable, studentpanel, transactionpanel)
    End Sub

    Private Sub Panel6_Click(sender As Object, e As EventArgs) Handles Panel6.Click
        currentPanel = billtable.Name
        utils.redirectPage(currentPanel, balancepanel, billtable, studentpanel, transactionpanel)
    End Sub

    Private Sub Panel7_Click(sender As Object, e As EventArgs) Handles Panel7.Click
        currentPanel = transactionpanel.Name
        utils.redirectPage(currentPanel, balancepanel, billtable, studentpanel, transactionpanel)
    End Sub

    Private Sub Panel11_Click(sender As Object, e As EventArgs) Handles Panel11.Click
        currentPanel = studentpanel.Name
        utils.redirectPage(currentPanel, balancepanel, billtable, studentpanel, transactionpanel)
    End Sub



    Private Sub handleStyles_StudentList()
        'handle stylings of datagrid for student list
        student_list_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        student_list_grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        student_list_grid.Font = New Font("Tahoma", 12)
        student_list_grid.ForeColor = Color.Black

        'handle stylings of datagrid for student list
        student_list_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        student_list_grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        ' Customize column header appearance
        student_list_grid.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Bold)
        student_list_grid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
        ' Set column properties
        student_list_grid.Columns("FullName").HeaderText = "Name"
        student_list_grid.Columns("StudentNo").HeaderText = "Student Number"
        student_list_grid.Columns("Type").HeaderText = "Type of User"
        student_list_grid.Columns("Type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    End Sub

    Dim selectedStudenName As String
    Private Sub student_list_grid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles student_list_grid.CellClick
        Try
            'set the value of clicked task  into the text field for actions
            If Not e.ColumnIndex = 0 Then
                Return
            End If

            Dim selectedCell As DataGridViewCell = student_list_grid.CurrentCell
            selectedStudenName = selectedCell.Value.ToString()


            student_fullname.Text = selectedStudenName

            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If

            Dim cmd As New MySqlCommand("Select * from users where Fullname = @fullname;", getConn())
            cmd.Parameters.AddWithValue("@fullname", selectedStudenName)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                reader.Read()
                student_number.Text = reader.GetString("StudentNo")
            End If
            reader.Close()
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        Finally
            CloseConn()
        End Try
    End Sub

    'only change the cursor if it is pointing in the fullname
    Private Sub student_list_grid_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex = 0 Then
            student_list_grid.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub student_list_grid_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex = 0 Then
            student_list_grid.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub drop_btn_Click(sender As Object, e As EventArgs) Handles drop_btn.Click
        If student_fullname.Text = "" Or student_number.Text = "" Then
            Return
        End If

        Try
            If getConn().State = ConnectionState.Closed Then
                connect()
            End If

            Dim cmd As New MySqlCommand("DELETE FROM `users` WHERE `users`.`FullName` = @fullname or `users`.`StudentNo` = @studentno;", getConn())
            cmd.Parameters.AddWithValue("@fullname", student_fullname.Text)
            cmd.Parameters.AddWithValue("@studentno", student_number.Text)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
            Return
        Finally
            CloseConn()
        End Try

        student_fullname.Text = ""
        student_number.Text = ""
        students.fetch(student_list_grid, studentCount, student_count)

    End Sub

    Private Sub update_btn_Click(sender As Object, e As EventArgs) Handles update_btn.Click
        If student_fullname.Text = "" Or student_number.Text = "" Then
            Return
        End If


        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If

            Dim cmd As New MySqlCommand("UPDATE `users` SET `users`.`FullName` = @fullname, `users`.`StudentNo` = @studentno WHERE `users`.`FullName` = @fullname or `users`.`StudentNo` = @studentno;", getConn())
            cmd.Parameters.AddWithValue("@fullname", student_fullname.Text)
            cmd.Parameters.AddWithValue("@studentno", student_number.Text)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
            Return
        Finally
            CloseConn()
        End Try

        student_fullname.Text = ""
        student_number.Text = ""
        students.fetch(student_list_grid, studentCount, student_count)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        currentPanel = billpanel.Name
        utils.redirectPage(currentPanel, balancepanel, billtable, studentpanel, transactionpanel)
        setCurrentUser("")
        username.Text = ""
        Me.Close()
        login.Show()
        With Login
            Login.fullname.Focus()
            Login.password.UseSystemPasswordChar = True
            Login.Label2.Text = "Show"
        End With
    End Sub



    'display the details on the form when a bill has been clicked
    Dim selectedValue As String = ""
    Private Sub billcpanel_click(ByVal sender As Object, ByVal e As EventArgs)
        ' cast the sender to a control
        Dim clickedcontrol As Control = TryCast(sender, Control)


        ' check if the clicked control is a label or a panel
        If TypeOf clickedcontrol Is Label Then
            ' extract the parent panel's name
            Dim parentpanelname As String = clickedcontrol.Parent.Name
            selectedValue = parentpanelname
        ElseIf TypeOf clickedcontrol Is Panel Then
            ' extract the panel's name
            Dim panelname As String = clickedcontrol.Name
            selectedValue = panelname
        End If

        If selectedValue = "" Then
            Return
        End If

        Try
            'assign the array before extracting its value
            bills.getSelectedPendingBill(selectedValue)
            Dim billData As Object() = bills.getSelectedPendingBill(selectedValue)
            If billData IsNot Nothing Then
                'cstr converts the integer to string
                txtbillname.Text = billData(0)
                txtbillamount.Text = billData(1).ToString()
                txtbillstatus.Text = billData(2)
            End If
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        End Try
    End Sub
    Private Sub view_Click(sender As Object, e As EventArgs) Handles view.Click
        If selectedValue = "" Then
            Return
        End If
        billnamelabel.Text = transactions.getFirstBillName(selectedValue)
        transactions.fetchDefaultTransaction(payergridview, selectedValue)
        transactions.summarize(transactions.getFirstBillId(selectedValue.ToString()), billnamesummary, billsummarypaid, billsummarynotpaid, billsumurayfund)
        billtable.Visible = False
        currentPanel = "transactionpanel"
        transactionpanel.Visible = True
    End Sub
    Private Sub recentcpanel_click(ByVal sender As Object, ByVal e As EventArgs)
        ' cast the sender to a control
        Dim clickedcontrol As Control = TryCast(sender, Control)
        Dim selectedValue As String = ""

        ' check if the clicked control is a label or a panel
        If TypeOf clickedcontrol Is Label Then
            ' extract the parent panel's name
            Dim parentpanelname As String = clickedcontrol.Parent.Name
            selectedValue = parentpanelname
        ElseIf TypeOf clickedcontrol Is Panel Then
            ' extract the panel's name
            Dim panelname As String = clickedcontrol.Name
            selectedValue = panelname
        End If

        If selectedValue Is "" Then
            Return
        End If

        Try
            'assign the array before extracting its value
            bills.getSelectedPaidBill(selectedValue)
            Dim billData As Object() = bills.getSelectedPaidBill(selectedValue)
            If billData IsNot Nothing Then
                'cstr converts the integer to string
                labelpaidname.Text = billData(0)
                labelpaidamount.Text = billData(1).ToString() + ".00"
                labelpaidstatus.Text = billData(2)
            End If
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        End Try
    End Sub

    Private Sub cancel_bill_Click(sender As Object, e As EventArgs) Handles cancel_bill.Click
        txtbillname.Text = ""
        txtbillamount.Text = ""
        txtbillstatus.Text = "No Selected"
        unknownInt = 0
    End Sub

    Private Sub pay_bill_Click(sender As Object, e As EventArgs) Handles pay_bill.Click
        If txtbillname.Text = "" Or txtbillamount.Text = "" Or txtbillstatus.Text = "No Selected" Then
            Return
        End If
        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If

            Dim currentDate As DateTime = DateTime.Now
            Dim currentDateString As String = currentDate.ToString("MM/dd/yyyy")

            Dim currentfund = balances.getFund()
            Dim billamount = bills.getBillAmount(unknownInt)

            If currentfund < billamount Then
                Throw New Exception("Insufficient Fund")
                Return
            End If

            balances.deductfund(billamount, classfund)
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If
            Dim cmd As New MySqlCommand("UPDATE bills SET Status = @status, DatePaid = @datepaid WHERE BillName = @billname AND Amount = @amount AND BillId = @id;", getConn())
            cmd.Parameters.AddWithValue("@status", "Paid")
            cmd.Parameters.AddWithValue("@datepaid", currentDateString)
            cmd.Parameters.AddWithValue("@billname", txtbillname.Text)
            cmd.Parameters.AddWithValue("@amount", txtbillamount.Text)
            cmd.Parameters.AddWithValue("@id", unknownInt)

            Dim rows As Integer = cmd.ExecuteNonQuery()
            If rows > 0 Then
                'clear fields
                txtbillname.Text = ""
                txtbillamount.Text = ""
                txtbillstatus.Text = "No Selected"
                unknownInt = 0
                'refresh the bills
                bills.loadbills(billpanel, recentbill, AddressOf billcpanel_click, AddressOf recentcpanel_click, isPendingAsc, isPaidAsc)
                getallbillspending()
                getallbillspaid()
                populateChartBill()
            Else
                Throw New Exception(txtbillname.Text + " With Amount of " + txtbillamount.Text + " does not exists in the record")
            End If


        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        Finally
            CloseConn()
        End Try

    End Sub


    Private Sub update_bill_Click(sender As Object, e As EventArgs) Handles update_bill.Click

        If txtbillamount.Text = "" Or txtbillname.Text = "" Then
            Return
        End If
        'sanitize amount input
        Dim amountint As Integer
        If Not Integer.TryParse(txtbillamount.Text, amountint) Then
            errorform.errorlabel.Text = "Invalid Amount: Only Numeric Characters Valid"
            errorform.Show()
            txtbillamount.Focus()
            Return
        End If

        bills.updateBill(txtbillname.Text, txtbillamount.Text)
        'clear fields
        txtbillname.Text = ""
        txtbillamount.Text = ""
        txtbillstatus.Text = "No Selected"
        unknownInt = 0
        'refresh the bills
        bills.loadbills(billpanel, recentbill, AddressOf billcpanel_click, AddressOf recentcpanel_click, isPendingAsc, isPaidAsc)

    End Sub



    Dim archiveBill As New Archive()
    'Private Sub Archive_Click(sender As Object, e As EventArgs) Handles Archive.Click
    '    If txtbillname.Text = "" Or txtbillamount.Text = "" Or txtbillstatus.Text = "No Selected" Then
    '        txtbillname.Text = ""
    '        txtbillamount.Text = ""
    '        txtbillstatus.Text = "No Selected"
    '        Return
    '    End If
    '    archiveBill.setARCHIVE()
    '    txtbillname.Text = ""
    '    txtbillamount.Text = ""
    '    txtbillstatus.Text = "No Selected"
    '    unknownInt = 0
    '    'refresh the bills
    '    bills.loadbills(billpanel, recentbill, AddressOf billcpanel_click, AddressOf recentcpanel_click, isPendingAsc, isPaidAsc)
    'End Sub
    Private Sub rcarchive_Click(sender As Object, e As EventArgs) Handles rcarchive.Click
        If labelpaidname.Text = "No Selected" Or labelpaidamount.Text = "No Selected" Or labelpaidstatus.Text = "No Selected" Then
            Return
        End If

        archiveBill.setARCHIVE()
        labelpaidname.Text = "No Selected"
        labelpaidamount.Text = "No Selected"
        labelpaidstatus.Text = "No Selected"

        unknownInt = 0
        showarchive()
        bills.loadbills(billpanel, recentbill, AddressOf billcpanel_click, AddressOf recentcpanel_click, isPendingAsc, isPaidAsc)
    End Sub

    Private Sub showarchive()
        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If
            Dim cmd As New MySqlCommand("SELECT * FROM bills WHERE Archive = 1 OR Archive = True", getConn())
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            'bind to the archivegrid
            archivedatagrid.DataSource = dt

            'handle stylings of archivegrid for overview
            archivedatagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            archivedatagrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            archivedatagrid.Font = New Font("Tahoma", 8)
            archivedatagrid.ForeColor = Color.Black

            'handle stylings of datagrid for archive list
            archivedatagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            archivedatagrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            ' Customize column header appearance
            archivedatagrid.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            archivedatagrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
            ' Set column properties
            archivedatagrid.Columns("BillId").Visible = False
            archivedatagrid.Columns("BillName").HeaderText = "ARCHIVE"
            archivedatagrid.Columns("Amount").HeaderText = "AMOUNT"
            archivedatagrid.Columns("Status").HeaderText = "STATUS"
            archivedatagrid.Columns("DatePaid").Visible = False
            archivedatagrid.Columns("Archive").Visible = False
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        End Try
        CloseConn()
    End Sub

    'refresh panel bill
    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        bills.loadbills(billpanel, recentbill, AddressOf billcpanel_click, AddressOf recentcpanel_click, isPendingAsc, isPaidAsc)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles sort.Click
        If isPendingAsc = True Then
            isPendingAsc = False
            sortlabel.Text = "Desc"
        Else
            isPendingAsc = True
            sortlabel.Text = "Asc"
        End If
        bills.loadbills(billpanel, recentbill, AddressOf billcpanel_click, AddressOf recentcpanel_click, isPendingAsc, isPaidAsc)
    End Sub

    Private Sub addbill_Click_1(sender As Object, e As EventArgs) Handles addbill.Click
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).Clear()
            End If
        Next

        'automatically refresh the page when new data is added
        AddHandler addbills.DataAdded, AddressOf addbills_DataAdded
        With addbills
            addbills.billname.Focus()
        End With
        addbills.ShowDialog()
    End Sub

    Private Sub addbills_DataAdded(sender As Object, e As EventArgs)
        ' New data has been added, so reload the bills
        bills.loadbills(billpanel, recentbill, AddressOf billcpanel_click, AddressOf recentcpanel_click, isPendingAsc, isPaidAsc)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        students.fetch(student_list_grid, studentCount, student_count)
    End Sub

    Private Sub searchbillbutton_Click(sender As Object, e As EventArgs) Handles searchbillbutton.Click
        If billnamesearchfield.Text = "" Then
            Return
        End If

        If getConn().State = ConnectionState.Closed Then
            Connect()
        End If

        Try
            'display the bills returned by the result
            Dim query As String = "SELECT * FROM bills WHERE (Amount = @amount OR BillName = @billname) AND Status = @status;"
            Dim cmd As New MySqlCommand(query, getConn())
            cmd.Parameters.AddWithValue("@amount", billnamesearchfield.Text)
            cmd.Parameters.AddWithValue("@billname", billnamesearchfield.Text)
            cmd.Parameters.AddWithValue("@status", "Pending")
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            If dt.Rows.Count > 0 Then
                'handle stylings of datagrid for search list
                searchresultgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                searchresultgrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
                searchresultgrid.Font = New Font("Tahoma", 9)
                searchresultgrid.ForeColor = Color.Black

                'handle stylings of datagrid for search list
                searchresultgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                searchresultgrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
                ' Customize column header appearance
                searchresultgrid.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 10)
                searchresultgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
                'bind to the search result grid
                searchresultgrid.DataSource = dt
                searchresultgrid.Columns("BillId").HeaderText = "Bill ID"
                searchresultgrid.Columns("BillName").HeaderText = "Bill Name"
                searchresultgrid.Columns("Amount").HeaderText = "Price"
                searchresultgrid.Columns("Date").Visible = False
                searchresultgrid.Columns("Status").Visible = False
                searchresultgrid.Columns("DatePaid").Visible = False
                searchresultgrid.Columns("Archive").Visible = False
            Else
                MessageBox.Show("No Bills Matched")
            End If

        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        Finally
            CloseConn()
        End Try
    End Sub

    'get the id of the clicked cell in the serach result grid
    Private Sub searchresultgrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles searchresultgrid.CellClick
        If e.RowIndex >= 0 Then
            Dim value As Object = searchresultgrid.Rows(e.RowIndex).Cells(0).Value
            billnamelabel.Text = transactions.getFirstBillName(value)
            transactions.fetchDefaultTransaction(payergridview, value)
            transactions.summarize(transactions.getFirstBillId(value.ToString()), billnamesummary, billsummarypaid, billsummarynotpaid, billsumurayfund)
        End If
    End Sub

    'get the first and second index of the clicked payer row
    Dim selectedpayerid As Object = Nothing
    Dim selectedpayername As Object = Nothing
    Private Sub payergridview_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles payergridview.CellClick
        If e.RowIndex >= 0 Then
            selectedpayerid = payergridview.Rows(e.RowIndex).Cells(2).Value
            selectedpayername = payergridview.Rows(e.RowIndex).Cells(1).Value
            Dim amount As Object = payergridview.Rows(e.RowIndex).Cells(4).Value
            Dim status As Object = payergridview.Rows(e.RowIndex).Cells(3).Value
            Dim datepaid As Object = payergridview.Rows(e.RowIndex).Cells(5).Value

            payerfname.Text = selectedpayername
            Dim newamount = amount.ToString()
            If newamount.Length = 1 Then
                payeramount.Text = "₱0" + newamount + ".00"
            Else
                payeramount.Text = "₱" + newamount + ".00"
            End If
            payerstatus.Text = status
            payerdatepaid.Text = datepaid
        End If
    End Sub

    Private Sub paypayer_Click(sender As Object, e As EventArgs) Handles paypayer.Click
        Try
            If selectedpayerid Is Nothing Or selectedpayername Is Nothing Then
                Return
            End If
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If
            Dim action = MessageBox.Show("Do you want to mark " + selectedpayername.ToString().ToUpper + " as Paid?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If action = DialogResult.Yes Then

                Dim query As String = "SELECT * FROM payers WHERE BillId = @billid AND FullName = @fname LIMIT 1;"
                Dim cmd1 As New MySqlCommand(query, getConn())
                cmd1.Parameters.AddWithValue("@billid", selectedpayerid)
                cmd1.Parameters.AddWithValue("fname", selectedpayername)

                Dim reader As MySqlDataReader = cmd1.ExecuteReader()
                Dim status As String

                If reader.HasRows Then
                    reader.Read()
                    status = reader.GetString("Status")
                    If status = "Paid" Then
                        errorform.errorlabel.Text = selectedpayername + " is already PAID"
                        errorform.Show()
                        Return
                    End If
                End If
                reader.Close()

                Dim datenow As Date = Date.Now.Date.ToString()
                Dim cmd As New MySqlCommand("UPDATE payers SET Status = @status, DatePaid = @datepaid WHERE Status = @status1 AND BillId = @billid AND FullName = @fname;", getConn())
                cmd.Parameters.AddWithValue("@status", "Paid")
                cmd.Parameters.AddWithValue("@datepaid", datenow)
                cmd.Parameters.AddWithValue("@billid", selectedpayerid)
                cmd.Parameters.AddWithValue("@fname", selectedpayername)
                cmd.Parameters.AddWithValue("@status1", "Pending")
                cmd.ExecuteNonQuery()
                payerfname.Text = "No Selected"
                payeramount.Text = "₱00.00"
                payerstatus.Text = "Pending"
                payerdatepaid.Text = "MM/DD/YY"

                balances.setFund(selectedpayerid, classfund)

                transactions.fetchDefaultTransaction(payergridview, selectedpayerid)
                transactions.summarize(transactions.getFirstBillId(selectedpayerid), billnamesummary, billsummarypaid, billsummarynotpaid, billsumurayfund)
                transactions.addbalance(selectedpayerid, selectedpayername)

                selectedpayername = Nothing
                selectedpayerid = Nothing
                'balances.sumBalance(classfund)
            Else
                Return
            End If
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        Finally
            CloseConn()
        End Try
    End Sub

    'redirect to another page
    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        billnamelabel.Text = transactions.getFirstBillName()
        transactions.fetchDefaultTransaction(payergridview)
        transactions.summarize(transactions.getFirstBillId(), billnamesummary, billsummarypaid, billsummarynotpaid, billsumurayfund)
    End Sub

    Public Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        timer.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Public Sub populateChartBill()
        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If

            ' Create a command to select the BillName and Amount columns from the Bills table
            Dim cmd As MySqlCommand = New MySqlCommand("SELECT BillName, Amount FROM bills Where Status = @status", getConn())
            cmd.Parameters.AddWithValue("@status", "Pending")
            ' Create a data adapter and fill a data table with the results of the command
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            da.Fill(dt)
            ' Set the data source of the chart to the data table
            Chart1.DataSource = dt

            ' Set the X and Y values of the chart to the BillName and Amount columns, respectively
            Chart1.Series(0).XValueMember = "BillName"
            Chart1.Series(0).YValueMembers = "Amount"

            ' Set the chart type to pie
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        End Try
    End Sub

    'count the raw bills
    Public Sub getallbillspending()
        Dim count = Nothing
        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If
            Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM bills WHERE STATUS = @status", getConn())
            cmd.Parameters.AddWithValue("@status", "Pending")

            Dim result As Integer = cmd.ExecuteScalar()

            If result = 0 Then
                count = Nothing
            End If
            count = result
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        Finally
            CloseConn()
        End Try

        If count IsNot Nothing Then
            numbills.Text = count
        Else
            numbills.Text = "0"
        End If

    End Sub
    Public Sub getallbillspaid()
        Dim count = Nothing
        Try
            If getConn().state = ConnectionState.Closed Then
                Connect()
            End If
            Dim cmd As New MySqlCommand("select count(*) from bills where status = @status", getConn())
            cmd.Parameters.AddWithValue("@status", "Paid")

            Dim result As Integer = cmd.ExecuteScalar()

            If result = 0 Then
                count = Nothing
            End If
            count = result
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        Finally
            CloseConn()
        End Try

        If count IsNot Nothing Then
            paidbills.Text = count
        Else
            paidbills.Text = "0"
        End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If ListView1.Items.Count = 0 Then
            Dim item As New ListViewItem("No new notification")
            ListView1.Items.Add(item)
        Else
            students.getNotification(ListView1)
            If ListView1.Visible = False Then
                ListView1.Visible = True
            Else
                ListView1.Visible = False
            End If
        End If


    End Sub
    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count > 0 Then
            Dim selected As ListViewItem = ListView1.SelectedItems(0)
            Dim words() As String = selected.Text.Split(" "c)
            Dim sno As String = words(0)
            Try
                If getConn().state = ConnectionState.Closed Then
                    Connect()
                End If
                Dim cmd As New MySqlCommand("UPDATE users SET isApproved = 1 WHERE StudentNo = @sno", getConn())
                cmd.Parameters.AddWithValue("@sno", sno)
                cmd.ExecuteNonQuery()
                CloseConn()
                ListView1.Items.Remove(selected)
            Catch ex As Exception
                errorform.errorlabel.Text = ex.Message
                errorform.Show()
            End Try
        End If
    End Sub

End Class
