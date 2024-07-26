<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Diem.aspx.cs" Inherits="qlsv_www.Diem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlMaLop"  runat="server"></asp:DropDownList>
            <asp:Button ID="btnLoadKCT" runat="server" Text="Load môn" OnClick="btnLoadKCT_Click"/>
        </div>
        <div>
            <asp:DropDownList ID="ddlMaMon"  runat="server"></asp:DropDownList>
            <asp:Button ID="btnHienThiDiem" runat="server" Text="Hiển thị điểm" OnClick="btnHTdiem_Click"/>
        </div>
        <div>
             <%=LoadTableDiem()%>
        </div>
    </form>
</body>
</html>
