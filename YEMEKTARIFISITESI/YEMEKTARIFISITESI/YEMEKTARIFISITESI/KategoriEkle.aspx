<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="YEMEKTARIFISITESI.KategoriEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <div style="margin-bottom: 10px">
            <strong>KATEGORİ EKLEME</strong>
        </div>
    </table>
    <table id="tblForm" style="width: 100%;">
        <tr>
            <td class="auto-style10"></td>
            <td class="auto-style10"></td>
        </tr>
        <tr>
            <td>KATEGORİ AD</td>
            <td>
                <asp:TextBox ID="txtbx_KategoriAd" runat="server" ClientIDMode="Static" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>KATEGORİ İKON</td>
            <td>
                <asp:FileUpload ID="fu_kategoriResim" runat="server" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnKategoriEkle" runat="server" Text="KATEGORİ EKLE" OnClick="btnKategoriEkle_Click" OnClientClick="ClearTB()" />

            </td>
        </tr>
    </table>
<script>
    function ClearTB() {
        document.getElementById("txtbx_KategoriAd").value = document.getElementById("txtbx_KategoriAd").value.replace(/^\s+/, '').replace(/\s+$/, '');
    }
</script>
</asp:Content>

