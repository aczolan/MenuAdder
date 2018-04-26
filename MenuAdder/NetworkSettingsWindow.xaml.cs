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
using System.Windows.Shapes;

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
