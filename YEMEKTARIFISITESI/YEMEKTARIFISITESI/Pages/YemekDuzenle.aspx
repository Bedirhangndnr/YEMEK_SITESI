<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="YemekDuzenle.aspx.cs" Inherits="YEMEKTARIFISITESI.YemekDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 96px;
        }

        .auto-style3 {
            width: 96px;
            height: 112px;
        }

        .auto-style4 {
            height: 112px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;" class="tblForm">
        <tr>
            <td class="auto-style2">Ekleyen kişi ad soyad</td>
            <td>
                <asp:TextBox ID="txtbx_EkleyenAd" runat="server" ClientIDMode="Static" Width="300px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td class="auto-style2">Ekleyen mail</td>
            <td>
                <asp:TextBox ID="txtbx_EkleyenMail" runat="server" ClientIDMode="Static" Width="300px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td class="auto-style2">Yemek Adı</td>
            <td>
                <asp:TextBox ID="txtbxYemekAd" runat="server" ClientIDMode="Static" Width="300px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td class="auto-style2">Malzemeler</td>
            <td>
                <asp:TextBox ID="txtbxYemekMalzemeler" runat="server" ClientIDMode="Static" Height="86px" TextMode="MultiLine" Width="300px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td class="auto-style2">Tarif</td>
            <td>
                <asp:TextBox ID="txtbxYemekTarif" runat="server" ClientIDMode="Static" Height="132px" TextMode="MultiLine" Width="299px" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td class="auto-style2">Kategori</td>
            <td>
                <asp:DropDownList ID="ddlKategoriler" runat="server" Width="300px" required data-parsley-no-focus data-parsley-error-message="Please enter a message.">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Yemexk Resim</td>
            <td>
                <%--Burada ekleme yapıldığında gerekli, güncelleme yapıldığında gerekli değil şeklinde bir düzenleme gerekir. Yapmadım bunu şu an--%>
                <asp:FileUpload ID="fu_yemekResim" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Image ID="img_YemekResim" runat="server" Style="max-height: 50px; max-width: 130px" Width="130px" />
            </td>
            <td class="auto-style4">
                <%--################################onclientclick özelliğine confirm(alert('gerçekten gundellemek istediğinize eminmisiniz uyarısını ekleyemedim)) ###########################################################--%>

                    <asp:Button ID="btn_GununYemegiYp" Text="Gunun Yemegi Yap" OnClientClick="return confirm('Gerçekten Günün Yemeği Yapmak İstediğinizden Emnin Misiniz?');" CssClass="btn btn-primary" runat="server" OnCommand="GununYemegiYap" CommandArgument='<%# Eval("Yemekid") %>'/>
                    <asp:Button ID="btn_Guncele" OnClientClick="ClearTB()" Text="Guncelle" CssClass="btn btn-success" runat="server" OnCommand="Guncelle_Ekle" CommandArgument='<%# Eval("Yemekid") %>'/>
                    <asp:Button ID="btn_Sil" Text="Sil" OnClientClick="return Validate();" CssClass="btn btn-danger" runat="server" OnCommand="Sil" CommandArgument='<%# Eval("Yemekid") %>'/>

                <br />
                <br />
                <asp:Label ID="lbl_BasariliYadaDegil" runat="server" Text="Label"></asp:Label>
                <br />

    </table>



    <script>
        function ClearTB() {
            document.getElementById("txtbx_EkleyenAd").value = document.getElementById("txtbx_EkleyenAd").value.replace(/^\s+/, '').replace(/\s+$/, '');
            document.getElementById("txtbx_EkleyenMail").value = document.getElementById("txtbx_EkleyenMail").value.replace(/^\s+/, '').replace(/\s+$/, '');
            document.getElementById("txtbxYemekAd").value = document.getElementById("txtbxYemekAd").value.replace(/^\s+/, '').replace(/\s+$/, '');
            document.getElementById("txtbxYemekMalzemeler").value = document.getElementById("txtbxYemekMalzemeler").value.replace(/^\s+/, '').replace(/\s+$/, '');
            document.getElementById("txtbxYemekTarif").value = document.getElementById("txtbxYemekTarif").value.replace(/^\s+/, '').replace(/\s+$/, '');
            document.getElementById("ddlKategoriler").value = document.getElementById("ddlKategoriler").value.replace(/^\s+/, '').replace(/\s+$/, '');
        }
    </script>
</asp:Content>
