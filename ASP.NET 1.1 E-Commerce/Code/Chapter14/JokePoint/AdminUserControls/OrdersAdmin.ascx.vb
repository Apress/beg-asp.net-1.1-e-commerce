Public MustInherit Class OrdersAdmin1
  Inherits System.Web.UI.UserControl
  Protected WithEvents Label1 As System.Web.UI.WebControls.Label
  Protected WithEvents recordCountTextBox As System.Web.UI.WebControls.TextBox
  Protected WithEvents Label2 As System.Web.UI.WebControls.Label
  Protected WithEvents Label3 As System.Web.UI.WebControls.Label
  Protected WithEvents Label4 As System.Web.UI.WebControls.Label
  Protected WithEvents Label5 As System.Web.UI.WebControls.Label
  Protected WithEvents Label6 As System.Web.UI.WebControls.Label
  Protected WithEvents endDateTextBox As System.Web.UI.WebControls.TextBox
  Protected WithEvents ordersByRecentButton As System.Web.UI.WebControls.Button
  Protected WithEvents ordersByDateButton As System.Web.UI.WebControls.Button
  Protected WithEvents statusList As System.Web.UI.WebControls.DropDownList
  Protected WithEvents ordersByStatusButton As System.Web.UI.WebControls.Button
  Protected WithEvents customerIDTextBox As System.Web.UI.WebControls.TextBox
  Protected WithEvents ordersByCustomerButton As System.Web.UI.WebControls.Button
  Protected WithEvents Label7 As System.Web.UI.WebControls.Label
  Protected WithEvents orderIDTextBox As System.Web.UI.WebControls.TextBox
  Protected WithEvents orderByIDButton As System.Web.UI.WebControls.Button
  Protected WithEvents errorLabel As System.Web.UI.WebControls.Label
  Protected WithEvents startDateValidator As System.Web.UI.WebControls.RangeValidator
  Protected WithEvents endDateValidator As System.Web.UI.WebControls.RangeValidator
  Protected WithEvents compareDatesValidator As System.Web.UI.WebControls.CompareValidator
  Protected WithEvents validationSummary As System.Web.UI.WebControls.ValidationSummary
  Protected WithEvents grid As System.Web.UI.WebControls.DataGrid
  Protected WithEvents customerIDValidator As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents orderIDValidator As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents startDateTextBox As System.Web.UI.WebControls.TextBox

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
        'Put user code to initialize the page here
        errorLabel.Text = ""

        If Not IsPostBack Then
            Dim om As New OrderManager
            If Not Request.Params("OrderID") Is Nothing Then
                ' Set OrderID text box to selected order
                orderIDTextBox.Text = Request.Params("OrderID")

                ' Get selected Order
                grid.DataSource = _
                   om.GetOrder(Convert.ToInt32(Request.Params("OrderID")))
                grid.DataKeyField = "OrderID"
                grid.DataBind()
            End If

            statusList.DataSource = om.GetStatuses()
            statusList.DataTextField = "Description"
            statusList.DataValueField = "StatusID"
            statusList.DataBind()
        End If
    End Sub

    Private Sub grid_SelectedIndexChanged(ByVal sender As System.Object, _
          ByVal e As System.EventArgs) Handles grid.SelectedIndexChanged
        Dim orderId As String
        orderId = grid.DataKeys(grid.SelectedIndex)
        Response.Redirect("ordersAdmin.aspx?OrderID=" & orderId)
    End Sub


    Private Sub ordersByStatusButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ordersByStatusButton.Click
        Dim om As New OrderManager
        Dim status As Integer

        Try
            status = statusList.SelectedItem.Value

            grid.DataSource = om.GetOrdersByStatus(status)
            grid.DataKeyField = "OrderID"
            grid.DataBind()
        Catch
            errorLabel.Text = "Could not get the requested data!"
        End Try
    End Sub

    Private Sub ordersByCustomerButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ordersByCustomerButton.Click
        Dim om As New OrderManager
        Dim customerID As Integer

        Try
            customerID = Int32.Parse(customerIDTextBox.Text)

            grid.DataSource = om.GetOrdersByCustomer(customerID)
            grid.DataKeyField = "OrderID"
            grid.DataBind()
        Catch
            errorLabel.Text = "Could not get the requested data!"
        End Try
    End Sub

    Private Sub orderByIDButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles orderByIDButton.Click
        Dim om As New OrderManager
        Dim orderID As Integer

        Try
            orderID = Int32.Parse(orderIDTextBox.Text)
            grid.DataSource = om.GetOrder(orderID)
            grid.DataKeyField = "OrderID"
            grid.DataBind()
        Catch
            errorLabel.Text = "Could not get the requested data!"
        End Try
    End Sub

    Private Sub ordersByRecentButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ordersByRecentButton.Click
        Dim om As New OrderManager
        Dim recordCount As Integer

        Try
            recordCount = Int32.Parse(recordCountTextBox.Text)

            grid.DataSource = om.GetOrdersByRecent(recordCount)
            grid.DataKeyField = "OrderID"
            grid.DataBind()
        Catch
            errorLabel.Text = "Could not get the requested data!"
        End Try
    End Sub

    Private Sub ordersByDateButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ordersByDateButton.Click
        Dim om As New OrderManager
        Dim startDate As String
        Dim endDate As String

        Try
            startDate = startDateTextBox.Text
            endDate = endDateTextBox.Text

            grid.DataSource = om.GetOrdersByDate(startDate, endDate)
            grid.DataKeyField = "OrderID"
            grid.DataBind()
        Catch
            errorLabel.Text = "Could not get the requested data!"
        End Try
    End Sub
End Class
