using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// <summary>
    /// Interaction logic for RecycleBin.xaml
    /// </summary>
    public partial class RecycleBin : Window
    {
        AccessToDB acdb = new AccessToDB();
        AppContext apc = new AppContext();
        List<Phone> order;
        double totalSum = 0;
        public RecycleBin() 
        {
            InitializeComponent();
        }
        public RecycleBin(List<Phone> order)
        {
            InitializeComponent();
            this.order = order;
            if (order == null)
            {
                BinList_ListBox.ItemsSource = null;
                BinList_ListBox.Items.Clear();
            }
            else
            {
                BinList_ListBox.ItemsSource = this.order;
                foreach (Phone phone in order)
                {
                    totalSum += phone.Cost;
                }
            }
            TotalCost_TextBlock.Text = "Сумма заказа: " + totalSum + " руб.";
            Closing += OnWindowClosing;
        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Owner.Show();
        }

        private void CheckoutOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            if (order.Count > 0)
            {
                if (Addres_textBox.Text.Length > 0)
                {
                    foreach (Phone phone in order)
                    {
                        acdb.Insert($"INSERT INTO [orders] VALUES({MainWindow.currentUserID}, {phone.phoneID}, {phone.Cost}, '{Addres_textBox.Text}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.f")}')");
                    }
                    MainForm main = Owner as MainForm;
                    main.phonesInBin = null;
                    MessageBox.Show("Заказ создан успешно!");
                    Close();
                }
                else
                    MessageBox.Show("Укажите адрес доставки");
            }
            else
                MessageBox.Show("Корзина пуста");
        }

        private void DeletePhoneFromOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            if (BinList_ListBox.SelectedIndex > -1)
            {
                order.RemoveAt(BinList_ListBox.SelectedIndex);
                MessageBox.Show("Товар удален из корзины");
            }
            else
                MessageBox.Show("Выберите товар, который хотите удалить");
        }
    }
}
