using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qlsv_www
{
    public partial class Diem : System.Web.UI.Page
    {
        static string malop;
        static string mamon;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                malop = Request.QueryString["malop"].ToString();
                mamon = Request.QueryString["mamon"].ToString();
                LoadCboLop();
                LoadCboMon();
                
            }
        }

        public string LoadTableDiem()
        {
            if ((malop != "0") & (mamon != "0"))
            {
                MyDataBase db = new MyDataBase();
                DataTable dt = new DataTable();
                dt = db.GetDataBySqlString(@"select a.MaSV, b.TenSV, a.Diem from DIEM a, SINHVIEN b where a.MaSV = b.MaSV and a.MaHocPhan = '" + mamon + "' and b.MaLop = '" + malop + "'");
                string htmlStr = "";
                htmlStr += "<table>";
                htmlStr += "<thead>";
                htmlStr += "<tr>";
                htmlStr += "<th> STT </th>";
                htmlStr += "<th> Mã sinh viên </th>";
                htmlStr += "<th> Tên sinh viên </th>";
                htmlStr += "<th> Điểm </th>";
                htmlStr += "</tr>";
                htmlStr += "</thead>";
                htmlStr += "<tbody>";
                int i = 0;
                foreach (DataRow item in dt.Rows)
                {
                    htmlStr += "<tr>";
                    htmlStr += "<td>" + (i + 1).ToString() + "</td>";
                    htmlStr += "<td>" + item["MaSV"] + "</td>";
                    htmlStr += "<td>" + item["TenSV"] + "</td>";
                    htmlStr += "<td>" + item["Diem"] + "</td>";                   
                    htmlStr += "</tr>";
                    i++;
                }
                htmlStr += "</tbody>";
                htmlStr += "</table>";
                return htmlStr;
            }
            else
                return "";
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
        private void LoadCboMon()
        {
            MyDataBase db = new MyDataBase();
            DataTable dtm = new DataTable();
            string StrSql = "SELECT HOCPHAN.MaHocPhan, dbo.HOCPHAN.TenHocPhan " +
                                "FROM KHUNGCT INNER JOIN HOCPHAN ON dbo.KHUNGCT.MaHocPhan = dbo.HOCPHAN.MaHocPhan " +
                                "WHERE(dbo.KHUNGCT.MaLop = '" + malop + "')";
            dtm = db.GetDataBySqlString(StrSql);
            ddlMaMon.DataSource = dtm;
            ddlMaMon.DataTextField = "TenHocPhan";
            ddlMaMon.DataValueField = "MaHocPhan";
            ddlMaMon.DataBind();
        }
        protected void btnLoadKCT_Click(object sender, EventArgs e)
        {
            Response.Redirect("Diem.aspx?malop=" + ddlMaLop.SelectedValue.ToString() + "&mamon=0");
        }
        protected void btnHTdiem_Click(object sender, EventArgs e)
        {
            Response.Redirect("Diem.aspx?malop=" + ddlMaLop.SelectedValue.ToString() + "&mamon="+ddlMaMon.SelectedValue.ToString());
        }
        
    }
}