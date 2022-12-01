using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_admin_SanPham_QuanLySize_Size_ThemMoi : System.Web.UI.UserControl
{
    private string thaotac = "";
    private string id = "";//lấy id của size cần chỉnh sửa
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
            cbThemNhieuSize.Visible = false;

            DataTable dt = new DataTable();
            dt = shopquanao.Size.Thongtin_Size_by_id(id);
            if (dt.Rows.Count > 0)
            {
                tbTenSize.Text = dt.Rows[0]["TenSize"].ToString();
            }
        }

        else
        {
            btThemMoi.Text = "Thêm Mới";
            cbThemNhieuSize.Visible = true;
        }

    }
    protected void btThemMoi_Click(object sender, EventArgs e)
    {
        if (thaotac == "ThemMoi")
        {
            #region code nút thêm mới

            shopquanao.Size.Size_Insert(tbTenSize.Text, "");
            ltrThongBao.Text = "<div class='thongBaoTaoThanhCong' style='color:#00DD00;font-size:14px;padding-bottom:20px;text-align:center;font-weight:bold'>Đã tạo màu: " + tbTenSize.Text + "</div>";

            if (cbThemNhieuSize.Checked)
            {
                //viết code xử lý xóa mau đã nhập để người dùng nhập danh mục tiếp theo
                ResetControl();
            }

            else
            {
                //đẩy trang về trang danh sách các damnh mục đã tạo

                Response.Redirect("Admin.aspx?modul=SanPham&modulphu=Size");
            }
            #endregion
        }
        else
        {
            #region code nút chỉnh sửa

            shopquanao.Size.Size_Update(id, tbTenSize.Text);

            //đẩy trang về trang danh sách các damnh mục đã tạo
            Response.Redirect("Admin.aspx?modul=SanPham&modulphu=Size");

            #endregion
        }
    }

    private void ResetControl()
    {
        tbTenSize.Text = "";
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        ResetControl();
    }
}