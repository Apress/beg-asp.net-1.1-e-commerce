<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ShoppingCart.ascx.vb" Inherits="JokePoint.ShoppingCart1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<P><BR>
	<asp:Label id="introLabel" runat="server" CssClass="ListDescription">These are the products in your shopping cart:</asp:Label></P>
<P>
	<asp:DataGrid id="grid" runat="server" AutoGenerateColumns="False">
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
	</asp:DataGrid></P>
<table width="100%">
	<tr>
		<td width="100%">
			<asp:label id="Label2" runat="server" CssClass="ProductDescription">
        Total amount:</asp:label>&nbsp;
			<asp:label id="totalAmountLabel" runat="server" CssClass="ProductPrice"></asp:label>
		</td>
		<td>
			<asp:Button id="placeOrderButton" runat="server" Text="Place Order"></asp:Button>
		</td>
	</tr>
</table>
<P>
	<asp:Button id="continueShoppingButton" runat="server" Text="Continue Shopping" CssClass="AdminButtonText"></asp:Button></P>
