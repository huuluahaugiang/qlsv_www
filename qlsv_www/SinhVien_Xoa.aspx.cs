using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qlsv_www
{
    public partial class SinhVien_Xoa : System.Web.UI.Page
    {
        static string ma = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ma = Request.QueryString["ma"].ToString();
                XoaSV();
                Response.Redirect("SinhVien.aspx");
            }
        }
        private void XoaSV()
        {
            MyDataBase db = new MyDataBase();   
            db.ConnectToDatabase();         
            SqlCommand cmd = new SqlCommand("Delete SinhVien Where MaSV = '" + ma + "'", db.cnn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();               
            db.DisConnect();     
        }
    }
}