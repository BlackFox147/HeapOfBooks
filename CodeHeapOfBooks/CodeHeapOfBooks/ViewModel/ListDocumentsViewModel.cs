using CodeHeapOfBooks.Model;
using CodeHeapOfBooks.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CodeHeapOfBooks.ViewModel
{
    public class ListDocumentsViewModel : BindableBase
    {
        private ObservableCollection<TabControls> listOpenCollection;
        private TabControls tabIndex;

        public ListDocumentsViewModel()
        {
            listOpenCollection = new ObservableCollection<TabControls>();
        }



        public ObservableCollection<TabControls> ListOpenCollection
        {
            get
            {
                return listOpenCollection;
            }
            set
            {
                listOpenCollection = value;
                OnPropertyChanged("ListOpenCollection");
            }
        }

        public TabControls TabIndex
        {
            get
            {
                return tabIndex;
            }
            set
            {
                tabIndex = value;
                OnPropertyChanged("TabIndex");
            }
        }

        public void AddNewTab()
        {
            //var temp = new DocumentsView();
            ////(temp.DataContext as DocumentsViewModel).Test = listOpenCollection.Count() + 1;
            //var header = "Ноутбуки" + listOpenCollection.Count();
          
            //listOpenCollection.Add(new TabControls(header, tabItem));
            //var tempTab = new TabControls();


            //    listOpenCollection.Add(new TabItem
            //{
            //    //Header = new TextBlock { Text = "Ноутбуки" + listOpenCollection.Count() }, // установка заголовка вкладки
            //    Header = "Ноутбуки" + listOpenCollection.Count(),
            //    Content = temp // установка содержимого вкладки
            //});
            TabIndex = listOpenCollection.LastOrDefault();
            (TabIndex.ContentTab as DocumentsViewModel).Test = listOpenCollection.Count() + 1;
            OnPropertyChanged("ListOpenCollection");
        }
    }
}
