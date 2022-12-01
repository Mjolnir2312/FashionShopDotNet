<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/cms/display/DisplayLoadControl.ascx" TagPrefix="uc1" TagName="DisplayLoadControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="shortcut icon" href="images/favicon.png">
    <title>Welcome to FlatShop</title>
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,300,300italic,400italic,500,700,500italic,100italic,100' rel='stylesheet' type='text/css'>
    <link href="css/font-awesome.min.css" rel="stylesheet">
    <link rel="stylesheet" href="css/flexslider.css" type="text/css" media="screen" />
    <link href="css/sequence-looptheme.css" rel="stylesheet" media="all" />
    <link href="css/style.css" rel="stylesheet">
    <script src="js/jquery-1.8.3.min.js"></script>
</head>
<body id="home">
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="header">
                <div class="container">
                    <div class="row">
                        <div class="col-md-2 col-sm-2">
                            <div class="logo">
                                <a href="index.html">
                                    <img src="images/logo.png" alt="FlatShop"></a>
                            </div>
                        </div>
                        <div class="col-md-10 col-sm-10">
                            <div class="header_top">
                                <div class="row">
                                    <div class="col-md-6">
                                        <ul class="topmenu">
                                            <li><a href="#">About Us</a></li>
                                            <li><a href="#">News</a></li>
                                            <li><a href="#">Service</a></li>
                                            <li><a href="#">Recruiment</a></li>
                                            <li><a href="#">Media</a></li>
                                            <li><a href="#">Support</a></li>
                                        </ul>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="usermenu">
                                            <asp:PlaceHolder ID="plChuaDangNhap" runat="server">
                                                <ul>
                                                    <li><a href="Default.aspx?modul=ThanhVien&modulphu=DangKy" class="reg">Đăng ký</a></li>
                                                    <li><a href="Default.aspx?modul=ThanhVien&modulphu=DangNhap" class="log">Đăng nhập</a></li>
                                                </ul>
                                            </asp:PlaceHolder>

                                            <asp:PlaceHolder ID="plDaDangNhap" runat="server" Visible="False">
                                                <ul>
                                                    <li><asp:LinkButton ID="lbtDangXuat" runat="server" CausesValidation="False" OnClick="lbtDangXuat_Click">Đăng xuất</asp:LinkButton></li>
                                                    <li>
                                                        <asp:Literal ID="ltrTenKhachHang" runat="server"></asp:Literal></li>
                                                </ul>
                                            </asp:PlaceHolder>
              
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="header_bottom">
                                <ul class="option">

                                    <!--Tìm kiếm-->
                                    <li id="search" class="search">
                                        <div>
                                            <input class="search-input" placeholder="Enter your search term..." type="text" name="pr_name" value="<%=tukhoa %>" id="keysearch" onkeydown="CheckPostSearch(event)">  
                                            <a href="javascript://" onclick="PostSearch()" class="search-submit"></a>
                                        </div>
                                            <script type="text/javascript">
                                            function CheckPostSearch(e) {
                                                if (e.keyCode === 1) {
                                                    PostSearch();

                                                    e.preventDefault();
                                                }
                                            }

                                            function PostSearch() {
                                                $("#keysearch").show().focus();
                                                if ($("#keysearch").val() !== "")
                                                    window.location = "/Default.aspx?modul=SanPham&modulphu=TimKiem&tukhoa=" + $("#keysearch").val();
                                            }
                                            </script>
                                    </li>

                                    <!--giỏ hàng-->
                                    <li class="option-cart">
                                        <a href="/Default.aspx?modul=SanPham&modulphu=GioHang" class="cart-icon">cart</a>
                                    </li>
                                </ul>


                                <!--Menu-->
                                <div class="navbar-collapse collapse">
                                    <ul class="nav navbar-nav">

                                        <li><a href="Default.aspx">Home</a></li>

                                        <li class="dropdown">
                                            <a href="Default.aspx?modul=SanPham" class="dropdown-toggle" data-toggle="dropdown">Sản phẩm</a>
                                            <div class="dropdown-menu mega-menu">
                                                <div class="row">
                                                    <div class="col-md-6 col-sm-6">
                                                        <ul class="mega-menu-links">
                                                            <asp:Literal ID="ltrDanhMucSanPham" runat="server"></asp:Literal>
                                                            <li><a href="Default.aspx?modul=SanPham">Tất cả</a></li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>

                                        <li class="dropdown">
                                            <a href="/Default.aspx?modul=TinTuc" class="dropdown-toggle" data-toggle="dropdown">Tin tức</a>
                                            <div class="dropdown-menu mega-menu">
                                                <div class="row">
                                                    <div class="col-md-6 col-sm-6">
                                                        <ul class="mega-menu-links">
                                                            <asp:Literal ID="ltrDanhMucTinTuc" runat="server"></asp:Literal>
                                                            <li><a href="Default.aspx?modul=TinTuc">Tất cả</a></li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>

                                        <li><a href="#">Liên hệ</a></li>
                                        <li><a href="#">Giới thiệu</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>


        <!--Thân trang -->
        <uc1:DisplayLoadControl runat="server" ID="DisplayLoadControl" />


        <div class="clearfix"></div>
        <div class="footer">
            <div class="footer-info">
                <div class="container">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="footer-logo">
                                <a href="#">
                                    <img src="images/logo.png" alt=""></a>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-6">
                            <h4 class="title">Contact <strong>Info</strong></h4>
                            <p>Trường cao đẳng công nghệ Bách Khoa Hà Nội</p>
                            <p>Phone : (+84) 329807206</p>
                            <p>Email : Quangseven.love@gmail.com</p>
                        </div>
                        <div class="col-md-3 col-sm-6">
                            <h4 class="title">Customer<strong> Support</strong></h4>
                            <ul class="support">
                                <li><a href="#">FAQ</a></li>
                                <li><a href="#">Payment Option</a></li>
                                <li><a href="#">Booking Tips</a></li>
                                <li><a href="#">Infomation</a></li>
                            </ul>
                        </div>
                        <div class="col-md-3">
                            <h4 class="title">Get Our <strong>Newsletter </strong></h4>
                            <p></p>
                            <div class="newsletter">
                                <input type="text" name="" placeholder="Type your email....">
                                <input type="submit" value="SignUp" class="button">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="copyright-info">
                <div class="container">
                    <div class="row">
                        <div class="col-md-6">
                            <p>Copyright © 2020. Designed by <a href="#">Tran Quang</a>. All rights reseved</p>
                        </div>
                        <div class="col-md-6">
                            <ul class="social-icon">
                                <li>
                                    <a href="#" class="linkedin"></a>
                                </li>
                                <li>
                                    <a href="#" class="google-plus"></a>
                                </li>
                                <li>
                                    <a href="#" class="twitter"></a>
                                </li>
                                <li>
                                    <a href="#" class="facebook"></a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Bootstrap core JavaScript==================================================-->
        <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
        <script type="text/javascript" src="js/jquery.easing.1.3.js"></script>
        <script type="text/javascript" src="js/bootstrap.min.js"></script>
        <script type="text/javascript" src="js/jquery.sequence-min.js"></script>
        <script type="text/javascript" src="js/jquery.carouFredSel-6.2.1-packed.js"></script>
        <script src="js/jquery.flexslider.js"></script>
        <script type="text/javascript" src="js/script.min.js"></script>
    </form>
</body>
</html>
