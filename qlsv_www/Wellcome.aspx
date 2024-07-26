<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wellcome.aspx.cs" Inherits="qlsv_www.Wellcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body> 
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">Navbar</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNavDropdown">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="#">Home</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Features</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Pricing</a>
        </li>
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" role="button" data-bs-toggle="dropdown" aria-expanded="false">
            Dropdown link
          </a>
          <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
            <li><a class="dropdown-item" href="#">Action</a></li>
            <li><a class="dropdown-item" href="#">Another action</a></li>
            <li><a class="dropdown-item" href="#">Something else here</a></li>
          </ul>
        </li>
      </ul>
    </div>
  </div>
</nav>
    <form id="form1" runat="server">
     <div>
            TRANG CHỦ
            <br>
            <a href ="SinhVien.aspx">Danh sách sinh viên</a>
            <br>
            <a href ="SinhVien.aspx">Danh mục lớp</a>
            <br>
            <a href ="TimKiem.aspx?key=0" >Tìm kiếm</a>
            <br>
            <a href ="Diem.aspx?malop=0&mamon=0" >Điểm</a>
            <br>
            <asp:DropDownList ID="ddlMaLop"  runat="server"></asp:DropDownList>
             <asp:Button ID="btnHienThi" runat="server" Text="Hiển thị" OnClick="btnHienThi_Click"/>
     </div>
   </form>
</body>
</html>
