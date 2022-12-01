using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_admin_SanPham_QuanLyMau_MauThemMoi : System.Web.UI.UserControl
{
    private string thaotac = "";
    private string id = "";//lấy id của màu cần chỉnh sửa
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["thaotac"] != null)
            thaotac = Request.QueryString["thaotac"];
        if (Request.QueryString["id"] != null)
            id = Request.QueryString["id"];
        if (!IsPostBack)
        {
            HienThiThongTin(id);
        }

    }

    private void HienThiThongTin(string id)
    {
        if (thaotac == "ChinhSua")
        {
            btThemMoi.Text = "Chỉnh Sửa";
            cbThemNhieuMau.Visible = false;

            DataTable dt = new DataTable();
            dt = shopquanao.Mau.Thongtin_Mau_by_id(id);
            if (dt.Rows.Count > 0)
            {
                tbTenMau.Text = dt.Rows[0]["TenMau"].ToString();
            }
        }

        else
        {
            btThemMoi.Text = "Thêm Mới";
            cbThemNhieuMau.Visible = true;
        }

    }
    protected void btThemMoi_Click(object sender, EventArgs e)
    {
        if (thaotac == "ThemMoi")
        {
            #region code nút thêm mới   

            shopquanao.Mau.Mau_Insert(tbTenMau.Text, "");
            ltrThongBao.Text = "<div class='thongBaoTaoThanhCong' style='color:#00DD00;font-size:14px;padding-bottom:20px;text-align:center;font-weight:bold'>Đã tạo màu: " + tbTenMau.Text + "</div>";

            if (cbThemNhieuMau.Checked)
            {
                //viết code xử lý xóa mau đã nhập để người dùng nhập danh mục tiếp theo
                ResetControl();
            }

            else
            {
                //đẩy trang về trang danh sách các damnh mục đã tạo

                Response.Redirect("Admin.aspx?modul=SanPham&modulphu=Mau");
            }
            #endregion
        }
        else
        {
            #region code nút chỉnh sửa

            shopquanao.Mau.Mau_Update(id, tbTenMau.Text);

            //đẩy trang về trang danh sách các damnh mục đã tạo
            Response.Redirect("Admin.aspx?modul=SanPham&modulphu=Mau");

            #endregion
        }
    }

    private void ResetControl()
    {
        tbTenMau.Text = "";
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        ResetControl();
    }
}