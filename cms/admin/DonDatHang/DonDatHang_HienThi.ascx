<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DonDatHang_HienThi.ascx.cs" Inherits="cms_admin_DonDatHang_ĐonDatHang_HienThi" %>

<div class="head">
    Danh sách đơn hàng
    <div class="cb"></div>
</div>
<div class="KhungChuaBang">
   <table class="tbDonDatHang">
       <tr>
           <th class="cotMa">Mã đơn hàng</th>
           <th class="cotNgay">Ngày tạo</th>
           <th class="cotGia">Giá tiền</th>
           <th class="cotTen">Tên khách hàng</th>
           <th class="cotSDT">Số điện thoại</th>
           <th class="cotEmail">Email</th>
           <th class="cotCongCu">Công cụ</th>
       </tr>
       <asp:Literal ID="ltrDonHang" runat="server"></asp:Literal>
   </table>
</div>