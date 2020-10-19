using ConfectioneryChain.DB;
using System;
using System.Data.Entity;
using System.Windows;

namespace ConfectioneryChain.WPF.Dictionary
{
    /// <summary>
    /// Interaction logic for EditConf.xaml
    /// </summary>
    public partial class EditPos : Window
    {
        private readonly Action Save;
        private readonly DbSet Data;
        private int ID;
        public EditPos(ConfectioneryChain_V5Entities db)
        {
            InitializeComponent();

            Data = db.Positions;
            Save = () => db.SaveChanges();
            LoadValue();
            //Общее
            CloseGeneral.Click += CloseConf_Click;
            //Для 1 сотрудника
            SaveOne.Click += SaveConf_Click;
            CancelOne.Click += CancelConf_Click;

            //Для всех сотрудников
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
                    FillingFields();
                    break;
            }
        }

        private void FillingFields()
        {
            var str = (DataGrid1.Items[DataGrid1.SelectedIndex]) as Position;

            NamePosition.Text = str.Name;
            MinimumHours.Value = str.MinimumHours;
            WorkHourRate.Value = str.WorkHourRate;

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
            NamePosition.Text = "";
            MinimumHours.Value = 0;
            WorkHourRate.Value = 0;
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
                conf.IDPosition = (Data.Local[ID] as Position).IDPosition;
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

        private Position New()
        {
            var obj = new Position
            {
                Name = NamePosition.Text,
                MinimumHours = MinimumHours.Value.Value,
                WorkHourRate = WorkHourRate.Value.Value
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
