<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ShoppingCart.ascx.vb" Inherits="JokePoint.ShoppingCart1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="ProductsList" Src="ProductsList.ascx" %>
<P><BR>
	<asp:label id="introLabel" CssClass="ListDescription" runat="server">These are the products in your shopping cart:</asp:label></P>
<P><asp:datagrid id="grid" runat="server" AutoGenerateColumns="False">
		<ItemStyle Font-Size="X-Small" Font-Names="Verdana" BackColor="Gainsboro"></ItemStyle>
		<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
		<Columns>
			<asp:BoundColumn DataField="Name" ReadOnly="True" HeaderText="Product Name"></asp:BoundColumn>
			<asp:BoundColumn DataField="Price" ReadOnly="True" HeaderText="Price" DataFormatString="{0:c}"></asp:BoundColumn>
			<asp:TemplateColumn HeaderText="Quantity">
				<ItemTemplate>
					<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Quantity") %>'>
					</asp:Label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox id=quantityTextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Quantity") %>' Width="65px" MaxLength="3">
					</asp:TextBox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:BoundColumn DataField="Subtotal" ReadOnly="True" HeaderText="Subtotal" DataFormatString="{0:c}"></asp:BoundColumn>
			<asp:EditCommandColumn ButtonType="PushButton" UpdateText="Update" CancelText="Cancel" EditText="Edit Quantity"></asp:EditCommandColumn>
			<asp:ButtonColumn Text="Remove" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
		</Columns>
	</asp:datagrid></P>
<P>
	<table width="100%">
		<tr>
			<td width="100%"><asp:label id="Label2" CssClass="ProductDescription" runat="server">
        Total amount:</asp:label>&nbsp;
				<asp:label id="totalAmountLabel" CssClass="ProductPrice" runat="server"></asp:label></td>
			<td><asp:button id="placeOrderButton" runat="server" Text="Checkout"></asp:button></td>
		</tr>
	</table>
<P><asp:button id="continueShoppingButton" CssClass="AdminButtonText" runat="server" Text="Continue Shopping"></asp:button></P>
<P><asp:label id="similarProductsLabel" CssClass="ListDescription" runat="server">Customers who bought these products also bought:</asp:label></P>
<P>
	<uc1:ProductsList id="ProductsList1" runat="server"></uc1:ProductsList></P>
