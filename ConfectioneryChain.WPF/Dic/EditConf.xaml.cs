using ConfectioneryChain.DB;
using ConfectioneryChain.DB.Inheritance;
using System;
using System.Data.Entity;
using System.Windows;

namespace ConfectioneryChain.WPF.Dic
{
    /// <summary>
    /// Interaction logic for EditConf.xaml
    /// </summary>
    public partial class EditConf : Window
    {
        private readonly ConfectioneryChain_V5Entities DB;


        DbSet Data;
        private int ID;
        General General;
        public EditConf(ConfectioneryChain_V5Entities db)
        {
            InitializeComponent();
            DB = db;

            Loaded += (s, e) => { Edit_Loaded(); };
            //Общее
            CloseGeneral.Click += CloseGeneral_Click;
            //Для 1 кафе
            SaveOne.Click += SaveOne_Click;
            CancelOne.Click += CancelOne_Click;

            //Для всех кафе
            EditAll.Click += EditAll_Click;
            AddAll.Click += AddAll_Click;

        }

        /// <summary>
        /// Закрыть
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseGeneral_Click(object sender, RoutedEventArgs e)
        {
            Edit.IsEnabled = false;
            DialogResult = true;
        }


        /// <summary>
        /// Редактировать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditAll_Click(object sender, RoutedEventArgs e)
        {
            ID = TableGeneral.SelectedIndex;
            if (ID == -1)
            {
                MessageBox.Show($"Вы не выбрали поле.", "Неправильно выбраны поля", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Edit.IsEnabled = true;
                FillingFielsFromGeneral(Data.Local[TableGeneral.SelectedIndex]);
            }
        }


        /// <summary>
        /// Добавить новый
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAll_Click(object sender, RoutedEventArgs e)
        {
            Edit.IsEnabled = true;
            ID = -1;
            FillingFielsFromGeneral(null);

        }

        /// <summary>
        /// Отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelOne_Click(object sender, RoutedEventArgs e)
        {
            Edit.IsEnabled = false;
            FillingFielsFromGeneral(null);
        }

        /// <summary>
        /// Сохранить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveOne_Click(object sender, RoutedEventArgs e)
        {
            FillingGeneralFromFields();
            if (ID == -1)
            {
                Data.Add(General);
            }
            else
            {
                ((General)Data.Local[ID]).Fill(General);
            }

            try
            {
                DB.SaveChanges();
                Edit.IsEnabled = false;
                Edit_Loaded();
            }
            catch (Exception ex)
            {
                if (ID == -1)
                {
                    Data.Remove(General);
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

        #region Изменяемое
        /// <summary>
        /// Действия при загрузке
        /// </summary>
        private void Edit_Loaded()
        {
            TableGeneral.ItemsSource = null;
            DB.Confectioneries.Load();
            Data = DB.Confectioneries;
            TableGeneral.ItemsSource = Data.Local;
        }


        /// <summary>
        /// Заполнить Поля из Объекта
        /// </summary>
        /// <param name="str"></param>
        private void FillingFielsFromGeneral(object str)
        {
            if (str is null)
            {
                str = new Confectionery().CreateNew();
            }
            if (str is Confectionery general)
            {
                General = general;

                NameConfectionery.Text = general.Name;
                AddressConfectionery.Text = general.Address;
                RentPricelConfectionery.Value = general.RentPricel;
                BeginWorkConfectionery.Value = new DateTime(general.BeginWork.Ticks);
                EndWorkConfectionery.Value = new DateTime(general.EndWork.Ticks);
                MoneyConfectionery.Value = general.Money;
            };

        }


        /// <summary>
        /// Заполнить объект из полей
        /// </summary>
        private void FillingGeneralFromFields()
        {
            if (General is Confectionery general)
            {
                general.Name = NameConfectionery.Text;
                general.Address = AddressConfectionery.Text;
                general.RentPricel = RentPricelConfectionery.Value.Value;
                general.BeginWork = new TimeSpan(BeginWorkConfectionery.Value.Value.Ticks);
                general.EndWork = new TimeSpan(EndWorkConfectionery.Value.Value.Ticks);
                general.Money = MoneyConfectionery.Value.Value;
            }
        }
        #endregion







    }
}
