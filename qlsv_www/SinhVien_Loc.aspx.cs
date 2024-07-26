using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qlsv_www
{
    public partial class SinhVien_Loc : System.Web.UI.Page
    {   string ma;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                ma = Request.QueryString["ma"].ToString();
                LoadData();
            }
        }
        public string LoadData()
        {
            MyDataBase db = new MyDataBase();
            DataTable dt = new DataTable();
            dt = db.GetDataBySqlString("Select * from sinhvien where MaLop = '" + ma +"'");
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
                htmlStr += "<td> <a href =\"SinhVien_Sua.aspx?ma=" + item["MaSV"] + "\">Sửa</a></td>";
                htmlStr += "<td> <a href =\"SinhVien_Xoa.aspx?ma=" + item["MaSV"] + "\">Xóa</a></td>";
                htmlStr += "</tr>";
                i++;
            }
            htmlStr += "</tbody>";
            htmlStr += "</table>";
            return htmlStr;
        }
    }
}