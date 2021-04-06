using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MobilePhoneShop
{
    public partial class Register : Window
    {
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

        AppContext appContext;
        AccessToDB acdb;
        public Register()
        {
            InitializeComponent();
            Closing += OnWindowClosing;
            appContext = new AppContext();
            acdb = new AccessToDB();
            this.SourceInitialized += MainWindow_SourceInitialized;
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
            List<User> users = appContext.users.ToList();
            string cond = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            if (users.Where(user => user.Login == login).Count() == 0)
            {
                if (Regex.IsMatch(email, cond))
                {
                    if (login.Length > 0 && password.Length > 0 && password == repeatPassword && email.Length > 0 && firstName.Length>0)
                    {
                        acdb.Insert($"INSERT INTO [users] VALUES('{login}','{password}')");
                        acdb.Insert($"INSERT INTO [userDatas] VALUES('{secondName}', '{firstName}', '{thirdName}', '{telNumber}', '{email}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.f")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.f")}')");
                        SendRegisterNoticeMail(email);
                        //закрытие окна регистрации
                        Application.Current.MainWindow.Show();
                        Close();
                    }
                }
                else
                    MessageBox.Show("Неверный формат электронной почты");
            }
            else
                MessageBox.Show("Пользователь с таким логином уже зарегистрирован");
        }
        private void SendRegisterNoticeMail(string email)
        {
            SmtpClient Smtp = new SmtpClient("smtp.gmail.com", 587);
            Smtp.EnableSsl = true;
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            Smtp.UseDefaultCredentials = false;
            Smtp.Credentials = new NetworkCredential("nstrkrll.mobiles4you@gmail.com", "Jz0%$FTG");
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("nstrkrll.mobiles4you@gmail.com");
            Message.To.Add(new MailAddress(email));
            Message.Subject = "Регистрация в магазине мобильных телефонов";
            Message.Body = "Поздравляем! Вы успешно завершили регистрацию в магазине. Удачных покупок!";
            Smtp.Send(Message);
        }
    }
}
