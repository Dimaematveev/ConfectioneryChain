using ConfectioneryChain.DB;
using ConfectioneryChain.DB.Inheritance;
using System;
using System.Data.Entity;
using System.Windows;

namespace ConfectioneryChain.WPF.GoodRecipe
{
    /// <summary>
    /// Interaction logic for EditConf.xaml
    /// </summary>
    public partial class EditGoodRecipe : Window
    {
        private readonly ConfectioneryChain_V5Entities DB;


        DbSet Data;
        private int ID;
        General General;
        public EditGoodRecipe(ConfectioneryChain_V5Entities db)
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
            DB.Recipes.Load();
            DB.Employees.Load();
            ChefIDRecipe.ItemsSource = DB.Employees.Local;
            Data = DB.Recipes;
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
                str = new Recipe().CreateNew();
            }
            if (str is Recipe general)
            {
                General = general;


                DateCreateRecipe.Value = general.DateCreate;
                MarkIsWorkRecipe.IsChecked = general.MarkIsWork;
                ChefIDRecipe.SelectedValue = general.ChefID;
                NameRecipe.Text = general.Name;
                DescriptionRecipe.Text = general.Description;
            };

        }


        /// <summary>
        /// Заполнить объект из полей
        /// </summary>
        private void FillingGeneralFromFields()
        {
            if (General is Recipe general)
            {

                general.DateCreate = DateCreateRecipe.Value.Value;
                general.MarkIsWork = MarkIsWorkRecipe.IsChecked.Value;
                general.ChefID = (int)ChefIDRecipe.SelectedValue;
                general.Name = NameRecipe.Text;
                general.Description = DescriptionRecipe.Text;
            }
        }
        #endregion




    }
}
