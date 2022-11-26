<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site1.Master" AutoEventWireup="true" CodeBehind="GununYemegi.aspx.cs" Inherits="YEMEKTARIFISITESI.GununYemegi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            text-align: right;
        }

        .auto-style3 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="width=1000px">
        GÜNÜN YEMEGİ<br />
        <br />

            <asp:DataList ID="DataList3" runat="server">
                <ItemTemplate>
                    <div style="border: 2px solid; width=100%; height=100%;">
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
                            <%-- Puan:
                            <asp:Label ID="lbl_Puan" Style="font-weight: normal" runat="server" Text='<%# Eval("YemekPuan") %>'></asp:Label>--%>
                        </p>
                        <asp:Image ID="Image2" runat="server" Style="width=auto; height=auto; max-width=300px; max-height: 300px;" ImageUrl='<%# Eval("YemekResim") %>' />
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
</asp:Content>
