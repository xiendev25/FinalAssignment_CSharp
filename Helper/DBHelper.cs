using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Helper
{
    public static class DBHelper
    {
        public static readonly string ConnectionString =
            "Server=DESKTOP-ECAIF50;Database=Employee;Trusted_Connection=True;TrustServerCertificate=True;";

        private static readonly string SqlScriptFile = "script.sql";

        public static bool CheckDatabaseExists()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    return connection.State == System.Data.ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }

        public static string? DatabaseInitialize()
        {
            string? re = null;
            try
            {
                if (!File.Exists(SqlScriptFile))
                    return "Không tìm thấy file script.sql";

                string sqlScript = File.ReadAllText(SqlScriptFile);

                

                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string[] commands = sqlScript.Split(
                    new[] { "\r\nGO\r\n", "\nGO\n", "\rGO\r" },
                    StringSplitOptions.RemoveEmptyEntries);
                    foreach (var commandText in commands)
                    {
                        if (string.IsNullOrWhiteSpace(commandText)) continue;
                        using (var cmd = new SqlCommand(commandText, connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                re = $"Lỗi: {ex.Message}";
            }
            return re;
        }
    }
}
