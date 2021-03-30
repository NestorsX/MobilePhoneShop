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
        UserData currentUser;
        AccessToDB acdb = new AccessToDB();
        AppContext apc = new AppContext();
        public ProfileWindow()
        {
            InitializeComponent();
            Closing += OnWindowClosing;
            currentUser = apc.userDatas.Where(userData => userData.dataID == MainWindow.currentUserID).FirstOrDefault();
            MessageBox.Show(currentUser.Email.ToString());

        }
        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Application.Current.MainWindow.Show();
        }
    }
}
