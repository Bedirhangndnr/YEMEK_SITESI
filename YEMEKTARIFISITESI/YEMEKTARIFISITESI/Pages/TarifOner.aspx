<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site1.Master" AutoEventWireup="true" CodeBehind="TarifOner.aspx.cs" Inherits="YEMEKTARIFISITESI.TarifOner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 26px;
        }

        .auto-style3 {
            height: 150px;
        }

        .auto-style4 {
            margin-bottom: 7px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tblForm" border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <th>Tarif Önerisi Formu</th>
        </tr>
        <tr>
            <td>Tarif Ad</td>
            <td>
                <asp:TextBox ID="txtTarifAd" runat="server" ClientIDMode="Static" Width="247px" required data-parsley-no-focus data-parsley-error-message="Please enter a message.">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Malzemeler</td>
            <td>
                <asp:TextBox ID="txtTarifMalzemeler" runat="server" ClientIDMode="Static" Height="74px" TextMode="MultiLine" Width="247px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Yapılış</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtTarifYapilis" runat="server" ClientIDMode="Static"  Height="140px" TextMode="MultiLine" Width="247px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox></td>

        </tr>
        <tr>
            <td>Resim</td>
            <td>
                <asp:FileUpload ID="fuTarifResim" runat="server" Width="247px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Öneren kişi ad soyad:</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtTarifOneri" runat="server" ClientIDMode="Static" Width="247px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox></td>

        </tr>
        <tr>
            <td>Mail Adresi</td>
            <td>
                <asp:TextBox ID="txtTarifMail" runat="server" ClientIDMode="Static" Width="247px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="Button1" Text="Tarifi Gönder" runat="server" ClientIDMode="Static" OnClick="btnTarifOner_Click" required data-parsley-no-focus data-parsley-error-message="Please enter a message." OnClientClick="ClearTB()" Width="105px" BackColor="#66FFCC" /></td>
            <td></td>
        </tr>
    </table>
    <asp:Label ID="lbl_TarifOnerisiBasariliYadaDeğil" Text="Tarif önerisi başarıyla kaydedilmiştir." Visible="true" runat="server" Font-Bold="true" Font-Size="Small" />
            <script>
                function ClearTB() {
                    document.getElementById("txtTarifAd").value = document.getElementById("txtTarifAd").value.replace(/^\s+/, '').replace(/\s+$/, '');
                    document.getElementById("txtTarifMalzemeler").value = document.getElementById("txtTarifMalzemeler").value.replace(/^\s+/, '').replace(/\s+$/, '');
                    document.getElementById("txtTarifYapilis").value = document.getElementById("txtTarifYapilis").value.replace(/^\s+/, '').replace(/\s+$/, '');
                    document.getElementById("txtTarifOneri").value = document.getElementById("txtTarifOneri").value.replace(/^\s+/, '').replace(/\s+$/, '');
                    document.getElementById("txtTarifMail").value = document.getElementById("txtTarifMail").value.replace(/^\s+/, '').replace(/\s+$/, '');
                }
            </script>
</asp:Content>
