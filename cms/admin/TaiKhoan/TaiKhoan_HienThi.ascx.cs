using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_admin_TaiKhoan_TaiKhoan_HienThi : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LayTaiKhoan();
    }

    private void LayTaiKhoan()
    {
        DataTable dt = new DataTable();
        dt = shopquanao.DangKy.Thongtin_Dangky();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ltrTaiKhoan.Text += @"
<tr id='maDong_" + dt.Rows[i]["TenDangNhap"] + @"'>
           <td class='cotTenDK'>" + dt.Rows[i]["TenDangNhap"] + @"</td>
           <td class='cotEmail'>" + dt.Rows[i]["EmailDK"] + @"</td>
           <td class='cotDiaChi'>" + dt.Rows[i]["DiaChiDK"] + @"</td>
           <td class='cotHoTen'>" + dt.Rows[i]["TenDayDu"] + @"</td>
           <td class='cotNgaySinh'>" + dt.Rows[i]["NgaySinh"] + @"</td>
           <td class='cotGioiTinh'>" + dt.Rows[i]["GioiTinhDK"] + @"</td>
           
           <td class='cotCongCu'>
     
               <a href='Admin.aspx?modul=TaiKhoan&modulphu=DanhSachTaiKhoan&thaotac=ChinhSua&id=" + dt.Rows[i]["TenDangNhap"] + @"' class='sua' title='Sửa'></a>
               <a href=javascript:XoaTaiKhoan('" + dt.Rows[i]["TenDangNhap"] + @"') class='xoa' title='Xóa'></a>
           </td>
</tr>
";
        }

    }
}