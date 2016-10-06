<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DepartmentsAdmin.ascx.vb" Inherits="JokePoint.DepartmentsAdmin" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:datagrid id="departmentsGrid" AutoGenerateColumns="False" Width="100%" runat="server">
	<ItemStyle Font-Size="X-Small" Font-Names="Verdana" BackColor="Gainsboro"></ItemStyle>
	<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
	<Columns>
		<asp:BoundColumn DataField="Name" HeaderText="Department Name"></asp:BoundColumn>
		<asp:TemplateColumn HeaderText="Department Description">
			<ItemTemplate>
				<asp:Label id=Label3 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
				</asp:Label>
			</ItemTemplate>
			<EditItemTemplate>
				<asp:TextBox id=editDescriptionTextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>' TextMode="MultiLine" Width="100%" Rows="3">
				</asp:TextBox>
			</EditItemTemplate>
		</asp:TemplateColumn>
		<asp:EditCommandColumn ButtonType="PushButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
		<asp:ButtonColumn Text="Edit Categories" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
		<asp:ButtonColumn Text="Delete" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
	</Columns>
</asp:datagrid><br>
<asp:label id="Label1" runat="server" CssClass="AdminPageText">Add new department:</asp:label>&nbsp;<asp:textbox id="nameTextBox" runat="server">(department name)</asp:textbox>&nbsp;<asp:textbox id="descriptionTextBox" runat="server">(department description)</asp:textbox>&nbsp;<asp:button id="addDepartmentButton" runat="server" CssClass="AdminButtonText" Text="Add"></asp:button>
