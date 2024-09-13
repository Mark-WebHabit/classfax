Imports System.Net.Mail
Imports System.Net
Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Try
        '    Dim mail As New MailMessage
        '    Dim smtpServer As New SmtpClient("smtp.gmail.com")
        '    mail.From = New MailAddress("classfax101@gmail.com")
        '    mail.To.Add("markbobis173@gmail.com")
        '    mail.Subject = "testing"
        '    mail.Body = "working"

        '    smtpServer.Port = 587
        '    smtpServer.Credentials = New System.Net.NetworkCredential("classfax101@gmail.com", "ClassFaXAdmin")
        '    smtpServer.EnableSsl = True
        '    smtpServer.Send(mail)
        '    MsgBox("sucess: ", vbInformation)
        'Catch ex As Exception
        '    MsgBox(ex.Message, vbCritical)
        'End Try

        ' create SmtpClient object and set its properties
        Try
            Dim smtp As New SmtpClient("smtp.gmail.com", 587)
            smtp.Credentials = New NetworkCredential("classfax101@gmail.com", "csurhrjvriukitnk")

            smtp.EnableSsl = True

            ' create MailMessage object and set its properties
            Dim message As New MailMessage()
            message.From = New MailAddress("classfax101@gmail.com")
            message.To.Add("m4rkluiz@gmail.com")
            message.Subject = "Test email"
            message.Body = "This is a test email."

            ' send the email
            smtp.Send(message)

            MessageBox.Show("success")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
End Class