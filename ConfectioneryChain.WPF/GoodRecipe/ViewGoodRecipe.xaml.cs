using ConfectioneryChain.DB;
using ConfectioneryChain.DB.Inheritance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace ConfectioneryChain.WPF.GoodRecipe
{
    /// <summary>
    /// Interaction logic for EditConf.xaml
    /// </summary>
    public partial class ViewGoodRecipe : Window
    {
        private readonly ConfectioneryChain_V5Entities DB;


        DbSet DataRecipe;
        IEnumerable<ToppingInRecipe> DataTopping;
        public ViewGoodRecipe(ConfectioneryChain_V5Entities db)
        {
            InitializeComponent();
            DB = db;
            Loaded += (s, e) => { View_Loaded(); };
            //Общее
            CloseGeneral.Click += CloseGeneral_Click;

            //Для всех кафе
            EditRecipe.Click += EditAll_Click;
            AddRecipe.Click += AddAll_Click;

            TableRecipe.SelectionChanged += TableRecipe_SelectionChanged;

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
        /// Редактировать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditAll_Click(object sender, RoutedEventArgs e)
        {
            int ID = TableRecipe.SelectedIndex;
            if (ID == -1)
            {
                MessageBox.Show($"Вы не выбрали поле.", "Неправильно выбраны поля", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Window edit = new EditGoodRecipe(DB, (General)TableRecipe.Items[ID]);
                edit.ShowDialog();
                View_Loaded();
            }
        }


        /// <summary>
        /// Добавить новый
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAll_Click(object sender, RoutedEventArgs e)
        {
            Window edit = new EditGoodRecipe(DB,null);
            edit.ShowDialog();
            View_Loaded();

        }

      
        #region Изменяемое
        /// <summary>
        /// Действия при загрузке
        /// </summary>
        private void View_Loaded()
        {
            TableRecipe.ItemsSource = null;
            TableTopping.ItemsSource = null;
            DataRecipe = DB.Recipes;
            TableRecipe.ItemsSource = DataRecipe.Local;
            DB.ToppingInRecipes.Load();
            DataTopping = DB.ToppingInRecipes.Local.Where(x => x.RecipeID == TableRecipe.SelectedIndex);
            TableTopping.ItemsSource = DataTopping;
            
        }

        

        private void TableRecipe_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            TableTopping.ItemsSource = null;
            DataTopping = DB.ToppingInRecipes.Local.Where(x => x.RecipeID == ((Recipe)TableRecipe.Items[TableRecipe.SelectedIndex]).IDRecipe);
            TableTopping.ItemsSource = DataTopping;
        }

        #endregion




    }
}
