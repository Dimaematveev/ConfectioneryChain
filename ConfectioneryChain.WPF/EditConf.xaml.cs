using ConfectioneryChain.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.SqlClient;
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
            Save = save;
            LoadValue();
            //Общее
            CloseConf.Click += CloseConf_Click;
            //Для 1 кафе
            SaveConf.Click += SaveConf_Click;
            CancelConf.Click += CancelConf_Click;

            //Для всех кафе
            EditConfBut.Click += EditConfBut_Click;
            AddConf.Click += AddConf_Click;

        }

        private void LoadValue()
        {
            Data.Load();
            DataGrid1.ItemsSource = Data.Local;
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
                    Edit.IsEnabled = true;
                    FillingFields();
                    break;
            }
        }

        private void FillingFields()
        {
            Confectionery str = (DataGrid1.Items[DataGrid1.SelectedIndex]) as Confectionery;
            
            NameConf.Text = str.Name;
            AdressConf.Text = str.Address;
            RentPriceConf.Value = str.RentPricel;

            BeginTime.Value = new DateTime(str.BeginWork.Ticks);
            EndTime.Value = new DateTime(str.EndWork.Ticks); 


        }

        private void AddConf_Click(object sender, RoutedEventArgs e)
        {
            Edit.IsEnabled = true;
            DefaultValue();

        }

        private void CancelConf_Click(object sender, RoutedEventArgs e)
        {
            Edit.IsEnabled = false;
            DefaultValue();
        }

        private void DefaultValue()
        {
            ID = -1;
            NameConf.Text = "";
            AdressConf.Text = "";
            RentPriceConf.Value = 0;
            BeginTime.Value = new DateTime();
            EndTime.Value = new DateTime();
        }

        private void SaveConf_Click(object sender, RoutedEventArgs e)
        {
            Edit.IsEnabled = false;
            if (ID==-1)
            {
                Data.Local.Add(NewConfectionery());
            }
            else
            {
                var conf = NewConfectionery();
                conf.IDConfectionery = (Data.Local[ID] as Confectionery).IDConfectionery;
                Data.Local[ID] = conf;
            }

            try
            {
                Save();
            }
            catch (Exception ex)
            {
                if (ID == -1)
                {
                    Data.Local.RemoveAt(Data.Local.Count - 1);
                }
                Exception ex1 = ex;
                string err = "";
                while(ex1 != null)
                {
                    err += "\n";
                    err += new string('-',30);
                    err += "\n";
                    err += ex1.Source;
                    err += "\n";
                    err += ex1.Message;
                    ex1 = ex1.InnerException;
                } 
                
                MessageBox.Show(err, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private Confectionery NewConfectionery()
        {
            Confectionery conf = new Confectionery();
            conf.Name = NameConf.Text;
            conf.Address = AdressConf.Text;
            conf.RentPricel = RentPriceConf.Value.Value;
            conf.BeginWork = new TimeSpan(BeginTime.Value.Value.Ticks);
            conf.EndWork = new TimeSpan(EndTime.Value.Value.Ticks);
            return conf;
        }
        private void CloseConf_Click(object sender, RoutedEventArgs e)
        {
            Edit.IsEnabled = false;
            DialogResult = true;
        }


    }
}
