<%@ Control Language="vb" AutoEventWireup="false" Codebehind="OrdersAdmin.ascx.vb" Inherits="JokePoint.OrdersAdmin1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<P>
	<asp:Label id="Label1" runat="server" CssClass="AdminPageText">Show the most recent</asp:Label>
	<asp:TextBox id="recordCountTextBox" runat="server" Width="35px">20</asp:TextBox>
	<asp:Label id="Label2" runat="server" CssClass="AdminPageText">records</asp:Label>
	<asp:Button id="mostRecentButton" runat="server" Text="Go!" CssClass="AdminButtonText"></asp:Button><BR>
	<asp:Label id="Label3" runat="server" CssClass="AdminPageText">Show all records created between</asp:Label>
	<asp:TextBox id="startDateTextBox" runat="server" Width="70px"></asp:TextBox>
	<asp:Label id="Label4" runat="server">and</asp:Label>
	<asp:TextBox id="endDateTextBox" runat="server" Width="70px"></asp:TextBox>
	<asp:Button id="betweenDatesButton" runat="server" Text="Go!" CssClass="AdminButtonText"></asp:Button><BR>
	<asp:Label id="Label5" runat="server" CssClass="AdminPageText">Show all unverified orders that have not been canceled (need to either verify or cancel them)</asp:Label>
	<asp:Button id="unverifiedOrdersButton" runat="server" Text="Go!" CssClass="AdminButtonText"></asp:Button><BR>
	<asp:Label id="Label6" runat="server" CssClass="AdminPageText">Show all verified orders that are not completed (we need to ship them)</asp:Label>
	<asp:Button id="verifiedOrdersButton" runat="server" Text="Go!" CssClass="AdminButtonText"></asp:Button></P>
<P>
	<asp:Label id="errorLabel" runat="server" CssClass="AdminErrorText" EnableViewState="False"></asp:Label>
	<asp:RangeValidator id="startDateValidator" runat="server" ErrorMessage="Invalid start date." ControlToValidate="startDateTextBox"
		Display="None" MaximumValue="1/1/2005" MinimumValue="1/1/1999" Type="Date"></asp:RangeValidator>
	<asp:RangeValidator id="endDateValidator" runat="server" ErrorMessage="Invalid end date." ControlToValidate="endDateTextBox"
		Display="None" MaximumValue="1/1/2005" MinimumValue="1/1/1999" Type="Date"></asp:RangeValidator>
	<asp:CompareValidator id="compareDatesValidator" runat="server" ErrorMessage="Start date should be more recent than end date."
		ControlToValidate="startDateTextBox" Display="None" Type="Date" ControlToCompare="endDateTextBox"
		Operator="LessThan"></asp:CompareValidator>
	<asp:ValidationSummary id="validationSummary" runat="server" HeaderText="Validation errors:" CssClass="AdminErrorText"></asp:ValidationSummary><BR>
	<asp:DataGrid id="grid" runat="server" Width="100%" AutoGenerateColumns="False">
		<ItemStyle Font-Size="X-Small" Font-Names="Verdana" BackColor="Gainsboro"></ItemStyle>
		<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
		<Columns>
			<asp:BoundColumn DataField="OrderID" ReadOnly="True" HeaderText="Order ID"></asp:BoundColumn>
			<asp:BoundColumn DataField="DateCreated" ReadOnly="True" HeaderText="Date Created"></asp:BoundColumn>
			<asp:BoundColumn DataField="DateShipped" ReadOnly="True" HeaderText="Date Shipped"></asp:BoundColumn>
			<asp:TemplateColumn HeaderText="Verified">
				<ItemTemplate>
					<asp:CheckBox id="Checkbox1" Text="" runat="server" Enabled="False" Checked='<%# DataBinder.Eval(Container, "DataItem.Verified") %>'>
					</asp:CheckBox>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Completed">
				<ItemTemplate>
					<asp:CheckBox id="Checkbox2" Text="" runat="server" Enabled="False" Checked='<%# DataBinder.Eval(Container, "DataItem.Completed") %>'>
					</asp:CheckBox>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Canceled">
				<ItemTemplate>
					<asp:CheckBox id="Checkbox3" Text="" runat="server" Enabled="False" Checked='<%# DataBinder.Eval(Container, "DataItem.Canceled") %>'>
					</asp:CheckBox>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:BoundColumn DataField="CustomerName" ReadOnly="True" HeaderText="Customer"></asp:BoundColumn>
			<asp:ButtonColumn Text="View Details " ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
		</Columns>
	</asp:DataGrid></P>
