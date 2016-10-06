<%@ Control Language="vb" AutoEventWireup="false" Codebehind="OrderDetailsAdmin.ascx.vb" Inherits="JokePoint.OrderDetailsAdmin" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<P>
	<asp:Label id="Label1" runat="server" CssClass="ListDescription" Width="150px">Order ID:</asp:Label>
	<asp:Label id="orderIdLabel" runat="server" CssClass="ListDescription">Label</asp:Label><BR>
	<asp:Label id="Label3" runat="server" CssClass="AdminPageText" Width="150px">Total Amount:</asp:Label>
	<asp:Label id="totalAmountLabel" runat="server" CssClass="ProductPrice">Label</asp:Label><BR>
	<asp:Label id="Label5" runat="server" CssClass="AdminPageText" Width="150px">Date Created:</asp:Label>
	<asp:TextBox id="dateCreatedTextBox" runat="server" Width="400px"></asp:TextBox><BR>
	<asp:Label id="Label6" runat="server" CssClass="AdminPageText" Width="150px">Date Shipped:</asp:Label>
	<asp:TextBox id="dateShippedTextBox" runat="server" Width="400px"></asp:TextBox><BR>
	<asp:Label id="Label7" runat="server" CssClass="AdminPageText" Width="150px">Verified:</asp:Label>
	<asp:CheckBox id="verifiedCheck" runat="server"></asp:CheckBox><BR>
	<asp:Label id="Label8" runat="server" CssClass="AdminPageText" Width="150px">Completed:</asp:Label>
	<asp:CheckBox id="completedCheck" runat="server"></asp:CheckBox><BR>
	<asp:Label id="Label9" runat="server" CssClass="AdminPageText" Width="150px">Canceled:</asp:Label>
	<asp:CheckBox id="canceledCheck" runat="server"></asp:CheckBox><BR>
	<asp:Label id="Label10" runat="server" CssClass="AdminPageText" Width="150px">Comments:</asp:Label>
	<asp:TextBox id="commentsTextBox" runat="server" Width="400px"></asp:TextBox><BR>
	<asp:Label id="Label11" runat="server" CssClass="AdminPageText" Width="150px">Customer Name:</asp:Label>
	<asp:TextBox id="customerNameTextBox" runat="server" Width="400px"></asp:TextBox><BR>
	<asp:Label id="Label12" runat="server" CssClass="AdminPageText" Width="150px">Shipping Address:</asp:Label>
	<asp:TextBox id="shippingAddressTextBox" runat="server" Width="400px"></asp:TextBox><BR>
	<asp:Label id="Label99" runat="server" CssClass="AdminPageText" Width="150px">Customer Email:</asp:Label>
	<asp:TextBox id="customerEmailTextBox" runat="server" Width="400px"></asp:TextBox></P>
<P>
	<asp:Button id="editButton" runat="server" Text="Edit" CssClass="AdminButtonText" Width="100px"></asp:Button>
	<asp:Button id="updateButton" runat="server" Text="Update" CssClass="AdminButtonText" Width="100px"></asp:Button>
	<asp:Button id="cancelButton" runat="server" Text="Cancel" CssClass="AdminButtonText" Width="100px"></asp:Button><BR>
	<asp:Button id="markAsVerifiedButton" runat="server" Text="Mark this order as Verified" CssClass="AdminButtonText"
		Width="308px"></asp:Button><BR>
	<asp:Button id="markAsCompletedButton" runat="server" Text="Mark this order as Completed" CssClass="AdminButtonText"
		Width="308px"></asp:Button><BR>
	<asp:Button id="markAsCanceledButton" runat="server" Text="Mark this order as Canceled" CssClass="AdminButtonText"
		Width="308px"></asp:Button></P>
<P>
	<asp:DataGrid id="grid" runat="server" Width="100%" AutoGenerateColumns="False">
		<ItemStyle Font-Size="X-Small" Font-Names="verdana" BackColor="Gainsboro"></ItemStyle>
		<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
		<Columns>
			<asp:BoundColumn DataField="ProductID" HeaderText="Product ID"></asp:BoundColumn>
			<asp:BoundColumn DataField="ProductName" HeaderText="Product Name"></asp:BoundColumn>
			<asp:BoundColumn DataField="Quantity" HeaderText="Quantity"></asp:BoundColumn>
			<asp:BoundColumn DataField="UnitCost" HeaderText="Unit Cost" DataFormatString="{0:c}"></asp:BoundColumn>
			<asp:BoundColumn DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:c}"></asp:BoundColumn>
		</Columns>
	</asp:DataGrid></P>
