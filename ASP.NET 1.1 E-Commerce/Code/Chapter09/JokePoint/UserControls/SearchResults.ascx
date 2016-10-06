<%@ Control Language="vb" AutoEventWireup="false" Codebehind="SearchResults.ascx.vb" Inherits="JokePoint.SearchResults" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="ProductsList" Src="ProductsList.ascx" %>
<P>
	<asp:Label id="titleLabel" runat="server" CssClass="FirstPageText"></asp:Label></P>
<P>
	<asp:Label id="pageNumberLabel" runat="server" CssClass="SearchResults"></asp:Label>&nbsp;&nbsp;
	<asp:HyperLink id="previousLink" runat="server" CssClass="SearchResults">Previous</asp:HyperLink>&nbsp;&nbsp;
	<asp:HyperLink id="nextLink" runat="server" CssClass="SearchResults">Next</asp:HyperLink></P>
<P>
	<uc1:ProductsList id="ProductsList1" runat="server"></uc1:ProductsList></P>
