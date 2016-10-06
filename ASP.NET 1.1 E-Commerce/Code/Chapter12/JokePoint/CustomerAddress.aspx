<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CustomerAddress.aspx.vb" Inherits="JokePoint.CustomerAddress" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Address Details</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<p>Please enter your address details:</p>
			<p><table>
					<tr>
						<td><asp:label id="Label3" runat="server">Address 1:</asp:label></td>
						<td><asp:textbox id="txtAddress1" runat="server"></asp:textbox></td>
						<td><asp:RequiredFieldValidator ID="validateAddress1" Runat="server" ControlToValidate="txtAddress1" ErrorMessage="You must enter an address."></asp:RequiredFieldValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label1" runat="server">Address 2:</asp:label></td>
						<td><asp:textbox id="txtAddress2" runat="server"></asp:textbox></td>
						<td></td>
					</tr>
					<tr>
						<td><asp:label id="Label2" runat="server">Town/City:</asp:label></td>
						<td><asp:textbox id="txtCity" runat="server"></asp:textbox></td>
						<td><asp:RequiredFieldValidator ID="validateCity" Runat="server" ControlToValidate="txtCity" ErrorMessage="You must enter a town/city."></asp:RequiredFieldValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label4" runat="server">Region/State:</asp:label></td>
						<td><asp:textbox id="txtRegion" runat="server"></asp:textbox></td>
						<td><asp:RequiredFieldValidator ID="validateRegion" Runat="server" ControlToValidate="txtRegion" ErrorMessage="You must enter a region/state."></asp:RequiredFieldValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label5" runat="server">Postal Code/ZIP:</asp:label></td>
						<td><asp:textbox id="txtPostalCode" runat="server"></asp:textbox></td>
						<td><asp:RequiredFieldValidator ID="validatePostalCode" Runat="server" ControlToValidate="txtPostalCode" ErrorMessage="You must enter a postal code/ZIP."></asp:RequiredFieldValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label6" runat="server">Country:</asp:label></td>
						<td><asp:textbox id="txtCountry" runat="server"></asp:textbox></td>
						<td><asp:RequiredFieldValidator ID="validateCountry" Runat="server" ControlToValidate="txtCountry" ErrorMessage="You must enter a country."></asp:RequiredFieldValidator></td>
					</tr>
				</table>
			</p>
			<P><asp:button id="btnConfirm" runat="server" Text="Confirm"></asp:button><asp:button id="cancelButton" runat="server" Text="Cancel"></asp:button></P>
			<P><asp:label id="lblMsg" runat="server"></asp:label></P>
		</form>
	</body>
</HTML>
