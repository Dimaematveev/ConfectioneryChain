using ConfectioneryChain.DB;
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
using System.Windows.Interop;
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
        int ID;
        public EditConf(DbSet data,Action save) 
        {
            InitializeComponent();
            Data = data;
            DataGrid1.ItemsSource = data.Local;
            Save = save;

            //Общее
            CloseConf.Click += CloseConf_Click;
            //Для 1 кафе
            SaveConf.Click += SaveConf_Click;
            CancelConf.Click += CancelConf_Click;

            //Для всех кафе
            EditConfBut.Click += EditConfBut_Click;
            AddConf.Click += AddConf_Click;

        }

       

        private void EditConfBut_Click(object sender, RoutedEventArgs e)
        {
            
            switch (DataGrid1.SelectedIndex)
            {
                case -1:
                    MessageBox.Show($"Вы не выбрали поле.","Неправильно выбраны поля",MessageBoxButton.OK,MessageBoxImage.Warning);
                    break;
                default:
                    ID = DataGrid1.SelectedIndex;
                    FillingFields();
                    break;
            }
        }

        private void FillingFields()
        {
            Confectionery str = (DataGrid1.Items[DataGrid1.SelectedIndex]) as Confectionery;
            
            NameConf.Text = str.Name;
            AdressConf.Text = str.Address;
            RentPriceConf.Text = str.RentPricel.ToString();
            BeginTime.Text = str.BeginWork.ToString("c");
            EndTime.Text = str.EndWork.ToString("c");


        }

        private void AddConf_Click(object sender, RoutedEventArgs e)
        {
            ID = -1;
            NameConf.Text = "";
            AdressConf.Text = "";
            RentPriceConf.Text = "0";
            BeginTime.Text = "00:00:00";
            EndTime.Text = "00:00:00";
        }

        private void CancelConf_Click(object sender, RoutedEventArgs e)
        {
            ID = -1;
            NameConf.Text = "";
            AdressConf.Text = "";
            RentPriceConf.Text = "0";
            BeginTime.Text = "00:00:00";
            EndTime.Text = "00:00:00";
        }

        private void SaveConf_Click(object sender, RoutedEventArgs e)
        {
            
            if (ID==-1)
            {
                Data.Local.Add(NewConfectionery());
            }
            else
            {
                Data.Local[ID] = NewConfectionery();
            }
            Save();

        }

        private Confectionery NewConfectionery()
        {
            Confectionery conf = new Confectionery();
            conf.Name = NameConf.Text;
            conf.Address = AdressConf.Text;
            conf.RentPricel = int.Parse(RentPriceConf.Text);
            conf.BeginWork = TimeSpan.Parse(BeginTime.Text);
            conf.EndWork = TimeSpan.Parse(EndTime.Text);
            return conf;

        }
        private void CloseConf_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }


    }
}
