<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimKiem.aspx.cs" Inherits="qlsv_www.TimKiem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>                            
             <asp:TextBox ID="txtTen"  runat="server" placehoder="Nhập tên sinh viên"></asp:TextBox>
             <asp:Button ID="btnTim" runat="server" Text="Tìm" OnClick="btnTim_Click"/>
        </div>
        <div>
             <%=LoadTableSV() %>
        </div>
    </form>
</body>
</html>
