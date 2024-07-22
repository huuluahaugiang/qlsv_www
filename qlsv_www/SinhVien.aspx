<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SinhVien.aspx.cs" Inherits="qlsv_www.SinhVien" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>     
            <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click"/>
            <asp:HiddenField id="txtMa" runat="server" />
        </div>
        <div>
            <%=LoadTableSV()%>
        </div>
    </form>
</body>
</html>
