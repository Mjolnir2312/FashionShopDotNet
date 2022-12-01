using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["DangNhap"] !=null && Session["DangNhap"].ToString() == "1")
        {
            
        }else
        {
            Response.Redirect("/Login.aspx");
        }

        if (!IsPostBack)
            ltrTenDangNhap.Text = Session["TenDangNhap"].ToString();
    }
    protected string DanhDau(string tenModul)
    {
        string s = "";

        string modul = ""; //Biến lưu giá trị của querstring modul
        if (Request.QueryString["modul"] != null)
            modul = Request.QueryString["modul"];
        if (tenModul == modul)
            s = "current";

        return s;
    }

    protected void lbtDangXuat_Click(object sender, EventArgs e)
    {
        Session["DangNhap"] = "";
        Session["TenDangNhap"] = "";
        Response.Redirect("/Admin.aspx");
    }
}