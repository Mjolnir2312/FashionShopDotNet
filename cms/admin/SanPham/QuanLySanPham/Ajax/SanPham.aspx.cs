using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_admin_SanPham_QuanLySanPham_Ajax_SanPham : System.Web.UI.Page
{
    private string thaotac = "";
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
            case "XoaSanPham":
                XoaSanPham();
                break;

        }
    }

    private void XoaSanPham()
    {
        string MaSP = "";
        if (Request.Params["MaSP"] != null)
        {
            MaSP = Request.Params["MaSP"];

            //Thực hiện code xóa    
            //B1: Xóa ảnh đại diện đã lưu trên server - tạm b
            //B2: Xóa dữ liệu trên sqlserver
            shopquanao.SanPham.Sanpham_Delete(MaSP);

            // Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành công
            Response.Write("1");
        }
    }
}
