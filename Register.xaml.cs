using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MobilePhoneShop
{
    public partial class Register : Window
    {
        AppContext appContext;
        AccessToDB acdb;
        public Register()
        {
            InitializeComponent();
            Closing += OnWindowClosing;
            acdb = new AccessToDB();
            appContext = new AppContext();
        }
        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            acdb.Insert($"INSERT INTO данныеПользователей (Имя, [e-mail], ДатаРегистрации) VALUES ('Вася','ksh@gmail.com', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.f")}')");
            Application.Current.MainWindow.Show();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            string login = Login_TextBox.Text;
            string password = Password_TextBox.Password;
            string repeatPassword = RepeatPassword_TextBox.Password;
            string email = Email_TextBox.Text;
            int dataID = 0;

            User user = new User(login, password, dataID);
            
            appContext.Users.Add(user);
            appContext.SaveChanges();
        }
    }
}
