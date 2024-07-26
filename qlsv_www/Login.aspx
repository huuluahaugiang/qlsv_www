<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="qlsv_www.Login" %>

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
                            Tên đăng nhập
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        </div>
                    </td>     
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            Mật khẩu
                        </div>
                    </td>
                    <td>
                        <div class="form-group">                            
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </td>                   
                </tr>   
            </table> 
        </div>
        <div>
            <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" OnClick="btnLogin_Click"/>
        </div>      
    </form>
</body>
</html>
