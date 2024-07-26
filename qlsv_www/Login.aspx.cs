using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Optimization;

namespace qlsv_www
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                MyDataBase db = new MyDataBase();
                db.ConnectToDatabase();
                string SqlStr = @"Select * from NGUOIDUNG Where MaNguoiDung ='" + txtUserName.Text.ToString() + "' AND MatKhau = '" + txtPassword.Text.ToString() + "'";
                SqlCommand dc = new SqlCommand(SqlStr, db.cnn);
                SqlDataReader dr = dc.ExecuteReader();
                if (dr.Read())
                {                                                         
                    //Session["UserName"] = txtUserName.Text.ToString();
                    //userSession.UserName = user.UserName;
                    //userSession.UserID = user.ID;
                    //Session.Add(CommonConstants.USER_SESSION, userSession);
                    Response.Redirect("Wellcome.aspx");
                }
                else
                {
                    Session["UserName"] = null;
                    string script = "alert(\"Đăng nhập thất bại!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
        }
    }
}