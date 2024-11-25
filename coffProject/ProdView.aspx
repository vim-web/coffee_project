<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProdView.aspx.cs" Inherits="coffProject.ProdView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 175px;
        }
        .auto-style3 {
            height: 31px;
        }
        .auto-style4 {
            width: 175px;
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:DataList ID="DataList1" runat="server" GridLines="Both" RepeatColumns="4" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="10px" CellPadding="10" CellSpacing="10" HorizontalAlign="Center">
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <ItemTemplate>
                            <table class="auto-style1">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("pro_nme") %>'></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="auto-style2">
                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="118px" Width="112px" ImageUrl='<%# Eval("pro_pho") %>' OnClick="ImageButton1_Click" CommandArgument='<%# Eval("pro_id") %>' />
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("pro_discrip") %>'></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style3"></td>
                                    <td class="auto-style4">
                                        &nbsp;</td>
                                    <td class="auto-style3"></td>
                                    <td class="auto-style3"></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label5" runat="server" Text="Price :"></asp:Label>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("pro_price") %>'></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    </asp:DataList>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
