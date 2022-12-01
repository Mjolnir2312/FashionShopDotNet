<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DonDatHangLoadControl.ascx.cs" Inherits="cms_admin_DonDatHang_DonDatHangLoadControl" %>

<div class="container">
    <div style="clear:both;height:20px"></div>
    <div class="cotTrai">
        <div class="head">
            Quản lý
        </div>
        <ul>
            <li><a class="<%=DanhDau("DonDatHang","DanhSachDonHang","") %>" href="Admin.aspx?modul=DonDatHang&modulphu=DanhSachDonHang">Danh sách đơn hàng</a></li>
        </ul>
    </div>
    <div class="cotPhai">
        <asp:PlaceHolder ID="plLoadControl" runat="server"></asp:PlaceHolder>
    </div>
    <div class="cb"></div>

</div>