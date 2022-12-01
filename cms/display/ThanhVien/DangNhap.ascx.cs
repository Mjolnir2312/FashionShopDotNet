using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_Display_ThanhVien_DangNhap : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbtDangNhap_Click(object sender, EventArgs e)
    {
        //Kiểm trả email, matkhau co trong data không
        DataTable dt = new DataTable();
        dt = shopquanao.KhachHang.Thongtin_Khachhang_by_emailkh_matkhau(tbEmail.Text, shopquanao.MaHoaPass.MaHoaMD5(tbMatKhau.Text));
        if(dt.Rows.Count >0)
        {
            //Lưu giá trị vào session để đánh giấu đã đăng nhập thành công
            Session["KhachHang"] = "1"; //Đã đăng nhập thành công

            //gán thêm thông tin tài khoản đã đăng nhập
            Session["MaKH"] = dt.Rows[0]["MaKH"];
            Session["TenKh"] = dt.Rows[0]["TenKh"];
            Session["DiaChiKH"] = dt.Rows[0]["DiaChiKH"];
            Session["sdtKH"] = dt.Rows[0]["sdtKH"];
            Session["EmailKH"] = dt.Rows[0]["EmailKH"];

            Response.Redirect("/Default.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Sai tên đăng nhập hoặc mật khẩu');", true);
        }
    }
}