<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site1.Master" AutoEventWireup="true" CodeBehind="yemekDetay.aspx.cs" Inherits="YEMEKTARIFISITESI.yemekDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            font-size: x-large;
        }

        .auto-style3 {
            width: 130px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <asp:DataList ID="ddlYemekDetay" runat="server">
            <ItemTemplate>
                <div style="margin: left; border: 2px solid; width=100%; height=100%">
                    &nbsp;<asp:Label ID="lbl_Malzemeler0" runat="server" Text='<%# Eval("YemekAd") %>' Font-Bold="True" Font-Size="15pt"></asp:Label>
                    <p style="font-weight: bold">
                        Malzemeler:
                        <asp:Label ID="lbl_Malzemeler" Style="font-weight: normal" runat="server" Text='<%# Eval("YemekMalzeme") %>'></asp:Label>
                    </p>
                    <p style="font-weight: bold">
                        Yemek Tarifi:
                        <asp:Label ID="lbl_YemekTarifi" Style="font-weight: normal" runat="server" Text='<%# Eval("YemekTarif") %>'></asp:Label>
                    </p>
                    <p style="font-weight: bold">
                        Eklenme Tarihi:
                        <asp:Label ID="lbl_EklenmeTarihi" Style="font-weight: normal" runat="server" Text='<%# Eval("YemekTarih") %>'></asp:Label>
                    </p>
                    <p style="font-weight: bold">
                        Puan:
                            <asp:Label ID="lbl_Puan" Style="font-weight: normal" runat="server" Text='<%# Eval("YemekPuan") %>'></asp:Label>
                    </p>
                    <asp:Image ID="Image1" runat="server" Style="width=auto; height=auto; max-width=300px; max-height: 300px;" ImageUrl='<%# Eval("YemekResim") %>' />
                    <br />
                    <a href="YorumYap.aspx?Yemekid=<%#Eval("Yemekid") %>" class="btn btn-success" style="color: white; width: 100px">Yorum Yap</a>


                </div>





            </ItemTemplate>
        </asp:DataList>
        <br />
        <asp:DataList ID="DataList1" runat="server" Width="100%" CssClass="auto-style10">
            <ItemTemplate>

                <table class="auto-style2 table">
                    <tr>
                        <td class="auto-style5" style="width: 20%; border: solid 1px"><strong>
                            <asp:Label ID="lblKategoriIsım0" runat="server" Style="float: left" Text='<%# Eval("YorumAdSoyad") %>'></asp:Label>
                        </strong></td>

                        <td class="auto-style5" style="width: 65%; border: solid 1px">
                            <asp:Label ID="lbl_YorumIcerik" runat="server" Style="float: left" Text='<%# Eval("YorumIcerik") %>' />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>

    <%--    <div>
        YORUM YAPMA PANELİ
    </div>
    <asp:Panel ID="Panel1" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Ad Soyad </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Mail</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
                </td>
            </tr>


            <tr>
                <td class="auto-style3">Yorum</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Height="106px" Width="117px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                </td>
            </tr>
        </table>
</asp:Panel>--%>
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

