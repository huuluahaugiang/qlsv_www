using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qlsv_www
{
    public partial class SinhVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string LoadTableSV()
        {
            MyDataBase db = new MyDataBase();
            DataTable dt = new DataTable();
            dt = db.GetDataBySqlString("Select * from sinhvien");
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
                htmlStr += "<td> <a href =\"SinhVien_Sua.aspx?ma="+ item["MaSV"] + "\">Sửa</a></td>";
                htmlStr += "<td> <a href =\"SinhVien_Xoa.aspx?ma="+ item["MaSV"] + "\">Xóa</a></td>";                
                htmlStr += "</tr>";
                i++;
            }
            htmlStr += "</tbody>";
            htmlStr += "</table>";
            return htmlStr;
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            string ma = "";
            Response.Redirect("SinhVien_Them.aspx?MaSinhVien=" + ma + "&Flag=1");
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Value.ToString();
            Response.Redirect("SinhVien_New.aspx?MaSinhVien=" + ma + "&Flag=2");
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Value.ToString();
            MyDataBase db = new MyDataBase();
            db.DeleteBySqlString("Delete from sinhvien where MaSV = '" + ma + "'");
            Response.Redirect("SinhVien2.aspx");
        }
    }
}