﻿using System;
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
            Entry_TextBlock.Text = "Здравствуйте, " + currentUser.FirstName + " " + currentUser.ThirdName;
            secondName_TextBox.Text = currentUser.SecondName;
            firstName_TextBox.Text = currentUser.FirstName;
            thirdName_TextBox.Text = currentUser.ThirdName;
            email_TextBox.Text = currentUser.Email;
            telNumber_TextBox.Text = currentUser.TelNumber;
        }
        private void ConfirmChanges_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Application.Current.MainWindow.Show();
        }
    }
}
