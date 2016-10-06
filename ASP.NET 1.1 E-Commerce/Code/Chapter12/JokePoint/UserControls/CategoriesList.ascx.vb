Public Class CategoriesList
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents list As System.Web.UI.WebControls.DataList

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
        If Not IsPostBack Then
            ' The department for which we are loading the categories
            Dim departmentId As String = Request.QueryString("DepartmentID")
            ' Don't load categories if no department was selected
            If Not departmentId Is Nothing Then
                ' The index of the selected DataList item.
                Dim listIndex As String = Request.QueryString("CategoryIndex")
                ' The DataList item that was clicked is set as the selected item
                If Not listIndex Is Nothing Then
                    list.SelectedIndex = CInt(listIndex)
                End If
                ' GetCategoriesInDepartment returns an SqlDataReader object that has
                ' two fields: CategoryID and Name. These fields are read in
                ' the SelectedItemTemplate and ItemTemplate of the DataList
                list.DataSource = Catalog.GetCategoriesInDepartment(departmentId)
                ' Needed to bind the child controls(the HyperLink and Label controls)
                ' to the data source
                list.DataBind()
            End If
        End If
    End Sub

End Class
