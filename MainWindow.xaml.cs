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
            DataTable dt_user = acdb.Select("SELECT * FROM [dbo].[пользователи] WHERE Логин = '" + Login_TextBox.Text + "'");
            if (dt_user.Rows.Count>0)
            {
                if (dt_user.Rows[0][1].ToString() == Login_TextBox.Text && dt_user.Rows[0][2].ToString() == Password_TextBox.Password)
                    MessageBox.Show("Авторизация выполнена");
                else
                    MessageBox.Show("Неверный логин или пароль");
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
