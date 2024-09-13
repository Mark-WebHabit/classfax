Imports MySql.Data.MySqlClient
Public Class balance
    'add the price paid to the old value of fund
    Public Sub displayfund(ByVal classfund As Label)
        Dim fundstring = getFund().ToString()
        If fundstring.Length = 1 Then
            fundstring = "₱0" + fundstring + ".00"
        Else
            fundstring = "₱" + fundstring + ".00"
        End If
        classfund.Text = fundstring
    End Sub
    Public Sub setFund(billid As String, classfund As Label)
        Try
            Dim oldvalue = getFund()
            Dim fund = getPrice(billid)
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If
            Dim cmd As New MySqlCommand("UPDATE fund SET fund = @fund WHERE id = 3;", getConn())
            cmd.Parameters.AddWithValue("@fund", oldvalue + fund)
            cmd.ExecuteNonQuery()
            displayfund(classfund)
            CloseConn()
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        End Try

    End Sub

    Public Sub deductfund(amount As Integer, classfund As Label)
        Dim oldvalue = getFund()
        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If
            Dim cmd As New MySqlCommand("UPDATE fund SET fund = @fund WHERE id = 3;", getConn())
            cmd.Parameters.AddWithValue("@fund", oldvalue - amount)
            cmd.ExecuteNonQuery()

            displayfund(classfund)
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        End Try
    End Sub

    Public Function getFund()
        Dim fund As Integer = 0
        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If
            Dim cmd As New MySqlCommand("SELECT fund FROM fund WHERE id = 3;", getConn())
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                fund = reader.GetInt32("fund")
            End While
            reader.Close()
            CloseConn()
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        End Try

        Return fund
    End Function

    Private Function getPrice(ByVal billid As String)
        Dim price As Integer = 0
        Try
            If getConn().State = ConnectionState.Closed Then
                Connect()
            End If
            Dim cmd As New MySqlCommand("select Price from payers where billid = @billid LIMIT 1", getConn())
            cmd.Parameters.AddWithValue("@billid", billid)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                price = Convert.ToInt32(reader("Price"))
            End If
            reader.Close()
            CloseConn()
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message
            errorform.Show()
        End Try

        Return price
    End Function

End Class
