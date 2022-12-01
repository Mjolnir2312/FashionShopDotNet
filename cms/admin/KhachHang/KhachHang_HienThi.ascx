<%@ Control Language="C#" AutoEventWireup="true" CodeFile="KhachHang_HienThi.ascx.cs" Inherits="cms_admin_KhachHang_KhachHang_HienThi" %>

<div class="head">
    Danh sách khách hàng 
    <div class="cb"></div>
</div>
<div class="KhungChuaBang">
   <table class="tbKhachHang">
       <tr>
           <th class="cotMa">Mã khách hàng</th>
           <th class="cotTen">Tên khách hàng</th>
           <th class="cotAnh">Địa chỉ</th>
           <th class="cotThuTu">Số điện thoại</th>
           <th class="cotEmail">Email</th>
       </tr>
       <asp:Literal ID="ltrKhachHang" runat="server"></asp:Literal>
   </table>
</div>