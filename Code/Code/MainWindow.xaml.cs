using Code.Model;
using System;
using System.Collections.Generic;
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

namespace Code
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // add data 
            using (UserContext db = new UserContext())
            {
                // создаем объекты Book 
                Collection collection1 = new Collection { Name = "Граф Монтекристо", DateСreation = DateTime.Now };
                Collection collection2 = new Collection { Name = "Властелин колец", DateСreation = DateTime.Now };
                Collection collection3 = new Collection { Name = "Три толсяка", DateСreation = DateTime.Now };

                // добавляем в базу данных 
                db.Collections.Add(collection1);
                db.Collections.Add(collection2);
                db.Collections.Add(collection3);
                db.SaveChanges();
            }
        }
    }
}
