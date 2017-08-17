using System.Windows;
using System.Windows.Controls;

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
            if (text.Length != 0)
            {
                ((ViewModel)DataContext).AddInput(text);
            }
        }

        private void Button_Click_Del(object sender, RoutedEventArgs e)
        {
            string text = ((ViewModel)DataContext).Input;
            if (text.Length != 0)
            {
                ((ViewModel)DataContext).RemoveInput();
            }
        }
    }
}
