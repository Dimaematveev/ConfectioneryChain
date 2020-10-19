using ConfectioneryChain.DB;
using System;
using System.Data.Entity;
using System.Windows;

namespace ConfectioneryChain.WPF.Dictionary
{
    /// <summary>
    /// Interaction logic for EditConf.xaml
    /// </summary>
    public partial class EditConf : Window
    {
        private readonly Action Save;
        private readonly DbSet Data;
        private int ID;
        public EditConf(ConfectioneryChain_V5Entities db)
        {
            InitializeComponent();
            db.Positions.Load();
            Data = db.Confectioneries;
            Save = () => db.SaveChanges();
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
            Data.Load();
            DataGrid1.ItemsSource = Data.Local;
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

        private void FillingFields(Confectionery str)
        {
            NameConf.Text = str.Name;
            AdressConf.Text = str.Address;
            RentPriceConf.Value = str.RentPricel;

            BeginTime.Value = new DateTime(str.BeginWork.Ticks);
            EndTime.Value = new DateTime(str.EndWork.Ticks);


        }

        private void AddConf_Click(object sender, RoutedEventArgs e)
        {
            Edit.IsEnabled = true;
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
                Data.Local.Add(New());
            }
            else
            {
                var conf = New();
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

        private Confectionery New()
        {
            var obj = new Confectionery
            {
                Name = NameConf.Text,
                Address = AdressConf.Text,
                RentPricel = RentPriceConf.Value.Value,
                BeginWork = new TimeSpan(BeginTime.Value.Value.Ticks),
                EndWork = new TimeSpan(EndTime.Value.Value.Ticks)
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
