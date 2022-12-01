using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_admin_DonDatHang_ĐonDatHang_HienThi : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LayDonHang();
    }

    private void LayDonHang()
    {
        DataTable dt = new DataTable();
        dt = shopquanao.DonDatHang.Thongtin_Dondathang_Desc();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ltrDonHang.Text += @"
<tr id='maDong_" + dt.Rows[i]["MaDonDatHang"] + @"'>
           <td class='cotMa'>" + dt.Rows[i]["MaDonDatHang"] + @"</td>
           <td class='cotNgay'>" + dt.Rows[i]["NgayTao"] + @"</td>
           <td class='cotGia'>" + dt.Rows[i]["ThanhTienDH"] + @"</td>
           <td class='cotTen'>" + dt.Rows[i]["TenKH"] + @"</td>
           <td class='cotThuTu'>" + dt.Rows[i]["sdtKH"] + @"</td>
           <td class='cotEmail'>" + dt.Rows[i]["EmailKH"] + @"</td>
           <td class='cotCongCu'>
               
               
           </td>
</tr>
";
        }

    }
}