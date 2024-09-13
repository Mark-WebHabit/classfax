Imports System.Net.Mail
Imports System.Net
Public Class Email
    Dim utils As New Utilities
    Public Function EmailVerify(ByVal studentType As String, ByVal userEmail As String, ByVal studentNo As String, ByVal token As String, ByVal fname As String) As Boolean
        Try
            Dim verificationLink As String = utils.GenerateVerificationLink(studentNo, token)
            Dim mail As New MailMessage
            Dim smtpServer As New SmtpClient("smtp.gmail.com")
            mail.From = New MailAddress("classfax101@gmail.com")
            mail.To.Add(userEmail)
            mail.Subject = "Registry Verification"

            mail.Body = String.Format("Click the link below to approve the registration of: {0}{1} as {2}{0} Student Number: {3}{0} Registration ID: {4}{0}{5}", Environment.NewLine, fname, studentType, studentNo, token, verificationLink)

            smtpServer.Port = 587
            smtpServer.Credentials = New System.Net.NetworkCredential("classfax101@gmail.com", "csurhrjvriukitnk")
            smtpServer.EnableSsl = True
            smtpServer.Send(mail)
            MsgBox("An Email was sent to your Account, Registration Is Ongoing, Please wait until the Admin approve your Registration")
            Return True
        Catch ex As Exception
            errorform.errorlabel.Text = ex.Message + vbCritical
            errorform.Show()
            Return False
        End Try


    End Function
End Class
