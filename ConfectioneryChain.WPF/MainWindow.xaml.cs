using ConfectioneryChain.DB;
using ConfectioneryChain.WPF.Dictionary;
using System.Data.Entity;
using System.Windows;

namespace ConfectioneryChain.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConfectioneryChain_V5Entities db;
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            db = new ConfectioneryChain_V5Entities();
            //Словари
            db.Confectioneries.Load();
            LableConf.Content = db.Confectioneries.Local.Count;
            db.Employees.Load();
            LableEmpl.Content = db.Employees.Local.Count;
            db.Positions.Load();
            LablePos.Content = db.Positions.Local.Count;
            db.Goods.Load();
            LableGoods.Content = db.Goods.Local.Count;
            db.TypeOfGoods.Load();
            LableTypeGoods.Content = db.TypeOfGoods.Local.Count;
            db.Units.Load();
            LableTypeUnits.Content = db.Units.Local.Count;

            //Кондитерская
            db.DistributionOfEmployees.Load();
            LableDistributionOfEmployees.Content = db.DistributionOfEmployees.Local.Count;

        }


        private void EditConf_Click(object sender, RoutedEventArgs e)
        {

            Window edit = new EditConf(db);
            edit.ShowDialog();
            Init();
            
            
        }

        private void EditEmpl_Click(object sender, RoutedEventArgs e)
        {
            Window edit = new EditEmpl(db);
            edit.ShowDialog();
            Init();
        }

        private void EditPos_Click(object sender, RoutedEventArgs e)
        {
            Window edit = new EditPos(db);
            edit.ShowDialog();
            Init();
        }

      

        private void EditTypeGoods_Click(object sender, RoutedEventArgs e)
        {
            Window edit = new EditTypeGoods(db);
            edit.ShowDialog();
            Init();
        }

        

        private void EditTypeUnits_Click(object sender, RoutedEventArgs e)
        {
            Window edit = new EditUnits(db);
            edit.ShowDialog();
            Init();
        }

        private void EditGoods_Click(object sender, RoutedEventArgs e)
        {
            Window edit = new EditGoods(db);
            edit.ShowDialog();
            Init();
        }

        private void EditDistributionOfEmployees_Click(object sender, RoutedEventArgs e)
        {
            Window edit = new EditDistributionOfEmployees(db);
            edit.ShowDialog();
            Init();
        }
    }
}
