using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
    public partial class AdminPanel : Window
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

        AccessToDB acdb = new AccessToDB();
        AppContext apc = new AppContext();
        List<Phone> phones;
        string imagePath;
        public AdminPanel()
        {
            InitializeComponent();
            this.SourceInitialized += MainWindow_SourceInitialized;
            OS_ComboBox.ItemsSource = apc.os.ToList();
            DisplayTech_ComboBox.ItemsSource = apc.displayTeches.ToList();
            Accum_ComboBox.ItemsSource = apc.accs.ToList();
            Phones_ListBox.ItemsSource = apc.phones.ToList();
            phones = apc.phones.ToList();
        }

        private void AddMobilePhone_Click(object sender, RoutedEventArgs e)
        {
            string osID = OS_ComboBox.SelectedIndex.ToString();
            string displayTechID = DisplayTech_ComboBox.SelectedIndex.ToString();
            string model = Model_TextBox.Text;
            string simCount = SimCount_TextBox.Text;
            string processor = Processor_TextBox.Text;
            string mainCamRes = MainCameraRes_TextBox.Text;
            string frontCamRes = FrontCameraRes_TextBox.Text;
            string ramCapacity = RAMCapacity_TextBox.Text;
            string romCapacity = ROMCapacity_TextBox.Text;
            string colour = Colour_TextBox.Text;
            string weight = Weight_TextBox.Text;
            string accumID = Accum_ComboBox.SelectedIndex.ToString();
            string accumCapacity = AccumCapacity_TextBox.Text;
            string cost = Cost_TextBox.Text;
            if (phones.Where(phone => phone.Models == model).Count() == 0)
            {
                if (Convert.ToInt32(osID) > -1 && Convert.ToInt32(displayTechID) > -1 && model.Length > 0 && simCount.Length > 0 && processor.Length > 0 && mainCamRes.Length > 0
                    && frontCamRes.Length > 0 && ramCapacity.Length > 0 && romCapacity.Length > 0 && colour.Length > 0 && weight.Length > 0 && Convert.ToInt32(accumID) > -1
                    && accumCapacity.Length>0 && Convert.ToDouble(cost) > 0 && imagePath.Length>0)
                {
                    File.Copy(imagePath, "C:/Users/neste/Desktop/MobilePhoneShop/Images/" + System.IO.Path.GetFileName(imagePath));
                    acdb.Insert($"INSERT INTO [phones] VALUES({Convert.ToInt32(osID) + 1}, {Convert.ToInt32(displayTechID) + 1}, '{model}', {simCount}, " +
                        $"'{processor}', {mainCamRes}, {frontCamRes}, {ramCapacity}, {romCapacity}, '{colour}', {weight}, {Convert.ToInt32(accumID) + 1}, {accumCapacity}, {cost}, '{System.IO.Path.GetFileNameWithoutExtension(imagePath)}')");
                    MessageBox.Show("Телефон добавлен в систему");
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.Show();
                    Close();
                }
            }
            else
                MessageBox.Show("Модель телефона уже существует в системе");
        }

        private void AddOS_Click(object sender, RoutedEventArgs e)
        {
            string OS = OsType_TextBox.Text;
            if (apc.os.Where(os => os.Name == OS).Count() == 0)
            {
                if (OS.Length > 0)
                {
                    acdb.Insert($"INSERT INTO [os] VALUES('{OS}')");
                    MessageBox.Show("ОС добавлена");
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.Show();
                    Close();
                }
            }
            else
                MessageBox.Show("ОС уже существует в системе");
        }

        private void AddDisplay_Click(object sender, RoutedEventArgs e)
        {
            string Display = Display_TextBox.Text;
            if (apc.displayTeches.Where(display => display.Type == Display).Count() == 0)
            {
                if (Display.Length > 0)
                {
                    acdb.Insert($"INSERT INTO [displayTeches] VALUES('{Display}')");
                    MessageBox.Show("Тип матрицы добавлен");
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.Show();
                    Close();
                }
            }
            else
                MessageBox.Show("Тип матрицы уже существует в системе");
        }

        private void AddAccumulator_Click(object sender, RoutedEventArgs e)
        {
            string accum = Accumulator_TextBox.Text;
            if (apc.accs.Where(acc => acc.Type == accum).Count() == 0)
            {
                if (accum.Length > 0)
                {
                    acdb.Insert($"INSERT INTO [accs] VALUES('{accum}')");
                    MessageBox.Show("Тип аккумулятора добавлен");
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.Show();
                    Close();
                }
            }
            else
                MessageBox.Show("Тип аккумулятора уже существует в системе");
        }

        private void DeletePhone_Click(object sender, RoutedEventArgs e)
        {
            if(Phones_ListBox.SelectedIndex>-1)
            {
                acdb.Insert($"DELETE FROM [phones] WHERE [models] = '{Phones_ListBox.SelectedItem.ToString()}'");
                MessageBox.Show("Телефон удален");
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                Close();
            }
            else
                MessageBox.Show("Выберите телефон, чтобы удалить");
        }

        private void ChoosePicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fOpen = new OpenFileDialog();
            fOpen.Filter = "Image (*.jpg)|*.jpg";
            SolidColorBrush solidColor = new SolidColorBrush(Color.FromRgb(124, 252, 0));
            if (fOpen.ShowDialog() == true)
            {
                imagePath = fOpen.FileName;
                ChoosePicture.Content = System.IO.Path.GetFileName(imagePath);
                ChoosePicture.Background = solidColor;

            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow auth = new MainWindow();
            auth.Show();
            Close();
        }
    }
}
