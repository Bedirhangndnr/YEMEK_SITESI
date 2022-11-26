<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Tarifler.aspx.cs" Inherits="YEMEKTARIFISITESI.Tarifler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
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
            font-size: x-large;
        }

        .auto-style3 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel3" runat="server" BackColor="#CCCCCC">
        <table style="width: 100%;">
            <tr>
                <td class="auto-style6"><strong>
                    <asp:Button ID="btn_plusOnaysizYorum" runat="server" CssClass="auto-style9" Height="30px" Text="+" Width="30px" OnClick="btn_plusOnaysizYorum_Click" />
                </strong></td>
                <td class="auto-style7">
                    <asp:Button ID="btn_minusOnaysizYorum" runat="server" CssClass="auto-style8" Height="30px" Text="-" Width="30px" OnClick="btn_minusOnaysizYorum_Click" />
                </td>
                <td>ONAYSIZ TARİF&nbsp; <strong>LİSTESİ</strong></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel4" runat="server">
        <asp:DataList ID="DataList2" runat="server" Width="100%">
            <ItemTemplate>
                <table class="auto-style2">
                    <tr>
                        <td class="auto-style5"><strong>&nbsp;<asp:Label ID="lblTarifAd" runat="server" CssClass="auto-style4" Text='<%# Eval("YemekAd") %>'></asp:Label>
                        </strong></td>
                        <td class="auto-style3">
                            <a href="TarifOnayla.aspx?Yemekid=<%#Eval("Yemekid")%>">
                                <button type="button" class="btn btn-primary">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                                        <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                        <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                    </svg>
                                </button>
                            </a>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
    <asp:Panel ID="Panel5" runat="server" BackColor="#CCCCCC">
        <table style="width: 100%;">
            <tr>
                <td class="auto-style6">
                    <asp:Button ID="btn_PlusOnayliYorum" runat="server" OnClick="btn_PlusOnayliYorum_Click1" Text="+" />
                </td>
                <td class="auto-style7">
                    <asp:Button ID="btn_minusOnayliYorum" runat="server" OnClick="btn_minusOnayliYorum_Click1" Text="-" />
                </td>
                <td>ONAYLI TARİF&nbsp; <strong>LİSTESİ</strong></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel6" runat="server">
        <asp:DataList ID="DataList3" runat="server" Width="100%">
            <ItemTemplate>
                <table class="auto-style2">
                    <tr>
                        <td class="auto-style5"><strong>&nbsp;<asp:Label ID="lblTarifAd0" runat="server" CssClass="auto-style4" Text='<%# Eval("YemekAd") %>'></asp:Label>
                        </strong></td>
                        <td class="auto-style3">
                            <a href="TarifOnerDetay.aspx?Yemekid=<%#Eval("Yemekid")%>">
                                <button type="button" class="btn btn-primary">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                                        <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                        <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                    </svg>

                                </button>
                            </a>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
</asp:Content>
