<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="YemekEkle.aspx.cs" Inherits="YEMEKTARIFISITESI.YemekEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel3" runat="server">
        <table style="width: 100%;">
            <tr>
                <td class="auto-style6"><strong>
                    <asp:Button ID="btnPlus0" runat="server" CssClass="auto-style9" Height="30px" Text="+" Width="30px"/>
                    </strong></td>
                <td class="auto-style7">
                    <asp:Button ID="btnMinus0" runat="server" CssClass="auto-style8" Height="30px" Text="-" Width="30px"/>
                </td>
                <td><strong>YEMEK </strong>EKLEME</td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel4" runat="server">
        <table style="width: 100%;">
            <tr>
                <td class="auto-style10"></td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td>YEMEK AD</td>
                <td>
                    <asp:TextBox ID="txtbxYemekAd" runat="server" Width="300px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>YEMEK MALZEMELER</td>
                <td>
                    <asp:TextBox ID="txtbxYemekMalzemeler" runat="server" Height="90px" TextMode="MultiLine" Width="300px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">YEMEK TARİFİ</td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtbxYemekTarif" runat="server" Height="123px" TextMode="MultiLine" Width="300px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>KATEGORİ</td>
                <td>
                    <asp:DropDownList ID="ddlKategoriler" runat="server" Width="300px" required data-parsley-no-focus data-parsley-error-message="Please enter a message.">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style11"></td>
                <td class="auto-style11">
                    <asp:Button ID="btnYemekEkle" runat="server" OnClick="btnYemekEkle_Click" Text="YEMEK EKLE" />
                </td>
            </tr>
        </table>
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
            </script> required data-parsley-no-focus data-parsley-error-message="Please enter a message."
</asp:Content>
