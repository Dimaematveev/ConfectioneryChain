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

        Recipe Recipe;
        public EditGoodRecipe(ConfectioneryChain_V5Entities db, General general)
        {
            InitializeComponent();
            DB = db;
            Recipe = (Recipe)general;
            Loaded += (s, e) => { Edit_Loaded(); };
            //Общее
            CloseGeneral.Click += CloseGeneral_Click;
            //Для 1 кафе
            SaveOne.Click += SaveOne_Click;
            CancelOne.Click += CancelOne_Click;
        }

        /// <summary>
        /// Закрыть
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseGeneral_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }


       

        /// <summary>
        /// Отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelOne_Click(object sender, RoutedEventArgs e)
        {
            FillingFielsFromGeneral();
        }

        /// <summary>
        /// Сохранить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveOne_Click(object sender, RoutedEventArgs e)
        {
            FillingGeneralFromFields();
            if (Recipe.IDRecipe == -1)
            {
                DB.Recipes.Add(Recipe);
            }
            

            try
            {
                DB.SaveChanges();
                DialogResult = true;
            }
            catch (Exception ex)
            {
                if (Recipe.IDRecipe == -1)
                {
                    DB.Recipes.Remove(Recipe);
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
            DB.Recipes.Load();
            DB.Employees.Load();
            ChefIDRecipe.ItemsSource = DB.Employees.Local;
            FillingFielsFromGeneral();
        }


        /// <summary>
        /// Заполнить Поля из Объекта
        /// </summary>
        private void FillingFielsFromGeneral()
        {
            if (Recipe is null)
            {
                Recipe = (Recipe)new Recipe().CreateNew();
            }
            
            DateCreateRecipe.Value = Recipe.DateCreate;
            MarkIsWorkRecipe.IsChecked = Recipe.MarkIsWork;
            ChefIDRecipe.SelectedValue = Recipe.ChefID;
            NameRecipe.Text = Recipe.Name;
            DescriptionRecipe.Text = Recipe.Description;

        }


        /// <summary>
        /// Заполнить объект из полей
        /// </summary>
        private void FillingGeneralFromFields()
        {


            Recipe.DateCreate = DateCreateRecipe.Value.Value;
            Recipe.MarkIsWork = MarkIsWorkRecipe.IsChecked.Value;
            Recipe.ChefID = (int)ChefIDRecipe.SelectedValue;
            Recipe.Name = NameRecipe.Text;
            Recipe.Description = DescriptionRecipe.Text;
            
        }
        #endregion




    }
}
