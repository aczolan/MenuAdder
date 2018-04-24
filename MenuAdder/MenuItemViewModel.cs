using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MenuAdder
{
    public class MenuItemParentViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged Stuff
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private ObservableCollection<MenuItemViewModel> m_viewModelCollection;
        public ObservableCollection<MenuItemViewModel> ViewModelCollection
        {
            get => m_viewModelCollection;
            set
            {
                if (value != m_viewModelCollection)
                {
                    m_viewModelCollection = value;
                    NotifyPropertyChanged(nameof(ViewModelCollection));
                }
            }
        }
    }

    public class MenuItemViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged Stuff
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private object m_name;
        public object Name
        {
            get => m_name;
            set
            {
                if (value != m_name)
                {
                    m_name = value;
                    NotifyPropertyChanged(nameof(Name));
                }
            }
        }

        private string m_price;
        public string Price
        {
            get => m_price;
            set
            {
                if (value != m_price)
                {
                    m_price = value;
                    NotifyPropertyChanged(nameof(Price));
                }
            }
        }

        private string m_imgURL;
        public string ImgURL
        {
            get => m_imgURL;
            set
            {
                if (value != m_imgURL)
                {
                    m_imgURL = value;
                    NotifyPropertyChanged(nameof(ImgURL));
                }
            }
        }

        public MenuItemViewModel()
        {
        }

        public MenuItemViewModel(string name, string price, string imgUrl)
        {
            Name = name;
            Price = price;
            ImgURL = imgUrl;
        }
    }
}
