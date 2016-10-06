<%@ Register TagPrefix="uc1" TagName="SearchBox" Src="UserControls/SearchBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CategoriesList" Src="UserControls/CategoriesList.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="UserControls/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DepartmentsList" Src="UserControls/DepartmentsList.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Checkout.aspx.vb" Inherits="JokePoint.Checkout" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
    <title>Checkout</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="JokePoint.css" type="text/css" rel="stylesheet">
  </HEAD>
  <body>
    <form id="Form1" method="post" runat="server">
      <table height="100%" cellSpacing="0" cellPadding="0" width="770" border="0">
        <tr>
          <td vAlign="top" width="190" height="100%">
            <table height="100%" cellSpacing="0" cellPadding="0" width="190" border="0">
              <tr>
                <td vAlign="top" height="100%">
                  <uc1:departmentslist id="DepartmentsList1" runat="server"></uc1:departmentslist>
                  <uc1:categorieslist id="CategoriesList1" runat="server"></uc1:categorieslist>
                  <uc1:searchbox id="SearchBox1" runat="server"></uc1:searchbox>
                  <br>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:imagebutton id="viewCartButton" runat="server" ImageUrl="Images/ViewCart.gif"></asp:imagebutton>
                </td>
              </tr>
            </table>
          </td>
          <td vAlign="top" width="550"><br>
            <table>
              <tr>
                <td>
                  <uc1:Header id="Header1" runat="server"></uc1:Header></td>
              <tr>
                <td>
                  <p align="right">
                    <b>User logged in:</b>
                    <asp:label id="txtUserName" runat="server"></asp:label><br>
                    <asp:button id="logOutButton" runat="server" Text="Log Out"></asp:button><br>
                    <img src="Images/1n.gif" border="0" width="350" height="1">
                  </p>
                </td>
              </tr>
              <tr>
                <td id="pageContentsCell" runat="server">
                  <P><asp:label id="Label1" runat="server" CssClass="ListDescription">
                   Your order consists of the following items:
               </asp:label></P>
                  <P><asp:datagrid id="grid" runat="server" AutoGenerateColumns="False" Width="100%">
                      <ItemStyle Font-Size="X-Small" Font-Names="Verdana" BackColor="Gainsboro"></ItemStyle>
                      <HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
                      <Columns>
                        <asp:BoundColumn DataField="Name" ReadOnly="True" HeaderText="Product Name"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Price" ReadOnly="True" HeaderText="Price"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Quantity" ReadOnly="True" HeaderText="Quantity"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Subtotal" ReadOnly="True" HeaderText="Subtotal"></asp:BoundColumn>
                      </Columns>
                    </asp:datagrid></P>
                  <P>
                    Total amount:
                    <asp:label id="totalAmountLabel" runat="server" CssClass="ProductPrice"></asp:label>
                    <br>
                    <br>
                    <asp:label id="lblCreditCardNote" Runat="server"></asp:label>
                    <br>
                    <br>
                    <asp:label id="lblAddress" Runat="server"></asp:label>
                    <br>
                    <br>
                    <asp:button id="changeDetailsButton" runat="server" Text="Change Customer Details"></asp:button>
                    <asp:button id="addCreditCardButton" runat="server" Text="Add Credit Card"></asp:button>
                    <asp:button id="addAddressButton" runat="server" Text="Add Address"></asp:button>
                    <br>
                    <br>
                    <asp:button id="placeOrderButton" runat="server" Text="Place Order"></asp:button>
                    <asp:button id="cancelOrderButton" runat="server" Text="Continue Shopping"></asp:button>
                  </P>
                </td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </form>
  </body>
</HTML>
