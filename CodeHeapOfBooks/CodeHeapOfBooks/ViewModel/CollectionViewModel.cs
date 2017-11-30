using Code.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHeapOfBooks.ViewModel
{
    class CollectionViewModel : BindableBase
    {
        private List<Collection> listOfCillections;
        private Collection selectedCillection;

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
        }


    }
}
