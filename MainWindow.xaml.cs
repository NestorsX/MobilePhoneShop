using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

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
            DataTable dt_user = acdb.Select("SELECT * FROM [dbo].[пользователи] WHERE [Логин] = '" + Login_TextBox.Text + "' AND [Пароль] = '" + Password_TextBox.Password + "'");
            if (dt_user.Rows.Count > 0)
            {
                MessageBox.Show("Авторизация выполнена");
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
