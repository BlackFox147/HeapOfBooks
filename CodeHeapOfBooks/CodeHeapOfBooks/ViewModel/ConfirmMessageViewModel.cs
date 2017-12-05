using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHeapOfBooks.ViewModel
{
    public class ConfirmMessageViewModel : BindableBase
    {
        private string message;

        public ConfirmMessageViewModel(string messageShow)
        {
            this.message = messageShow;
        }

        public string Message
        {
            get
            {
                return message;
            }           
        }
    }
}
