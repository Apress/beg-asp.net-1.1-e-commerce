<%@ Page Language="vb" AutoEventWireup="false" Codebehind="shoppingCartAdmin.aspx.vb" Inherits="JokePoint.shoppingCartAdmin"%>
<%@ Register TagPrefix="uc1" TagName="Logout" Src="AdminUserControls/Logout.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>shoppingCartAdmin</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="JokePoint.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<strong><font size="5">JokePoint Admin Page</font></strong>
			<uc1:Logout id="Logout1" runat="server"></uc1:Logout>
			<P>
				<asp:label id="countLabel" runat="server" CssClass="AdminPageText">
      Hello!
    </asp:label></P>
			<P>
				<asp:Label id="Label1" runat="server">How many days?</asp:Label>
				<asp:DropDownList id="daysList" runat="server">
					<asp:ListItem Value="1">One</asp:ListItem>
					<asp:ListItem Value="10" Selected="True">Ten</asp:ListItem>
					<asp:ListItem Value="20">Twenty</asp:ListItem>
					<asp:ListItem Value="30">Thirty</asp:ListItem>
				</asp:DropDownList></P>
			<P>
				<asp:button id="countButton" runat="server" Text="Count Old Elements" CssClass="AdminButtonText"></asp:button>
			</P>
			<P>
				<asp:button id="deleteButton" runat="server" Text="Delete Old Elements" CssClass="AdminButtonText"></asp:button>
			</P>
		</form>
	</body>
</HTML>
