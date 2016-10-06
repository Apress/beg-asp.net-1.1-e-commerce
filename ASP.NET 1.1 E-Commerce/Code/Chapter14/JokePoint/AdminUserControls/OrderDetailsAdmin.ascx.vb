Imports System.Data
Imports System.Data.SqlClient
Imports CommerceLib

Public MustInherit Class OrderDetailsAdmin
  Inherits System.Web.UI.UserControl
  Protected WithEvents Label1 As System.Web.UI.WebControls.Label
  Protected WithEvents Label2 As System.Web.UI.WebControls.Label
  Protected WithEvents Label4 As System.Web.UI.WebControls.Label
  Protected WithEvents Label5 As System.Web.UI.WebControls.Label
  Protected WithEvents Label6 As System.Web.UI.WebControls.Label
  Protected WithEvents Label7 As System.Web.UI.WebControls.Label
  Protected WithEvents Label8 As System.Web.UI.WebControls.Label
  Protected WithEvents Label11 As System.Web.UI.WebControls.Label
  Protected WithEvents orderIdTextBox As System.Web.UI.WebControls.TextBox
  Protected WithEvents dateCreatedTextBox As System.Web.UI.WebControls.TextBox
  Protected WithEvents dateShippedTextBox As System.Web.UI.WebControls.TextBox
  Protected WithEvents statusTextBox As System.Web.UI.WebControls.TextBox
  Protected WithEvents authCodeTextBox As System.Web.UI.WebControls.TextBox
  Protected WithEvents referenceTextBox As System.Web.UI.WebControls.TextBox
  Protected WithEvents processButton As System.Web.UI.WebControls.Button
  Protected WithEvents customerGrid As System.Web.UI.WebControls.DataGrid
  Protected WithEvents Label3 As System.Web.UI.WebControls.Label
  Protected WithEvents auditGrid As System.Web.UI.WebControls.DataGrid
  Protected WithEvents orderDetailsGrid As System.Web.UI.WebControls.DataGrid
  Protected WithEvents grid As System.Web.UI.WebControls.DataGrid

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
            ' Update information in all controls
            PopulateControls()
        End If
    End Sub

    Private Sub PopulateControls()
        ' Create the OrderManager object which has the GetOrderDetails method
        Dim om As New OrderManager

        ' Get orderID from request parameters
        Dim orderID As Integer = Convert.ToInt32(Request.Params("OrderID"))

        ' The Order information is extracted using om.GetOrder
        Dim orderReader As SqlDataReader = om.GetOrder(orderID)

        If Not orderReader.Read() Then
            ' no data to display
            Return
        End If

        ' Populate the text boxes with order information
        orderIdTextBox.Text = orderReader("OrderID")
        dateCreatedTextBox.Text = orderReader("DateCreated")
        If Not orderReader("DateShipped").GetType() Is GetType(DBNull) Then
            dateShippedTextBox.Text = orderReader("DateShipped")
        End If
        statusTextBox.Text = orderReader("Description")
        If Not orderReader("AuthCode").GetType() Is GetType(DBNull) Then
            authCodeTextBox.Text = orderReader("AuthCode")
            referenceTextBox.Text = orderReader("Reference")
        End If

        ' Name or hide Process button
        If orderReader("Status") = 3 Then
            processButton.Text = "Confirm Stock"
        ElseIf orderReader("Status") = 6 Then
            processButton.Text = "Confirm Shipment"
        Else
            processButton.Visible = False
        End If

        ' close reader
        orderReader.Close()

        ' Fill the data grid with orderdetails
        orderDetailsGrid.DataSource = om.GetOrderDetails(orderID)
        orderDetailsGrid.DataKeyField = "OrderID"
        orderDetailsGrid.DataBind()

        ' Get full customer details
        customerGrid.DataSource = om.GetCustomerByOrderID(orderID)
        customerGrid.DataBind()

        ' Fill the audit trail with data
        auditGrid.DataSource = om.GetAuditTrail(orderID)
        auditGrid.DataKeyField = "DateStamp"
        auditGrid.DataBind()
    End Sub

    Private Sub processButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles processButton.Click
        ' Get orderID from request parameters
        Dim orderID As Integer = Convert.ToInt32(Request.Params("OrderID"))

        ' Get configuration for order processor
        Dim processorConfiguration As OrderProcessorConfiguration = _
           New OrderProcessorConfiguration( _
              ConfigurationSettings.AppSettings("ConnectionString"), _
              ConfigurationSettings.AppSettings("MailServer"), _
              ConfigurationSettings.AppSettings("AdminEmail"), _
              ConfigurationSettings.AppSettings("CustomerServiceEmail"), _
              ConfigurationSettings.AppSettings("OrderProcessorEmail"), _
              ConfigurationSettings.AppSettings("SupplierEmail"))

        ' Process order, ignore errors as they will be apparent when
        ' nothing changes!
        Try
            Dim processor As OrderProcessor = New OrderProcessor
            processor.Process(orderID, processorConfiguration)
        Catch ex As OrderProcessorException
            ' If an error occurs head to an error page
        End Try

        Response.Redirect("ordersAdmin.aspx?OrderID=" & orderID.ToString())
    End Sub
End Class
