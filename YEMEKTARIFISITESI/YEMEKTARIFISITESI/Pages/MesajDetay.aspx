<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="MesajDetay.aspx.cs" Inherits="YEMEKTARIFISITESI.MesajDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        table {
            margin: 10px;
            height: auto;
        }

        tr {
            border-bottom: solid 2px;
            margin: 5px;
        }

            tr:nth-child(even) {
                background-color: lightgray;
            }

        th, td {
            padding: 5px;
            text-align: left;
        }

        }
        .auto-style2 {
            float: left;
            width: 20px;
        }
    </style>
    <table style="width: 100%;" class="we-table">
        <tr>
            <td class="auto-style2">Mesaj Gönderen</td>
            <td>
                <asp:Label ID="lbl_MesajGonderen" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Başlık</td>
            <td>
                <asp:Label ID="Lbl_MesajBaslik" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td cssclass="basliklar" class="auto-style2">Mesaj Adres</td>
            <td>
                <asp:Label ID="lbl_MesajAdres" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Mesaj İçerik</td>
            <td>
                <asp:Label ID="lbl_MesajIcerik" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>

    </table>
</asp:Content>
