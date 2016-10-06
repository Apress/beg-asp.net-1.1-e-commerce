<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Catalog.ascx.vb" Inherits="JokePoint.Catalog1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="ProductsList" Src="ProductsList.ascx" %>
<P align="right">
	<asp:label id="sectionTitleLabel" CssClass="SectionTitle" runat="server"></asp:label>
</P>
<asp:label id="descriptionLabel" CssClass="ListDescription" runat="server"></asp:label>
<br>
<br>
<uc1:ProductsList id="ProductsList1" runat="server"></uc1:ProductsList>
