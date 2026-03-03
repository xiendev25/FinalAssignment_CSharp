using ClosedXML.Excel;
using Helper;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            string? re = null;
            bool exists = DBHelper.CheckDatabaseExists();
            if (exists)
            {
                DialogResult d = MessageBox.Show("Bạn có muốn xoá file cũ và tạo file mới theo script?", "Thông báo", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    re = DBHelper.DatabaseInitialize();
                }
            }
            else
            {
                re = DBHelper.DatabaseInitialize();
            }

            if (re != null)
            {
                MessageBox.Show($"Lỗi: {re}", "Thông báo");
            }
            try
            {
                string path = "user.json";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Run(new F_Login());
        }
    }
}