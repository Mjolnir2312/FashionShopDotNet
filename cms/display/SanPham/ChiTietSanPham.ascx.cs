using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_Display_SanPham_ChiTietSanPham : System.Web.UI.UserControl
{
    protected string id = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
            id = Request.QueryString["id"];

        if (!IsPostBack)
            LayChiTietSanPham(id);
    }



    private string LayChiTietSanPham(string id)
    {
        string s = "";
        DataTable dt = new DataTable();
        dt = shopquanao.SanPham.Thongtin_Sanpham_by_id(id);
        if (dt.Rows.Count > 0)
        {
            ltrAnhSanPham.Text = "<img class='imgsp' src='/picture/sanpham/" + dt.Rows[0]["AnhSP"] + @"' alt='" + dt.Rows[0]["TenSP"] + @"' />";

            ltrTenSanPham.Text = dt.Rows[0]["TenSP"].ToString();
            ltrGiaSP.Text = dt.Rows[0]["GiaSP"].ToString();

            ltrKichThuoc.Text = LayTenKichThuoc(dt.Rows[0]["SizeID"].ToString());
            ltrMau.Text = LayTenMau(dt.Rows[0]["MauID"].ToString());
            ltrChatLieu.Text = LayTenChatLieu(dt.Rows[0]["ChatLieuID"].ToString());

            ltrThongTinchiTiet.Text = dt.Rows[0]["MotaSP"].ToString();
        }
        return s;
    }
    private string LayTenKichThuoc(string SizeID)
    {
        DataTable dt = new DataTable();
        dt = shopquanao.Size.Thongtin_Size_by_id(SizeID);
        if (dt.Rows.Count > 0)
            return dt.Rows[0]["TenSize"].ToString();
        else
            return "";
    }

    private string LayTenMau(string MauID)
    {
        DataTable dt = new DataTable();
        dt = shopquanao.Mau.Thongtin_Mau_by_id(MauID);
        if (dt.Rows.Count > 0)
            return dt.Rows[0]["TenMau"].ToString();
        else
            return "";
    }

    private string LayTenChatLieu(string ChatLieuID)
    {
        DataTable dt = new DataTable();
        dt = shopquanao.ChatLieu.Thongtin_ChatLieu_by_id(ChatLieuID);
        if (dt.Rows.Count > 0)
            return dt.Rows[0]["TenChatLieu"].ToString();
        else
            return "";
    }
}