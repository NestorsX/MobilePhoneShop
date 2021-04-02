using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;

namespace MobilePhoneShop
{
    public partial class MainWindow : Window
    {
        public static int currentUserID;
        AccessToDB acdb = new AccessToDB();
        AppContext apc = new AppContext();
        public MainWindow()
        {
            InitializeComponent();
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
                if (isAdmin != null && isAdmin.userID == 1)
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
