<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ProductsAdmin.ascx.vb" Inherits="JokePoint.ProductsAdmin" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<P>
	<asp:Label id="firstLabel" CssClass="AdminPageText" runat="server">Editing products for category:</asp:Label>
	<asp:LinkButton id="categoryNameLink" CssClass="ListDescription" runat="server"></asp:LinkButton></P>
<P>
	<asp:DataGrid id="productsGrid" runat="server" AutoGenerateColumns="False">
		<ItemStyle Font-Size="X-Small" Font-Names="verdana" BackColor="Gainsboro"></ItemStyle>
		<HeaderStyle Font-Size="X-Small" Font-Names="verdana" Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn HeaderText="Product Image">
				<ItemTemplate>
					<img border="0" height="50" src='ProductImages/<%# DataBinder.Eval(Container, "DataItem.ImagePath") %>'>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:BoundColumn DataField="Name" HeaderText="Product Name"></asp:BoundColumn>
			<asp:TemplateColumn HeaderText="Product Description">
				<ItemTemplate>
					<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
					</asp:Label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox id=editDescriptionTextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>' TextMode="MultiLine" Width="250" Rows="3">
					</asp:TextBox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:BoundColumn DataField="Price" HeaderText="Price"></asp:BoundColumn>
			<asp:BoundColumn DataField="ImagePath" HeaderText="Image Path"></asp:BoundColumn>
			<asp:TemplateColumn HeaderText="Dept.prom.">
				<ItemTemplate>
					<asp:CheckBox Text="" Enabled="False" runat="server" ID="Checkbox1" Checked='<%# DataBinder.Eval(Container, "DataItem.OnDepartmentPromotion") %>' >
					</asp:CheckBox>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:CheckBox id="deptPromListCheck" Text="" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.OnDepartmentPromotion") %>'>
					</asp:CheckBox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Cat.prom.">
				<ItemTemplate>
					<asp:CheckBox Text="" Enabled="False" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.OnCatalogPromotion") %>' ID="Checkbox2">
					</asp:CheckBox>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:CheckBox id="catPromListCheck" Text="" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.OnCatalogPromotion") %>'>
					</asp:CheckBox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:EditCommandColumn ButtonType="PushButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
			<asp:ButtonColumn Text="Select" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
		</Columns>
	</asp:DataGrid></P>
<P>
	<asp:Label id="newProductLabel" CssClass="AdminPageText" runat="server">Create a new product and add it to the selected category:</asp:Label><BR>
	<asp:TextBox id="nameTextBox" runat="server">(name)</asp:TextBox>
	<asp:TextBox id="descriptionTextBox" runat="server">(description)</asp:TextBox>
	<asp:TextBox id="priceTextBox" runat="server">(price)</asp:TextBox>
	<asp:CheckBox id="departmentPromotionCheck" CssClass="AdminPageText" runat="server" Text="Department Promotion"></asp:CheckBox>
	<asp:CheckBox id="catalogPromotionCheck" CssClass="AdminPageText" runat="server" Text="Catalog Promotion"></asp:CheckBox>
	<asp:Button id="createProductButton" CssClass="AdminButtonText" runat="server" Text="Add"></asp:Button>&nbsp;</P>
