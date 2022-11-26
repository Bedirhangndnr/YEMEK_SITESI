<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Yemekler.aspx.cs" Inherits="YEMEKTARIFISITESI.Yemekler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }

        .yemek-listesi {
            height: 600px !important;
            overflow: scroll;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:DropDownList ID="ddlOnayTuru" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlOnayTuru_SelectedIndexChanged" runat="server">
            <asp:ListItem >Hepsi</asp:ListItem>
            <asp:ListItem Text="Onaylı" Value="1" />
            <asp:ListItem Text="Onaysız" Value="-1" />
        </asp:DropDownList>
    </div>
    <div class="yemek-listesi">

        <asp:DataList ID="DataList2" runat="server">
        </asp:DataList>

        <asp:DataList ID="DataList1" runat="server" Width="100%">
            <ItemTemplate>
                <table class="auto-style2">
                    <tr style="border-bottom: 2px solid">
                        <td class="auto-style5"><strong>
                            <asp:Label ID="lblYemekIsım" runat="server" CssClass="auto-style4" Text='<%# Eval("YemekAd") %>'></asp:Label>
                        </strong></td>
                        <td class="auto-style3">
                          <%--                              <asp:LinkButton Text="SİL" style="margin-right: 10px; margin-top: 7px; margin-bottom: 7px" OnCommand="lblbtn_Sil" CommandArgument='<%# Eval("Yemekid") %>' CssClass="btn btn-danger" runat="server" />
                            <asp:LinkButton Text="ONAYLA" style="margin-right: 10px; margin-top: 7px; margin-bottom: 7px" OnCommand="lblbtn_Onayla" CommandArgument='<%# Eval("Yemekid") %>' CssClass="btn btn-success" runat="server" />
                            <asp:LinkButton Text="ONAY KALDIR" style="margin-right: 10px; margin-top: 7px; margin-bottom: 7px" OnCommand="lblbtn_OnayKaldir" CommandArgument='<%# Eval("Yemekid") %>' CssClass="btn btn-warning" runat="server" />
                            <%--<asp:LinkButton Text="DÜZENLE" style="margin-right: 10px; margin-top: 7px; margin-bottom: 7px" OnCommand="lblbtn_Sil" CommandArgument='<%# Eval("Yemekid") %>' CssClass="btn btn-primary" runat="server" />--%>
                            <%--<a style="margin-right: 10px; margin-top: 7px; margin-bottom: 7px" class="btn btn-primary" href="YemekDuzenle.aspx?Yemekid=<%#Eval("Yemekid") %>" style="margin-block: 10px">DÜZENLE</a>--%>


                            <asp:LinkButton style="margin-right: 10px; margin-top: 7px; margin-bottom: 7px" class="btn btn-danger"  Text="sil" runat="server" OnCommand="btn_Sil" CommandArgument='<%# Eval("Yemekid") %>'/>
                            <asp:LinkButton style="margin-right: 10px; margin-top: 7px; margin-bottom: 7px" class="btn btn-success" Text="onayla" runat="server" OnCommand="btn_Onayla" CommandArgument='<%# Eval("Yemekid") %>'/>
                            <asp:LinkButton style="margin-right: 10px; margin-top: 7px; margin-bottom: 7px" class="btn btn-warning" Text="onay kaldır" runat="server" OnCommand="btn_OnayKaldir" CommandArgument='<%# Eval("Yemekid") %>'/>

                            <a style="margin-right: 10px; margin-top: 7px; margin-bottom: 7px" class="btn btn-primary" href="YemekDuzenle.aspx?Yemekid=<%#Eval("Yemekid") %>" style="margin-block: 10px">Düzenle
                            </a>
                        </td>
                    </tr>

                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>



    <asp:Panel ID="Panel4" runat="server">
    </asp:Panel>
</asp:Content>
