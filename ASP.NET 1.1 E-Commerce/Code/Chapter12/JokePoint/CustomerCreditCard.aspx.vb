Imports System.Data.SqlClient
Imports SecurityLib

Public Class CustomerCreditCard
  Inherits System.Web.UI.Page
  Protected WithEvents Label3 As System.Web.UI.WebControls.Label
  Protected WithEvents txtCardHolder As System.Web.UI.WebControls.TextBox
  Protected WithEvents validateCardHolder As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Label1 As System.Web.UI.WebControls.Label
  Protected WithEvents txtCardNumber As System.Web.UI.WebControls.TextBox
  Protected WithEvents validateCardNumber As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Label2 As System.Web.UI.WebControls.Label
  Protected WithEvents txtExpDate As System.Web.UI.WebControls.TextBox
  Protected WithEvents validateExpDate As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Label4 As System.Web.UI.WebControls.Label
  Protected WithEvents txtIssueDate As System.Web.UI.WebControls.TextBox
  Protected WithEvents Label5 As System.Web.UI.WebControls.Label
  Protected WithEvents txtIssueNumber As System.Web.UI.WebControls.TextBox
  Protected WithEvents Label6 As System.Web.UI.WebControls.Label
  Protected WithEvents txtCardType As System.Web.UI.WebControls.DropDownList
  Protected WithEvents validateCardType As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents cancelButton As System.Web.UI.WebControls.Button
  Protected WithEvents btnConfirm As System.Web.UI.WebControls.Button

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
        Response.Redirect("CustomerLogin.aspx?returnPage=CustomerCreditCard.aspx")
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

      ' decrypt credit card information if any is present
      If Not customerReader("CreditCard").GetType() Is GetType(DBNull) Then
        Dim cardDetails As SecureCard = New SecureCard(customerReader("CreditCard"))
        txtCardHolder.Text = cardDetails.CardHolder
        txtCardNumber.Text = cardDetails.CardNumber
        txtExpDate.Text = cardDetails.ExpiryDate
        txtIssueDate.Text = cardDetails.IssueDate
        txtIssueNumber.Text = cardDetails.IssueNumber
        Dim item As ListItem
        Dim index As Integer
        For Each item In txtCardType.Items
          If item.Text = cardDetails.CardType Then
            item.Selected = True
          End If
        Next
      End If
      connection.Close()
    End If
  End Sub

  Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
    ' initialize SecureCard instance for card detail encryption
    Dim cardDetails As SecureCard = New SecureCard(txtCardHolder.Text, txtCardNumber.Text, txtIssueDate.Text, txtExpDate.Text, txtIssueNumber.Text, txtCardType.SelectedItem.Text)
    ' Create Instance of Connection and Command Object
    Dim connection As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
    Dim command As SqlCommand = New SqlCommand("UpdateCreditCard", connection)
    command.CommandType = CommandType.StoredProcedure
    command.Parameters.Add("@CustomerID", Convert.ToInt32(Context.Session("JokePoint_CustomerID")))
    command.Parameters.Add("@CreditCard", cardDetails.EncryptedData)

    ' update credit card details, using encrypted data
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
