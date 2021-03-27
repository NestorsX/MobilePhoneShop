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
        AccessToDB acdb = new AccessToDB();
        public Register()
        {
            InitializeComponent();
            Closing += OnWindowClosing;
            acdb.Insert($"INSERT INTO [dbo].[данные пользователей] (Имя, e-mail, ДатаРегистрации, ДатаПоследнегоДоступа ) VALUES ('Вася','ksh@gmail.com','{DateTime.Now}','{DateTime.Now}')");
        }
        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Application.Current.MainWindow.Show();
        }
    }
}
