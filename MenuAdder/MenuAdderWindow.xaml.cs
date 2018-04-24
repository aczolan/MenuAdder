using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using System.Xml;

namespace MenuAdder
{
    /// <summary>
    /// Interaction logic for MenuAdderWindow.xaml
    /// </summary>
    public partial class MenuAdderWindow : Window, INotifyPropertyChanged
    {
        #region PropertyChanged Stuff
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private MenuItemParentViewModel m_displayedViewModel;
        public MenuItemParentViewModel DisplayedViewModel
        {
            get => m_displayedViewModel;
            set
            {
                if (value != m_displayedViewModel)
                {
                    m_displayedViewModel = value;
                    NotifyPropertyChanged(nameof(DisplayedViewModel));
                }
            }
        }

        public MenuAdderWindow()
        {
            InitializeComponent();
            DisplayedViewModel = new MenuItemParentViewModel();
            DataContext = DisplayedViewModel;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                DisplayedViewModel.LoadViewModelsFromXMLFile(ofd.FileName);
            }
        }

        private void DebugButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayedViewModel.ViewModelCollection.Add(new MenuItemViewModel("thing", "$0.99", "thing.com"));
        }
    }
}
