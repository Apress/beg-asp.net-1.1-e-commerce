Public Class shoppingCartAdmin
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents countLabel As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents daysList As System.Web.UI.WebControls.DropDownList
    Protected WithEvents countButton As System.Web.UI.WebControls.Button
    Protected WithEvents deleteButton As System.Web.UI.WebControls.Button

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

    Private Sub deleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteButton.Click
        Dim days As Integer = Integer.Parse(daysList.SelectedItem.Value)
        ShoppingCart.CleanShoppingCart(days)
        countLabel.Text = "Old elements were removed from shopping cart"
    End Sub

    Private Sub countButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles countButton.Click
        Dim days As Integer = Integer.Parse(daysList.SelectedItem.Value)
        countLabel.Text = "There are " & ShoppingCart.CountOldShoppingCartElements(days) & " old shopping cart elements"
    End Sub
End Class
