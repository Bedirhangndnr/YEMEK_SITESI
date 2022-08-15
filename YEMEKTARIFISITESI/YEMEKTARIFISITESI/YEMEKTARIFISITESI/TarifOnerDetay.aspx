
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TarifOnerDetay.aspx.cs" Inherits="YEMEKTARIFISITESI.Tar_fOnerDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 144px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Tarif Ad</td>
                <td>
                    <asp:TextBox ID="txtbx_TarifAd" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Tarif Malzemeler</td>
                <td>
                    <asp:TextBox ID="txtbx_TarifMalzemeler" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Tarif</td>
                <td>
                    <asp:TextBox ID="txtbx_Tarif" runat="server" Height="106px" Width="250px" TextMode="MultiLine"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Tarif Resim</td>
                <td>
                    <asp:FileUpload ID="fu_TarifResim" runat="server" Width="250px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Öneren Ad Soyad</td>
                <td>
                    <asp:TextBox ID="txtbx_TrfOnerenAdSyd" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Öneren Mail</td>
                <td>
                    <asp:TextBox ID="txtbx_TarifOnerenMail" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Kategori</td>
                <td>
                    <asp:DropDownList ID="ddl_Kategoriler" runat="server" Height="16px" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:Button ID="btn_TarifOner" runat="server" OnClick="btn_TarifOner_Click" Text="Tarifi Onayla/Güncelle" Width="250px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>