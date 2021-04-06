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
    public partial class ProfileWindow : Window
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

        UserData currentUserData;
        User currentUser;
        AccessToDB acdb = new AccessToDB();
        AppContext apc = new AppContext();
        public ProfileWindow()
        {
            InitializeComponent();
            this.SourceInitialized += MainWindow_SourceInitialized;
            Closing += OnWindowClosing;
            currentUserData = apc.userDatas.Where(userData => userData.dataID == MainWindow.currentUserID).FirstOrDefault();
            Entry_TextBlock.Text = "Здравствуйте, " + currentUserData.FirstName + " " + currentUserData.ThirdName;
            secondName_TextBox.Text = currentUserData.SecondName;
            firstName_TextBox.Text = currentUserData.FirstName;
            thirdName_TextBox.Text = currentUserData.ThirdName;
            email_TextBox.Text = currentUserData.Email;
            telNumber_TextBox.Text = currentUserData.TelNumber;
            using (AppContext apc = new AppContext())
            {
                currentUser = apc.users.Where(user => user.userID == currentUserData.dataID).FirstOrDefault();
            }
        }
        private void ConfirmChanges_Button_Click(object sender, RoutedEventArgs e)
        {
            string cond = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            if (firstName_TextBox.Text.Length > 0 && email_TextBox.Text.Length > 0 && Regex.IsMatch(email_TextBox.Text, cond))
            {
                acdb.Insert($"UPDATE [userDatas] SET" +
                    $" [secondName] = '{secondName_TextBox.Text}', " +
                    $" [firstName] = '{firstName_TextBox.Text}', " +
                    $" [thirdName] = '{thirdName_TextBox.Text}', " +
                    $" [telNumber] = '{telNumber_TextBox.Text}', " +
                    $" [email] = '{email_TextBox.Text}' " +
                    $"WHERE [dataID] = '{currentUserData.dataID}'");
                Entry_TextBlock.Text = "Здравствуйте, " + firstName_TextBox.Text + " " + thirdName_TextBox.Text;
                if (OldPassword_TextBox.Password.Length > 0 && NewPassword_TextBox.Password.Length > 0 && RetryOldPassword_TextBox.Password.Length > 0)
                {
                    if (OldPassword_TextBox.Password == currentUser.Password && NewPassword_TextBox.Password == RetryOldPassword_TextBox.Password)
                    {
                        acdb.Insert($"UPDATE [users] SET [password] = '{NewPassword_TextBox.Password}' WHERE [userID] = '{currentUser.userID}'");
                        SendRegisterNoticeMail(currentUserData.Email);
                    }
                }
                else
                    MessageBox.Show("Неверный пароль");
                MessageBox.Show("Данные обновлены успешно");
            }
        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Owner.Show();
            Application.Current.MainWindow.Show();
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
            Message.Subject = "Изменение пароля";
            Message.Body = "Здравствуйте, " + currentUserData.FirstName.Trim() + " " + currentUserData.ThirdName.Trim() + "\nВаш пароль был изменен. Если это были не вы - обратитесь к администратору!";
            Smtp.Send(Message);
        }
    }
}
