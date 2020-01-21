using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public class DB
    {
        private static SqlConnection _connection;
        private static void Openconnection()
        {
            try
            {
                var scon1 = @"Data Source=DESKTOP-ILIFVF2\SQLEXPRESS;Initial Catalog=QLBH;Integrated Security=True";
                if (_connection == null)
                    _connection = new SqlConnection(scon1);
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Kết Nối Thất Bại","lỗi to chà bá");
            }
        }
        // ngắt kết nối
        private static void Closeconnection()
        {
            if (_connection == null)
                return;
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
        }
        //hàm chứa tên thủ tục và tham số
        private static SqlCommand BuildCommand(string procedureName, SqlParameter[] sqlParameters)
        {
            var cmd = new SqlCommand
            {
                CommandText = procedureName,
                Connection = _connection,
                CommandType = CommandType.StoredProcedure
            };
            foreach(var sqlParameter in sqlParameters)
            {
                cmd.Parameters.Add(sqlParameter);
               
            }
            return cmd;
        }

        private static SqlCommand BuildIntCommand(string procedureName, SqlParameter[] Parameters)
        {
            var cmd = BuildCommand(procedureName, Parameters);
            cmd.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 
                4, 
                ParameterDirection.ReturnValue, 
                false, 
                0, 
                0, 
                string.Empty, 
                DataRowVersion.Default, 
                null));
            return cmd;
        }
        // hàm thực thi thủ tục và trả  về số dòng thay đổi (>0 là thành công)
        // dung để thêm xoá
        public static int ExecuteNonQuery(string procedureName, SqlParameter[] Parameters)
        {
            try
            {
                Openconnection();
                var cmd = BuildCommand(procedureName,Parameters);
                cmd.CommandType = CommandType.StoredProcedure;
                var rec = cmd.ExecuteNonQuery();
                Closeconnection();
                return rec;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // hàm thực thi thủ tục và trả  về danh sách (datatable)
        public static DataTable ExecuteQuery(string procedureName, SqlParameter[] Parameters)
        {
            try
            {
                Openconnection();
                using (var sqlDa = new SqlDataAdapter(BuildCommand(procedureName, Parameters)))
                {
                    using(var ds=new DataSet())
                    {
                        sqlDa.Fill(ds);
                        Closeconnection();
                        return ds.Tables[0];
                    }
                }             
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int ExecuteIntCommand(string procedureName, SqlParameter[] Parameters)
        {
            Openconnection();
            var cmd = BuildCommand(procedureName, Parameters);
            cmd.ExecuteNonQuery();
            var rec = (int)cmd.Parameters["ReturnValue"].Value;
            Closeconnection();
            return rec;

        }
    }
}
