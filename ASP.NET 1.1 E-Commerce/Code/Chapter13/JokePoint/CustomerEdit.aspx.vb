Imports System.Data.SqlClient
Imports SecurityLib

Public Class CustomerEdit
  Inherits System.Web.UI.Page
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
  Protected WithEvents cancelButton As System.Web.UI.WebControls.Button
  Protected WithEvents lblMsg As System.Web.UI.WebControls.Label

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: This method call is required by the Web Form Designer
    'Do not modify it using the code editor.
    InitializeComponent()
  End Sub

#End Region

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If Not Page.IsPostBack Then
      If Context.Session("JokePoint_CustomerID") Is Nothing Then
        Response.Redirect("CustomerLogin.aspx?returnPage=CustomerEdit.aspx")
      End If
      ' Create Instance of Connection and Command Object
      Dim connection As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
      Dim command As SqlCommand = New SqlCommand("GetCustomer", connection)
      command.CommandType = CommandType.StoredProcedure
      command.Parameters.Add("@CustomerID", Context.Session("JokePoint_CustomerID"))

      ' extract existing customer details
      connection.Open()
      Dim customerReader As SqlDataReader = command.ExecuteReader()
      customerReader.Read()
      txtUserName.Text = customerReader("Name")
      txtEmail.Text = customerReader("Email")
      txtPhone.Text = customerReader("Phone")
      connection.Close()
    End If
  End Sub

  Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
    ' Create Instance of Connection and Command Object, check for existing user
    Dim connection As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
    Dim command As SqlCommand = New SqlCommand("GetCustomerIDPassword", connection)
    command.CommandType = CommandType.StoredProcedure
    command.Parameters.Add("@Email", txtEmail.Text)

    ' ensure that the new e-mail address doesn't match a reader other than the current one
    connection.Open()
    Dim customerReader As SqlDataReader = command.ExecuteReader()
    If customerReader.Read = True Then
      If customerReader("CustomerID") <> Context.Session("JokePoint_CustomerID") Then
        lblMsg.Text = "A user with that Email address already exists."
        connection.Close()
        Return
      End If
    End If
    connection.Close()

    ' Update user
    command = New SqlCommand("UpdateCustomerDetails", connection)
    command.CommandType = CommandType.StoredProcedure
    command.Parameters.Add("@CustomerID", Context.Session("JokePoint_CustomerID"))
    command.Parameters.Add("@Name", txtUserName.Text)
    command.Parameters.Add("@Email", txtEmail.Text)
    command.Parameters.Add("@Password", PasswordHasher.Hash(txtPassword.Text))
    command.Parameters.Add("@Phone", txtPhone.Text)
    connection.Open()
    command.ExecuteNonQuery()
    connection.Close()

    ' redirect user
    If Not Context.Request.QueryString("ReturnPage") Is Nothing Then
      Response.Redirect(Context.Request.QueryString("ReturnPage"))
    Else
      Response.Redirect("default.aspx")
    End If
  End Sub

  Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click
    ' redirect user
    If Not Context.Request.QueryString("ReturnPage") Is Nothing Then
      Response.Redirect(Context.Request.QueryString("ReturnPage"))
    Else
      Response.Redirect("default.aspx")
    End If
  End Sub
End Class
