using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_Display_SanPham_TrangChuModulSanPham : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            ltrNhomSanPham.Text = LayDanhMucSanPham();
        }
    }


    private string LayDanhMucSanPham()
    {
        string s = "";
        DataTable dt = new DataTable();
        dt = shopquanao.DanhMuc.Thongtin_Danhmuc_by_MaDMCha("0");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            s += @"<h3 class='title'>" + dt.Rows[i]["TenDM"] + @"</h3>";
            s += "<div class='control'><a id='prev_hot' class='prev' href='#'>&lt;</a><a id='next_hot' class='next' href='#'>&gt;</a></div>";
            s += "      <ul id='hot'>";
            s += "<li>";

            s += LayDanhSachSanPhamTheoDanhMuc(dt.Rows[i]["MaDM"].ToString());

            s += "</li>";
            s += "   </ul>";
        }

        return s;
    }

    private string LayDanhSachSanPhamTheoDanhMuc(string MaDM)
    {
        string s = "";
        DataTable dt = new DataTable();
        dt = shopquanao.SanPham.Thongtin_Sanpham_by_madm(MaDM);

        string link = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            link = "Default.aspx?modul=SanPham&modulphu=ChiTietSanPham&id=" + dt.Rows[i]["MaSP"];

            s += @"
                 <div class='col-md-3 col-sm-6'>
                    <div class='products'>
                      <div class='offer'>- %20</div>
                         <div class='thumbnail'>
                                <a href = '" + link + @"' title='" + dt.Rows[i]["TenSP"] + @"' >
                                <img src='/picture/sanpham/" + dt.Rows[i]["AnhSP"] + @"' alt='" + dt.Rows[i]["TenSP"] + @"'></a>
                         </div>
                          <div class='productname'>" + dt.Rows[i]["TenSP"] + @"</div>
                          <h4 class='price'>Giá: " + dt.Rows[i]["GiaSP"] + @"</h4>
                          <div class='button_group'><button class='button add-cart' type='button'>Add To Cart</button><button class='button compare' type='button'><i class='fa fa-exchange'></i></button><button class='button wishlist' type='button'><i class='fa fa-heart-o'></i></button></div>
                      </div>
                 </div>   
";
        }
        return s;
    }

}