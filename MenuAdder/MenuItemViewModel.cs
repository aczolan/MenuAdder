using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAdder
{
    public class MenuItemParentViewModel
    {
        private ObservableCollection<MenuItemViewModel> m_viewModelCollection;
        public ObservableCollection<MenuItemViewModel> ViewModelCollection;
    }

    public class MenuItemViewModel
    {
        private string m_name;
        public string Name;

        private string m_price;
        public string Price;

        private string m_imgURL;
        public string ImgURL;
    }
}
