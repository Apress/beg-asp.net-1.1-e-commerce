<%@ Control Language="vb" AutoEventWireup="false" Codebehind="FirstPage.ascx.vb" Inherits="JokePoint.FirstPage" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="ProductsList" Src="ProductsList.ascx" %>
<br>
<img src="Images/welcome.gif" border="0" width="102" height="18"><br>
<font class="FirstPageText">
	<br>
	We hope you have a pleasant experience developing JokePoint,<br>
	<br>
	the virtual novelty store presented in Beginning ASP.NET E-Commerce!
<br>
<br>
Press here for the <a href="admin.aspx">catalog admin page</a>&nbsp;or 
<a href="shoppingCartAdmin.aspx"> cart admin page</a>.</font>
<br><br>
<font class="ListDescription">
	Here are a few samples from our collection: </font>
<br>
<br>
<uc1:ProductsList id="ProductsList1" runat="server"></uc1:ProductsList>
