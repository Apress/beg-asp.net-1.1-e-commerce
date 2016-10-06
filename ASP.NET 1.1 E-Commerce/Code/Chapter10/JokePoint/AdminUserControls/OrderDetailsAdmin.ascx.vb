Public Class OrderDetailsAdmin
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents orderIdLabel As System.Web.UI.WebControls.Label
    Protected WithEvents totalAmountLabel As System.Web.UI.WebControls.Label
    Protected WithEvents dateCreatedTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents dateShippedTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents verifiedCheck As System.Web.UI.WebControls.CheckBox
    Protected WithEvents commentsTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents customerNameTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents shippingAddressTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents customerEmailTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label99 As System.Web.UI.WebControls.Label
    Protected WithEvents editButton As System.Web.UI.WebControls.Button
    Protected WithEvents updateButton As System.Web.UI.WebControls.Button
    Protected WithEvents cancelButton As System.Web.UI.WebControls.Button
    Protected WithEvents markAsVerifiedButton As System.Web.UI.WebControls.Button
    Protected WithEvents markAsCompletedButton As System.Web.UI.WebControls.Button
    Protected WithEvents markAsCanceledButton As System.Web.UI.WebControls.Button
    Protected WithEvents grid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents completedCheck As System.Web.UI.WebControls.CheckBox
    Protected WithEvents canceledCheck As System.Web.UI.WebControls.CheckBox

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
        If Not Page.IsPostBack Then
            ' Update information in all controls
            PopulateControls()
            ' Initially Edit mode should be disabled
            ' (administrator can't change order information)
            SetEditMode(False)
        End If
    End Sub

    Private Sub PopulateControls()
        ' The OrderInfo object will be populated by calling  
        ' OrderManager.GetOrderDetails
        Dim orderInfo As OrderInfo
        ' We receive the order ID in the query string
        Dim orderId As String = Request.Params("OrderID")
        ' Get order info by calling OrderManager.GetOrderDetails
        orderInfo = OrderManager.GetOrderInfo(orderId)
        ' Populate the text boxes with order information
        orderIdLabel.Text = orderInfo.OrderID
        totalAmountLabel.Text = String.Format("{0:c}", orderInfo.TotalAmount)
        dateCreatedTextBox.Text = orderInfo.DateCreated
        dateShippedTextBox.Text = orderInfo.DateShipped
        verifiedCheck.Checked = orderInfo.Verified
        completedCheck.Checked = orderInfo.Completed
        canceledCheck.Checked = orderInfo.Canceled
        commentsTextBox.Text = orderInfo.Comments
        customerNameTextBox.Text = orderInfo.CustomerName
        shippingAddressTextBox.Text = orderInfo.ShippingAddress
        customerEmailTextBox.Text = orderInfo.CustomerEmail
        ' By default the Edit button is enabled
        ' and the Update and Cancel buttons are disabled
        editButton.Enabled = True
        updateButton.Enabled = False
        cancelButton.Enabled = False
        ' Decide which one of the other three buttons
        ' should be enabled and which should be disabled
        If canceledCheck.Checked Or completedCheck.Checked Then
            ' if the order was canceled or completed ...
            markAsVerifiedButton.Enabled = False
            markAsCompletedButton.Enabled = False
            markAsCanceledButton.Enabled = False
        ElseIf verifiedCheck.Checked Then
            ' if the order was not canceled but is verified ...
            markAsVerifiedButton.Enabled = False
            markAsCompletedButton.Enabled = True
            markAsCanceledButton.Enabled = True
        Else
            ' if the order was not canceled and is not verified ...
            markAsVerifiedButton.Enabled = True
            markAsCompletedButton.Enabled = False
            markAsCanceledButton.Enabled = True
        End If
        ' Fill the data grid with orderdetails
        grid.DataSource = OrderManager.GetOrderDetails(orderId)
        grid.DataKeyField = "OrderID"
        grid.DataBind()
    End Sub

    Private Sub SetEditMode(ByVal value As Boolean)
        dateCreatedTextBox.Enabled = value
        dateShippedTextBox.Enabled = value
        verifiedCheck.Enabled = value
        completedCheck.Enabled = value
        canceledCheck.Enabled = value
        commentsTextBox.Enabled = value
        customerNameTextBox.Enabled = value
        shippingAddressTextBox.Enabled = value
        customerEmailTextBox.Enabled = value
        editButton.Enabled = Not value
        updateButton.Enabled = value
        cancelButton.Enabled = value
    End Sub

    Private Sub editButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editButton.Click
        SetEditMode(True)
    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click
        SetEditMode(False)
        PopulateControls()
    End Sub

    Private Sub updateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateButton.Click
        ' Store the new order details in an OrderInfo object
        Dim orderInfo As New OrderInfo
        orderInfo.OrderID = orderIdLabel.Text
        orderInfo.DateCreated = dateCreatedTextBox.Text
        orderInfo.DateShipped = dateShippedTextBox.Text
        orderInfo.Verified = verifiedCheck.Checked
        orderInfo.Completed = completedCheck.Checked
        orderInfo.Canceled = canceledCheck.Checked
        orderInfo.Comments = commentsTextBox.Text
        orderInfo.CustomerName = customerNameTextBox.Text
        orderInfo.ShippingAddress = shippingAddressTextBox.Text
        orderInfo.CustomerEmail = customerEmailTextBox.Text
        Try
            ' Update the order
            OrderManager.UpdateOrder(orderInfo)
        Catch ex As Exception
            ' Do nothing in case the update fails
        End Try
        ' Exit edit mode and update controls' information
        SetEditMode(False)
        PopulateControls()
    End Sub

    Private Sub markAsVerifiedButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles markAsVerifiedButton.Click
        Dim orderId As String = orderIdLabel.Text
        OrderManager.MarkOrderAsVerified(orderId)
        PopulateControls()
    End Sub

    Private Sub markAsCompletedButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles markAsCompletedButton.Click
        Dim orderId As String = orderIdLabel.Text
        OrderManager.MarkOrderAsCompleted(orderId)
        PopulateControls()
    End Sub

    Private Sub markAsCanceledButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles markAsCanceledButton.Click
        Dim orderId As String = orderIdLabel.Text
        OrderManager.MarkOrderAsCanceled(orderId)
        PopulateControls()
    End Sub
End Class
