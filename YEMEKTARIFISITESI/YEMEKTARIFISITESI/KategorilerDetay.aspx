<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="KategorilerDetay.aspx.cs" Inherits="YEMEKTARIFISITESI.KategorilerDetay1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row" style="width=1000px">

    <asp:DataList ID="DataList2" runat="server">
        <ItemTemplate>
 <div>
                    <div style="border: 2px solid; width=100%; height=100%">
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
                        <div class="row">
                            <div class="col-md-6">
                                <a href="YorumYap.aspx?Yemekid=<%#Eval("Yemekid") %>" class="btn btn-success" style="color: white; float: right; width: 100px">Yorum Yap</a>
                            </div>
                            <div class="col-md-6">
                                <a href="yemekDetay.aspx?Yemekid=<%#Eval("Yemekid") %>" class="btn btn-success" style="color: white; float: left; width: 100px">Detay</a>
                            </div>

                        </div>
                    </div>


                </div>

                </div>



        </ItemTemplate>
    </asp:DataList>
</asp:Content>
