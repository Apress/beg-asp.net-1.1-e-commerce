Public Class SearchResults
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents titleLabel As System.Web.UI.WebControls.Label
    Protected WithEvents pageNumberLabel As System.Web.UI.WebControls.Label
    Protected WithEvents previousLink As System.Web.UI.WebControls.HyperLink
    Protected WithEvents nextLink As System.Web.UI.WebControls.HyperLink

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
        ' Save the search string parameters to String variables
        Dim searchString As String = Request.QueryString("Search")
        Dim allWords As String = Request.QueryString("AllWords")
        Dim pageNumber As String = Request.QueryString("PageNumber")
        Dim productsOnPage As String = Request.QueryString("ProductsOnPage")

        ' Perform the search and get back the number of results
        ' The search results will be read from ProductsList.ascx
        Dim howManyResults As Integer
        howManyResults = Catalog.SearchCatalog(searchString, pageNumber, _
                             productsOnPage, allWords)

        ' Do you have any results?
        If howManyResults = 0 Then
            titleLabel.Text = "Your search for <font color=red>" + searchString + _
                      "</font> generated no results."
            previousLink.Visible = False
            nextLink.Visible = False
            pageNumberLabel.Visible = False
        Else
            titleLabel.Text = "Your search for <font color=red>" + searchString + _
                      "</font> generated " + howManyResults.ToString + _
                      " results:"

            ' Calculate how many pages of results
            Dim howManyPages As Integer = _
              Math.Ceiling(howManyResults / (CType(productsOnPage, Integer)))

            ' Show "Page x of y" text
            pageNumberLabel.Text = "Page " + pageNumber + _
                         " of " + howManyPages.ToString

            ' Initialize the "Previous" link
            If pageNumber = "1" Then
                previousLink.Enabled = False
            Else
                previousLink.NavigateUrl = _
                   Request.Url.AbsolutePath + _
                   "?Search=" + searchString + _
                   "&AllWords=" + allWords + _
                   "&PageNumber=" + (CType(pageNumber, Integer) - 1).ToString + _
                   "&ProductsOnPage=" + productsOnPage
            End If

            ' Initialize the "Next" link
            If pageNumber = howManyPages.ToString() Then
                nextLink.Enabled = False
            Else
                nextLink.NavigateUrl = _
                   Request.Url.AbsolutePath + _
                   "?Search=" + searchString + _
                   "&AllWords=" + allWords + _
                   "&PageNumber=" + (CType(pageNumber, Integer) + 1).ToString + _
                   "&ProductsOnPage=" + productsOnPage
            End If
        End If
    End Sub

End Class
