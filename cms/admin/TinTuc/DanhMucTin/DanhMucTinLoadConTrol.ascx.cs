using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_admin_TinTuc_DanhMucTin_DanhSachTinLoadConTrol : System.Web.UI.UserControl
{
    private string thaotac = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["thaotac"] != null)
            thaotac = Request.QueryString["thaotac"];
        switch (thaotac)
        {
            case "ThemMoi":
            case "ChinhSua":
                plLoadControl.Controls.Add(LoadControl("DanhMucTin_ThemMoi.ascx"));
                break;

            case "HienThi":
                plLoadControl.Controls.Add(LoadControl("DanhMucTin_HienThi.ascx"));
                break;

            default:
                plLoadControl.Controls.Add(LoadControl("DanhMucTin_HienThi.ascx"));
                break;
        }
    }
}