<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CustomerLogin.aspx.vb" Inherits="JokePoint.CustomerLogin" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
    <title>Customer Login</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body MS_POSITIONING="GridLayout">
    <form id="Form1" method="post" runat="server">
      <p>If you are a returning customer please enter your login details here:</p>
      <P>
        <table>
          <tr>
            <td><asp:label id="Label1" runat="server" text="E-Mail Address:" /></td>
            <td><asp:textbox id="txtEmail" runat="server" /></td>
          </tr>
          <tr>
            <td><asp:label id="Label2" runat="server" text="Password:" /></td>
            <td><asp:textbox id="txtPassword" runat="server" TextMode="Password" /></td>
          </tr>
        </table>
      </P>
      <P><asp:button id="btnLogin" runat="server" Text="Login"></asp:button></P>
      <P><asp:label id="lblLoginMsg" runat="server"></asp:label></P>
      <P>If you are a new customer please press the following button to register:</P>
      <P><asp:button id="btnRegister" runat="server" Text="Register"></asp:button></P>
    </form>
  </body>
</HTML>
