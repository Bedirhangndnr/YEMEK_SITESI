<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="GununYemegiAdmin.aspx.cs" Inherits="YEMEKTARIFISITESI.GununYemegiAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .yemek-listesi {
            height: 300px !important;
            overflow: scroll;
        }

        .auto-style6 {
            width: 48px;
        }

        .auto-style9 {
            font-weight: bold;
            font-size: large;
        }

        .auto-style7 {
            width: 16px;
        }

        .auto-style8 {
            font-weight: bold;
            font-size: large;
            margin-left: 0px;
        }

        .auto-style2 {
            width: 100%;
        }

        .auto-style5 {
            width: 287px;
            text-align: left;
        }

        .auto-style4 {
            font-size: medium;
            text-align: right;

        }

        .auto-style3 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" BackColor="#CCCCCC">
        <table style="width: 100%;">
            <tr>
                <td class="auto-style6"><strong>
                    <asp:Button ID="btnPlus" runat="server" CssClass="auto-style9" Height="30px" Text="+" Width="30px" OnClick="btnPlus_Click" />
                </strong>
                </td>
                <td class="auto-style7">
                    <asp:Button ID="btnMinus" runat="server" CssClass="auto-style8" Height="30px" Text="-" Width="30px" OnClick="btnMinus_Click" />
                </td>
                <td><strong>YEMEK LİSTESİ</strong></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <div class="yemek-listesi">

            <asp:DataList ID="DataList1" runat="server" Width="100%">
                <ItemTemplate>
                    <table class="auto-style2">
                        <tr>
                            <td class="auto-style5"><strong>
                            <asp:Label ID="lblYemekIsım" runat="server" CssClass="auto-style4" Text='<%# Eval("YemekAd") %>'></asp:Label>
                            </strong></td>
                            <td class="auto-style3"><a href="YemekDuzenle.aspx?Yemekid=<%#Eval("Yemekid") %>">
                                <button type="button" class="btn btn-primary">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pass-fill" viewBox="0 0 16 16">
                                        <path d="M10 0a2 2 0 1 1-4 0H3.5A1.5 1.5 0 0 0 2 1.5v13A1.5 1.5 0 0 0 3.5 16h9a1.5 1.5 0 0 0 1.5-1.5v-13A1.5 1.5 0 0 0 12.5 0H10ZM4.5 5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1 0-1Zm0 2h4a.5.5 0 0 1 0 1h-4a.5.5 0 0 1 0-1Z" />
                                    </svg>
                                </button>
                            </a></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </asp:Panel>
</asp:Content>
