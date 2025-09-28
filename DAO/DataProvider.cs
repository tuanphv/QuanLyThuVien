using System.Data;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class DataProvider
    {
        private static string connectionSTR = "Server=localhost;Database=QuanLyThuVien;Uid=appuser;Pwd=123456;";

        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        private DataProvider() { }

        public static bool TestConnection()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionSTR))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            DataTable data = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionSTR))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(data);
                    }
                }
            }

            return data;
        }

        public int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            int result = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionSTR))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    result = command.ExecuteNonQuery();
                }
            }

            return result;
        }

        public object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            object result;

            using (MySqlConnection connection = new MySqlConnection(connectionSTR))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    result = command.ExecuteScalar();
                }
            }

            return result;
        }
    }
}
