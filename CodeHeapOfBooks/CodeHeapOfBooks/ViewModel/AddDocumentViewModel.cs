using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHeapOfBooks.ViewModel
{
    public class AddDocumentViewModel : BindableBase
    {
        private string newName;
        private string pathDocument;

        public string NewName
        {
            get
            {
                return newName;
            }
            set
            {
                newName = value;
                OnPropertyChanged("NewName");
            }
        }

        public string PathDocument
        {
            get
            {
                return pathDocument;
            }
            set
            {
                pathDocument = value;
                OnPropertyChanged("PathDocument");
            }
        }

        public AddDocumentViewModel()
        {
            AddCommand = new MyICommand<object>(GetNewName);
        }

        public MyICommand<object> AddCommand { get; private set; }
        private void GetNewName(object destination)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() != true) return;

            PathDocument = openFileDialog1.FileName;
        }



    }
}
