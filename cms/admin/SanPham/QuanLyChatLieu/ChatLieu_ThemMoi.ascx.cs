using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_admin_SanPham_QuanLyChatLieu_ChatLieu_ThemMoi : System.Web.UI.UserControl
{
    private string thaotac = "";
    private string id = "";//lấy id của chất liệu cần chỉnh sửa
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
            cbThemNhieuChatLieu.Visible = false;

            DataTable dt = new DataTable();
            dt = shopquanao.ChatLieu.Thongtin_ChatLieu_by_id(id);
            if (dt.Rows.Count > 0)
            {
                tbTenChatLieu.Text = dt.Rows[0]["TenChatLieu"].ToString();
            }
        }

        else
        {
            btThemMoi.Text = "Thêm Mới";
            cbThemNhieuChatLieu.Visible = true;
        }

    }
    protected void btThemMoi_Click(object sender, EventArgs e)
    {
        if (thaotac == "ThemMoi")
        {
            #region code nút thêm mới

            shopquanao.ChatLieu.Chatlieu_Insert(tbTenChatLieu.Text, "");
            ltrThongBao.Text = "<div class='thongBaoTaoThanhCong' style='color:#00DD00;font-size:14px;padding-bottom:20px;text-align:center;font-weight:bold'>Đã tạo màu: " + tbTenChatLieu.Text + "</div>";

            if (cbThemNhieuChatLieu.Checked)
            {
                //viết code xử lý xóa chất liệu đã nhập để người dùng nhập danh mục tiếp theo
                ResetControl();
            }

            else
            {
                //đẩy trang về trang danh sách các chất liệu đã tạo

                Response.Redirect("Admin.aspx?modul=SanPham&modulphu=ChatLieu");
            }
            #endregion
        }
        else
        {
            #region code nút chỉnh sửa

            shopquanao.ChatLieu.Chatlieu_Update(id, tbTenChatLieu.Text);

            //đẩy trang về trang danh sách các damnh mục đã tạo
            Response.Redirect("Admin.aspx?modul=SanPham&modulphu=ChatLieu");

            #endregion
        }
    }

    private void ResetControl()
    {
        tbTenChatLieu.Text = "";
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        ResetControl();
    }
}