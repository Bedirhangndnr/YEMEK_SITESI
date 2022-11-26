<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="YorumDetay.aspx.cs" Inherits="YEMEKTARIFISITESI.YorumDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 156px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Ad Soyad</td>
            <td>
                <asp:TextBox ID="txtbx_AdSoyad" runat="server" Width="250px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Mail</td>
            <td>
                <asp:TextBox ID="txtbx_Mail" runat="server" Width="250px" type="email" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">İcerik</td>
            <td>
                <asp:TextBox ID="txtbx_Icerik" runat="server" Height="61px" TextMode="MultiLine" Width="250px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Yemek</td>
            <td>
                <asp:TextBox ID="txtbx_Yemek" runat="server" Width="250px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Button ID="btn_Onayla" runat="server" OnClick="btn_Onayla_Click" Text="Onayla" />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
            <script>
            (function () {

                $('.floatlabel').SmartPlaceholders();

                var $form = $('#form'),
                    $success = $('.success'),
                    $smart = $('.smart-placeholder-wrapper'),
                    parsley = $form.parsley();

                $form.submit(function (e) {
                    e.preventDefault();
                    if (parsley.validationResult == true) {
                        var name = $('#name').val();
                        success(name);
                        clearForm(this);
                    }
                });

                function success(name) {
                    $('.name').text(name);
                    $("html, body").animate({ scrollTop: 0 }, 300);
                    $success
                        .slideDown()
                        .delay(3000)
                        .slideUp();
                }

                function clearForm(el) {
                    el.reset();
                    $smart.removeClass('focused, populated');
                }

            })();
            </script>
</asp:Content>
