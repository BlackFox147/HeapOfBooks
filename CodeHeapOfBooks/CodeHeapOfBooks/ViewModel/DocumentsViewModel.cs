using Code.Model;
using CodeHeapOfBooks.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFMVVMPrism;

namespace CodeHeapOfBooks.ViewModel
{
    public class DocumentsViewModel : BindableBase
    {
        private int test;
        private Document document;
        private List<Document> documents;
        private RelayCommand openCommand;
        private AddDocumentView addDocumenView;
        private ConfirmMessageView confirmMessageView;
        private Collection collection;
        private bool isWork;


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


        public Collection Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
                OnPropertyChanged("Collection");
            }
        }

        public bool IsWork
        {
            get
            {
                return isWork;
            }
            set
            {
                isWork = value;
                OnPropertyChanged("IsWork");
            }
        }


        public DocumentsViewModel()
        {
            this.documents = new List<Document>();
            AddCommand = new MyICommand<object>(GetNewName);
            DelCommand = new MyICommand<object>(DeleteCollection);
            SetCommand = new MyICommand<object>(SetDoc);
            PathCommand = new MyICommand<object>(GetNewPath);
            SaveCommand = new MyICommand<object>(SaveInfo);
            IsWork = true;
        }

        public RelayCommand OpenCommand
        {
            get { return openCommand ?? (openCommand = new RelayCommand(param => this.OpenDocumentCommand(param))); }

        }

        private void OpenDocumentCommand(object destination)
        {
            //var temp = new DocumentsView();
            //(temp.DataContext as DocumentsViewModel).Test = count;
            //var t = destination as Collection;
            //using (UserContext db = new UserContext())
            //{
            //    var tempCol = db.Collections.Include("Documents").Where(x => x.Id == (t).Id).ToList().FirstOrDefault();
            //    (temp.DataContext as DocumentsViewModel).Documents = tempCol.Documents.ToList();
            //    DocumentsViewModelQ = temp;
            //}
            var t = destination as Document;
            int a = 1;
            Process.Start(t.FilePath);
        }

        public void Init(Collection collection)
        {
           
            this.Collection = collection;
            using (UserContext db = new UserContext())
            {
                UpDateListDocuments(db);
            }
           
        }

        private void UpDateListDocuments(UserContext db)
        {
            var tempCol = db.Collections.Include("Documents").Where(x => x.Id == (this.collection).Id).ToList().FirstOrDefault();
            this.Documents = tempCol.Documents.ToList();
        }

        public MyICommand<object> AddCommand { get; private set; }
        private void GetNewName(object destination)
        {
            addDocumenView = new AddDocumentView();

            if (addDocumenView.ShowDialog() == true)
            {
                
                var tempName = (addDocumenView.DataContext as AddDocumentViewModel).NewName;
                var tempPath = (addDocumenView.DataContext as AddDocumentViewModel).PathDocument;
                using (UserContext db = new UserContext())
                {

                    Document doc = new Document
                    {
                        Name = tempName,
                        DateСreation = DateTime.Now,
                        FilePath = tempPath,
                        DateLastChange = DateTime.Now,
                        Collection = db.Collections.Where(x => x.Id == (collection).Id).ToList().FirstOrDefault(),
                        CollectionId = this.collection.Id
                    };
                    db.Documents.Add(doc);

                    if (db.SaveChanges() == 1)
                    {
                        UpDateListDocuments(db);
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
            if (document != null)
            {
                confirmMessageView = new ConfirmMessageView("Вы уверены, что хотите удалить эту коллекцию?");

                if (confirmMessageView.ShowDialog() == true)
                {
                    using (UserContext db = new UserContext())
                    {
                        var temp = db.Documents.Find(document.Id);

                        db.Documents.Remove(temp);

                        if (db.SaveChanges() == 1)
                        {
                            UpDateListDocuments(db);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка базы данных!");
                        }

                    }
                }
            }
        }

        public MyICommand<object> SetCommand { get; private set; }
        private void SetDoc(object destination)
        {
            if(document != null)
            {
                IsWork = !IsWork;
                OnPropertyChanged("SelectedDocument");
                OnPropertyChanged("Documents");
            }           

        }

        public MyICommand<object> PathCommand { get; private set; }
        private void GetNewPath(object destination)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() != true) return;

            SelectedDocument.FilePath = openFileDialog1.FileName;
            OnPropertyChanged("SelectedDocument");

        }

        public MyICommand<object> SaveCommand { get; private set; }
        private void SaveInfo(object destination)
        {
            //int a = 0;
            using(UserContext db = new UserContext())
            {
                document.DateLastChange = DateTime.Now;
                db.Entry(document).State = EntityState.Modified;
                if (db.SaveChanges() != 1)
                {
                    MessageBox.Show("Ошибка базы данных!");
                }
            }
            
        }


    }
}
