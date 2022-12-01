<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GioHang.ascx.cs" Inherits="cms_Display_SanPham_GioHang" %>

<link href="css/gio-hang.css" rel="stylesheet" />
<div class="modal-content">
    <div class="modal-header">
        <h4 class="modal-title" id="exampleModalLabel">Bạn có <span class="TongSoSPTrongGioHang">0</span> sản phẩm trong giỏ hàng.</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <a aria-hidden="true"></a>
        </button>
    </div>
    <div>
        <div class="modal-body" id="BangThongTinGioHang">
            <%--Khự vực chứa dữ liệu về giỏ hàng được lấy qua ajax--%>
        </div>
        <div class="cb" style="padding-right: 10px">
            <div class="total-price-modal">
                Tổng cộng : <span class="item-total TongTienTrongGioHang">0</span>đ
            </div>
        </div>
        <div class="modal-footer">
            <div class="dienThongTinDatHang">
                <div class="goiY">Quý khách vui lòng điền đầy đủ thông tin theo form phía dưới và nhấn nút Đặt hàng.<br />
                    Lưu ý: Nếu quý khách điền vào ô Email thì hệ thống sẽ kiểm tra và tạo cho quý khách một tài khoản thành viên với tên đăng nhập và mật khẩu chính là email của quý khách để quý khách có thể đặt hàng dễ dàng hơn ở lần sau.</div>
                <div class="row">
                    <div class="col-lg-3">
                        <div class="modal-title-note">
                            Họ tên (*):
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="modal-note">
                            <input id="tbHoTen" type="text" value="<%=hoTen %>" />
                        </div>
                    </div>
                    <div class="cb"></div>
                </div>

                <div class="row">
                    <div class="col-lg-3">
                        <div class="modal-title-note">
                            Địa chỉ:
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="modal-note">
                            <input id="tbDiaChi" type="text" value="<%=diaChi %>" />
                        </div>
                    </div>
                    <div class="cb"></div>
                </div>

                <div class="row">
                    <div class="col-lg-3">
                        <div class="modal-title-note">
                            Số điện thoại (*):
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="modal-note">
                            <input id="tbSoDienThoai" type="text" value="<%=soDienThoai %>" />
                        </div>
                    </div>
                    <div class="cb"></div>
                </div>

                <div class="row">
                    <div class="col-lg-3">
                        <div class="modal-title-note">
                            Email:
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="modal-note">
                            <input id="tbEmail" type="text" value="<%=email %>" />
                        </div>
                    </div>
                    <div class="cb"></div>
                </div>
            </div>

            <div class="CacHinhThucThanhToan">
                <div class="goiY">
                </div>
                <div>                    
                    <input id="rbTTKhiNhanHang" type="radio" name="rbHinhThucThanhToan"/><label for="rbChuyenKhoan">Thanh toán khi nhận hàng</label>
                </div><br/>
                <div>
                    <input id="rbChuyenKhoan" type="radio" name="rbHinhThucThanhToan" /><label for="rbChuyenKhoan">Thanh toán chuyển khoản</label>
                    <div class="paymentInfo">
                    </div>
                </div>
                <br />
                <div>
                    <input id="rbOnepay" type="radio" name="rbHinhThucThanhToan" checked="checked" /><label for="rbOnepay">Thanh toán trực tuyến qua thẻ ATM</label>
                    <div class="paymentInfo">
                        <script type="text/javascript" src="http://202.9.84.88/documents/payment/logoscript.jsp?logos=at&lang=vi"></script>
                        <div class="cb">
                            <!---->
                        </div>
                    </div>
                </div>
                <br />
                <div>
                    <input id="rbOnepayQuocTe" type="radio" name="rbHinhThucThanhToan" /><label for="rbOnepayQuocTe">Thanh toán trực tuyến qua thẻ Visa, Master, American Express,...</label>
                    <div class="paymentInfo">
                        <script type="text/javascript" src="http://202.9.84.88/documents/payment/logoscript.jsp?logos=v,m,a,j,u&lang=en"></script>
                        <div class="cb">
                            <!---->
                        </div>
                    </div>
                </div>
                <br />
            </div>
            <div class="thongTinTheTest">
            </div>

            <div class="row" style="margin-top: 10px;">
                <div class="col-lg-6">
                    <div class="comeback">
                        <a href="/">
                            <img src="../picture/dangnhap/icon-tieptuc.png" />
                            Tiếp tục mua hàng
                        </a>
                    </div>
                </div>
                <div class="col-lg-6 text-right">
                    <div class="buttons btn-modal-cart">
                        <a href="javacript://" onclick="GuiDonHang()" class="button-default">Đặt hàng</a>
                    </div>
                </div>
            </div>

        </div>

    </div>
