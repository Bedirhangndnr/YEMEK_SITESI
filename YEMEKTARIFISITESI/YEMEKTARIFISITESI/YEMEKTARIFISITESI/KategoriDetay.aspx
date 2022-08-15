<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="KategoriDetay.aspx.cs" Inherits="YEMEKTARIFISITESI.KategorilerDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row" style="width=1000px">
    <asp:DataList ID="DataList2" runat="server">
        <ItemTemplate>
            Malzemeler:xx
            <asp:Label ID="lbl_Malzemeler" runat="server" Text="Label" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:Label>
            <br />
            Yemek Tarifi:
            <asp:Label ID="lbl_YemekTarifi" runat="server" Text="Label" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:Label>
            <br />
            Eklenme Tarihi:
            <asp:Label ID="lbl_EklenmeTarihi" runat="server" Text="Label" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:Label>
            <br />
            Puan:
            <asp:Label ID="lbl_Puan" runat="server" Text="Label"></asp:Label>
            &nbsp;
        </ItemTemplate>
    </asp:DataList>
        </div>
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
