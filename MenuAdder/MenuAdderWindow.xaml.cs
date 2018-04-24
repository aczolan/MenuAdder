using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class MenuAdderWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

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
            //dummy viewmodel
            DisplayedViewModel = new MenuItemParentViewModel();
        }

        public MenuAdderWindow()
        {
            InitializeComponent();
            InitializeViewModel();
        }
    }
}
