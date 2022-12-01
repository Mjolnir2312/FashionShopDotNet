using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_Display_ThanhVien_ThanhVienLoadControl : System.Web.UI.UserControl
{
    private string modul = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["modulphu"] != null)
            modul = Request.QueryString["modulphu"];
        switch (modul)
        {
            case "DangKy":
                plLoadControl.Controls.Add(LoadControl("DangKy.ascx"));
                break;
            case "DanhNhap":
                plLoadControl.Controls.Add(LoadControl("DanhNhap.ascx"));
                break;

            default:
                plLoadControl.Controls.Add(LoadControl("DangNhap.ascx"));
                break;
        }
    }
}