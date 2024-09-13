
Imports System.Text.RegularExpressions

Public Class Utilities
    Public Sub closeApp()
        Application.Exit()
    End Sub

    'handle page redirection, depending on the section clicked
    Public Sub redirectPage(currentPanel As String, ParamArray panels() As Object)
        For Each panel As Object In panels
            If (panel.Name <> currentPanel) Then
                panel.Visible = False
            Else
                panel.Visible = True
            End If
        Next
    End Sub

    'inherits the parent action passed to the child
    Public Sub AddClickHandlerToChildControls(ByVal ctrl As Control, panel As EventHandler)
        For Each c As Control In ctrl.Controls
            ' Add Click event handler to child controls of the panel
            AddHandler c.Click, panel
            If c.HasChildren Then
                ' If the child control has more child controls, add handlers to them recursively
                AddClickHandlerToChildControls(c, panel)
            End If
        Next
    End Sub

    'handle hover events
    Public Sub ChangePanelStyle(panel As Panel, page As Object, currentPage As String)
        Dim Cpage As String = currentPage
        Dim Opage As Object = page
        ' Set the initial style
        panel.BorderStyle = BorderStyle.FixedSingle
        panel.ForeColor = Color.Black
        ' Handle the MouseEnter event to change the style when the mouse enters the panel or its child controls
        AddHandler panel.MouseEnter, Sub()
                                         If panel.ClientRectangle.Contains(panel.PointToClient(Control.MousePosition)) Then
                                             panel.BackColor = Color.FromArgb(20, 20, 20)
                                             panel.BorderStyle = BorderStyle.Fixed3D
                                             panel.ForeColor = Color.White
                                         End If
                                     End Sub

        ' Handle the MouseLeave event to return the panel to its original style when the mouse leaves
        AddHandler panel.MouseLeave, Sub()
                                         panel.BackColor = Color.FromArgb(128, 255, 255)
                                         panel.BorderStyle = BorderStyle.FixedSingle
                                         panel.ForeColor = Color.Black
                                     End Sub
    End Sub

    'generate a token that is unique that will later be used in email verification
    Public Function GenerateTokenId() As String
        Dim tokenId As Guid = Guid.NewGuid()
        Return tokenId.ToString()
    End Function

    'generate a link that will be the verification module/mean for the registration
    Public Function GenerateVerificationLink(ByVal studentno As String, ByVal token As String) As String
        Dim baseUrl As String = "https://example.com/verify"
        Dim queryParams As String = String.Format("?id={0}&token={1}", studentno, token)
        Return baseUrl & queryParams
    End Function

    'validate email
    Public Function ValidateEmail(ByVal email As String) As Boolean
        ' Use a regular expression pattern to match against a valid email address
        Dim pattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
        Dim regex As New Regex(pattern)

        ' Check if the email matches the pattern
        If regex.IsMatch(email) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub AddClickHandlerToChildControlsMouseEnter(ByVal ctrl As Control, panel As EventHandler)
        For Each c As Control In ctrl.Controls
            ' Add Click event handler to child controls of the panel
            AddHandler c.MouseEnter, panel
            If c.HasChildren Then
                ' If the child control has more child controls, add handlers to them recursively
                AddClickHandlerToChildControls(c, panel)
            End If
        Next
    End Sub


End Class
