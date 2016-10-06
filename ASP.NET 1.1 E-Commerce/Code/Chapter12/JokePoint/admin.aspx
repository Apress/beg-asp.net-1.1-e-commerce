<%@ Register TagPrefix="uc1" TagName="DepartmentsAdmin" Src="AdminUserControls/DepartmentsAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CategoriesAdmin" Src="AdminUserControls/CategoriesAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ProductsAdmin" Src="AdminUserControls/ProductsAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Logout" Src="AdminUserControls/Logout.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="admin.aspx.vb" Inherits="JokePoint.admin"%>
<%@ Register TagPrefix="uc1" TagName="ProductDetailsAdmin" Src="AdminUserControls/ProductDetailsAdmin.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>admin</title>
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
			<br>
			<br>
			<table border="0" cellpadding="0">
				<tr>
					<td>
						<uc1:DepartmentsAdmin id="DepartmentsAdmin1" runat="server"></uc1:DepartmentsAdmin>
					</td>
				</tr>
				<tr>
					<td>
						<uc1:CategoriesAdmin id="CategoriesAdmin1" runat="server"></uc1:CategoriesAdmin>
					</td>
				<tr>
					<td>
						<uc1:ProductsAdmin id="ProductsAdmin1" runat="server"></uc1:ProductsAdmin>
					</td>
				</tr>
				<tr>
					<td>
						<uc1:ProductDetailsAdmin id="ProductDetailsAdmin1" runat="server"></uc1:ProductDetailsAdmin>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
