<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="HakkimizdaAdmin.aspx.cs" Inherits="YEMEKTARIFISITESI.HakkimizdaAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:TextBox ID="txtbx_Hakkimizda" runat="server" Height="165px" TextMode="MultiLine" Width="415px"></asp:TextBox>
        <br />
        <asp:Button ID="btn_Guncelle" runat="server" OnClick="btn_Guncelle_Click" Text="Güncelle" Width="421px" />
        <br />
        <asp:Label ID="lbl_IsSucess" runat="server" Text="Label" Visible="False"></asp:Label>
</asp:Content>
