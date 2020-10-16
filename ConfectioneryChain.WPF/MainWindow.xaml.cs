using ConfectioneryChain.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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
        }


        private void EditConf_Click(object sender, RoutedEventArgs e)
        {

            Window edit = new EditConf(db.Confectioneries, ()=>db.SaveChanges());
            edit.ShowDialog();
            Init();
            
            
        }
    }
}
