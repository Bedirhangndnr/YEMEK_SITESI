<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Iletisim.aspx.cs" Inherits="YEMEKTARIFISITESI.Iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified" id="tblForm" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td><h3>Mesaj paneli </h3></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtGonderenAdSoyad" runat="server" style="width:30%" ClientIDMode="Static" placeholder="Ad Soyad"  required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtGonderenMail" runat="server" style="width:30%" ClientIDMode="Static" CssClass="required" placeholder="Mail" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtKonu" runat="server" style="width:30%" ClientIDMode="Static" CssClass="required" placeholder="Konu" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtMesaj" runat="server" style="width:30%" ClientIDMode="Static" CssClass="required" placeholder="Mesaj" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                    <asp:Button ID="Button1" style="margin-block: 5px" Text="Tarifi Gönder" runat="server" OnClick="btnMsjGndr_Click" CssClass="btn btn-success" OnClientClick="ClearTB()" Width="105px" />
                    ,<br />
                    <asp:Label ID="lbl_isSucces" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
<script>
    function ClearTB() {
        document.getElementById("txtGonderenAdSoyad").value = document.getElementById("txtGonderenAdSoyad").value.replace(/^\s+/, '').replace(/\s+$/, '');
        document.getElementById("txtGonderenMail").value = document.getElementById("txtGonderenMail").value.replace(/^\s+/, '').replace(/\s+$/, '');
        document.getElementById("txtKonu").value = document.getElementById("txtKonu").value.replace(/^\s+/, '').replace(/\s+$/, '');
        document.getElementById("txtMesaj").value = document.getElementById("txtMesaj").value.replace(/^\s+/, '').replace(/\s+$/, ''); ClientIDMode = "Static"
    }
</script>
</asp:Content>
