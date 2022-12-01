<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TrangChuLoadControl.ascx.cs" Inherits="cms_Display_TrangChu_TrangChuLoadControl" %>

<div class="hom-slider">
    <div class="container">
        <div id="sequence">
            <div class="sequence-prev"><i class="fa fa-angle-left"></i></div>
            <div class="sequence-next"><i class="fa fa-angle-right"></i></div>
            <ul class="sequence-canvas">
                <li class="animate-in">
                    <div class="flat-caption caption1 formLeft delay300 text-center"><span class="suphead">Paris show 2020</span></div>
                    <div class="flat-caption caption2 formLeft delay400 text-center">
                        <h1>Collection For Winter</h1>
                    </div>
                    <div class="flat-caption caption3 formLeft delay500 text-center">
                        <p>
                            Trước khi COVID-19 ập đến, chúng ta đã có những sàn diễn thời trang sôi động, đầy cuốn hút,<br />
                            nơi trình diễn những bộ sưu tập không chỉ đẹp mắt mà còn lắng đọng nhiều cảm xúc
                        </p>
                    </div>
                    <div class="flat-button caption4 formLeft delay600 text-center"><a class="more" href="/Default.aspx?modul=TinTuc&modulphu=ChiTietTinTuc&id=13">More Details</a></div>
                    <div class="flat-image formBottom delay200" data-duration="5" data-bottom="true">
                        <img src="images/slider-img2.png" alt="">
                    </div>
                </li>
                <li>
                    <div class="flat-caption caption2 formLeft delay400">
                        <h1>Collection For Winter</h1>
                    </div>
                    <div class="flat-caption caption3 formLeft delay500">
                        <h2>Etiam velit purus, luctus vitae velit sedauctor<br>
                            egestas diam, Etiam velit purus.</h2>
                    </div>
                    <div class="flat-button caption5 formLeft delay600"><a class="more" href="#">More Details</a></div>
                    <div class="flat-image formBottom delay200" data-bottom="true">
                        <img src="images/slider-img1.png" alt="">
                    </div>
                </li>
                <li>
                    <div class="flat-caption caption2 formLeft delay400 text-center">
                        <h1>New Fashion of 2021</h1>
                    </div>
                    <div class="flat-caption caption3 formLeft delay500 text-center">
                        <p>                     
The trends for spring / summer 2021 can be bold and brave, or dreamy and creative.
                            <br>
                            
                        </p>
                    </div>
                    <div class="flat-button caption4 formLeft delay600 text-center"><a class="more" href="/Default.aspx?modul=TinTuc&modulphu=ChiTietTinTuc&id=12">More Details</a></div>
                    <div class="flat-image formBottom delay200" data-bottom="true">
                        <img src="images/slider-image-02.png" alt="">
                    </div>
                </li>
            </ul>
        </div>
    </div>
    <div class="promotion-banner">
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-sm-4 col-xs-4">
                    <div class="promo-box">
                        <img src="images/promotion-01.png" alt="">
                    </div>
                </div>
                <div class="col-md-4 col-sm-4 col-xs-4">
                    <div class="promo-box">
                        <img src="images/promotion-02.png" alt="">
                    </div>
                </div>
                <div class="col-md-4 col-sm-4 col-xs-4">
                    <div class="promo-box">
                        <img src="images/promotion-03.png" alt="">
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>




<div class="container_fullwidth">
    <div class="container">
        <div class="hot-products">
            <asp:Literal ID="ltrNhomSanPham" runat="server"></asp:Literal>
        </div>
    </div>
</div>
