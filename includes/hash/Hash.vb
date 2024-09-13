Imports System.Security.Cryptography

Public Class Hash
    'hashing password
    Public Function SHA1Hash(ByVal strText As String) As String
        Dim objSHA1 As New SHA1CryptoServiceProvider
        Dim arrData() As Byte
        Dim arrHash() As Byte

        'Convert the input string to a byte array
        arrData = System.Text.Encoding.ASCII.GetBytes(strText)

        'Compute the hash
        arrHash = objSHA1.ComputeHash(arrData)

        'Return the hash as a hexadecimal string
        SHA1Hash = BitConverter.ToString(arrHash)
        SHA1Hash = SHA1Hash.Replace("-", "")
    End Function
End Class
