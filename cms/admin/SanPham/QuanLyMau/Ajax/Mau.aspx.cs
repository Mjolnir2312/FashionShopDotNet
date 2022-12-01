using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_admin_SanPham_QuanLyMau_Ajax_Mau : System.Web.UI.Page
{
    string thaotac = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["DangNhap"] != null && Session["DangNhap"].ToString() == "1")
        {

        }
        else
        {
            return;
        }

        if (Request.Params["ThaoTac"] != null)
        {
            thaotac = Request.Params["ThaoTac"];
        }

        switch (thaotac)
        {
            case "XoaMau":
                XoaMau();
                break;

        }
    }

    private void XoaMau()
    {
        string MauID = "";
        if (Request.Params["MauID"] != null)
        {
            MauID = Request.Params["MauID"];

            //Thực hiện code xóa
            //B2: Xóa dữ liệu trên sqlserver
            shopquanao.Mau.Mau_Delete(MauID);

            // Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành công
            Response.Write("1");
        }
    }

}