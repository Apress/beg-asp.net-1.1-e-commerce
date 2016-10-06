Imports System.Data.SqlClient
Imports SecurityLib

Public Class CustomerNew
  Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents Label3 As System.Web.UI.WebControls.Label
  Protected WithEvents txtUserName As System.Web.UI.WebControls.TextBox
  Protected WithEvents validateUserName As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Label1 As System.Web.UI.WebControls.Label
  Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
  Protected WithEvents validateEmail As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Label2 As System.Web.UI.WebControls.Label
  Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
  Protected WithEvents validatePassword As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Label4 As System.Web.UI.WebControls.Label
  Protected WithEvents txtPasswordConfirm As System.Web.UI.WebControls.TextBox
  Protected WithEvents validatePasswordReEntry As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents validatePasswordMatch As System.Web.UI.WebControls.CompareValidator
  Protected WithEvents Label5 As System.Web.UI.WebControls.Label
  Protected WithEvents txtPhone As System.Web.UI.WebControls.TextBox
  Protected WithEvents validatePhone As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents btnConfirm As System.Web.UI.WebControls.Button
  Protected WithEvents lblMsg As System.Web.UI.WebControls.Label

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

  Private Sub btnConfirm_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles btnConfirm.Click
    ' Create Instance of Connection and Command Object, check for existing user
    Dim connection As SqlConnection = _
        New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
    Dim command As SqlCommand = _
        New SqlCommand("GetCustomerIDPassword", connection)
    command.CommandType = CommandType.StoredProcedure
    command.Parameters.Add("@Email", txtEmail.Text)

    connection.Open()
    Dim customerReader As SqlDataReader = command.ExecuteReader()
    If customerReader.Read = True Then
      lblMsg.Text = "A user with that Email address already exists."
      connection.Close()
      Return
    End If
    connection.Close()
    ' Add user
    command = New SqlCommand("AddCustomer", connection)
    command.CommandType = CommandType.StoredProcedure
    command.Parameters.Add("@Name", txtUserName.Text)
    command.Parameters.Add("@Email", txtEmail.Text)
    command.Parameters.Add("@Password", PasswordHasher.Hash(txtPassword.Text))
    command.Parameters.Add("@Phone", txtPhone.Text)
    Dim customerID As Integer
    connection.Open()
    customerID = command.ExecuteScalar()
    connection.Close()
    Context.Session("JokePoint_CustomerID") = customerID
    If Not Context.Request.QueryString("ReturnPage") Is Nothing Then
      Response.Redirect(Context.Request.QueryString("ReturnPage"))
    Else
      Response.Redirect("default.aspx")
    End If
  End Sub

End Class
