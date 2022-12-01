using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_Display_TinTuc_TinTucLoadControl : System.Web.UI.UserControl
{
    private string modul = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["modulphu"] != null)
            modul = Request.QueryString["modulphu"];
        switch (modul)
        {
            case "DanhSachTinTuc":
                plLoadControl.Controls.Add(LoadControl("DanhSachTinTuc.ascx"));
                break;
            case "ChiTietTinTuc":
                plLoadControl.Controls.Add(LoadControl("ChiTietTinTuc.ascx"));
                break;

            default:
                plLoadControl.Controls.Add(LoadControl("TrangChuModulTinTuc.ascx"));
                break;
        }
    }
}