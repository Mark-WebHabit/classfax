Imports MySql.Data.MySqlClient
Public Class Students
    Public Sub fetch(ByVal student_list_grid As DataGridView, ByVal studentCount As Integer, ByVal student_count As Label)
        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If

            Dim cmd As New MySqlCommand("SELECT FullName, StudentNo, Type FROM users WHERE isApproved = 1 ORDER BY FullName ASC;", getConn())
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            student_list_grid.DataSource = dt

            ' Count the number of rows returned by the query
            Dim countCmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE isApproved = 1;", getConn())
            studentCount = countCmd.ExecuteScalar()

            student_count.Text = studentCount.ToString() + " Student(s)"

        Catch ex As Exception
            errorform.errorlabel.Text = "An error occurred while fetching data: " + ex.Message
            errorform.Show()
            Return
        Finally
            CloseConn()
        End Try
    End Sub

    Public Sub getNotification(ByVal listview As ListView)
        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If

            Dim query As String = "SELECT * FROM users WHERE isApproved = 0;"
            Dim cmd As New MySqlCommand(query, getConn())
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim fname = reader.GetString("FullName")
                Dim sno = reader.GetString("StudentNo")
                Dim item As New ListViewItem(sno.ToUpper() & " " & fname.ToUpper & " registering as ADMIN")
                listview.Items.Add(item)
            End While
            reader.Close()
            CloseConn()
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        End Try
    End Sub

End Class
