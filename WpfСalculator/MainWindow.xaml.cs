using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfСalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(var uiElement in MainRoot.Children)
            {
                if(uiElement is Button) ((Button)uiElement).Click += Button_Click;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var buttonText = ((Button)e.OriginalSource).Content.ToString();

            if(buttonText == "AC") textLabel1.Text = "";
            else if(buttonText == "=")
            {
                var value = new DataTable().Compute(textLabel1.Text, null).ToString();
                textLabel1.Text = value;
            }
            else textLabel1.Text += buttonText;


        }
    }
}
