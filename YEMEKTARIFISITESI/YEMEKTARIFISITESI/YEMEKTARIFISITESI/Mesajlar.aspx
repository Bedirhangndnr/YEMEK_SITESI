<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Mesajlar.aspx.cs" Inherits="YEMEKTARIFISITESI.Mesajlar" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table {
            width: 100%;
            text-align: left;
        }

        
        .scroll-list {
            height: 600px !important;
            overflow: scroll;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="margin-bottom: 20px; margin-top: 10px">
        <strong style="font-size: 24px;">MESAJ LİSTESİ</strong>
    </div>
    <div class="scroll-list">
        <asp:DataList ID="DataList1" runat="server">
            <HeaderTemplate>
                <table style="width: 100%;" class="table">
                    <tr>
                        <td class="col-md-3"><strong style="font-size:22px">GÖNDEREN</strong>
                        </td>
                        <td class="col-md-4"><strong style="font-size:22px">MESAJ</strong>
                        </td>
                        <td>&nbsp;</td>
                        </td>

                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <table style="width: 100%;">
                    <tr style="border-bottom: 2px solid">
                        <td class="col-md-3">
                            <asp:Label ID="lbl_MesajGonderen" runat="server" Style="float: left" Text='<%# Eval("MesajGonderen") %>'></asp:Label>
                        </td>
                        <td class="col-md-4">
                            <asp:Label ID="lbl_MesajBaslik" runat="server" Style="float: left" Text='<%# Eval("Mesajicerik") %>'></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td class="col-md-5" style="float: right; margin-block: 20px">
                            <a href="MesajDetay.aspx?Mesajid=<%#Eval("Mesajid")%>" style="float: right" class="btn btn-primary btn-group-sm active">Mesaj Detay</a>
                        </td>

                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>

</asp:Content>
