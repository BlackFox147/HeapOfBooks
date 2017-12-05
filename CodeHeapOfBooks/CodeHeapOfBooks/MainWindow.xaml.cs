using Code.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeHeapOfBooks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (UserContext db = new UserContext())
            {


                //var temp = db.Collections.Include("Documents").ToList().First();
                //Document collection1 = new Document { Name = "doc1", DateСreation = DateTime.Now, DateLastChange = DateTime.Now, Collection = temp, CollectionId = temp.Id };
                //db.Documents.Add(collection1);


                //db.SaveChanges();


                //Document collection2 = new Document { Name = "doc2", DateСreation = DateTime.Now, Collection = temp, CollectionId = temp.Id };

                //temp.Documents.Add(collection1);
                //temp.Documents.Add(collection2);
                //var docs = temp.Documents;

                //docs.Add(collection1);

                //temp.Documents = docs;
                //db.Entry(temp).State = EntityState.Modified;
                //db.SaveChanges();


                // создаем объекты Book 
                //Collection collection1 = new Collection { Name = "Властелин колец", DateСreation = DateTime.Now };
                //Collection collection2 = new Collection { Name = "Эрагон", DateСreation = DateTime.Now };
                //Collection collection3 = new Collection { Name = "Песнь льда и пламени", DateСreation = DateTime.Now };

                //// добавляем в базу данных 
                //db.Collections.Add(collection1);
                //db.Collections.Add(collection2);
                //db.Collections.Add(collection3);
                //db.SaveChanges();
            }

            
        }
    }
}
