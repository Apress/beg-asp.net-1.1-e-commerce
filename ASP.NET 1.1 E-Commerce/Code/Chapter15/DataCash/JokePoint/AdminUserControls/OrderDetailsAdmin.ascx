<%@ Control Language="vb" AutoEventWireup="false" Codebehind="OrderDetailsAdmin.ascx.vb" Inherits="JokePoint.OrderDetailsAdmin" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<P>
  <asp:Label id="Label1" runat="server" CssClass="AdminPageText" Width="150px">Order ID:</asp:Label>
  <asp:TextBox id="orderIdTextBox" runat="server" Width="400px"></asp:TextBox><BR>
  <asp:Label id="Label4" runat="server" CssClass="AdminPageText" Width="150px">Date Created:</asp:Label>
  <asp:TextBox id="dateCreatedTextBox" runat="server" Width="400px"></asp:TextBox><BR>
  <asp:Label id="Label5" runat="server" CssClass="AdminPageText" Width="150px">Date Shipped:</asp:Label>
  <asp:TextBox id="dateShippedTextBox" runat="server" Width="400px"></asp:TextBox><BR>
  <asp:label id="Label6" CssClass="AdminPageText" Width="150px" runat="server">
      Status:</asp:label>
  <asp:textbox id="statusTextBox" Width="400px" runat="server" ReadOnly="True"></asp:textbox><BR>
  <asp:label id="Label7" CssClass="AdminPageText" Width="150px" runat="server">
      AuthCode:</asp:label>
  <asp:textbox id="authCodeTextBox" Width="400px" runat="server" ReadOnly="True"></asp:textbox><BR>
  <asp:label id="Label8" CssClass="AdminPageText" Width="150px" runat="server">
      Reference:</asp:label>
  <asp:textbox id="referenceTextBox" Width="400px" runat="server" ReadOnly="True"></asp:textbox></P>
<P>
  <asp:button id="processButton" CssClass="AdminButtonText" Width="302px" runat="server" Text="Process Button"></asp:button></P>
<P><asp:label id="Label2" CssClass="AdminPageText" Width="150px" runat="server">
      Order Details:</asp:label>
  <asp:DataGrid id="orderDetailsGrid" runat="server" Width="100%" AutoGenerateColumns="False">
    <ItemStyle Font-Size="X-Small" Font-Names="verdana" BackColor="Gainsboro"></ItemStyle>
    <HeaderStyle Font-Size="X-Small" Font-Names="verdana" Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
    <Columns>
      <asp:BoundColumn DataField="ProductID" HeaderText="Product ID"></asp:BoundColumn>
      <asp:BoundColumn DataField="ProductName" HeaderText="Product Name"></asp:BoundColumn>
      <asp:BoundColumn DataField="Quantity" HeaderText="Quantity"></asp:BoundColumn>
      <asp:BoundColumn DataField="UnitCost" HeaderText="Unit Cost"></asp:BoundColumn>
      <asp:BoundColumn DataField="Subtotal" HeaderText="Subtotal"></asp:BoundColumn>
    </Columns>
  </asp:DataGrid></P>
<P><asp:label id="Label11" CssClass="AdminPageText" Width="150px" runat="server">
      Customer Details:</asp:label>
  <asp:datagrid id="customerGrid" Width="100%" runat="server" AutoGenerateColumns="False">
    <ItemStyle Font-Size="X-Small" Font-Names="Verdana" BackColor="Gainsboro"></ItemStyle>
    <HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
    <Columns>
      <asp:BoundColumn DataField="CustomerID" HeaderText="ID"></asp:BoundColumn>
      <asp:BoundColumn DataField="Name" HeaderText="Name"></asp:BoundColumn>
      <asp:BoundColumn DataField="Email" HeaderText="EMail"></asp:BoundColumn>
      <asp:BoundColumn DataField="Address1" HeaderText="Address1"></asp:BoundColumn>
      <asp:BoundColumn DataField="Address2" HeaderText="Address2"></asp:BoundColumn>
      <asp:BoundColumn DataField="City" HeaderText="Town/City"></asp:BoundColumn>
      <asp:BoundColumn DataField="Region" HeaderText="Region/State"></asp:BoundColumn>
      <asp:BoundColumn DataField="PostalCode" HeaderText="Postal Code/ZIP"></asp:BoundColumn>
      <asp:BoundColumn DataField="Country" HeaderText="Country"></asp:BoundColumn>
      <asp:BoundColumn DataField="Phone" HeaderText="Phone"></asp:BoundColumn>
    </Columns>
  </asp:datagrid></P>
<P><asp:label id="Label3" CssClass="AdminPageText" Width="150px" runat="server">
      Audit Trail:</asp:label>
  <asp:datagrid id="auditGrid" Width="100%" runat="server" AutoGenerateColumns="False">
    <ItemStyle Font-Size="X-Small" Font-Names="Verdana" BackColor="Gainsboro"></ItemStyle>
    <HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
    <Columns>
      <asp:BoundColumn DataField="DateStamp" HeaderText="Date Recorded"></asp:BoundColumn>
      <asp:BoundColumn DataField="Message" HeaderText="Message"></asp:BoundColumn>
      <asp:BoundColumn DataField="MessageNumber" HeaderText="Message Number"></asp:BoundColumn>
    </Columns>
  </asp:datagrid></P>
