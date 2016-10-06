<%@ Control Language="vb" AutoEventWireup="false" Codebehind="OrdersAdmin.ascx.vb" Inherits="JokePoint.OrdersAdmin1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<P>
  <asp:Label id="Label1" runat="server" CssClass="AdminPageText">Show the most recent </asp:Label>
  <asp:TextBox id="recordCountTextBox" runat="server" Width="35px">20</asp:TextBox>
  <asp:Label id="Label2" runat="server" CssClass="AdminPageText">orders</asp:Label>
  <asp:Button id="ordersByRecentButton" runat="server" Text="Go!" CssClass="AdminButtonText"></asp:Button><BR>
  <asp:Label id="Label3" runat="server" CssClass="AdminPageText">Show all orders created between </asp:Label>
  <asp:TextBox id="startDateTextBox" runat="server" Width="70px"></asp:TextBox>
  <asp:Label id="Label4" runat="server" CssClass="AdminPageText">and</asp:Label>
  <asp:TextBox id="endDateTextBox" runat="server" Width="70px"></asp:TextBox>
  <asp:button id="ordersByDateButton" CssClass="AdminButtonText" runat="server" Text="Go!"></asp:button><BR>
  <asp:label id="Label5" CssClass="AdminPageText" runat="server">
      Show orders by status</asp:label>
  <asp:dropdownlist id="statusList" Runat="server"></asp:dropdownlist>
  <asp:button id="ordersByStatusButton" CssClass="AdminButtonText" runat="server" Text="Go!"></asp:button><BR>
  <asp:label id="Label6" CssClass="AdminPageText" runat="server">
      Show orders for customer with CustomerID</asp:label>
  <asp:textbox id="customerIDTextBox" runat="server" Width="35px">
      1</asp:textbox>
  <asp:button id="ordersByCustomerButton" CssClass="AdminButtonText" runat="server" Text="Go!"></asp:button><BR>
  <asp:label id="Label7" CssClass="AdminPageText" runat="server">
      Show order with OrderID</asp:label>
  <asp:textbox id="orderIDTextBox" runat="server" Width="35px">
      1</asp:textbox>
  <asp:button id="orderByIDButton" CssClass="AdminButtonText" runat="server" Text="Go!"></asp:button></P>
<P>
  <asp:Label id="errorLabel" runat="server" CssClass="AdminErrorText" EnableViewState="False"></asp:Label>
  <asp:RangeValidator id="startDateValidator" runat="server" ErrorMessage="Invalid start date." ControlToValidate="startDateTextBox"
    Display="None" MaximumValue="1/1/2005" MinimumValue="1/1/1999" Type="Date"></asp:RangeValidator>
  <asp:RangeValidator id="endDateValidator" runat="server" ErrorMessage="Invalid end date." ControlToValidate="endDateTextBox"
    Display="None" MaximumValue="1/1/2005" MinimumValue="1/1/1999" Type="Date"></asp:RangeValidator>
  <asp:requiredfieldvalidator id="customerIDValidator" Display="None" ControlToValidate="customerIDTextBox" ErrorMessage="You must enter a customer ID."
    Runat="server"></asp:requiredfieldvalidator>
  <asp:requiredfieldvalidator id="orderIDValidator" Display="None" ControlToValidate="orderIDTextBox" ErrorMessage="You must enter an order ID."
    Runat="server"></asp:requiredfieldvalidator>
  <asp:CompareValidator id="compareDatesValidator" runat="server" ErrorMessage="End date should be more recent than start date."
    ControlToValidate="startDateTextBox" Display="None" Type="Date" ControlToCompare="endDateTextBox" Operator="LessThan"></asp:CompareValidator>
  <asp:ValidationSummary id="validationSummary" runat="server" CssClass="AdminErrorText" HeaderText="Validation errors:"></asp:ValidationSummary><BR>
  <asp:DataGrid id="grid" runat="server" Width="100%" AutoGenerateColumns="False">
    <ItemStyle Font-Size="X-Small" Font-Names="Verdana" BackColor="Gainsboro"></ItemStyle>
    <HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
    <Columns>
      <asp:BoundColumn DataField="OrderID" HeaderText="Order ID"></asp:BoundColumn>
      <asp:BoundColumn DataField="DateCreated" HeaderText="Date Created"></asp:BoundColumn>
      <asp:BoundColumn DataField="DateShipped" HeaderText="Date Shipped"></asp:BoundColumn>
      <asp:BoundColumn DataField="Description" HeaderText="Status"></asp:BoundColumn>
      <asp:BoundColumn DataField="CustomerID" HeaderText="Customer ID"></asp:BoundColumn>
      <asp:BoundColumn DataField="Name" HeaderText="Customer Name"></asp:BoundColumn>
      <asp:ButtonColumn Text="View Details" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
    </Columns>
  </asp:DataGrid></P>
<P></P>
