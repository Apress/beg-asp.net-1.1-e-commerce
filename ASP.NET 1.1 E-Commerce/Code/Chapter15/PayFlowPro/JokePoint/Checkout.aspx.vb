Imports System.Data.SqlClient
Imports SecurityLib
Imports System.Text
Imports CommerceLib

Public Class Checkout
  Inherits System.Web.UI.Page
  Private customerID As Integer

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents txtUserName As System.Web.UI.WebControls.Label
  Protected WithEvents logOutButton As System.Web.UI.WebControls.Button
  Protected WithEvents Label1 As System.Web.UI.WebControls.Label
  Protected WithEvents grid As System.Web.UI.WebControls.DataGrid
  Protected WithEvents totalAmountLabel As System.Web.UI.WebControls.Label
  Protected WithEvents lblCreditCardNote As System.Web.UI.WebControls.Label
  Protected WithEvents lblAddress As System.Web.UI.WebControls.Label
  Protected WithEvents changeDetailsButton As System.Web.UI.WebControls.Button
  Protected WithEvents addCreditCardButton As System.Web.UI.WebControls.Button
  Protected WithEvents addAddressButton As System.Web.UI.WebControls.Button
  Protected WithEvents placeOrderButton As System.Web.UI.WebControls.Button
  Protected WithEvents cancelOrderButton As System.Web.UI.WebControls.Button
  Protected WithEvents pageContentsCell As System.Web.UI.HtmlControls.HtmlTableCell
  Protected WithEvents viewCartButton As System.Web.UI.WebControls.ImageButton

  'NOTE: The following placeholder declaration is required by the Web Form Designer.
  'Do not delete or move it.
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: This method call is required by the Web Form Designer
    'Do not modify it using the code editor.
    InitializeComponent()
  End Sub

#End Region

  Private Sub Page_Load(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles MyBase.Load
    If Not Page.IsPostBack Then
      If Context.Session("JokePoint_CustomerID") Is Nothing Then
        Response.Redirect("CustomerLogin.aspx?ReturnPage=Checkout.aspx")
      Else
        customerID = _
            Convert.ToInt32(Context.Session("JokePoint_CustomerID"))
      End If
      BindShoppingCart()
      BindUserDetails()
    Else
      customerID = Convert.ToInt32(Context.Session("JokePoint_CustomerID"))
    End If
  End Sub

  Private Sub BindShoppingCart()
    ' Populate the data grid and set its DataKey field
    Dim cart As New ShoppingCart
    grid.DataSource = cart.GetProducts
    grid.DataKeyField = "ProductID"
    grid.DataBind()

    ' Set the total amount label using the Currency format
    totalAmountLabel.Text = String.Format("{0:c}", cart.GetTotalAmount())
  End Sub

  Private Sub BindUserDetails()
    ' Create Instance of Connection and Command Object
    Dim connection As SqlConnection = _
        New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
    Dim command As SqlCommand = New SqlCommand("GetCustomer", connection)
    command.CommandType = CommandType.StoredProcedure
    command.Parameters.Add("@CustomerID", customerID)

    ' get customer details
    connection.Open()
    Dim customerReader As SqlDataReader = command.ExecuteReader()
    If customerReader.Read = False Then
      Response.Redirect("CustomerLogin.aspx?returnPage=Checkout.aspx")
    End If

    ' set customer data display
    txtUserName.Text = customerReader("Name")
    If customerReader("CreditCard").GetType() Is GetType(DBNull) Then
      lblCreditCardNote.Text = "No credit card details stored."
      placeOrderButton.Visible = False
    Else
      Dim cardDetails As SecureCard = _
          New SecureCard(customerReader("CreditCard"))
      lblCreditCardNote.Text = "Credit card to use: " & cardDetails.CardType _
          & ", Card number: " & cardDetails.CardNumberX()
      addCreditCardButton.Text = "Change Credit Card"
    End If
    If customerReader("Address1").GetType() Is GetType(DBNull) Then
      lblAddress.Text = "Shipping address required to place order."
      placeOrderButton.Visible = False
    Else
      Dim addressBuilder As StringBuilder = New StringBuilder
      addressBuilder.Append("Shipping address:<br><br>")
      addressBuilder.Append(customerReader("Address1"))
      addressBuilder.Append("<br>")
      If Not customerReader("Address2").GetType() Is GetType(DBNull) Then
        If customerReader("Address2") <> "" Then
          addressBuilder.Append(customerReader("Address2"))
          addressBuilder.Append("<br>")
        End If
      End If
      addressBuilder.Append(customerReader("City"))
      addressBuilder.Append("<br>")
      addressBuilder.Append(customerReader("Region"))
      addressBuilder.Append("<br>")
      addressBuilder.Append(customerReader("PostalCode"))
      addressBuilder.Append("<br>")
      addressBuilder.Append(customerReader("Country"))
      lblAddress.Text = addressBuilder.ToString()
      addAddressButton.Text = "Change Address"
    End If
    connection.Close()
  End Sub

  Private Sub addCreditCardButton_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles addCreditCardButton.Click
    Response.Redirect("CustomerCreditCard.aspx?ReturnPage=Checkout.aspx")
  End Sub

  Private Sub addAddressButton_Click(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles addAddressButton.Click
    Response.Redirect("CustomerAddress.aspx?ReturnPage=Checkout.aspx")
  End Sub

  Private Sub changeDetailsButton_Click(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles changeDetailsButton.Click
    Response.Redirect("CustomerEdit.aspx?ReturnPage=Checkout.aspx")
  End Sub

  Private Sub logOutButton_Click(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles logOutButton.Click
    Context.Session("JokePoint_CustomerID") = Nothing
    Response.Redirect("default.aspx")
  End Sub

  Private Sub cancelOrderButton_Click(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cancelOrderButton.Click
    Response.Redirect("default.aspx")
  End Sub

  Private Sub placeOrderButton_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles placeOrderButton.Click
    ' The Shopping Cart object
    Dim cart As New ShoppingCart

    ' Create the order and store the order ID

    Dim orderId As Integer = cart.CreateOrder(customerID)

    ' Get configuration for order processor
    Dim processorConfiguration As OrderProcessorConfiguration = _
       New OrderProcessorConfiguration( _
          ConfigurationSettings.AppSettings("ConnectionString"), _
          ConfigurationSettings.AppSettings("MailServer"), _
          ConfigurationSettings.AppSettings("AdminEmail"), _
          ConfigurationSettings.AppSettings("CustomerServiceEmail"), _
          ConfigurationSettings.AppSettings("OrderProcessorEmail"), _
          ConfigurationSettings.AppSettings("SupplierEmail"), _
          ConfigurationSettings.AppSettings("PayFlowProUser"), _
          ConfigurationSettings.AppSettings("PayFlowProVendor"), _
          ConfigurationSettings.AppSettings("PayFlowProPartner"), _
          ConfigurationSettings.AppSettings("PayFlowProPwd"), _
          ConfigurationSettings.AppSettings("PayFlowProHost"))

    ' Process order
    Try
      Dim processor As OrderProcessor = New OrderProcessor
      processor.Process(orderId, processorConfiguration)
    Catch ex As OrderProcessorException
      ' If an error occurs head to an error page
      Response.Redirect("OrderError.aspx?message=" & ex.Message)
    End Try

    ' On success head to an order successful page
    Response.Redirect("OrderDone.aspx")
  End Sub

End Class
