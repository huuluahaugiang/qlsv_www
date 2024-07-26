using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qlsv_www
{
    public partial class BangDiemCaNhan : System.Web.UI.Page
    {
        static string ma;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ma = Request.QueryString["ma"].ToString();
            }
        }
        public string LoadTableDiem()
        {
            MyDataBase db = new MyDataBase();
            DataTable dt = new DataTable();
            dt = db.GetDataBySqlString(@"select c.MaHocPhan, c.tenhocphan, a.Diem from DIEM a, HOCPHAN c where a.MaHocPhan = c.MaHocPhan and a.MaSV = '" + ma + "'");
            string htmlStr = "";
            htmlStr += "<table>";
            htmlStr += "<thead>";
            htmlStr += "<tr>";
            htmlStr += "<th> STT </th>";
            htmlStr += "<th> Mã môn </th>";
            htmlStr += "<th> Tên môn </th>";
            htmlStr += "<th> Điểm </th>";
            htmlStr += "</tr>";
            htmlStr += "</thead>";
            htmlStr += "<tbody>";
            int i = 0;
            foreach (DataRow item in dt.Rows)
            {
                htmlStr += "<tr>";
                htmlStr += "<td>" + (i + 1).ToString() + "</td>";
                htmlStr += "<td>" + item["MaHocPhan"] + "</td>";
                htmlStr += "<td>" + item["TenHocPhan"] + "</td>";
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