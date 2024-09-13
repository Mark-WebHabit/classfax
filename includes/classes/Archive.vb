Imports MySql.Data.MySqlClient
Public Class Archive
    Public Sub setARCHIVE()
        If getConn().State = ConnectionState.Closed Then
            Connect()
        End If
        Try
            Dim cmd As New MySqlCommand("UPDATE bills SET Archive = NOT ARCHIVE WHERE BillId = @id;", getConn())
            cmd.Parameters.AddWithValue("@id", unknownInt)

            Dim row = cmd.ExecuteNonQuery()

            If Not row > 0 Then
                Throw New Exception("Select a bill to Archive")
            End If
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        Finally
            CloseConn()
        End Try

    End Sub
End Class
