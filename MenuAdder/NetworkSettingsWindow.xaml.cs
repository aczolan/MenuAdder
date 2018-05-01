using System.Windows;

namespace MenuAdder
{
    /// <summary>
    /// Interaction logic for NetworkSettingsWindow.xaml
    /// </summary>
    public partial class NetworkSettingsWindow : Window
    {
        public string EnteredAddress
        {
            get
            {
                return IPTextBox.Text + ":" + PortTextBox.Text + DirTextBox.Text;
            }
        }

        public NetworkSettingsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
