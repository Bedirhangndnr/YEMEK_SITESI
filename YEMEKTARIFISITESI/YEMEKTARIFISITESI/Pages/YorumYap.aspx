<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site1.Master" AutoEventWireup="true" CodeBehind="YorumYap.aspx.cs" Inherits="YEMEKTARIFISITESI.YorumYap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @import url(//netdna.bootstrapcdn.com/font-awesome/3.2.1/css/font-awesome.css);

        fieldset input, textarea {
            width: 200px;
        }

            input:hover, textarea:hover {
                background-color: whitesmoke;
            }

        .success {
            margin: 3px;
            display: none;
            color: $blue;
            font-weight: 400;
            text-align: center;
            margin-bottom: 2.5em;

            @media (max-width: $breakpoint) {
                font-size: .875em;
            }

            .name

        {
            color: $green;
            font-weight: 700;
            font-size: 1.125em;
        }

        }

        .rating {
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

        .auto-style2 {
            height: 23px;
        }

        .auto-style3 {
            font-size: x-large;
        }

        .auto-style4 {
            margin-top: 0px;
        }

        .center {
            display: block;
            margin-left: auto;
            margin-right: auto;
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
    <div class="row">
        <div class="col-md-12" style="width=%100">
            <form id="form" data-parsley-validate>
                <div class="success">
                    <p>Mesaj başarılı bir şekilde iletildi.</p>
                </div>
                <h1 style="font-size:20px">Mesaj Gönder</h1>
                <fieldset>
                    <asp:TextBox ID="inpt_AdSoyad" runat="server" class="floatlabel" placeholder="Name" required data-parsley-no-focus data-parsley-error-message="Please enter a message."></asp:TextBox>
                </fieldset>
                <fieldset>
                    <asp:TextBox runat="server" ID="inpt_Mail" class="floatlabel" type="email" placeholder="Email" required data-parsley-no-focus data-parsley-error-message="Please enter a valid email address." />
                </fieldset>
                <fieldset>
                    <asp:TextBox runat="server" ID="inpt_Mesaj" class="floatlabel" placeholder="Message" required data-parsley-no-focus data-parsley-error-message="Please enter a message." TextMode="MultiLine" />
                </fieldset>
                <fieldset>
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Gönder" Style="height: auto; max-height: 25px; margin-top: 2px; font-size: 10px" OnClick="Button1_Click1" />
                </fieldset><asp:Label ID="lbl_YorumYapmaBasariliYadaDeğil" runat="server" BorderStyle="None" Text="Label" Visible="False"></asp:Label>
&nbsp;</form>
        </div>
        <%--        <div class="col-md-6">

            <fieldset class="rating" style="margin-top: 12px; float:right;margin-left: 50%">
                <input type="radio" id="five" name="rating" value="5" onclick="document.getElementById('puanVer').innerHTML = 10" /><label class="full" for="five" title="Awesome - 5 stars"></label>
                <input type="radio" id="star4half" name="rating" value="4 and a half" onclick="document.getElementById('puanVer').innerHTML = 9" /><label class="half" for="star4half" title="Pretty good - 4.5 stars"></label>
                <input type="radio" id="star4" name="rating" value="4" onclick="document.getElementById('puanVer').innerHTML = 8" /><label class="full" for="star4" title="Pretty good - 4 stars"></label>
                <input type="radio" id="star3half" name="rating" value="3 and a half" onclick="document.getElementById('puanVer').innerHTML = 7" /><label class="half" for="star3half" title="Meh - 3.5 stars"></label>
                <input type="radio" id="star3" name="rating" value="3" onclick="document.getElementById('puanVer').innerHTML = 6" /><label class="full" for="star3" title="Meh - 3 stars"></label>
                <input type="radio" id="star2half" name="rating" value="2 and a half" onclick="document.getElementById('puanVer').innerHTML = 5" /><label class="half" for="star2half" title="Kinda bad - 2.5 stars"></label>
                <input type="radio" id="star2" name="rating" value="2" onclick="document.getElementById('puanVer').innerHTML = 4" /><label class="full" for="star2" title="Kinda bad - 2 stars"></label>
                <input type="radio" id="star1half" name="rating" value="1 and a half" onclick="document.getElementById('puanVer').innerHTML = 3" /><label class="half" for="star1half" title="Meh - 1.5 stars"></label>
                <input type="radio" id="star1" name="rating" value="1" onclick="document.getElementById('puanVer').innerHTML = 2" /><label class="full" for="star1" title="Sucks big time - 1 star"></label>
                <input type="radio" id="starhalf" name="rating" value="half" onclick="document.getElementById('puanVer').innerHTML = 1" /><label class="half" for="starhalf" title="Sucks big time - 0.5 stars"></label>
            </fieldset>
        </div>
        <div class="col-md-6">
            <label id="puanVer" style="margin-top: 18px; float:left"></label>
            <asp:LinkButton Style="float: left; margin-left: 3px" Text="Puan Ver" CssClass="btn btn-success" ID="LinkButton1" runat="server" OnClientClick="return confirm('Puanınız gönderilsin mi?');" OnClick="LinkButton1_Click" />
        </div>
    </div>--%>
    <script>
        (function () {

            $('.floatlabel').SmartPlaceholders();

            var $form = $('#form'),
                $success = $('.success'),
                $smart = $('.smart-placeholder-wrapper'),
                parsley = $form.parsley();

            $form.submit(function (e) {
                e.preventDefault();
                if (parsley.validationResult == true) {
                    var name = $('#name').val();
                    success(name);
                    clearForm(this);
                }
            });

            function success(name) {
                $('.name').text(name);
                $("html, body").animate({ scrollTop: 0 }, 300);
                $success
                    .slideDown()
                    .delay(3000)
                    .slideUp();
            }

            function clearForm(el) {
                el.reset();
                $smart.removeClass('focused, populated');
            }

        })();
    </script>
</asp:Content>
