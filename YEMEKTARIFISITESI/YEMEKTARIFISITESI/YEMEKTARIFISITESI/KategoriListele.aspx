<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="YEMEKTARIFISITESI.KategoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:DropDownList ID="ddl_Kategoriler" runat="server" Height="16px" Width="250px">
    </asp:DropDownList>
    <asp:Panel ID="Panel1" runat="server" BackColor="#CCCCCC">
        <table style="width: 100%;">
            <tr>
                <td><strong>KATEGORİ LİSTESİ</strong></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <div class="yemek-listesi" style="width:60%; margin:auto; border:solid 1px" >

            <asp:DataList ID="DataList1" runat="server" Width="100%">
                <ItemTemplate>
                    <table class="auto-style2 table">
                        <tr>
                            <td class="auto-style5" style="float:left;"><strong>
                                <asp:Label ID="lblYemekIsım" runat="server" CssClass="auto-style4" Text='<%# Eval("KategoriAd") %>'></asp:Label>
                            </strong></td>

                            <td class="auto-style3" style="float:right">
                                 <a href="KategoriDuzenle.aspx?Kategoriid=<%#Eval("Kategoriid") %>">
                                    <button type="button" class="btn btn-primary">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pass-fill" viewBox="0 0 16 16">
                                            <path d="M10 0a2 2 0 1 1-4 0H3.5A1.5 1.5 0 0 0 2 1.5v13A1.5 1.5 0 0 0 3.5 16h9a1.5 1.5 0 0 0 1.5-1.5v-13A1.5 1.5 0 0 0 12.5 0H10ZM4.5 5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1 0-1Zm0 2h4a.5.5 0 0 1 0 1h-4a.5.5 0 0 1 0-1Z" />
                                        </svg>
                                    </button>
                                </a>
                            </td>

                        </tr>

                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>

    </asp:Panel>


</asp:Content>
