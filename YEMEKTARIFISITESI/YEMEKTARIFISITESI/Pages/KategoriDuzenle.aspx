<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="KategoriDuzenle.aspx.cs" Inherits="YEMEKTARIFISITESI.KategoriDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin-bottom: 10px;
        }

        .auto-style3 {
            width: 220px
        }

        tr {
            margin-top: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="auto-style3">Kategori Ad:</td>
            <td __designer:mapid="4">
                <asp:TextBox ID="txtbx_KategoriAd" runat="server"  ClientIDMode="Static" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Kategori Resim:<asp:Image ID="img_KategoriResim" runat="server" Style="max-height: 50px; max-width: 50px" Width="50px" required data-parsley-no-focus data-parsley-error-message="Please enter a message." />
            </td>
            <td __designer:mapid="c">
                <asp:FileUpload ID="Fu_KategoriResim" runat="server" CssClass="auto-style2" Enabled='<%# Eval("KategoriResim") %>' Height="28px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:Button ID="btn_Güncelle" runat="server" CssClass="btn btn-success" OnClientClick="ClearTB()" OnClick="btn_Güncelle_Click" Text="Güncelle" />
                <asp:Button ID="btn_sil" runat="server" CssClass="btn btn-danger" OnClick="btn_Sil_Click" Text="Sil" />
                <br />
                <asp:Label ID="lbl_BasariliYadaDegil" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <script>
        function ClearTB() {
            document.getElementById("txtbx_KategoriAd").value = document.getElementById("txtbx_KategoriAd").value.replace(/^\s+/, '').replace(/\s+$/, '');
        }
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
