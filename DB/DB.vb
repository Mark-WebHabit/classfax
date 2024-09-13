Imports System.Configuration
Imports MySql.Data.MySqlClient
Module DB
    'Dim conn As New MySqlConnection("server=127.0.0.1;user=root;password=orewaluffy;database=test;")
    Dim query As String = System.Configuration.ConfigurationManager.ConnectionStrings("connection_string").ConnectionString
    Dim conn As New MySqlConnection(query)


    Public Sub connect()
        'open the connection then handle the potential error
        Dim retries As Integer = 0
        While conn.State <> ConnectionState.Open AndAlso retries < 3
            Try
                conn.Open()
            Catch ex As Exception
                'wait for 1 second before retrying
                System.Threading.Thread.Sleep(1000)
                retries += 1
            End Try
        End While

        If conn.State <> ConnectionState.Open Then
            Throw New Exception("failed to open database connection")
        End If
    End Sub

    Public Sub CloseConn()
        Try
            If (conn.State = ConnectionState.Open) Then
                conn.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function getConn()
        Return conn
    End Function
End Module