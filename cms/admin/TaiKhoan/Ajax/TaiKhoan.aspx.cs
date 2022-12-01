using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_admin_TaiKhoan_Ajax_TaiKhoan : System.Web.UI.Page
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
            case "XoaTaiKhoan":
                XoaTaiKhoan();
                break;

        }
    }

    private void XoaTaiKhoan()
    {
        string TenDangNhap = "";
        if (Request.Params["TenDangNhap"] != null)
        {
            TenDangNhap = Request.Params["TenDangNhap"];

            //Thực hiện code xóa
            //B2: Xóa dữ liệu trên sqlserver
            if (TenDangNhap.ToLower() != "admin") //không cho xóa tài khoản "admin"
            {
                shopquanao.DangKy.Dangky_Delete(TenDangNhap);
                // Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành công
                Response.Write("1");
            }
            else
            {
                Response.Write("Không thể xóa tài khoản admin");
            }

        }
    }
}