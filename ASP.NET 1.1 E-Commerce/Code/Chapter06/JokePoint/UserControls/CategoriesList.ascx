<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CategoriesList.ascx.vb" Inherits="JokePoint.CategoriesList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:DataList id="list" runat="server" CellPadding="0">
	<HeaderTemplate>
		<IMG alt="" src="Images/CategHeader.gif" border="0">
	</HeaderTemplate>
	<SelectedItemTemplate>
		&nbsp;&raquo;
		<asp:Label id="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' CssClass="CategorySelected">Label</asp:Label>
	</SelectedItemTemplate>
	<FooterTemplate>
		<IMG alt="" src="Images/CategFooter.gif" border="0">
	</FooterTemplate>
	<ItemStyle BackColor="PaleGoldenrod"></ItemStyle>
	<ItemTemplate>
		&nbsp;&raquo;
		<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl='<%# "../default.aspx?DepartmentID=" &amp; Request.QueryString("DepartmentID") &amp; "&amp;DepartmentIndex=" &amp; Request.QueryString("DepartmentIndex") &amp; "&amp;CategoryID=" &amp; DataBinder.Eval(Container.DataItem, "categoryID") &amp; "&amp;CategoryIndex=" &amp; Container.ItemIndex  %>' Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' CssClass="CategoryUnselected">HyperLink</asp:HyperLink>
	</ItemTemplate>
	<HeaderStyle BackColor="PaleGoldenrod"></HeaderStyle>
</asp:DataList>
