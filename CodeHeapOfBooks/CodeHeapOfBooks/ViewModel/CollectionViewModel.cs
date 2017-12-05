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
            else
            {
                MessageBox.Show("Ошибка!");
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
                else
                {
                    MessageBox.Show("Ошибка!");
                }
            }
           
        }
    }
}
