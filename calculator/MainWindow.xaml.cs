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

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Input(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string text = (string)button.Tag;
            ((ViewModel)DataContext).Input += text;
        }

        private void Button_Click_Del(object sender, RoutedEventArgs e)
        {
            string text = ((ViewModel)DataContext).Input;
            if (text.Length != 0)
            {
                ((ViewModel)DataContext).Input = text.Substring(0, text.Length - 1);
            }
        }
    }
}
