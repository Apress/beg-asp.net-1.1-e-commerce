Public Class SearchBox
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents searchTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents allWordsCheckBox As System.Web.UI.WebControls.CheckBox

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

    Private Sub searchTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchTextBox.TextChanged
        ExecuteSearch()
    End Sub

    Private Sub ExecuteSearch()
        If Trim(searchTextBox.Text) <> "" Then
            Response.Redirect(Request.Url.AbsolutePath + _
                         "?Search=" + searchTextBox.Text + _
                         "&AllWords=" + allWordsCheckBox.Checked.ToString() + _
                         "&PageNumber=1&ProductsOnPage=4")
        End If
    End Sub
End Class
