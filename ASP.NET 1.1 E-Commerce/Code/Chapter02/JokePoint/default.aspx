<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="JokePoint._default"%>
<%@ Register TagPrefix="uc1" TagName="Header" Src="UserControls/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>JokePoint</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="770" border="0">
				<tr>
					<td width="190" height="100%">
						<table height="100%" width="190" cellspacing="0" cellpadding="0">
							<tr>
								<td vAlign="top" height="100%">Place List of Departments Here
								</td>
							</tr>
						</table>
					</td>
					<td vAlign="top" width="550"><br>
						<table>
							<tr>
								<td>
									<uc1:Header id="Header1" runat="server"></uc1:Header></td>
							</tr>
							<tr>
								<td id="pageContentsCell" runat="server">
									Place Contents Here
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
