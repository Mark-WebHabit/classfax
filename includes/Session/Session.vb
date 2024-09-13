Module Session
    Private CurrentUser As String = ""
    Private UserType As String = "Student"

    Public Function getCurrentUser()
        Return CurrentUser.ToUpper()
    End Function

    Public Function getUserType()
        Return UserType
    End Function

    Public Sub setCurrentUser(ByVal user As String)
        CurrentUser = user
    End Sub

    Public Sub setUserType(ByVal type As String)
        UserType = type
    End Sub
End Module
