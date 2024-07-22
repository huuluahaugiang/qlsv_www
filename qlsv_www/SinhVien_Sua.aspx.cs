using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qlsv_www
{
    public partial class SinhVien_Sua : System.Web.UI.Page
    {
        static string ma = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ma = Request.QueryString["ma"].ToString();
                LoadData();
            }
        }
        private void LoadData()
        {
            MyDataBase db = new MyDataBase();
            db.ConnectToDatabase();
            string SqlStr = @"Select * from SinhVien Where MaSV ='" + ma + "'";
            SqlCommand dc = new SqlCommand(SqlStr, db.cnn);
            SqlDataReader dr = dc.ExecuteReader();
            if (dr.Read())
            {
                txtMaSV.Text = dr[0].ToString();
                txtTenSV.Text = dr[1].ToString();
                txtGioiTinh.Text = dr[2].ToString();
                txtNamSinh.Text = dr[3].ToString();
                    
            }
            db.DisConnect();
        }
        private void CapNhatSV()
        {
            MyDataBase db = new MyDataBase();
            db.ConnectToDatabase();
            SqlCommand dc = new SqlCommand();
            dc.Connection = db.cnn;
            dc.Parameters.Add("@MaSV", SqlDbType.VarChar, 10, "MaSV").Value = txtMaSV.Text;
            dc.Parameters.Add("@TenSV", SqlDbType.NVarChar, 100, "TenSV").Value = txtTenSV.Text;
            dc.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 5, "GioiTinh").Value = txtGioiTinh.Text;
            dc.Parameters.Add("@NamSinh", SqlDbType.NVarChar, 5, "NamSinh").Value = txtNamSinh.Text;
            dc.Parameters.Add("@MaLop", SqlDbType.VarChar, 10, "MaLop").Value = "111015";
            dc.CommandType = CommandType.Text;
            dc.CommandText = @"Update SinhVien set TenSV = @TenSV, NamSinh = @NamSinh, GioiTinh = @GioiTinh, MaLop = @MaLop  Where MaSV = @MaSV";
            dc.ExecuteNonQuery();
            db.DisConnect();
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                CapNhatSV();
                Response.Redirect("sinhvien.aspx");
            }
        }
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("SinhVien.aspx");
        }
    }
}