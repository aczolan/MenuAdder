﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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

        private MenuItemViewModel m_selectedViewModel;
        public MenuItemViewModel SelectedViewModel
        {
            get => m_selectedViewModel;
            set
            {
                if (value != m_selectedViewModel)
                {
                    m_selectedViewModel = value;
                    NotifyPropertyChanged("SelectedViewModel");
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

            XmlDocument doc = new XmlDocument();
            ViewModelCollection = new ObservableCollection<MenuItemViewModel>();

            try
            {
                doc.Load(filepath);
            }
            catch(Exception e)
            { }

            try
            {
                //XmlNodeList does not support foreach and it makes me upset

                XmlNodeList itemNodes = doc.GetElementsByTagName("item");
                for (int i = 0; i < itemNodes.Count; i++)
                {
                    MenuItemViewModel childVM = new MenuItemViewModel();

                    var itemPropNodes = itemNodes[i].ChildNodes;
                    for (int j = 0; j < itemPropNodes.Count; j++)
                    {
                        var node = itemPropNodes[j];
                        string nodeName = node.Name.Trim().ToLower();
                        string nodeContent = node.InnerText.Trim();

                        if (nodeName == "triggers")
                        {
                            XmlNodeList trigNodes = node.ChildNodes;
                            for (int k = 0; k < trigNodes.Count; k++)
                            {
                                var trigNode = trigNodes[k];
                                if (trigNode.Name == "trigger")
                                {
                                    childVM.Triggers.Add(trigNode.InnerText);
                                }
                            }
                        }
                        else
                        {
                            CheckXMLTagToSetStringDictionary.FirstOrDefault((kvp) => kvp.Key(nodeName)).Value.Invoke(childVM, nodeContent);
                        }
                    }

                    ViewModelCollection.Add(childVM);
                }
            }
            catch(Exception e)
            { }
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

        private const string DEFAULT_STRING = "";

        private string m_name = DEFAULT_STRING;
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

        private string m_price = DEFAULT_STRING;
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

        private string m_imgURL = DEFAULT_STRING;
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

        private ObservableCollection<string> m_triggers = new ObservableCollection<string>();
        public ObservableCollection<string> Triggers
        {
            get => m_triggers;
            set
            {
                if (value != m_triggers)
                {
                    m_triggers = value;
                    NotifyPropertyChanged("Triggers");
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
