Imports System.Data.SqlClient
Imports SecurityLib

Public Class CustomerLogin
  Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents Label1 As System.Web.UI.WebControls.Label
  Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
  Protected WithEvents Label2 As System.Web.UI.WebControls.Label
  Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
  Protected WithEvents btnLogin As System.Web.UI.WebControls.Button
  Protected WithEvents lblLoginMsg As System.Web.UI.WebControls.Label
  Protected WithEvents btnRegister As System.Web.UI.WebControls.Button

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
    'Put user code to initialize the page here
  End Sub

  Private Sub btnLogin_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles btnLogin.Click
    ' create instance of Connection and Command objects
    Dim connection As SqlConnection = _
        New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
    Dim command As SqlCommand = _
        New SqlCommand("GetCustomerIDPassword", connection)
    command.CommandType = CommandType.StoredProcedure
    command.Parameters.Add("@Email", txtEmail.Text)

    ' execute command, checking for a user with the e-mail entered
    connection.Open()
    Dim customerReader As SqlDataReader = command.ExecuteReader()
    If customerReader.Read = False Then
      ' display error, close connection, and exit method
      lblLoginMsg.Text = "Unrecognized Email."
      connection.Close()
      Return
    End If

    ' extract user information and close connection
    Dim customerID As Integer = customerReader("CustomerID")
    Dim hashedPassword As String = customerReader("Password")
    connection.Close()

    ' check password
    If PasswordHasher.Hash(txtPassword.Text) <> hashedPassword Then
      ' display error
      lblLoginMsg.Text = "Unrecognized password."
    Else
      ' set session variable, storing customer ID for later retrieval
      Context.Session("JokePoint_CustomerID") = customerID

      ' redirect user
      If Not Context.Request.QueryString("ReturnPage") Is Nothing Then
        Response.Redirect(Context.Request.QueryString("ReturnPage"))
      Else
        Response.Redirect("default.aspx")
      End If
    End If
  End Sub

  Private Sub btnRegister_Click(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles btnRegister.Click
    ' redirect user
    If Not Context.Request.QueryString("ReturnPage") Is Nothing Then
      Response.Redirect("CustomerNew.aspx?ReturnPage=" _
          & Context.Request.QueryString("ReturnPage"))
    Else
      Response.Redirect("CustomerNew.aspx")
    End If
  End Sub

End Class
