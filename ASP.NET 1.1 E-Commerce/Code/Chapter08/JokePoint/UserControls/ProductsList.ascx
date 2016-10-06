<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ProductsList.ascx.vb" Inherits="JokePoint.ProductsList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:datalist id="list" EnableViewState="False" RepeatDirection="Horizontal" runat="server" RepeatColumns="2">
	<ItemTemplate>
		<table cellPadding="0" align="left">
			<tr>
				<td align="center" width="110">
					<img src='ProductImages/<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>' border="0" vspace="10"></a>
				</td>
				<td vAlign="top" width="200" height="200">
					<font class="ProductName">
						<%# DataBinder.Eval(Container.DataItem, "Name") %>
					</font>
					<br>
					<br>
					<font class="ProductDescription">
						<%# DataBinder.Eval(Container.DataItem, "Description") %>
						<br>
						<br>
						Price: </font><font class="ProductPrice">
						<%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %>
						<br>
						<br>
						<a href='JavaScript: OpenPayPalWindow("https://www.paypal.com/cgi-bin/webscr?cmd=_cart&business=youremail@yourserver.com&item_name=<%# DataBinder.Eval(Container.DataItem, "Name")%>&amount=<%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}")%>&add=1&return=www.yourwebsite.com&cancel_return=www.yourwebsite.com")'>
							<IMG src="Images/AddToCart.gif" border="0"> </a>
			</tr>
		</table>
	</ItemTemplate>
</asp:datalist>
