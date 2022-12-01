using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class cms_admin_TinTuc_DanhMucTin_DanhSachTin_HienThi : System.Web.UI.UserControl
{
    string madmcha = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["madmcha"] != null)
            madmcha = Request.QueryString["madmcha"];
        if (!IsPostBack)
            LayDanhMuc();
    }

    private void LayDanhMuc()
    {
        DataTable dt = new DataTable();
        dt = shopquanao.DanhMucTin.Thongtin_DanhmucTin_by_MaDMCha(madmcha);
        for(int i = 0; i < dt.Rows.Count; i++)
        {
            ltrDanhMuc.Text += @"
        <tr id='maDong_" + dt.Rows[i]["MaDM"] + @"'>
            <td class='cotMa'>" + dt.Rows[i]["MaDM"] + @"</td>
            <td class='cotTen'>" + dt.Rows[i]["TenDM"] + @"</td>
            <td class='cotAnh'>
             <img class='anhDaiDien'src='/Picture/TinTuc/" + dt.Rows[i]["AnhDaiDien"] + @"'/>
             <img class='anhDaiDienHover'src='/Picture/TinTuc/" + dt.Rows[i]["AnhDaiDien"] + @"'/>
            </td>
            <td class='cottduTu'>" + dt.Rows[i]["ThuTu"] + @"</td>
            <td class='cotCongCu'>";
            if (CotDanhMucCon(dt.Rows[i]["MaDM"].ToString()))
                ltrDanhMuc.Text += @"<a href='Admin.aspx?modul=TinTuc&modulphu=DanhMucTin&madmcha=" + dt.Rows[i]["MaDM"] + @"' class='dmcon' title='Xem danh mục con'></a>";
            ltrDanhMuc.Text += @"
               <a href='Admin.aspx?modul=TinTuc&modulphu=DanhMucTin&thaotac=ChinhSua&id=" + dt.Rows[i]["MaDM"] + @"' class='sua' title='Sửa'></a>
               <a href='javascript:XoaDanhMuc(" + dt.Rows[i]["MaDM"] + @")' class='xoa' title='Xóa'></a>
</td>
        </tr>
";
        }
    }

    private bool CotDanhMucCon(string MaDMCha)
    {
        DataTable dt = new DataTable();
        dt = shopquanao.DanhMucTin.Thongtin_DanhmucTin_by_MaDMCha(MaDMCha);
        if (dt.Rows.Count > 0)
            return true;
        else
            return false;
    }
}