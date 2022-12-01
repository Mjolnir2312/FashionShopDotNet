﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using shopquanao;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_display_SanPham_Ajax_XuLyGioHang : System.Web.UI.Page
{
    private string thaotac = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        thaotac = Request.Params["ThaoTac"];
        switch (thaotac)
        {
            case "ThemVaoGioHang":
                ThemVaoGioHang();
                break;

            case "LayThongTinGioHang":
                LayThongTinGioHang();
                break;

            case "LayTongSoSanPhamTrongGioHang":
                LayTongSoSanPhamTrongGioHang();
                break;

            case "LayTongTienTrongGioHang":
                LayTongTienTrongGioHang();
                break;

            case "XoaSPTrongGioHang":
                XoaSPTrongGioHang();
                break;

            case "CapNhatSoLuongVaoGioHang":
                CapNhatSoLuongVaoGioHang();
                break;
            case "GuiDonHang":
                GuiDonHang();
                break;
        }
    }

    private void CapNhatSoLuongVaoGioHang()
    {
        //Lấy id sản phẩm cần loại khỏi giỏ hàng
        string idSanPham = Request.Params["idSanPham"];
        string soLuongMoi = Request.Params["soLuongMoi"];

        //Nếu tồn tại giỏ hàng thì mới lấy ra kết quả
        if (Session["GioHang"] != null)
        {
            //Khai báo datatable để chứa giỏ hàng
            DataTable dtGioHang = new DataTable();
            dtGioHang = (DataTable)Session["GioHang"];

            //Lặp qua danh sách sản phẩm trong giỏ hàng --> Cập nhật số lượng cho sản phẩm theo id được yêu cầu
            for (int i = 0; i < dtGioHang.Rows.Count; i++)
            {
                if (dtGioHang.Rows[i]["MaSP"].ToString() == idSanPham)
                    dtGioHang.Rows[i]["SoLuong"] = soLuongMoi;
            }

            //Gán lại vào session
            Session["GioHang"] = dtGioHang;
        }

        Response.Write("");
    }

    private void XoaSPTrongGioHang()
    {
        //Lấy id sản phẩm cần loại khỏi giỏ hàng
        string idSanPham = Request.Params["idSanPham"];

        //Nếu tồn tại giỏ hàng thì mới lấy ra kết quả
        if (Session["GioHang"] != null)
        {
            //Khai báo datatable để chứa giỏ hàng
            DataTable dtGioHang = new DataTable();
            dtGioHang = (DataTable)Session["GioHang"];

            //Lặp qua danh sách sản phẩm trong giỏ hàng --> Loại sản phẩm theo id truyền lên
            for (int i = 0; i < dtGioHang.Rows.Count; i++)
            {
                if (dtGioHang.Rows[i]["MaSP"].ToString() == idSanPham)
                    dtGioHang.Rows[i].Delete();
            }

            //Gán lại vào session
            Session["GioHang"] = dtGioHang;
        }

        Response.Write("");
    }

    private void LayTongTienTrongGioHang()
    {
        double tongTien = 0;

        //Nếu tồn tại giỏ hàng thì mới lấy ra kết quả
        if (Session["GioHang"] != null)
        {
            //Khai báo datatable để chứa giỏ hàng
            DataTable dtGioHang = new DataTable();
            dtGioHang = (DataTable)Session["GioHang"];

            //Chạy vòng lặp và tính ra tổng tiền (Thành tiền = Số lượng * Đơn giá)
            for (int i = 0; i < dtGioHang.Rows.Count; i++)
            {
                tongTien += int.Parse(dtGioHang.Rows[i]["SoLuong"].ToString()) * double.Parse(dtGioHang.Rows[i]["GiaSP"].ToString());
            }
        }

        Response.Write(tongTien);
    }

    private void LayTongSoSanPhamTrongGioHang()
    {
        int tongSo = 0;

        //Nếu tồn tại giỏ hàng thì mới lấy ra kết quả
        if (Session["GioHang"] != null)
        {
            //Khai báo datatable để chứa giỏ hàng
            DataTable dtGioHang = new DataTable();
            dtGioHang = (DataTable)Session["GioHang"];

            //Chạy vòng lặp và đếm tổng số sản phẩm trong giỏ hàng
            for (int i = 0; i < dtGioHang.Rows.Count; i++)
            {
                tongSo += int.Parse(dtGioHang.Rows[i]["SoLuong"].ToString());
            }
        }

        Response.Write(tongSo);
    }

    private void LayThongTinGioHang()
    {
        string ketQua = "";

        //Nếu tồn tại giỏ hàng thì mới lấy ra kết quả
        if (Session["GioHang"] != null)
        {
            //Khai báo datatable để chứa giỏ hàng
            DataTable dtGioHang = new DataTable();
            dtGioHang = (DataTable)Session["GioHang"];

            ketQua += @"
<table style='width:100%;' id='cart-table'>
    <tbody>
        <tr>
            <th></th>
            <th>Tên sản phẩm</th>
            <th>Số lượng</th>
            <th>Đơn giá</th>
            <th></th>
        </tr>
        <tr class='line-item original'>
            <td class='item-image'></td>
            <td class='item-title'>
                <a></a>
            </td>
            <td class='item-quantity'></td>
            <td class='item-price'></td>
            <td class='item-delete'></td>
        </tr>";

            //Chạy vòng lặp và xuất dữ liệu trong giỏ hàng ra dạng bảng
            for (int i = 0; i < dtGioHang.Rows.Count; i++)
            {
                ketQua += @"
        <tr class='line-item' id='tr_" + dtGioHang.Rows[i]["MaSP"] + @"'>
            <td class='item-image'><img class='anhSPGioHang' src='/picture/SanPham/" + dtGioHang.Rows[i]["AnhSP"] + @"' /></td>
            <td class='item-title'>
                <a href='/Default.aspx?modul=SanPham&modulphu=ChiTietSanPham&id=" + dtGioHang.Rows[i]["MaSP"] + @"'>" + dtGioHang.Rows[i]["TenSP"] + @"</a>
            </td>
            <td class='item-quantity'><input onchange='CapNhatSoLuongVaoGioHang(" + dtGioHang.Rows[i]["MaSP"] + @")' id='quantity_" + dtGioHang.Rows[i]["MaSP"] + @"' name='updates[]' min='1' type='number' value='" + dtGioHang.Rows[i]["SoLuong"] + @"' class=''></td>
            <td class='item-price'>" + dtGioHang.Rows[i]["GiaSP"] + @"</td>
            <td class='item-delete'><a href='javascript://' onclick='XoaSPTrongGioHang(" + dtGioHang.Rows[i]["MaSP"] + @")'>Xóa</a></td>
        </tr>
";
            }

            ketQua += @"
    </tbody>
</table>
";
        }

        Response.Write(ketQua);
    }

    private void ThemVaoGioHang()
    {
        string ketQua = "";

        string id = Request.Params["id"];
        string soLuong = Request.Params["soLuong"];

        //Lấy thông tin chi tiết sản phẩm được add vào giỏ hàng
        DataTable dt = new DataTable();
        dt = shopquanao.SanPham.Thongtin_Sanpham_by_id(id);
        if (dt.Rows.Count > 0)//Nếu tồn tại sản phẩm mới thực hiện thao tác
        {
            //Nếu chưa có giỏ hàng --> tạo giỏ hàng
            if (Session["GioHang"] == null)
            {
                //Khai báo datatable để lưu thông tin sản phẩm vào giỏ hàng lần đầu tiên
                DataTable dtGioHang = new DataTable();
                dtGioHang.Columns.Add("MaSP");
                dtGioHang.Columns.Add("TenSP");
                dtGioHang.Columns.Add("AnhSP");
                dtGioHang.Columns.Add("GiaSP");
                dtGioHang.Columns.Add("SoLuong");

                //Lưu các thông tin của sản phẩm hiện tại vào datatable
                dtGioHang.Rows.Add(dt.Rows[0]["MaSP"].ToString(), dt.Rows[0]["TenSP"].ToString(),
                    dt.Rows[0]["AnhSP"].ToString(), dt.Rows[0]["GiaSP"].ToString(), soLuong);

                //Gán giá trị của bảng tạm - datatable vào giỏ hàng
                Session["GioHang"] = dtGioHang;

            }
            //Nếu đã có giỏ hàng --> thêm mới sản phẩm vào giỏ hàng
            else
            {
                //Khai báo datatable để chứa giỏ hàng
                DataTable dtGioHang = new DataTable();
                dtGioHang = (DataTable)Session["GioHang"];

                //Kiểm tra xem trong giỏ hàng có sản phẩm này chưa
                //Nếu có --> tăng số lượng ở dòng chứa sản phẩm này
                //Nếu chưa có --> thêm sản phẩm vào dòng cuối giỏ hàng

                int viTriSPTrongGioHang = -1;//Nếu sau vòng lặp vị trí thay đổi --> tức là có sản phẩm trong giỏ hàng
                for (int i = 0; i < dtGioHang.Rows.Count; i++)
                {
                    if (dtGioHang.Rows[i]["MaSP"].ToString() == id)
                    {
                        //Có tồn tại sản phẩm này trong giỏ hàng
                        viTriSPTrongGioHang = i;
                        //Thoát vòng lặp
                        break;
                    }
                }

                //Nếu có
                if (viTriSPTrongGioHang != -1)
                {
                    //Lấy ra số lượng hiện tại của sản phẩm đó trong giỏ hàng
                    int soLuongHienTai = int.Parse(dtGioHang.Rows[viTriSPTrongGioHang]["SoLuong"].ToString());

                    //Tăng số lượng lên
                    soLuongHienTai += int.Parse(soLuong);

                    //Cập nhật vào dòng chứa thông tin sản phẩm hiện tại
                    dtGioHang.Rows[viTriSPTrongGioHang]["SoLuong"] = soLuongHienTai;

                    //Gán lại giá trị của bảng tạm vào giỏ hàng
                    //Gán giá trị của bảng tạm - datatable vào giỏ hàng
                    Session["GioHang"] = dtGioHang;
                }
                //Nếu không có trong giỏ hàng
                else
                {
                    //Lưu các thông tin của sản phẩm hiện tại vào datatable
                    dtGioHang.Rows.Add(dt.Rows[0]["MaSP"].ToString(), dt.Rows[0]["TenSP"].ToString(),
                        dt.Rows[0]["AnhSP"].ToString(), dt.Rows[0]["GiaSP"].ToString(), soLuong);

                    //Gán giá trị của bảng tạm - datatable vào giỏ hàng
                    Session["GioHang"] = dtGioHang;
                }
            }
        }
        else
        {
            ketQua = "Không tồn tại sản phẩm này";
        }

        Response.Write(ketQua);
    }

    private void GuiDonHang()
    {
        string ketQua = "";

        //Lấy các thông tin người dùng gửi lên
        string hoTen = Request.Params["hoTen"];
        string diaChi = Request.Params["diaChi"];
        string soDienThoai = Request.Params["soDienThoai"];
        string email = Request.Params["email"];
        string phuongThucThanhToan = Request.Params["phuongThucThanhToan"];


        //Nếu tồn tại giỏ hàng thì mới xử lý đặt hàng
        if (Session["GioHang"] != null)
        {
            //Khai báo datatable để chứa giỏ hàng
            DataTable dtGioHang = new DataTable();
            dtGioHang = (DataTable)Session["GioHang"];

            #region Lặp trong giỏ hàng để lấy ra tổng tiền
            double tongTien = 0;
            for (int i = 0; i < dtGioHang.Rows.Count; i++)
            {
                tongTien += int.Parse(dtGioHang.Rows[i]["SoLuong"].ToString()) * double.Parse(dtGioHang.Rows[i]["GiaSP"].ToString());
            }
            #endregion

            #region Kiểm tra và thêm thông tin vào bảng Khách hàng

            string maKH = XuLyThongTinKhachHang(hoTen, diaChi, soDienThoai, email);

            #endregion

            //Lấy ngày giờ hiện tại trả về dạng số để làm mã thanh toán trực tuyến
            string mathanhtoantructuyen = DateTime.Now.Ticks.ToString();

            #region Thêm thông tin vào bảng Đơn đặt hàng
            //Tạo đơn đặt hàng
            string ngayTao = DateTime.Now.ToString();
            DonDatHang.Dondathang_Insert(ngayTao, tongTien.ToString(), mathanhtoantructuyen, maKH, hoTen, soDienThoai,
                email, "");

            //Lấy ra thông tin Đơn đặt hàng vừa tạo
            DataTable dtDonDatHang = DonDatHang.Thongtin_Dondathang_Desc();
            string maDonDatHang = dtDonDatHang.Rows[0]["MaDonDatHang"].ToString();
            #endregion

            #region Đọc giỏ hàng và thêm từng sản phẩm vào bảng Chi tiết đơn đặt hàng
            for (int i = 0; i < dtGioHang.Rows.Count; i++)
            {
                ChiTietDonDatHang.Chitietdondathang_Insert(dtGioHang.Rows[i]["MaSP"].ToString(), maDonDatHang, dtGioHang.Rows[i]["SoLuong"].ToString(), dtGioHang.Rows[i]["GiaSP"].ToString(), "");
            }
            #endregion

            #region Xóa session giỏ hàng

            Session["GioHang"] = null;

            #endregion

            
        }
        else
            ketQua = "Giỏ hàng đã hết hạn, vui lòng thực hiện chọn lại sản phẩm và đặt hàng lại";

        Response.Write(ketQua);
    }

    private string XuLyThongTinKhachHang(string hoTen, string diaChi, string soDienThoai, string email)
    {
        //Lấy danh sách khách hàng theo email --> nếu chưa có --> Thêm mới, nếu đã có thì không thực hiện gì nữa
        DataTable dt = KhachHang.Thongtin_Khachhang_by_emailkh(email);
        if (dt.Rows.Count == 0)
        {
            //Thêm mới khách hàng với mật khẩu chính là email của khách hàng
            string matKhau = shopquanao.MaHoaPass.MaHoaMD5(email);
            KhachHang.Khachang_Insert(hoTen, diaChi, soDienThoai, email, matKhau, "");

            //Thực hiện lấy lại thông tin khách hàng vừa thêm và trả về mã khách hàng
            dt = KhachHang.Thongtin_Khachhang_by_emailkh(email);
            return dt.Rows[0]["MaKH"].ToString();
        }
        else
            return dt.Rows[0]["MaKH"].ToString();
    }
}