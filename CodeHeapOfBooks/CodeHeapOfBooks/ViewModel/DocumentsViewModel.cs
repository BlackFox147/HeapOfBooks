using Code.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHeapOfBooks.ViewModel
{
    public class DocumentsViewModel : BindableBase
    {
        private int test;
        private Document document;
        private List<Document> documents;

        public int Test
        {
            get
            {
                return test;
            }
            set
            {
                test = value;
                OnPropertyChanged("Test");
            }            
        }

        public Document SelectedDocument
        {
            get
            {
                return document;
            }
            set
            {
                document = value;
                OnPropertyChanged("SelectedDocument");
            }
        }

        public List<Document> Documents
        {
            get
            {
                return documents;
            }
            set
            {
                documents = value;
                OnPropertyChanged("Documents");
            }
        }


        public DocumentsViewModel()
        {
            this.documents = new List<Document>();
        }
       
    }
}
