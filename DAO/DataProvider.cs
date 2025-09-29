using System.Data;
using System.Diagnostics;
using DotNetEnv;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class DataProvider
    {
        private static string? connectionSTR;

        private static DataProvider? instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        private DataProvider() 
        {
            var solutionDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName;
            var envPath = Path.Combine(solutionDir, ".env");
            Debug.WriteLine($"Loading .env file from: {envPath}");
            Env.Load(envPath);
            string server = Env.GetString("DB_SERVER") ?? "localhost";
            string port = Env.GetString("DB_PORT") ?? "3306";
            string database = Env.GetString("DB_NAME") ?? "QuanLyThuVien";
            string uid = Env.GetString("DB_USER") ?? "root";
            string pwd = Env.GetString("DB_PASSWORD") ?? "";
            connectionSTR = $"server={server};port={port};database={database};uid={uid};pwd={pwd};";
        }

        public bool TestConnection()
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
