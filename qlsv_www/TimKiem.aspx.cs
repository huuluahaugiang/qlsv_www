using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qlsv_www
{
    public partial class TimKiem : System.Web.UI.Page
    {
        static string key;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                key= Request.QueryString["key"].ToString();
            }    

        }
        protected void btnTim_Click(object sender, EventArgs e)
        {
            Response.Redirect("TimKiem.aspx?key=" + txtTen.Text.Trim());
        }
        public string LoadTableSV()
        {
            MyDataBase db = new MyDataBase();
            DataTable dt = new DataTable();
            dt = db.GetDataBySqlString("Select * from sinhvien where TenSV LIKE '%" + key + "%'");
            string htmlStr = "";
            htmlStr += "<table>";
            htmlStr += "<thead>";
            htmlStr += "<tr>";
            htmlStr += "<th> STT </th>";
            htmlStr += "<th> Mã sinh viên </th>";
            htmlStr += "<th> Tên sinh viên </th>";
            htmlStr += "<th> Giới tính </th>";
            htmlStr += "<th> Năm sinh </th>";
            htmlStr += "<th> Mã lớp </th >";
            htmlStr += "<th> Thao tác </th>";
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
                htmlStr += "<td>" + item["GioiTinh"] + "</td>";
                htmlStr += "<td>" + item["NamSinh"] + "</td>";
                htmlStr += "<td>" + item["MaLop"] + "</td>";
                htmlStr += "<td> <a href =\"BangDiemCaNhan.aspx?ma=" + item["MaSV"] + "\">Bảng điểm cá nhân</a></td>";
                htmlStr += "</tr>";
                i++;
            }
            htmlStr += "</tbody>";
            htmlStr += "</table>";
            return htmlStr;
        }
    }
}