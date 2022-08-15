<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Yorumlar.aspx.cs" EnableEventValidation="false" Inherits="YEMEKTARIFISITESI.Yorumlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style6 {
            width: 48px;
        }

        .auto-style7 {
            width: 16px;
        }

        .auto-style2 {
            width: 100%;
            text-align: left;
        }

        .auto-style5 {
            width: 287px;
        }

        .auto-style4 {
            font-size: x-large;
        }

        .auto-style3 {
            text-align: right;
        }

        .auto-style10 {
            margin-left: 0px;
        }

        .scroll-list {
            height: 600px !important;
            overflow: scroll;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:DropDownList ID="ddlOnayTuru" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlOnayTuru_SelectedIndexChanged" runat="server">
            <asp:ListItem Text="Seçiniz" Value="0" />
            <asp:ListItem Text="Onaylı" Value="1" />
            <asp:ListItem Text="Onaysız" Value="-1" />
        </asp:DropDownList>
    </div>
    <br />
    <div class="scroll-list">

        <asp:DataList ID="DataList1" runat="server" Width="100%" CssClass="auto-style10">
            <ItemTemplate>

                <table class="auto-style2 table">
                    <tr>
                        <td class="auto-style5"><strong>
                            <asp:Label ID="lblKategoriIsım0" runat="server" CssClass="auto-style4" Text='<%# Eval("YorumAdSoyad") %>'></asp:Label>
                        </strong></td>
                        <td class="auto-style5"><strong>
                            <asp:Label ID="lblOnayDurum" runat="server" CssClass="auto-style4" Text='<%# Eval("YorumDurum") %>'></asp:Label>
                        </strong></td>
                        <td class="auto-style3">
                            <asp:Button Text="Onayla" CssClass="btn btn-success" runat="server" OnCommand="Onayla" CommandArgument='<%# Eval("Yorumid") %>' />
                        </td>
                        <td class="auto-style3">
                            <asp:Button Text="Onay İptal" CssClass="btn btn-warning" runat="server" OnCommand="OnayIptal" CommandArgument='<%# Eval("Yorumid") %>' />
                        </td>
                        <td class="auto-style3">
                            <a href="YorumDetay.aspx?Yorumid=<%#Eval("Yorumid")%>" class="btn btn-primary">Detay</a>
                        </td>
                        <td class="auto-style3">
                            <asp:LinkButton Text="Sil" OnClientClick="return confirm('Gerçekten Silmek İstediğinizden Emnin Misiniz?');" CssClass="btn btn-danger" runat="server" OnCommand="Sil" CommandArgument='<%# Eval("Yorumid") %>'>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
