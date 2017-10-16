﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Site.Master" CodeBehind="Index.aspx.cs" Inherits="Justice.Main.Index" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="Server">
    <script src="../Scripts/Main/jssor.slider-25.2.0.min.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script>
        jssor_1_slider_init = function () {

            var jssor_1_SlideshowTransitions = [
                { $Duration: 1200, $Zoom: 1, $Easing: { $Zoom: $Jease$.$InCubic, $Opacity: $Jease$.$OutQuad }, $Opacity: 2 },
                { $Duration: 1000, $Zoom: 11, $SlideOut: true, $Easing: { $Zoom: $Jease$.$InExpo, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 1200, $Zoom: 1, $Rotate: 1, $During: { $Zoom: [0.2, 0.8], $Rotate: [0.2, 0.8] }, $Easing: { $Zoom: $Jease$.$Swing, $Opacity: $Jease$.$Linear, $Rotate: $Jease$.$Swing }, $Opacity: 2, $Round: { $Rotate: 0.5 } },
                { $Duration: 1000, $Zoom: 11, $Rotate: 1, $SlideOut: true, $Easing: { $Zoom: $Jease$.$InExpo, $Opacity: $Jease$.$Linear, $Rotate: $Jease$.$InExpo }, $Opacity: 2, $Round: { $Rotate: 0.8 } },
                { $Duration: 1200, x: 0.5, $Cols: 2, $Zoom: 1, $Assembly: 2049, $ChessMode: { $Column: 15 }, $Easing: { $Left: $Jease$.$InCubic, $Zoom: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 1200, x: 4, $Cols: 2, $Zoom: 11, $SlideOut: true, $Assembly: 2049, $ChessMode: { $Column: 15 }, $Easing: { $Left: $Jease$.$InExpo, $Zoom: $Jease$.$InExpo, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 1200, x: 0.6, $Zoom: 1, $Rotate: 1, $During: { $Left: [0.2, 0.8], $Zoom: [0.2, 0.8], $Rotate: [0.2, 0.8] }, $Easing: $Jease$.$Swing, $Opacity: 2, $Round: { $Rotate: 0.5 } },
                { $Duration: 1000, x: -4, $Zoom: 11, $Rotate: 1, $SlideOut: true, $Easing: { $Left: $Jease$.$InExpo, $Zoom: $Jease$.$InExpo, $Opacity: $Jease$.$Linear, $Rotate: $Jease$.$InExpo }, $Opacity: 2, $Round: { $Rotate: 0.8 } },
                { $Duration: 1200, x: -0.6, $Zoom: 1, $Rotate: 1, $During: { $Left: [0.2, 0.8], $Zoom: [0.2, 0.8], $Rotate: [0.2, 0.8] }, $Easing: $Jease$.$Swing, $Opacity: 2, $Round: { $Rotate: 0.5 } },
                { $Duration: 1000, x: 4, $Zoom: 11, $Rotate: 1, $SlideOut: true, $Easing: { $Left: $Jease$.$InExpo, $Zoom: $Jease$.$InExpo, $Opacity: $Jease$.$Linear, $Rotate: $Jease$.$InExpo }, $Opacity: 2, $Round: { $Rotate: 0.8 } },
                { $Duration: 1200, x: 0.5, y: 0.3, $Cols: 2, $Zoom: 1, $Rotate: 1, $Assembly: 2049, $ChessMode: { $Column: 15 }, $Easing: { $Left: $Jease$.$InCubic, $Top: $Jease$.$InCubic, $Zoom: $Jease$.$InCubic, $Opacity: $Jease$.$OutQuad, $Rotate: $Jease$.$InCubic }, $Opacity: 2, $Round: { $Rotate: 0.7 } },
                { $Duration: 1000, x: 0.5, y: 0.3, $Cols: 2, $Zoom: 1, $Rotate: 1, $SlideOut: true, $Assembly: 2049, $ChessMode: { $Column: 15 }, $Easing: { $Left: $Jease$.$InExpo, $Top: $Jease$.$InExpo, $Zoom: $Jease$.$InExpo, $Opacity: $Jease$.$Linear, $Rotate: $Jease$.$InExpo }, $Opacity: 2, $Round: { $Rotate: 0.7 } },
                { $Duration: 1200, x: -4, y: 2, $Rows: 2, $Zoom: 11, $Rotate: 1, $Assembly: 2049, $ChessMode: { $Row: 28 }, $Easing: { $Left: $Jease$.$InCubic, $Top: $Jease$.$InCubic, $Zoom: $Jease$.$InCubic, $Opacity: $Jease$.$OutQuad, $Rotate: $Jease$.$InCubic }, $Opacity: 2, $Round: { $Rotate: 0.7 } },
                { $Duration: 1200, x: 1, y: 2, $Cols: 2, $Zoom: 11, $Rotate: 1, $Assembly: 2049, $ChessMode: { $Column: 19 }, $Easing: { $Left: $Jease$.$InCubic, $Top: $Jease$.$InCubic, $Zoom: $Jease$.$InCubic, $Opacity: $Jease$.$OutQuad, $Rotate: $Jease$.$InCubic }, $Opacity: 2, $Round: { $Rotate: 0.8 } }
            ];

            var jssor_1_options = {
                $AutoPlay: 1,
                $SlideshowOptions: {
                    $Class: $JssorSlideshowRunner$,
                    $Transitions: jssor_1_SlideshowTransitions,
                    $TransitionsOrder: 1
                },
                $BulletNavigatorOptions: {
                    $Class: $JssorBulletNavigator$
                },
                $ThumbnailNavigatorOptions: {
                    $Class: $JssorThumbnailNavigator$,
                    $Cols: 4,
                    $Orientation: 2,
                    $Align: 150
                }
            };

            var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);

            /*#region responsive code begin*/
            /*remove responsive code if you don't want the slider scales while window resizing*/
            function ScaleSlider() {
                var refSize = jssor_1_slider.$Elmt.parentNode.clientWidth;
                if (refSize) {
                    refSize = Math.min(refSize, 1138);
                    jssor_1_slider.$ScaleWidth(refSize);
                }
                else {
                    window.setTimeout(ScaleSlider, 30);
                }
            }
            ScaleSlider();
            $Jssor$.$AddEvent(window, "load", ScaleSlider);
            $Jssor$.$AddEvent(window, "resize", ScaleSlider);
            $Jssor$.$AddEvent(window, "orientationchange", ScaleSlider);
            /*#endregion responsive code end*/
        };
    </script>
    <style>
        /* jssor slider loading skin double-tail-spin css */

        .jssorl-004-double-tail-spin img {
            animation-name: jssorl-004-double-tail-spin;
            animation-duration: 1.2s;
            animation-iteration-count: infinite;
            animation-timing-function: linear;
        }

        @keyframes jssorl-004-double-tail-spin {
            from {
                transform: rotate(0deg);
            }

            to {
                transform: rotate(360deg);
            }
        }

        .jssorb056 .i {
            position: absolute;
            cursor: pointer;
        }

            .jssorb056 .i .b {
                fill: #000;
                fill-opacity: 0.3;
                stroke: #fff;
                stroke-width: 400;
                stroke-miterlimit: 10;
                stroke-opacity: 0.7;
            }

            .jssorb056 .i:hover .b {
                fill-opacity: .7;
            }

        .jssorb056 .iav .b {
            fill-opacity: 1;
        }

        .jssorb056 .i.idn {
            opacity: .3;
        }

        .jssort051 .p {
            position: absolute;
            top: 0;
            left: 0;
            background-color: #000;
        }

        .jssort051 .t {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            border: none;
            opacity: .45;
        }

        .jssort051 .p:hover .t {
            opacity: .8;
        }

        .jssort051 .pav .t, .jssort051 .pdn .t, .jssort051 .p:hover.pdn .t {
            opacity: 1;
        }
    </style>

    <section id="slider">
        <div class="container-fluid">
            <div class="row">
                <div id="jssor_1" style="position: relative; margin: 0 auto; top: 0px; left: 0px; width: 1138px; height: 380px; overflow: hidden; visibility: hidden;">
                    <!-- Loading Screen -->
                    <div data-u="loading" class="jssorl-004-double-tail-spin" style="position: absolute; top: 0px; left: 0px; text-align: center; background-color: rgba(0,0,0,0.7);">
                        <img style="margin-top: -19px; position: relative; top: 50%; width: 38px; height: 38px;" src="../Content/Main/images/double-tail-spin.svg" />
                    </div>
                    <div data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 1138px; height: 380px; overflow: hidden;">
                        <div>
                            <img data-u="image" src="../Content/Main/images/slider/slide1.jpg" />
                            <img data-u="thumb" src="../Content/Main/images/slider/slide1.jpg" />
                        </div>
                        <div>
                            <img data-u="image" src="../Content/Main/images/slider/slide2.jpg" />
                            <img data-u="thumb" src="../Content/Main/images/slider/slide2.jpg" />
                        </div>
                        <div>
                            <img data-u="image" src="../Content/Main/images/slider/slide3.jpg" />
                            <img data-u="thumb" src="../Content/Main/images/slider/slide3.jpg" />
                        </div>
                        <div>
                            <img data-u="image" src="../Content/Main/images/slider/slide4.jpg" />
                            <img data-u="thumb" src="../Content/Main/images/slider/slide4.jpg" />
                        </div>
                        <div>
                            <img data-u="image" src="../Content/Main/images/slider/slide5.jpg" />
                            <img data-u="thumb" src="../Content/Main/images/slider/slide5.jpg" />
                        </div>
                        <div>
                            <img data-u="image" src="../Content/Main/images/slider/slide6.jpg" />
                            <img data-u="thumb" src="../Content/Main/images/slider/slide6.jpg" />
                        </div>
                    </div>
                    <!-- Thumbnail Navigator -->
                    <div data-u="thumbnavigator" class="jssort051" style="position: absolute; left: 0px; top: 0px; width: 200px; height: 380px;" data-autocenter="2" data-scale-left="0.75">
                        <div data-u="slides">
                            <div data-u="prototype" class="p" style="width: 200px; height: 100px;">
                                <div data-u="thumbnailtemplate" class="t"></div>
                            </div>
                        </div>
                    </div>
                    <!-- Bullet Navigator -->
                    <div data-u="navigator" class="jssorb056" style="position: absolute; bottom: 12px; right: 12px;" data-scale="0.5">
                        <div data-u="prototype" class="i" style="width: 16px; height: 16px;">
                            <svg viewbox="0 0 16000 16000" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;">
                                <rect class="b" x="2200" y="2200" width="11600" height="11600"></rect>
                            </svg>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section id="show_case">
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <div class="best_seller">
                        <div class="title">
                            <h3 class="text-left">Ən çox satılan</h3>
                            <p class="text-right"><a href="mostsold.php">Hamısını göstər</a></p>
                        </div>
                        <div class='row title_content'>
                            <div class='col-md-5'>
                                <img src='thumb/thumb_".$json->data[1]->image1."' alt=''>
                            </div>
                            <div class='col-md-7'>
                                <h3>Product Name</h3>
                                <div class='addShopp'>
                                    <p class='pull-left'>XXX AZN</p>
                                    <a href=''></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="new_product">
                        <div class="title">
                            <h3 class="text-left">Yeni məhsullar</h3>
                            <p class="text-right"><a href="lastproducts.php">Hamısını göstər</a></p>
                        </div>
                        <div class='row title_content'>
                            <div class='col-md-5'>
                                <img src='thumb/thumb_".$json->data[0]->image1."' alt=''>
                            </div>
                            <div class='col-md-7'>
                                <h3>PRODUCT NAME</h3>
                                <div class='addShopp'>
                                    <p class='pull-left'>XXX AZN</p>
                                    <a href=''></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="konsept">
                        <div class="title">
                            <h3 class="text-left">Konsept məhsullar</h3>
                            <p class="text-right"><a href="category.php?cat=5">Hamısını göstər</a></p>
                        </div>
                        <div class='row title_content'>
                            <div class='col-md-5'>
                                <img src='thumb/thumb_".$json->data[0]->image1."' alt=''>
                            </div>
                            <div class='col-md-7'>
                                <h3>PRODUCT NAME</h3>
                                <div class='addShopp'>
                                    <p class='pull-left'>XXX AZN</p>
                                    <a href=''></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </section>
    <section id="products">
        <div class="container">
            <div class="col-md-12 title">
                <h3>Sizin üçün seçdiklərimiz</h3>
            </div>
            <div class="row">
                <asp:Repeater  ID="productRepeater" runat="server">
                    <ItemTemplate>
                        <div class='col-md-3'>
                            <div class='product'>
                                <div class='discount' style='right: 25px;'>
                                    <span><%# Eval("Discount")%> AZN</span>
                                </div>
                                <div class='images'>
                                    <a href='Product/?id=<%# Eval("ID") %>'>
                                        <img class='img-responsive' src='../Content/Main/images/products/<%# Eval("Image1") %>.jpg' alt=''></a>
                                </div>
                                <div class='detailes'>
                                    <h5 class='text-center'>
                                        <a href='Product/?id=<%# Eval("ID") %>'><%# Eval("ProductName") %></a>
                                    </h5>
                                    <div class='addShopp'>
                                        <p class='pull-left'><%# Eval("Price") %> AZN</p>
                                        <a href=''>
                                            <button class='pull-right'>
                                                <a href='http://192.168.5.22/api/?v=1&m=addFavorite&user_id=".$json2->data->id."&product_id=".$data->id."'><i class='fa fa-star-o fa-2x' aria-hidden='true'></i></a>
                                            </button>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
    <script type="text/javascript">jssor_1_slider_init();</script>
</asp:Content>
  <asp:Content ID="EndContent" ContentPlaceHolderID="EndContent" runat="server">
    <%: Scripts.Render("~/bundles/indexJs") %>
</asp:Content>