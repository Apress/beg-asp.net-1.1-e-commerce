Public Class OrdersAdmin1
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents recordCountTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents mostRecentButton As System.Web.UI.WebControls.Button
    Protected WithEvents startDateTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents endDateTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents betweenDatesButton As System.Web.UI.WebControls.Button
    Protected WithEvents unverifiedOrdersButton As System.Web.UI.WebControls.Button
    Protected WithEvents verifiedOrdersButton As System.Web.UI.WebControls.Button
    Protected WithEvents grid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents errorLabel As System.Web.UI.WebControls.Label
    Protected WithEvents startDateValidator As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents endDateValidator As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents compareDatesValidator As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents validationSummary As System.Web.UI.WebControls.ValidationSummary

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

    Private Sub mostRecentButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mostRecentButton.Click
        Dim recordCount As Integer
        Try
            recordCount = Int16.Parse(recordCountTextBox.Text)
            grid.DataSource = OrderManager.GetMostRecentOrders(recordCount)
            grid.DataKeyField = "OrderID"
            grid.DataBind()
        Catch ex As Exception
            errorLabel.Text = "Could not get the requested data!"
        End Try
    End Sub

    Private Sub betweenDatesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles betweenDatesButton.Click
        Dim startDate As String
        Dim endDate As String
        Try
            startDate = startDateTextBox.Text
            endDate = endDateTextBox.Text
            grid.DataSource = OrderManager.GetOrdersBetweenDates(startDate, endDate)
            grid.DataKeyField = "OrderID"
            grid.DataBind()
        Catch ex As Exception
            errorLabel.Text = "Could not get the requested data!"
        End Try
    End Sub

    Private Sub unverifiedOrdersButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unverifiedOrdersButton.Click
        Try
            grid.DataSource = OrderManager.GetUnverifiedUncanceledOrders()
            grid.DataKeyField = "OrderID"
            grid.DataBind()
        Catch ex As Exception
            errorLabel.Text = "Could not get the requested data!"
        End Try
    End Sub

    Private Sub verifiedOrdersButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles verifiedOrdersButton.Click
        Try
            grid.DataSource = OrderManager.GetVerifiedUncompletedOrders()
            grid.DataKeyField = "OrderID"
            grid.DataBind()
        Catch ex As Exception
            errorLabel.Text = "Could not get the requested data!"
        End Try
    End Sub

    Private Sub grid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grid.SelectedIndexChanged
        Dim orderId As String
        orderId = grid.DataKeys(grid.SelectedIndex)
        Response.Redirect("ordersAdmin.aspx?OrderID=" & orderId)
    End Sub
End Class
