<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CategoriesAdmin.ascx.vb" Inherits="JokePoint.CategoriesAdmin" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<P>
	<asp:Label id="Label1" runat="server" CssClass="AdminPageText">Edit categories for department:</asp:Label>
	<asp:LinkButton id="departmentNameLink" runat="server" CssClass="ListDescription"></asp:LinkButton></P>
<P>
	<asp:DataGrid id="categoriesGrid" runat="server" AutoGenerateColumns="False" Width="100%">
		<ItemStyle Font-Size="X-Small" Font-Names="verdana" BackColor="Gainsboro"></ItemStyle>
		<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
		<Columns>
			<asp:BoundColumn DataField="Name" HeaderText="Category Name"></asp:BoundColumn>
			<asp:TemplateColumn HeaderText="Category Description">
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
			<asp:ButtonColumn Text="Edit Products" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
			<asp:ButtonColumn Text="Delete" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
		</Columns>
	</asp:DataGrid></P>
<P>
	<asp:Label id="Label2" runat="server" CssClass="AdminPageText">Add new category:</asp:Label>
	<asp:TextBox id="nameTextBox" runat="server">(category name)</asp:TextBox>
	<asp:TextBox id="descriptionTextBox" runat="server">(category description)</asp:TextBox>
	<asp:Button id="addCategoryButton" runat="server" Text="Add" CssClass="AdminButtonText"></asp:Button></P>
