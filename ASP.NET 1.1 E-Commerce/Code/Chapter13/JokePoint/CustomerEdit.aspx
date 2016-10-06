<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CustomerEdit.aspx.vb" Inherits="JokePoint.CustomerEdit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Customer Details</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<p>Please enter your details:</p>
			<table>
				<tr>
					<td><asp:label id="Label3" runat="server">Username:</asp:label></td>
					<td><asp:textbox id="txtUserName" runat="server"></asp:textbox></td>
					<td><asp:requiredfieldvalidator id="validateUserName" ErrorMessage="You must enter a user name." ControlToValidate="txtUserName" Runat="server"></asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<td><asp:label id="Label1" runat="server">E-Mail Address:</asp:label></td>
					<td><asp:textbox id="txtEmail" runat="server"></asp:textbox></td>
					<td><asp:requiredfieldvalidator id="validateEmail" ErrorMessage="You must enter an e-mail address." ControlToValidate="txtEmail" Runat="server"></asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server">Password:</asp:label></td>
					<td><asp:textbox id="txtPassword" runat="server" TextMode="Password"></asp:textbox></td>
					<td><asp:requiredfieldvalidator id="validatePassword" ErrorMessage="You must enter a password." ControlToValidate="txtPassword" Runat="server"></asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<td><asp:label id="Label4" runat="server">Re-enter Password:</asp:label></td>
					<td><asp:textbox id="txtPasswordConfirm" runat="server" TextMode="Password"></asp:textbox></td>
					<td><asp:requiredfieldvalidator id="validatePasswordReEntry" ErrorMessage="You must re-enter your password." ControlToValidate="txtPasswordConfirm" Runat="server"></asp:requiredfieldvalidator><asp:comparevalidator id="validatePasswordMatch" ErrorMessage="You must re-enter the same password." ControlToValidate="txtPassword" Runat="server" Operator="Equal" ControlToCompare="txtPasswordConfirm"></asp:comparevalidator></td>
				</tr>
				<tr>
					<td><asp:label id="Label5" runat="server">Phone Number:</asp:label></td>
					<td><asp:textbox id="txtPhone" runat="server"></asp:textbox></td>
					<td><asp:requiredfieldvalidator id="validatePhone" ErrorMessage="You must enter a phone number." ControlToValidate="txtPhone" Runat="server"></asp:requiredfieldvalidator></td>
				</tr>
			</table>
			<P></P>
			<P><asp:button id="btnConfirm" runat="server" Text="Confirm"></asp:button><asp:button id="cancelButton" runat="server" Text="Cancel"></asp:button></P>
			<P><asp:label id="lblMsg" runat="server"></asp:label></P>
		</form>
	</body>
</HTML>
