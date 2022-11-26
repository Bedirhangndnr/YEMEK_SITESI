<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site1.Master" AutoEventWireup="true" CodeBehind="Hakkimizda.aspx.cs" Inherits="YEMEKTARIFISITESI.Hakkimizda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">


        .auto-style6 {
            width: 48px;
        }

        .auto-style9 {
            font-weight: bold;
            font-size: large;
        }

        .auto-style7 {
            width: 16px;
        }

        .auto-style8 {
            font-weight: bold;
            font-size: large;
            margin-left: 0px;
        }

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <tr>
                <td><strong>HAKKIMIZDA</strong></td>
            </tr>

    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server">
        <asp:DataList ID="DataList2" runat="server">
            <ItemTemplate>
                <asp:Label ID="lbl_Hakkimizda" runat="server" Text='<%# Eval("Metin") %>'></asp:Label>
            </ItemTemplate>
        </asp:DataList>
        <asp:Label ID="lbl_Hakkimizda" runat="server" Height="165px" Width="415px">Deneme 123</asp:Label>
        <br />
    </asp:Panel>
</asp:Content>
