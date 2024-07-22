<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SinhVien_Them.aspx.cs" Inherits="qlsv_www.SinhVien_Them" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>    
                    <td>
                        <div class="form-group">
                            Mã sinh viên
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <asp:TextBox ID="txtMaSV" runat="server"></asp:TextBox>
                        </div>
                    </td>     
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            TenSinhVien
                        </div>
                    </td>
                    <td>
                        <div class="form-group">                            
                            <asp:TextBox ID="txtTenSV"  runat="server"></asp:TextBox>
                        </div>
                    </td>                   
                </tr>   
                <tr>
                    <td>
                        <div class="form-group">
                            Giới tính
                        </div>
                    </td>
                    <td>
                        <div class="form-group">                            
                            <asp:TextBox ID="txtGioiTinh"  runat="server"></asp:TextBox>
                        </div>
                    </td>                   
                </tr> 
                <tr>
                    <td>
                        <div class="form-group">
                            Năm sinh
                        </div>
                    </td>
                    <td>
                        <div class="form-group">                            
                            <asp:TextBox ID="txtNamSinh" runat="server"></asp:TextBox>
                        </div>
                    </td>                  
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            Mã lớp
                        </div>
                    </td>
                    <td style ="width:auto">
                        <div class="form-group">
                            <asp:DropDownList ID="ddlMaLop"  runat="server"></asp:DropDownList>
                        </div>
                    </td>
                </tr>
            </table>  
            <asp:HiddenField id="txtMa" runat="server" />
        </div>
        <asp:Button ID="btnLưu" CssClass ="btn btn-info" runat="server" Text="Lưu" OnClick="btnLuu_Click"/>
        <asp:Button ID="btnHuy" CssClass ="btn btn-info" runat="server" Text="Hủy" OnClick="btnHuy_Click" />
    </form>
</body>
</html>
