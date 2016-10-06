<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CustomerCreditCard.aspx.vb" Inherits="JokePoint.CustomerCreditCard" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Credit Card Details</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<p>Please enter your credit card details:</p>
			<P><table>
					<tr>
						<td><asp:label id="Label3" runat="server">Card holder:</asp:label></td>
						<td><asp:textbox id="txtCardHolder" runat="server"></asp:textbox></td>
						<td><asp:RequiredFieldValidator ID="validateCardHolder" Runat="server" ControlToValidate="txtCardHolder" ErrorMessage="You must enter a card holder."></asp:RequiredFieldValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label1" runat="server">Card Number (digits only):</asp:label></td>
						<td><asp:textbox id="txtCardNumber" runat="server"></asp:textbox></td>
						<td><asp:RequiredFieldValidator ID="validateCardNumber" Runat="server" ControlToValidate="txtCardNumber" ErrorMessage="You must enter a card number."></asp:RequiredFieldValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label2" runat="server">Expiry Date (MM/YY):</asp:label></td>
						<td><asp:textbox id="txtExpDate" runat="server"></asp:textbox></td>
						<td><asp:RequiredFieldValidator ID="validateExpDate" Runat="server" ControlToValidate="txtExpDate" ErrorMessage="You must enter an expiry date."></asp:RequiredFieldValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label4" runat="server">Issue Date (MM/YY if applicable):</asp:label></td>
						<td><asp:textbox id="txtIssueDate" runat="server"></asp:textbox></td>
						<td></td>
					</tr>
					<tr>
						<td><asp:label id="Label5" runat="server">Issue Number (if applicable):</asp:label></td>
						<td><asp:textbox id="txtIssueNumber" runat="server"></asp:textbox></td>
						<td></td>
					</tr>
					<tr>
						<td><asp:label id="Label6" runat="server">Card Type:</asp:label></td>
						<td><asp:dropdownlist id="txtCardType" runat="server">
								<asp:ListItem Value="Visa">Visa</asp:ListItem>
								<asp:ListItem Value="Mastercard">Mastercard</asp:ListItem>
								<asp:ListItem Value="Switch">Switch</asp:ListItem>
								<asp:ListItem Value="Solo">Solo</asp:ListItem>
								<asp:ListItem Value="American Express">American Express</asp:ListItem>
							</asp:dropdownlist></td>
						<td><asp:RequiredFieldValidator ID="validateCardType" Runat="server" ControlToValidate="txtCardType" ErrorMessage="You must enter a card type."></asp:RequiredFieldValidator>
						</td>
					</tr>
				</table>
			</P>
			<P><asp:button id="btnConfirm" runat="server" Text="Confirm"></asp:button><asp:button id="cancelButton" runat="server" Text="Cancel"></asp:button></P>
			<P></P>
		</form>
	</body>
</HTML>
