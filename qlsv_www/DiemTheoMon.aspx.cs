using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qlsv_www
{
    public partial class DiemTheoMon : System.Web.UI.Page
    {
        static string malop;
        static string mamon;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                malop = Request.QueryString["malop"].ToString();
                mamon = Request.QueryString["mamon"].ToString();               
            }
        }
        public string LoadTableDiem()
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
    }
}