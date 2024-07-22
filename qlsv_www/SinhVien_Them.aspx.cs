using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qlsv_www
{
    public partial class SinhVien_Them : System.Web.UI.Page
    {
        string ma = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCboLop();
            }
        }
        private void LoadCboLop()
        {
            MyDataBase db = new MyDataBase();
            DataTable dt = new DataTable();
            dt = db.GetDataBySqlString("Select * from lop");
            ddlMaLop.DataSource = dt;
            ddlMaLop.DataTextField = "TenLop";
            ddlMaLop.DataValueField = "MaLop";
            ddlMaLop.DataBind();
        }
        private void ThemSV()
        {
            MyDataBase db = new MyDataBase();
            db.ConnectToDatabase();
            SqlCommand dc = new SqlCommand();
            dc.Connection = db.cnn;
            dc.CommandType = CommandType.Text;
            dc.CommandText = "Insert Into Sinhvien(MaSV,TenSV,GioiTinh,NamSinh,MaLop) Values(@MaSV,@TenSV,@GioiTinh,@NamSinh,@MaLop)";
            dc.Parameters.Add("@MaSV", SqlDbType.VarChar, 10, "MaSV");
            dc.Parameters.Add("@TenSV", SqlDbType.NVarChar, 100, "TenSV");
            dc.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 5, "GioiTinh");
            dc.Parameters.Add("@NamSinh", SqlDbType.NVarChar, 5, "NamSinh");
            dc.Parameters.Add("@MaLop", SqlDbType.VarChar, 10, "MaLop");

            DataTable dt = new DataTable();
            dt.Columns.Add("MaSV", typeof(string));
            dt.Columns.Add("TenSV", typeof(string));
            dt.Columns.Add("GioiTinh", typeof(string));
            dt.Columns.Add("NamSinh", typeof(string));
            dt.Columns.Add("MaLop", typeof(string));

            DataRow dong = dt.NewRow();
            dong["MaSV"] = txtMaSV.Text;
            dong["TenSV"] = txtTenSV.Text;
            dong["GioiTinh"] = txtGioiTinh.Text;
            dong["NamSinh"] = txtNamSinh.Text;
            dong["MaLop"] = ddlMaLop.SelectedValue.ToString();            
            dt.Rows.Add(dong);
            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = dc;
            da.Update(dt);
            db.DisConnect();
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ThemSV();
                Response.Redirect("sinhvien.aspx");
            }
        }
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("SinhVien.aspx");
        }
    }
}