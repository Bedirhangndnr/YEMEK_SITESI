<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Kategoriler.aspx.cs" Inherits="YEMEKTARIFISITESI.Kategoriler" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }

        .auto-style3 {
            text-align: right;
        }

        .auto-style4 {
            font-size: x-large;
        }

        .auto-style5 {
            width: 287px;
            float: left;
            text-align: left;
        }

        .auto-style6 {
            width: 48px;
        }

        .auto-style7 {
            width: 16px;
        }

        .auto-style8 {
            font-weight: bold;
            font-size: large;
            margin-left: 0px;
        }

        .auto-style9 {
            font-weight: bold;
            font-size: large;
        }

        #Panel2 {
            background-color: green;
        }

        .auto-style11 {
            font-weight: bold;
            font-size: large;
            margin-top: 0;
        }

        .scroll-list {
            height: 600px !important;
            overflow: scroll;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-bottom: 20px; margin-top: 10px">
        <strong style="font-size: 24px;">KATEGORİ LİSTESİ</strong>
    </div>

    <div class="scroll-list">
        <asp:DataList ID="DataList1" runat="server" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" Width="100%">
            <ItemTemplate>
                <table class="auto-style2" data-bs-spy="scroll">
                    <div data-bs-spy="scroll" data-bs-target="#navbar-example2" data-bs-offset="0" class="scrollspy-example" tabindex="0">
                        <tr style="border-bottom: 2px solid; margin: 100px">
                            <td class="auto-style5">
                                <strong>
                                    <asp:Label ID="lblKategoriIsım" runat="server" CssClass="auto-style4" Text='<%# Eval("KategoriAd") %>'></asp:Label>
                                </strong>
                            </td>
                            <td class="auto-style3">
                                <asp:LinkButton Text="Sil" style="margin-block:20px; margin-right:20px" OnClientClick="return confirm('Gerçekten Silmek İstediğinizden Emnin Misiniz?');" CssClass="btn btn-danger" runat="server" OnCommand="Sil" CommandArgument='<%# Eval("Kategoriid") %>'>Sil
                                </asp:LinkButton>
                                <a href="KategoriDuzenle.aspx?Kategoriid=<%#Eval("Kategoriid") %>" style="float: right;margin-block:20px; margin-right:20px" class="btn btn-primary btn-group-sm active">Düzenle</a>
                            </td>
                        </tr>
                    </div>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>

    <script type="text/javascript">
        function Validate() {
            var isValid = true;

            //Reference the Table.
            var tblForm = document.getElementById("tblForm");

            //Reference all INPUT elements in the Table.
            var inputs = document.getElementsByTagName("input");

            //Loop through all INPUT elements.
            for (var i = 0; i < inputs.length; i++) {

                //Check whether the INPUT element is TextBox.
                if (inputs[i].type == "text") {
                    //Check whether its Value is not BLANK and Validation is required.
                    if (Trim(inputs[i].value) == "" && inputs[i].className.indexOf("required") != 1) {
                        //If Validation has FAILED, show error message.
                        isValid = false;
                        ShowHideError(inputs[i], "block");
                    } else {
                        //If Validation is SUCCESS, hide error message.
                        ShowHideError(inputs[i], "none");
                    }
                }
            }
            return isValid;
        };

        function ShowHideError(textbox, display) {
            var row = textbox.parentNode.parentNode;
            var errorMsg = row.getElementsByTagName("span")[0];
            if (errorMsg != null) {
                errorMsg.style.display = display;
            }
        };

        function Trim(value) {
            return value.replace(/^\s+|\s+$/g, '');
        };
    </script>
</asp:Content>

