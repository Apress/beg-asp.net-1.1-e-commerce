<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ProductDetailsAdmin.ascx.vb" Inherits="JokePoint.ProductDetailsAdmin" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table>
	<tr>
		<td width="150">
			<P align="center">
				<asp:Image id="productImage" runat="server"></asp:Image></P>
		</td>
		<td>
			<P>
				<asp:Label id="Label1" runat="server" CssClass="AdminPageText">Editing product:</asp:Label>
				<asp:LinkButton id="productNameLink" runat="server" CssClass="ListDescription"></asp:LinkButton></P>
			<P>
				<asp:Label id="Label2" runat="server" CssClass="AdminPageText">Product belongs to these categories:</asp:Label>
				<asp:Label id="categoriesListLabel" runat="server"></asp:Label></P>
			<P>
				<asp:Label id="Label4" runat="server" CssClass="AdminPageText">Assign product to this category:</asp:Label>
				<asp:DropDownList id="categoriesList" runat="server"></asp:DropDownList>
				<asp:Button id="assignButton" runat="server" Text="Assign" CssClass="AdminButtonText"></asp:Button></P>
			<P>
				<asp:Label id="Label5" runat="server" CssClass="AdminPageText">Move product to this category:</asp:Label>
				<asp:DropDownList id="categoriesList2" runat="server"></asp:DropDownList>
				<asp:Button id="moveButton" runat="server" Text="Move" CssClass="AdminButtonText"></asp:Button></P>
			<P>
				<asp:Button id="removeButton" runat="server" Text="Button" CssClass="AdminButtonText"></asp:Button></P>
			Upload picture: <input id="fileName" type="file" name="fileName" runat="server">
			<asp:button id="uploadFile" text="Upload" runat="server"></asp:button>
			<asp:label id="uploadMessageLabel" runat="server"></asp:label>
		</td>
	</tr>
</table>
