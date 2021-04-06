using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace MobilePhoneShop
{
    public partial class MainWindow : Window
    {
        // УДАЛЕНИЕ MAXIMIZEBOX С СОХРАНЕНИЕМ ВОЗМОЖНОСТИ ИЗМЕНЯТЬ РАЗМЕР ОКНА
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_STYLE = -16;

        private const int WS_MAXIMIZEBOX = 0x10000; //maximize button
        private IntPtr _windowHandle;
        private void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            _windowHandle = new WindowInteropHelper(this).Handle;
            DisableMaximizeButton();
        }

        protected void DisableMaximizeButton()
        {
            if (_windowHandle == null)
                throw new InvalidOperationException("The window has not yet been completely initialized");

            SetWindowLong(_windowHandle, GWL_STYLE, GetWindowLong(_windowHandle, GWL_STYLE) & ~WS_MAXIMIZEBOX);
        }

        //---------------------------------------------------------------------------------------------------------------

        public static int currentUserID;
        AccessToDB acdb = new AccessToDB();
        AppContext apc = new AppContext();
        public MainWindow()
        {
            InitializeComponent();
            this.SourceInitialized += MainWindow_SourceInitialized;
        }

        private void Log_in(object sender, RoutedEventArgs e)
        {
            User authUser;
            using (AppContext apc = new AppContext())
            {
                authUser = apc.users.Where(user => user.Login == Login_TextBox.Text && user.Password == Password_TextBox.Password).FirstOrDefault();
            }
            if(authUser!=null)
            {
                currentUserID = authUser.userID;
                acdb.Insert($"UPDATE [userDatas] SET [lastAccessDate] = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.f")}' WHERE [dataID] = '{currentUserID}'");
                Admin isAdmin = apc.admins.Where(admin => admin.userID == currentUserID).FirstOrDefault();
                if (isAdmin != null && isAdmin.userID == currentUserID)
                {
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.Show();
                    Close();
                }
                else
                {
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    Close();
                }
            }
            else
                MessageBox.Show("Неверный логин или пароль");
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            Hide();
            reg.ShowDialog();
        }
    }
}
