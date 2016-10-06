<%@ Control Language="vb" AutoEventWireup="false" Codebehind="SearchBox.ascx.vb" Inherits="JokePoint.SearchBox" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" enableViewState="False"%>
<table border="0" width="168" cellspacing="0" cellpadding="0" bgcolor="lightsteelblue">
	<tr>
		<td>
			<img src="Images/SearchBoxHeader.gif" border="0">
		</td>
	</tr>
	<tr bgcolor="lightsteelblue">
		<td align="center">
			<asp:TextBox id="searchTextBox" runat="server" Width="90%" CssClass="SearchBox" BorderStyle="Dotted"
				MaxLength="100"></asp:TextBox>
		</td>
	</tr>
	<tr>
		<td align="center">
			<asp:CheckBox id="allWordsCheckBox" CssClass="SearchBox" runat="server" Text="Search for all words"></asp:CheckBox>
		</td>
	</tr>
</table>
<img src="Images/SearchBoxFooter.gif" border="0">
