Imports System.Data.SqlClient

Public Class CustomerAddress
  Inherits System.Web.UI.Page
  Protected WithEvents Label3 As System.Web.UI.WebControls.Label
  Protected WithEvents txtAddress1 As System.Web.UI.WebControls.TextBox
  Protected WithEvents validateAddress1 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Label1 As System.Web.UI.WebControls.Label
  Protected WithEvents txtAddress2 As System.Web.UI.WebControls.TextBox
  Protected WithEvents Label2 As System.Web.UI.WebControls.Label
  Protected WithEvents txtCity As System.Web.UI.WebControls.TextBox
  Protected WithEvents validateCity As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Label4 As System.Web.UI.WebControls.Label
  Protected WithEvents txtRegion As System.Web.UI.WebControls.TextBox
  Protected WithEvents validateRegion As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Label5 As System.Web.UI.WebControls.Label
  Protected WithEvents txtPostalCode As System.Web.UI.WebControls.TextBox
  Protected WithEvents validatePostalCode As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Label6 As System.Web.UI.WebControls.Label
  Protected WithEvents txtCountry As System.Web.UI.WebControls.TextBox
  Protected WithEvents validateCountry As System.Web.UI.WebControls.RequiredFieldValidator
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
        Response.Redirect("CustomerLogin.aspx?returnPage=CustomerAddress.aspx")
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
      If Not customerReader("Address1").GetType() Is GetType(DBNull) Then
        txtAddress1.Text = customerReader("Address1")
        txtAddress2.Text = customerReader("Address2")
        txtCity.Text = customerReader("City")
        txtRegion.Text = customerReader("Region")
        txtPostalCode.Text = customerReader("PostalCode")
        txtCountry.Text = customerReader("Country")
      End If
      connection.Close()
    End If
  End Sub

  Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
    ' Create Instance of Connection and Command Object
    Dim connection As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
    Dim command As SqlCommand = New SqlCommand("UpdateAddress", connection)
    command.CommandType = CommandType.StoredProcedure
    command.Parameters.Add("@CustomerID", Convert.ToInt32(Context.Session("JokePoint_CustomerID")))
    command.Parameters.Add("@Address1", txtAddress1.Text)
    command.Parameters.Add("@Address2", txtAddress2.Text)
    command.Parameters.Add("@City", txtCity.Text)
    command.Parameters.Add("@Region", txtRegion.Text)
    command.Parameters.Add("@PostalCode", txtPostalCode.Text)
    command.Parameters.Add("@Country", txtCountry.Text)

    ' update address
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
