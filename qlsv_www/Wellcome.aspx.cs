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
    public partial class Wellcome : System.Web.UI.Page
    {    
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
            dt = db.GetDataBySqlString(@"SELECT DISTINCT b.MaLop, TenLop FROM LOP a, SINHVIEN b WHERE a.MaLop=b.MaLop");
            ddlMaLop.DataSource = dt;
            ddlMaLop.DataTextField = "TenLop";
            ddlMaLop.DataValueField = "MaLop";
            ddlMaLop.DataBind();
        }
        protected void btnHienThi_Click(object sender, EventArgs e)
        {
            Response.Redirect("SinhVien_Loc.aspx?ma="+ ddlMaLop.SelectedValue.ToString());
        }
    }
}