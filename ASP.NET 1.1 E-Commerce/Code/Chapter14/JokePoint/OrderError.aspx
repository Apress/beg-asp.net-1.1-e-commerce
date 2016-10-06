<%@ Page Language="vb" AutoEventWireup="false" Codebehind="OrderError.aspx.vb" Inherits="JokePoint.OrderError"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>OrderError</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<p>An error has occured during the processing of your order.</p>
			<p>Details:&nbsp;
				<asp:Label id="errorLabel" Runat="server"></asp:Label></p>
			<p>If you have an enquiry regarding this message please e-mail <a href="mailto:customerservice@JokePoint.com">
					customerservice@JokePoint.com</a></p>
			<p><a href="default.aspx">Back to shop</a></p>
		</form>
	</body>
</HTML>
