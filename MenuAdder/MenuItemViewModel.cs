using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MenuAdder
{
    public class MenuItemParentViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged Stuff
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private ObservableCollection<MenuItemViewModel> m_viewModelCollection = new ObservableCollection<MenuItemViewModel>();
        public ObservableCollection<MenuItemViewModel> ViewModelCollection
        {
            get => m_viewModelCollection;
            set
            {
                if (value != m_viewModelCollection)
                {
                    m_viewModelCollection = value;
                    NotifyPropertyChanged("ViewModelCollection");
                }
            }
        }

        public void LoadViewModelsFromXMLFile(string filepath)
        {
            var CheckXMLTagToSetStringDictionary = new Dictionary<Func<string, bool>, Action<MenuItemViewModel, string>>()
            {
                { (s) => s == "name"  , (vm, s) => vm.Name = s },
                { (s) => s == "price" , (vm, s) => vm.Price = s },
                { (s) => s == "url"   , (vm, s) => vm.ImgURL = s }
            };

            ViewModelCollection = new ObservableCollection<MenuItemViewModel>();
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);

            try
            {
                XmlNodeList grandparents = doc.GetElementsByTagName("menu");
                XmlNodeList parents = doc.GetElementsByTagName("item");
                for (int i = 0; i < parents.Count; i++)
                {
                    MenuItemViewModel childVM = new MenuItemViewModel();

                    var children = parents[i].ChildNodes;
                    for (int j = 0; j < children.Count; j++)
                    {
                        var node = children[j];
                        string nodeName = node.Name.Trim().ToLower();
                        string nodeContent = node.InnerText.Trim();

                        CheckXMLTagToSetStringDictionary.FirstOrDefault((kvp) => kvp.Key(nodeName)).Value.Invoke(childVM, nodeContent);
                    }

                    ViewModelCollection.Add(childVM);
                }
            }
            catch(Exception e)
            {
            }
        }

        public override string ToString()
        {
            return "I am MIPVM.";
        }

        public MenuItemParentViewModel()
        {
        }
    }

    public class MenuItemViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged Stuff
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private string m_name;
        public string Name
        {
            get => m_name;
            set
            {
                if (value != m_name)
                {
                    m_name = value;
                    NotifyPropertyChanged("Name");
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
                    NotifyPropertyChanged("Price");
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
                    NotifyPropertyChanged("ImgURL");
                }
            }
        }

        public override string ToString()
        {
            return (Name + ": " + Price);
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
