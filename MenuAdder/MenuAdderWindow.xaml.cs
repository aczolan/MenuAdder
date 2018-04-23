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

namespace MenuAdder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MenuAdderWindow : Window
    {
        private MenuItemParentViewModel m_displayedViewModel;
        public MenuItemParentViewModel DisplayedViewModel;

        private void ReadFromFile(string filepath)
        {

        }

        private void SaveToFile(string filepath)
        {

        }

        private void InitializeViewModel()
        {

        }

        public MenuAdderWindow()
        {
            InitializeComponent();
        }
    }
}
