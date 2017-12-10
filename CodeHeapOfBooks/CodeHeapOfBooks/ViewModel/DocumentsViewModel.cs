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
        public DocumentsViewModel()
        {
            //this.Test = a;
        }
       
    }
}
