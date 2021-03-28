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
        AccessToDB acdb = new AccessToDB();
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
                MessageBox.Show("Авторизация выполнена");
                MainForm mainForm = new MainForm();
                mainForm.Show();
                Close();
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
