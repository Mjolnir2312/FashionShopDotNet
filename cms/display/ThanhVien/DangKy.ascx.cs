using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_Display_ThanhVien_DangKy : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbtDangKy_Click(object sender, EventArgs e)
    {
        //Kiểm tra email đã có trong database khách hàng chưa thì mới cho đăng ký
        if (DaTonTaiEmail(tbEmail.Text)){
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Email này đã được đăng ký. Vui lòng chọn Email khác.');",true);
        }
        else
        {
            //Thực hiện thêm mới tài khoản
            string matkhau = shopquanao.MaHoaPass.MaHoaMD5(tbMatKhau.Text);
            shopquanao.KhachHang.Khachang_Insert(tbHoTen.Text, tbDiaChi.Text, tbSoDienThoai.Text, tbEmail.Text, matkhau, "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Đã đăng ký thành công.'); location.href='/Default.aspx?modul=ThanhVien&modulphu=DangNhap'", true);

        }
    }

    private bool DaTonTaiEmail(string email)
    {
        DataTable dt = new DataTable();
        dt = shopquanao.KhachHang.Thongtin_Khachhang_by_emailkh(email);
        if (dt.Rows.Count > 0)
        {
            return true;
        }
        else return false;
    }
}