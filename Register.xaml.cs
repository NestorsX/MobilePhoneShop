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
        public Register()
        {
            InitializeComponent();
            Closing += OnWindowClosing;
            appContext = new AppContext();
        }
        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Application.Current.MainWindow.Show();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            string login = Login_TextBox.Text;
            string password = Password_TextBox.Password;
            string repeatPassword = RepeatPassword_TextBox.Password;
            string email = Email_TextBox.Text;
            string firstName = FirstName_TextBox.Text;
            string secondName = SecondName_TextBox.Text;
            string thirdName = ThirdName_TextBox.Text;
            string telNumber = TelNumber_TextBox.Text;
            if (login.Length > 0 && password.Length > 0 && password == repeatPassword && email.Length > 0)
            {
                UserData userData = new UserData(firstName, email, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.f"));
                appContext.userDatas.Add(userData);
                appContext.SaveChanges();

                User user = new User(login, password);
                appContext.users.Add(user);
                appContext.SaveChanges();


                Application.Current.MainWindow.Show();
                Close();
            }

        }
    }
}