</div>
<script type="text/javascript">
    //Viết ajax lấy thông tin giỏ hàng từ session
    function LayThongTinGioHang() {
        $.post("cms/display/SanPham/Ajax/XuLyGioHang.aspx",
         {
             "ThaoTac": "LayThongTinGioHang"
         },
         function (data, status) {
             //alert("Data :" + data + "\n Status :" + status);
             $("#BangThongTinGioHang").html(data);
         });
    }

    function LayTongSoSanPhamTrongGioHang() {
        $.post("cms/display/SanPham/Ajax/XuLyGioHang.aspx",
         {
             "ThaoTac": "LayTongSoSanPhamTrongGioHang"
         },
         function (data, status) {
             //alert("Data :" + data + "\n Status :" + status);
             $(".TongSoSPTrongGioHang").html(data);
         });
    }

    function LayTongTienTrongGioHang() {
        $.post("cms/display/SanPham/Ajax/XuLyGioHang.aspx",
         {
             "ThaoTac": "LayTongTienTrongGioHang"
         },
         function (data, status) {
             //alert("Data :" + data + "\n Status :" + status);
             $(".TongTienTrongGioHang").html(data);
         });
    }


    //Gọi hàm lần đầu để khi load trang sẽ lấy ra thông tin luôn
    $(document)
        .ready(function () {
            LayThongTinGioHang();
            LayTongSoSanPhamTrongGioHang();
            LayTongTienTrongGioHang();
        });



    //Hàm xóa 1 sản phẩm trong giỏ hàng
    function XoaSPTrongGioHang(idSanPham) {
        //Hỏi để xác nhận lại yêu cầu xóa từ người dùng
        if (confirm("Bạn muốn xóa sản phẩm này khỏi giỏ hàng?")) {

            $.post("cms/display/SanPham/Ajax/XuLyGioHang.aspx",
                {
                    "ThaoTac": "XoaSPTrongGioHang",
                    "idSanPham": idSanPham
                },
                function (data, status) {
                    //alert("Data :" + data + "\n Status :" + status);

                    //Nếu không có lỗi (tức là xóa thành công) --> ẩn dòng chứa sản phẩm khỏi bảng hiển thị giỏ hàng --> Gọi hàm cập nhật số lượng, tổng tiền
                    if (data === "") {
                        $("#tr_" + idSanPham).remove();

                        LayTongSoSanPhamTrongGioHang();
                        LayTongTienTrongGioHang();
                    }
                });
        }
    }


    //Hàm cập nhật số lượng cho một sản phẩm trong giỏ hàng
    function CapNhatSoLuongVaoGioHang(idSanPham) {

        //Lấy số lượng mới sửa từ textbox
        var soLuongMoi = $("#quantity_" + idSanPham).val();

        $.post("cms/display/SanPham/Ajax/XuLyGioHang.aspx",
               {
                   "ThaoTac": "CapNhatSoLuongVaoGioHang",
                   "idSanPham": idSanPham,
                   "soLuongMoi": soLuongMoi
               },
               function (data, status) {
                   //alert("Data :" + data + "\n Status :" + status);

                   //Nếu không có lỗi (tức là xóa thành công) --> ẩn dòng chứa sản phẩm khỏi bảng hiển thị giỏ hàng --> Gọi hàm cập nhật số lượng, tổng tiền
                   if (data === "") {
                       LayTongSoSanPhamTrongGioHang();
                       LayTongTienTrongGioHang();
                   }
               });
    }



    //Hàm gửi đơn hàng
    function GuiDonHang() {
        //Kiểm tra xem khách hàng đã nhập đủ họ tên và số điện thoại chưa
        if ($("#tbHoTen").val() !== "" && $("#tbSoDienThoai").val() !== "") {

            var phuongthucthanhtoan = "";
            if ($("#rbTTKhiNhanHang").is(":checked")) phuongthucthanhtoan = "ThanhToanCOD"; 
            if ($("#rbChuyenKhoan").is(":checked")) phuongthucthanhtoan = "ChuyenKhoan";
            if ($("#rbOnepay").is(":checked")) phuongthucthanhtoan = "Onepay";
            if ($("#rbOnepayQuocTe").is(":checked")) phuongthucthanhtoan = "OnepayQuocTe";

            $.post("cms/display/SanPham/Ajax/XuLyGioHang.aspx",
                   {
                       "ThaoTac": "GuiDonHang",
                       "hoTen": $("#tbHoTen").val(),
                       "diaChi": $("#tbDiaChi").val(),
                       "soDienThoai": $("#tbSoDienThoai").val(),
                       "email": $("#tbEmail").val(),
                       "phuongThucThanhToan": phuongthucthanhtoan
                   },
                   function (data, status) {
                       //alert("Data :" + data + "\n Status :" + status);

                    //Nếu không có lỗi (tức là xóa thành công) --> thông báo đặt hàng thành công --> đẩy về trang chủ
                    if (phuongthucthanhtoan === "ThanhToanCOD" || phuongthucthanhtoan ==="ChuyenKhoan") {
                           if (data === "") {
                               alert("Bạn đã gửi đơn hàng thành công");
                               location.href = "/";
                           }
                       } else {//Trường hợp thanh toán online --> đẩy tới trang thanh toán của đơn vị tích hợp
                           location.href = data;
                       }
                   });
        } else {
            alert("Vui lòng nhập đầy đủ Họ tên và Số điện thoại để đặt hàng");
        }
    }
</script>
