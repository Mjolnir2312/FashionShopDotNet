using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_Display_TrangChu_TrangChuLoadControl : System.Web.UI.UserControl
{
    protected string id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ltrSlide.Text = LaySlide();
            ltrNhomSanPham.Text = LayNhomSanPham();
        }
    }

    private string LayNhomSanPham()
    {
        string s = "";
        DataTable dt = new DataTable();
        dt = shopquanao.NhomSanPham.Thongtin_Nhomsp();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
             
            s += @"<h3 class='title'>" + dt.Rows[i]["TenNhom"] + @"</h3>";
            s += "<div class='control'><a id='prev_hot' class='prev' href='#'>&lt;</a><a id='next_hot' class='next' href='#'>&gt;</a></div>";
            s += "      <ul id='hot'>";
            s += "<li>";
       
            s += LayDanhSachSanPhamTheoNhom(dt.Rows[i]["NhomID"].ToString(), dt.Rows[i]["SoSPHienThi"].ToString());
          
            s += "</li>";
            s += "   </ul>";
        }
        return s;
    }

    private string LayDanhSachSanPhamTheoNhom(string NhomID, string SoSPHienThi)
    {
        string s = "";
        DataTable dt = new DataTable();
        dt = shopquanao.SanPham.Thongtin_Sanpham_by_nhomid(NhomID, SoSPHienThi);

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
                          <div class='productname'>"+ dt.Rows[i]["TenSP"] + @"</div>
                          <h4 class='price'>Giá: " + dt.Rows[i]["GiaSP"] + @"</h4>
                          <div class='button_group'><button class='button add-cart' type='button'>Add To Cart</button><button class='button compare' type='button'><i class='fa fa-exchange'></i></button><button class='button wishlist' type='button'><i class='fa fa-heart-o'></i></button></div>
                      </div>
                 </div>     
  ";

        }
        return s;
    }
    //    private string LaySlide()
    //    {
    //        string s = "";

    //        //Code lấy ra vị trí quảng nhóm cáo
    //        DataTable dt = new DataTable();
    //        dt = shopquanao.NhomQuangCao.Thongtin_Nhomquangcao_by_vitriqc("slide");

    //        //Nếu tồn tại vị trí nhóm quảng cáo --> tìm quảng cáo trong nhóm đó
    //        if (dt.Rows.Count > 0)
    //        {
    //            //Gọi tới phương thức lấy ảnh quảng cáo theo id nhóm quảng cáo
    //            s = LayAnhSlide(dt.Rows[0]["NhomQuangCaoID"].ToString());
    //        }

    //        return s;
    //    }

    //    private string LayAnhSlide(string nhomQuangCaoID)
    //    {
    //        string s = "";

    //        DataTable dt = new DataTable();
    //        dt = shopquanao.QuangCao.Thongtin_Quangcao_by_nhomquangcaoid(nhomQuangCaoID);
    //        if (dt.Rows.Count > 0)
    //        {

    //            for (int i = 0; i < dt.Rows.Count; i++)
    //            {
    //                s += @"
    //<div data-p='225.00' style='display: none;'>                      
    //    <img data-u='image' src='/picture/quangcao/" + dt.Rows[i]["AnhQC"] + @"' alt='" + dt.Rows[i]["TenQC"] + @"' />
    //</div>";
    //            }

    //        }

    //        return s;
    //    }
}
