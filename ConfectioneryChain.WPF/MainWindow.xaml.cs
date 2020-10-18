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
            db.Confectioneries.Load();
            LableConf.Content = db.Confectioneries.Local.Count;
            db.Employees.Load();
            LableEmpl.Content = db.Employees.Local.Count;
            db.Positions.Load();
            LablePos.Content = db.Positions.Local.Count;
        }


        private void EditConf_Click(object sender, RoutedEventArgs e)
        {

            Window edit = new EditConf(db.Confectioneries, ()=>db.SaveChanges());
            edit.ShowDialog();
            Init();
            
            
        }

        private void EditEmpl_Click(object sender, RoutedEventArgs e)
        {
            Window edit = new EditEmpl(db.Employees, () => db.SaveChanges());
            edit.ShowDialog();
            Init();
        }

        private void EditPos_Click(object sender, RoutedEventArgs e)
        {
            Window edit = new EditPos(db.Positions, () => db.SaveChanges());
            edit.ShowDialog();
            Init();
        }
    }
}
