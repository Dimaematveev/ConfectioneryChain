using ConfectioneryChain.DB;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace ConfectioneryChain.WPF.Dictionary
{
    /// <summary>
    /// Interaction logic for EditConf.xaml
    /// </summary>
    public partial class EditConf : Window
    {
        private readonly ConfectioneryChain_V5Entities DB;
        private int ID;
        public EditConf(ConfectioneryChain_V5Entities db)
        {
            InitializeComponent();
            DB = db;
            LoadValue();
            //Общее
            CloseGeneral.Click += CloseConf_Click;
            //Для 1 кафе
            SaveOne.Click += SaveConf_Click;
            CancelOne.Click += CancelConf_Click;

            //Для всех кафе
            EditAll.Click += EditConfBut_Click;
            AddAll.Click += AddConf_Click;

        }

        private void LoadValue()
        {
            DB.Confectioneries.Load();
            DataGrid1.ItemsSource = DB.Confectioneries.Local;
        }


        private void EditConfBut_Click(object sender, RoutedEventArgs e)
        {

            switch (DataGrid1.SelectedIndex)
            {
                case -1:
                    MessageBox.Show($"Вы не выбрали поле.", "Неправильно выбраны поля", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                default:
                    ID = DataGrid1.SelectedIndex;
                    Edit.IsEnabled = true;
                    FillingFields((DataGrid1.Items[DataGrid1.SelectedIndex]) as Confectionery);
                    break;
            }
        }

       

        private void AddConf_Click(object sender, RoutedEventArgs e)
        {
            Edit.IsEnabled = true;
            ID = -1;
            FillingFields(new Confectionery().CreateNew() as Confectionery);

        }

        private void CancelConf_Click(object sender, RoutedEventArgs e)
        {
            Edit.IsEnabled = false;
            FillingFields(new Confectionery().CreateNew() as Confectionery);
        }

        private void SaveConf_Click(object sender, RoutedEventArgs e)
        {
            Edit.IsEnabled = false;
            if (ID == -1)
            {
                DB.Confectioneries.Local.Add(New());
            }
            else
            {
                var conf = New();
                conf.IDConfectionery = (DB.Confectioneries.Local[ID]).IDConfectionery;
                DB.Confectioneries.Local[ID] = conf;
            }

            try
            {
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ID == -1)
                {
                    DB.Confectioneries.Local.RemoveAt(DB.Confectioneries.Count() - 1);
                }
                Exception ex1 = ex;
                string err = "";
                while (ex1 != null)
                {
                    err += "\n";
                    err += new string('-', 30);
                    err += "\n";
                    err += ex1.Source;
                    err += "\n";
                    err += ex1.Message;
                    ex1 = ex1.InnerException;
                }

                MessageBox.Show(err, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void FillingFields(Confectionery str)
        {
            NameConf.Text = str.Name;
            AdressConf.Text = str.Address;
            RentPriceConf.Value = str.RentPricel;

            BeginTime.Value = new DateTime(str.BeginWork.Ticks);
            EndTime.Value = new DateTime(str.EndWork.Ticks);

            Money.Value = str.Money;
        }


        private Confectionery New()
        {
            var obj = new Confectionery
            {
                Name = NameConf.Text,
                Address = AdressConf.Text,
                RentPricel = RentPriceConf.Value.Value,
                BeginWork = new TimeSpan(BeginTime.Value.Value.Ticks),
                EndWork = new TimeSpan(EndTime.Value.Value.Ticks),
                Money = Money.Value.Value
            };
            return obj;
        }


        private void CloseConf_Click(object sender, RoutedEventArgs e)
        {
            Edit.IsEnabled = false;
            DialogResult = true;
        }


    }
}
