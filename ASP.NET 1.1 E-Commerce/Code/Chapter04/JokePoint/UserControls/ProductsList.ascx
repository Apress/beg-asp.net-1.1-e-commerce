<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ProductsList.ascx.vb" Inherits="JokePoint.ProductsList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:datalist id="list" RepeatColumns="2" runat="server" RepeatDirection="Horizontal">
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
					</font>
			</tr>
		</table>
	</ItemTemplate>
</asp:datalist>
