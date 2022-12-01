using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_Display_DisplayLoadControl : System.Web.UI.UserControl
{
    private string modul = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["modul"] != null)
            modul = Request.QueryString["modul"];
        switch (modul)
        {
            case "SanPham":
                plLoadControl.Controls.Add(LoadControl("SanPham/SanPhamLoadControl.ascx"));
                break;
            case "TrangChu":
                plLoadControl.Controls.Add(LoadControl("TrangChu/TrangChuLoadControl.ascx"));
                break;
            case "TinTuc":
                plLoadControl.Controls.Add(LoadControl("TinTuc/TinTucLoadControl.ascx"));
                break;
            case "ThanhVien":
                plLoadControl.Controls.Add(LoadControl("ThanhVien/ThanhVienLoadControl.ascx"));
                break;
            case "TimKiem":
                plLoadControl.Controls.Add(LoadControl("TimKiem/TimKiem.ascx"));
                break;

            default:
                plLoadControl.Controls.Add(LoadControl("TrangChu/TrangChuLoadControl.ascx"));
                break;
        }
    }
}