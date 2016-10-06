<%@ Page Language="vb" AutoEventWireup="false" Codebehind="login.aspx.vb" Inherits="JokePoint.login"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>login</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:Label id="loginMessageLabel" runat="server"></asp:Label></P>
			<P>
				<asp:Label id="userNameLabel" runat="server">User Name:</asp:Label>
				<asp:TextBox id="userNameTextBox" runat="server"></asp:TextBox><BR>
				<asp:Label id="passwordLabel" runat="server">Password:</asp:Label>
				<asp:TextBox id="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox></P>
			<P>
				<asp:CheckBox id="persistCheckBox" runat="server" Text="Persist Security Info"></asp:CheckBox></P>
			<P>
				<asp:Button id="loginButton" runat="server" Text="Login"></asp:Button></P>
		</form>
	</body>
</HTML>
