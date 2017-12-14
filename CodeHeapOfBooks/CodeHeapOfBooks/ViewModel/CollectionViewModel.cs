using Code.Model;
using CodeHeapOfBooks.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFMVVMPrism;

namespace CodeHeapOfBooks.ViewModel
{
    class CollectionViewModel : BindableBase
    {
        private List<Collection> listOfCillections;
        private Collection selectedCillection;
        private CreatedView createdView;
        private ConfirmMessageView confirmMessageView;
        private RelayCommand detCommand;
        private DocumentsView documentsView;

    

        public DocumentsView DocumentsViewModelQ
        {
            get
            {
                return documentsView;
            }
            set
            {
                //documentsViewModel = value;
                //OnPropertyChanged("DocumentsViewModel");
                 SetProperty(ref documentsView, value); 
            }
        }

        public List<Collection> ListOfCillections
        {
            get
            {
                return listOfCillections;
            }
            set
            {
                listOfCillections = value;
                OnPropertyChanged("ListOfCillections");
            }
        }

        public Collection SelectedCillection
        {
            get
            {
                return selectedCillection;
            }
            set
            {
                selectedCillection = value;
                OnPropertyChanged("SelectedCillection");
            }
        }

        public CollectionViewModel()
        {
            using (UserContext db = new UserContext())
            {
                ListOfCillections = new List<Collection>(db.Collections);
            }
            AddCommand = new MyICommand<object>(GetNewName);
            DelCommand = new MyICommand<object>(DeleteCollection);
            //DetailCommand = new MyICommand<object>(DetailAddCommand);
            DocumentsViewModelQ = new DocumentsView();
        }

        private void UpDateListCollection(UserContext db)
        {
            ListOfCillections = new List<Collection>(db.Collections);
        }

        public MyICommand<object> AddCommand { get; private set; }
        private void GetNewName(object destination)
        {
            createdView = new CreatedView();          

            if (createdView.ShowDialog() == true)
            {
                var temp = (createdView.DataContext as CreatedViewModel).NewName;
                using (UserContext db = new UserContext())
                {
                    Collection collection = new Collection { Name = temp, DateСreation = DateTime.Now };
                    db.Collections.Add(collection);
                    if (db.SaveChanges() == 1)
                    {
                        UpDateListCollection(db);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка базы данных!");
                    }

                }
            }           
        }



        public MyICommand<object> DelCommand { get; private set; }
        private void DeleteCollection(object destination)
        {
            if (selectedCillection != null)
            {
                confirmMessageView = new ConfirmMessageView("Вы уверены, что хотите удалить эту коллекцию?");

                if (confirmMessageView.ShowDialog() == true)
                {
                    using (UserContext db = new UserContext())
                    {
                        var temp = db.Collections.Find(selectedCillection.Id);

                        db.Collections.Remove(temp);

                        if (db.SaveChanges() == 1)
                        {
                            UpDateListCollection(db);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка базы данных!");
                        }

                    }
                }               
            }           
        }

        int count = 30;
        //public RelayCommand DetailCommand { get; private set; }


        public RelayCommand DetailCommand
        {
            get { return detCommand ?? (detCommand = new RelayCommand(param => this.DetailAddCommand(param))); }

        }

        private void DetailAddCommand(object destination)
        {
            //listDocumentsViewModel.AddNewTab();

            var temp = new DocumentsView();
            (temp.DataContext as DocumentsViewModel).Test = count;
            var t = destination as Collection;
            using (UserContext db = new UserContext())
            {
                //var tempCol = db.Collections.Include("Documents").Where(x=>x.Id == (t).Id).ToList().FirstOrDefault();
                //(temp.DataContext as DocumentsViewModel).Documents = tempCol.Documents.ToList();
                (temp.DataContext as DocumentsViewModel).Init(t);
                DocumentsViewModelQ = temp;
            }
               

           // DocumentsViewModelQ = new DocumentsView();
            //DocumentsViewModelQ.Test = count;
            //OnPropertyChanged("DocumentsViewModel");
            count++;
        }
    }
}
