<%@ Register TagPrefix="uc1" TagName="Logout" Src="AdminUserControls/Logout.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ordersAdmin.aspx.vb" Inherits="JokePoint.ordersAdmin"%>
<%@ Register TagPrefix="uc1" TagName="OrdersAdmin" Src="AdminUserControls/OrdersAdmin.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ordersAdmin</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="JokePoint.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<strong><font size="5">Orders Admin Page</font></strong>
			<uc1:Logout id="Logout1" runat="server"></uc1:Logout>
			<br>
			<br>
			<table border="0">
				<tr>
					<td>
						<uc1:OrdersAdmin id="OrdersAdmin1" runat="server"></uc1:OrdersAdmin>
					</td>
				</tr>
				<tr>
					<td runat="server" id="orderDetailsCell"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
