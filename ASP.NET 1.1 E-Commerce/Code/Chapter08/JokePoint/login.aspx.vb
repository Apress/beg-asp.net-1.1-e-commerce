Imports System.Web.Security

Public Class login
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents loginMessageLabel As System.Web.UI.WebControls.Label
    Protected WithEvents userNameLabel As System.Web.UI.WebControls.Label
    Protected WithEvents userNameTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents passwordLabel As System.Web.UI.WebControls.Label
    Protected WithEvents passwordTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents persistCheckBox As System.Web.UI.WebControls.CheckBox
    Protected WithEvents loginButton As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loginMessageLabel.Text = "Hello! Please enter the magic formula:"
    End Sub

    Private Sub loginButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginButton.Click
        ' Store the entered user name in a variable
        Dim user As String = userNameTextBox.Text
        ' Store the entered password in a variable
        Dim pass As String = passwordTextBox.Text
        ' This variable is True when persistCheckBox is checked
        Dim persist As Boolean = persistCheckBox.Checked

        ' Check if the (user, pass) combination exists
        If FormsAuthentication.Authenticate(user, pass) Then
            ' Attempt to load the originally solicited page using
            ' the supplied credentials
            FormsAuthentication.RedirectFromLoginPage(user, persist)
        End If
    End Sub
End Class
