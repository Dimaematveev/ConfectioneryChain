using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace ConfectioneryChain.WPF
{
    /// <summary>
    /// Interaction logic for EditConf.xaml
    /// </summary>
    public partial class EditConf : Window
    {
        Action Save;
        DbSet Data;
        public EditConf(DbSet data,Action save) 
        {
            InitializeComponent();
            Data = data;
            DataGrid1.ItemsSource = data.Local;
            Save = save;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DataGrid1.ItemsSource = Data.Local;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Save();
            DialogResult = true;
        }
    }
}
