using Code.Model;
using CodeHeapOfBooks.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CodeHeapOfBooks.ViewModel
{
    class CollectionViewModel : BindableBase
    {
        private List<Collection> listOfCillections;
        private Collection selectedCillection;
        private CreatedView createdView;
        private ConfirmMessageView confirmMessageView;
        private ListDocumentsViewModel listDocumentsViewModel;
        private DocumentsView documentsView;

        public ListDocumentsViewModel ListDocumentsViewModel
        {
            get
            {
                return listDocumentsViewModel;
            }
            set
            {
                listDocumentsViewModel = value;
                OnPropertyChanged("ListDocumentsViewModel");
            }
        }

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
            DetailCommand = new MyICommand<object>(DetailAddCommand);
            listDocumentsViewModel = new ListDocumentsViewModel();
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
        public MyICommand<object> DetailCommand { get; private set; }
        private void DetailAddCommand(object destination)
        {
            //listDocumentsViewModel.AddNewTab();

            var temp = new DocumentsView();
            (temp.DataContext as DocumentsViewModel).Test = count;

            DocumentsViewModelQ = temp;

           // DocumentsViewModelQ = new DocumentsView();
            //DocumentsViewModelQ.Test = count;
            //OnPropertyChanged("DocumentsViewModel");
            count++;
        }
    }
}
