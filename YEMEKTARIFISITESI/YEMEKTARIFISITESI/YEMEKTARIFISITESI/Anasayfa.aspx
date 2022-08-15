<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="YEMEKTARIFISITESI.Anasayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        @import url(//netdna.bootstrapcdn.com/font-awesome/3.2.1/css/font-awesome.css);

        fieldset, label {
            margin: auto;
            padding: 0;
        }

    

        h1 {
            font-size: 1.5em;
            margin: 10px;
        }

        /****** Style Star Rating Widget *****/

        .rating {
            border: none;
            float: left;
        }

            .rating > input {
                display: none;
            }

            .rating > label:before {
                margin: 5px;
                font-size: 1.25em;
                font-family: FontAwesome;
                display: inline-block;
                content: "\f005";
            }

            .rating > .half:before {
                content: "\f089";
                position: absolute;
            }

            .rating > label {
                color: #ddd;
                float: right;
            }

            /***** CSS Magic to Highlight Stars on Hover *****/

            .rating > input:checked ~ label, /* show gold star when clicked */
            .rating:not(:checked) > label:hover, /* hover current star */
            .rating:not(:checked) > label:hover ~ label {
                color: #FFD700;
            }
                /* hover previous stars in list */

                .rating > input:checked + label:hover, /* hover current star when changing rating */
                .rating > input:checked ~ label:hover,
                .rating > label:hover ~ input:checked ~ label, /* lighten current selection */
                .rating > input:checked ~ label:hover ~ label {
                    color: #FFED85;
                }

        .center {
            display: block;
            margin-left: auto;
            margin-right: auto;
            width: 30%;
        }

        a {
            border: none;
            color: black;
            padding: 5px 8px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 12px;
            margin: 4px 2px;
            cursor: pointer;
        }

            a:hover {
                font-size: 12px;
                background-color: black;
                color: black;
            }

        .round {
            border-radius: 50%;
        }


    </style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="width=1000px">

        <br />
        <!-- Carousel -->
        <div id="demo" class="carousel slide" data-bs-ride="carousel" style="height: 355px">

            <!-- Indicators/dots -->
            <div class="carousel-indicators center">
                <button type="button" data-bs-target="#demo" data-bs-slide-to="0" class="active"></button>
                <button type="button" data-bs-target="#demo" data-bs-slide-to="1"></button>
                <button type="button" data-bs-target="#demo" data-bs-slide-to="2"></button>
            </div>

            <!-- The slideshow/carousel -->


            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="resimler/etyemekleri.jpg" class="d-block center" style="width: auto; height: 300px">
                    <div class="header-text hidden-xs">
                        <div class="col-md-12 text-center">
                            <h2>
                                <span style="color: black">Et Yemekleri</span>
                            </h2>
                            <br>
                            <div class="">
                                <%--<a class="btn btn-theme btn-sm btn-min-block" href="#">Daha Fazla</a>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="resimler/corbalar.jpg" class="d-block center" style="width: auto; height: 300px">
                    <div class="header-text hidden-xs">
                        <div class="col-md-12 text-center">
                            <h2>
                                <span class="kategorilerSpannClass">Çorbalar</span>
                            </h2>
                            <br>
                            <div class="">
                                <%--<a class="btn btn-theme btn-sm btn-min-block" href="#">Daha Fazla</a>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="resimler/tatlilar.jpg" class="d-block center" style="width: auto; height: 300px">
                    <div class="header-text hidden-xs">
                        <div class="col-md-12 text-center">
                            <h2>
                                <span class="kategorilerSpannClass">Tatlılar</span>
                            </h2>
                            <br>
                            <div class="">
                                <%--<a class="btn btn-theme btn-sm btn-min-block" href="#">Daha Fazla</a>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Left and right controls/icons -->
            <button class="carousel-control-prev" type="button" data-bs-target="#demo" data-bs-slide="prev">
                <span class="carousel-control-prev-icon"></span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#demo" data-bs-slide="next">
                <span class="carousel-control-next-icon"></span>
            </button>
        </div>

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


                        <%-- Bu kısımda input değeri olan puanı alamadım.                        
    <div class="form-group" style="width:auto; height:auto; min-height:80px;" >
                            <fieldset class="rating" style="align-content: center; margin-bottom:100px">
                                <input type="radio" id="<%# Eval("Yemekid") %> + five" name="rating" value="5" onclick="document.getElementById(dene).innerHTML = 10" /><label class="full" for="<%# Eval("Yemekid") %> + five" title="Awesome - 5 stars"></label>
                                <input type="radio" id="<%# Eval("Yemekid") %> + star4half" name="rating" value="4 and a half" onclick="document.getElementById('<%# Eval("Yemekid") %> + puanVer').innerHTML = 9" /><label class="half" for="<%# Eval("Yemekid") %> + star4half" title="Pretty good - 4.5 stars"></label>
                                <input type="radio" id="<%# Eval("Yemekid") %> + star4" name="rating" value="4" onclick="document.getElementById('<%# Eval("Yemekid") %> + puanVer').innerHTML = 8" /><label class="full" for="<%# Eval("Yemekid") %> + star4" title="Pretty good - 4 stars"></label>
                                <input type="radio" id="<%# Eval("Yemekid") %> + star3half" name="rating" value="3 and a half" onclick="document.getElementById('<%# Eval("Yemekid") %> + puanVer').innerHTML = 7" /><label class="half" for="<%# Eval("Yemekid") %> + star3half" title="Meh - 3.5 stars"></label>
                                <input type="radio" id="<%# Eval("Yemekid") %> + star3" name="rating" value="3" onclick="document.getElementById('<%# Eval("Yemekid") %> + puanVer').innerHTML = 6" /><label class="full" for="<%# Eval("Yemekid") %> + star3" title="Meh - 3 stars"></label>
                                <input type="radio" id="<%# Eval("Yemekid") %> + star2half" name="rating" value="2 and a half" onclick="document.getElementById('<%# Eval("Yemekid") %> + puanVer').innerHTML = 5" /><label class="half" for="<%# Eval("Yemekid") %> + star2half" title="Kinda bad - 2.5 stars"></label>
                                <input type="radio" id="<%# Eval("Yemekid") %> + star2" name="rating" value="2" onclick="document.getElementById('<%# Eval("Yemekid") %> + puanVer').innerHTML = 4" /><label class="full" for="<%# Eval("Yemekid") %> + star2" title="Kinda bad - 2 stars"></label>
                                <input type="radio" id="<%# Eval("Yemekid") %> + star1half" name="rating" value="1 and a half" onclick="document.getElementById('<%# Eval("Yemekid") %> + puanVer').innerHTML = 3" /><label class="half" for="<%# Eval("Yemekid") %> + star1half" title="Meh - 1.5 stars"></label>
                                <input type="radio" id="<%# Eval("Yemekid") %> + star1" name="rating" value="1" onclick="document.getElementById('<%# Eval("Yemekid") %> + puanVer').innerHTML = 2" /><label class="full" for="<%# Eval("Yemekid") %> + star1" title="Sucks big time - 1 star"></label>
                                <input type="radio" id="<%# Eval("Yemekid") %> + starhalf" name="rating" value="half" onclick="document.getElementById('<%# Eval("Yemekid") %> + puanVer').innerHTML = 1" /><label class="half" for="starhalf" title="Sucks big time - 0.5 stars"></label>

                                <p>
                                <label id="<%# Eval("Yemekid") %> + puanVer" style="margin-top:15px" ></label>

                                <asp:LinkButton style="float:left; margin-left:3px; margin-bottom:100px" Text="Puan Ver" CssClass="btn btn-success" ID="LinkButton1" runat="server" OnCommand="btn_PuanVer" OnClientClick="return confirm('Puanınız gönderilsin mi?');" />                                
                                </p>
                            </fieldset>
                            
                            <asp:Label Text="text" ID="denemelbl" runat="server" />
                            <%--<textarea class="form-control" ID="txtar_yorumYap" rows="3"></textarea>          ######## Burada .cs dosyasında bu text areanın id si ile işlem yapamadım çünkü çıkmadı.#########--%>
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
            </ItemTemplate>
        </asp:DataList>
    </div>

</asp:Content>
