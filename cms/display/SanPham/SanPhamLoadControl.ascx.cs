using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_Display_SanPham_SanPhamLoadControl : System.Web.UI.UserControl
{
    private string modulphu = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["modulphu"] != null)
            modulphu = Request.QueryString["modulphu"];
        switch (modulphu)
        {
            case "DanhSachSanPham":
                plLoadControl.Controls.Add(LoadControl("DanhSachSanPham.ascx"));
                break;

            case "ChiTietSanPham":
                plLoadControl.Controls.Add(LoadControl("ChiTietSanPham.ascx"));
                break;

            case "GioHang":
                plLoadControl.Controls.Add(LoadControl("GioHang.ascx"));
                break;

            case "TimKiem":
                plLoadControl.Controls.Add(LoadControl("TimKiem.ascx"));
                break;

            default:
                plLoadControl.Controls.Add(LoadControl("TrangChuModulSanPham.ascx"));
                break;
        }
    }
}