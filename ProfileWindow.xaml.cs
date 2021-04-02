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
    public partial class ProfileWindow : Window
    {
        UserData currentUserData;
        User currentUser;
        AccessToDB acdb = new AccessToDB();
        AppContext apc = new AppContext();
        public ProfileWindow()
        {
            InitializeComponent();
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

            acdb.Insert($"UPDATE [userDatas] SET" + // ДОБАВИТЬ ПРОВЕРКИ ДЛЯ ТЕКСТБОКСОВ
                $" [secondName] = '{secondName_TextBox.Text}', " +
                $" [firstName] = '{firstName_TextBox.Text}', " +
                $" [thirdName] = '{thirdName_TextBox.Text}', " +
                $" [telNumber] = '{telNumber_TextBox.Text}', " +
                $" [email] = '{email_TextBox.Text}' " +
                $"WHERE [dataID] = '{currentUserData.dataID}'");
            if(OldPassword_TextBox.Password.Length>0 && NewPassword_TextBox.Password.Length>0 && RetryOldPassword_TextBox.Password.Length>0)
            {
                if(OldPassword_TextBox.Password == currentUser.Password && NewPassword_TextBox.Password == RetryOldPassword_TextBox.Password)
                {
                    acdb.Insert($"UPDATE [users] SET [password] = '{NewPassword_TextBox.Password}' WHERE [userID] = '{currentUser.userID}'");
                }
            }
            MessageBox.Show("Данные обновлены успешно");
        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Owner.Show();
            Application.Current.MainWindow.Show();
        }
    }
}
