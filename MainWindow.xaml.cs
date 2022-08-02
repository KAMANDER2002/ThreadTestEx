using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestExecute1.Server;

namespace TestExecute1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Reader1Bt.Click += Reader1Bt_Click;
            Reader2Bt.Click += Reader2Bt_Click;
            Reader3Bt.Click += Reader3Bt_Click;
            Reader4Bt.Click += Reader4Bt_Click;
            Writer1Bt.Click += Writer1Bt_Click;
            Writer2Bt.Click += Writer2Bt_Click;
            lvButton.Click += LvButton_Click;
            
        }

        private void LvButton_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < 50; i++)
            {
                if (i % 2 == 0)
                    ServerClass.AddToCount(2);
                else
                    Dispatcher.Invoke(() => lvCount.Items.Add(ServerClass.GetCount()));
            }
            Dispatcher.Invoke(() => lvCount.Items.Add("Выполнено"));
        }

        private void Writer2Bt_Click(object sender, RoutedEventArgs e)
        {
            ServerClass.AddToCount(Convert.ToInt32(Writer1TextBox.Text));
        }

        private void Writer1Bt_Click(object sender, RoutedEventArgs e)
        {
            ServerClass.AddToCount(Convert.ToInt32(Writer1TextBox.Text));
        }

        private void Reader4Bt_Click(object sender, RoutedEventArgs e)
        {
            CountTB_TextRead.Text = ServerClass.GetCount().ToString();
        }

        private void Reader3Bt_Click(object sender, RoutedEventArgs e)
        {
            CountTB_TextRead.Text = ServerClass.GetCount().ToString();
        }

        private void Reader2Bt_Click(object sender, RoutedEventArgs e)
        {
           CountTB_TextRead.Text = ServerClass.GetCount().ToString();
        }

        private void Reader1Bt_Click(object sender, RoutedEventArgs e)
        {
            CountTB_TextRead.Text = ServerClass.GetCount().ToString();
        }
    }
}
