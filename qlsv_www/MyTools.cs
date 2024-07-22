using System.Data.SqlClient;
using System.Data;

namespace qlsv_www
{
    public class MyDataBase
    {
        private SqlConnection _cnn;
        public SqlConnection cnn
        {
            get { return _cnn; }
            set { _cnn = value; }
        }

        public MyDataBase()
        {
            _cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QLSV2021;Integrated Security=True");
        }

        public MyDataBase(string strConn)
        {
            _cnn = new SqlConnection(strConn);
        }
        public void ConnectToDatabase()
        {
            try
            {
                if (_cnn.State == ConnectionState.Closed)
                {
                    _cnn.Open();
                }
            }
            catch
            {

            }
        }

        public void DisConnect()
        {
            //if (_cnn.State == ConnectionState.Open)
            //{
            //    _cnn.Close();
            //    _cnn.Dispose();
            //    _cnn = null;
            //}
        }

        public DataTable GetDataBySqlString(string StrSql)
        {
            ConnectToDatabase();
            SqlCommand cmd = new SqlCommand(StrSql, _cnn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DisConnect();
            return dt;
        }

        public void DeleteBySqlString(string StrSql)
        {
            ConnectToDatabase();
            SqlCommand cmd = new SqlCommand(StrSql, _cnn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DisConnect();
        }
        public void DeleteByStoreProcedure(string StoreName)
        {
            ConnectToDatabase();
            SqlCommand cmd = new SqlCommand(StoreName, _cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DisConnect();
        }

        public void XoaSV_sp(string MaSinhVien)
        {
            ConnectToDatabase();
            SqlCommand cmd = new SqlCommand("XoaSV", _cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(@"MaSV", SqlDbType.NVarChar, 10);
            cmd.Parameters[@"MaSV"].Value = MaSinhVien;
            cmd.ExecuteNonQuery();
            DisConnect();
        }

        public DataTable LayTatCaSinhVienDataSet()
        {
            ConnectToDatabase();
            SqlCommand cmd = new SqlCommand("Select * from SinhVien order by MaSV ASC", _cnn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "SinhVien");
            DataTable dt = new DataTable();
            dt = ds.Tables["SinhVien"];
            DisConnect();
            return dt;
        }

        public DataTable LayTatCaSinhVienClass()
        {
            DataTable dt = new DataTable();
            ConnectToDatabase();
            dt = GetDataBySqlString("Select * from SinhVien order by MaSV ASC");
            DisConnect();
            return dt;
        }
    }
}