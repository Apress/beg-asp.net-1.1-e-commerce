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
<asp:Button runat="server" Text="Add to Cart" 
     CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductID") %>' ID="Button1" NAME="Button1">
</asp:Button>
			</tr>
		</table>
	</ItemTemplate>
</asp:datalist>
