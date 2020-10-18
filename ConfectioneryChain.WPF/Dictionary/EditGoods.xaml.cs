using ConfectioneryChain.DB;
using System;
using System.Collections;
using System.Data.Entity;
using System.Windows;

namespace ConfectioneryChain.WPF.Dictionary
{
    /// <summary>
    /// Interaction logic for EditConf.xaml
    /// </summary>
    public partial class EditGoods : Window
    {
        Action Save;
        DbSet Data;
        int ID;
        public EditGoods(DbSet data,Action save,IEnumerable TypeGoods)
        {
            InitializeComponent();
            TypesOfGoodsChar.ItemsSource = TypeGoods;
            Data = data;
            Save = save;
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
            var str = (DataGrid1.Items[DataGrid1.SelectedIndex]) as Good;
            
            TypesOfGoodsChar.SelectedValue = str.TypesOfGoodsChar;
            UnitsID.Value = str.UnitsID;
            Name.Text = str.Name;
            Calories.Value = str.Calories;
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
            TypesOfGoodsChar.SelectedIndex = -1;
            UnitsID.Value = 0;
            Name.Text = "";
            Calories.Value = 0;
        }

        private void SaveConf_Click(object sender, RoutedEventArgs e)
        {
            Edit.IsEnabled = false;
            if (ID==-1)
            {
                Data.Local.Add(New());
            }
            else
            {
                var conf = New();
                conf.IDGoods = (Data.Local[ID] as Good).IDGoods;
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

        private Good New()
        {
            var obj = new Good();

            obj.TypesOfGoodsChar = TypesOfGoodsChar.SelectedValue.ToString();
            obj.UnitsID = UnitsID.Value.Value;
            obj.Name = Name.Text;
            obj.Calories = Calories.Value;
            return obj;
        }
        private void CloseConf_Click(object sender, RoutedEventArgs e)
        {
            Edit.IsEnabled = false;
            DialogResult = true;
        }


    }
}
