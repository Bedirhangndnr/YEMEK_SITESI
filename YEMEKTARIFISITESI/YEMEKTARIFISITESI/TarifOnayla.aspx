<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TarifOnayla.aspx.cs" Inherits="YEMEKTARIFISITESI.TarifOnayla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <table style="width: 100%;">
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Tarif Ad</td>
                <td>
                    <asp:TextBox ID="txtbx_TarifAd" runat="server" Width="250px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Tarif Malzemeler</td>
                <td>
                    <asp:TextBox ID="txtbx_TarifMalzemeler" runat="server" Width="250px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Tarif</td>
                <td>
                    <asp:TextBox ID="txtbx_Tarif" runat="server" Height="106px" Width="250px" TextMode="MultiLine" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
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
                    <asp:TextBox ID="txtbx_TrfOnerenAdSyd" runat="server" Width="250px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Öneren Mail</td>
                <td>
                    <asp:TextBox ID="txtbx_TarifOnerenMail" runat="server" Width="250px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Kategori</td>
                <td>
                    <asp:DropDownList ID="ddl_Kategoriler" runat="server" Height="16px" Width="250px" required data-parsley-no-focus data-parsley-error-message="Please enter a message.">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:Button ID="btn_TarifOner" runat="server" OnClick="btn_TarifOner_Click" Text="Tarifi Onayla" Width="250px" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lbl_TarifOnerisiBasariliYadaDeğil" Text="Tarif önerisi başarıyla kaydedilmiştir." Visible="true" runat="server" Font-Bold="true" Font-Size="Small" />

    </asp:Panel>
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
