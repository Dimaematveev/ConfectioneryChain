using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CreateItems.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Text.Document.Blocks.Clear();
            Text.Document.Blocks.Add(new Paragraph());

        }

        private void Pre_Click(object sender, RoutedEventArgs e)
        {
            string richText = new TextRange(Text.Document.ContentStart, Text.Document.ContentEnd).Text;
            

            richText = richText.Replace("\r", "");
            TheOneClass theOneClass = new TheOneClass(richText);
            

            string wpf= theOneClass.RetItemsWPF();
            NameWPF.Document.Blocks.Clear();
            NameWPF.Document.Blocks.Add(new Paragraph(new Run(wpf)));

            string clas = "";
            clas += theOneClass.RetEdit_Loaded();
            clas +="\n\n";
            clas += theOneClass.RetFillingFielsFromGeneral();
            clas +="\n\n";
            clas += theOneClass.RetFillingGeneralFromFields();
            NameCLASS.Document.Blocks.Clear();
            NameCLASS.Document.Blocks.Add(new Paragraph(new Run(clas)));

        }


        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }

    public class TheOneClass
    {
        string ClassName { get; set; }
        string ListName { get; set; }
        List<Item> items;

        public TheOneClass(string values)
        {
            var varible = values.Split('\n');
            ClassName = varible[0].Split('\t')[1];
            ListName = varible[1].Split('\t')[1];
            items = new List<Item>();
            foreach (var item in varible.Skip(2))
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(new Item(item));
                }
            }
        }

        public string RetItemsWPF()
        {
            string str = "";
            str += "<StackPanel Orientation=\"Vertical\" Grid.Row=\"0\" Grid.Column=\"0\" Margin=\"5\">\n";
            foreach (var item in items)
            {
                str += item.GetWPF();
            }
            str += "</StackPanel>\n";
            return str;
        }

        public string RetEdit_Loaded()
        {
            string str = "";
            str += "\t\t/// <summary>\n";
            str += "\t\t/// Действия при загрузке\n";
            str += "\t\t/// </summary>\n";
            str += "\t\tprivate void Edit_Loaded()\n";
            str += "\t\t{\n";
            str += "\t\t\tTableGeneral.ItemsSource = null;\n";
            str += $"\t\t\tDB.{ListName}.Load();\n";


            foreach (var item in items.Where(x=>!string.IsNullOrWhiteSpace(x.RefToType)))
            {
                str += $"\t\t\tDB.{item.RefToType}.Load();\n";
                str += $"\t\t\t{item.Name}.ItemsSource = DB.{item.RefToType}.Local;\n";
                
            }


            str += $"\t\t\tData = DB.{ListName};\n";
            str += "\t\t\tTableGeneral.ItemsSource = Data.Local;\n";
            str += "\t\t}\n";
            return str;
        }

        public string RetFillingGeneralFromFields()
        {
            string str = "";
            str += "\t\t/// <summary>\n";
            str += "\t\t/// Заполнить объект из полей\n";
            str += "\t\t/// </summary>\n";
            str += "\t\tprivate void FillingGeneralFromFields()\n";
            str += "\t\t{\n";
            str += $"\t\t\tif(General is {ClassName} general)\n";
            str += "\t\t\t{\n";
            foreach (var item in items)
            {
                str += "\t\t\t\t";
                str += item.GetFillingGeneralFromFields();
            }
            str += "\t\t\t}\n";
            str += "\t\t}\n";
            return str;
        }
        public string RetFillingFielsFromGeneral()
        {
            string str = "";
            str += "\t\t/// <summary>\n";
            str += "\t\t/// Заполнить Поля из Объекта\n";
            str += "\t\t/// </summary>\n";
            str += "\t\t/// <param name=\"str\"></param>\n";
            str += "\t\tprivate void FillingFielsFromGeneral(object str)\n";
            str += "\t\t{\n";
            str += "\t\t\tif (str is null)\n";
            str += "\t\t\t{\n";
            str += $"\t\t\t\tstr = new {ClassName}().CreateNew();\n";
            str += "\t\t\t}\n";
            str += $"\t\t\tif (str is {ClassName} general)\n";
            str += "\t\t\t{\n";
            str += "\t\t\t\tGeneral = general;\n\n";
            foreach (var item in items)
            {
                str += "\t\t\t\t";
                str += item.GetFillingFielsFromGeneral();
            }
            str += "\t\t\t};\n";
            str += "\n\t\t}\n";
            return str;
        }
    }

    public class Item
    {
        public Item(string all)
        {
            var items = all.Split('\t');
            if (items.Length!=6)
            {
                return;
            }
            RusName = items[0];
            Name = items[1];
            NameSQL = items[2];
            Type = items[3].ToLower();
            RefToType = items[4];
            IDRef = items[5];

            GetTypes();
        }
        public string RusName { get; set; }
        public string Name { get; set; }
        public string NameSQL { get; set; }
        public string Type { get; set; }
        public string RefToType { get; set; }
        public string IDRef { get; set; }

        
        private string NameUIElement { get; set; }
        private string ValueToUIElement { get; set; }
        private string ValueFromUIElement { get; set; }

        private string ValueToSQL { get; set; }
        private string ValueFromSQL { get; set; }
        

        public string GetWPF()
        {
            string str = "";
            str += "<StackPanel Orientation=\"Vertical\">\n";
            str += $"<Label> {RusName}:</Label>\n";
            str += $"<{NameUIElement} x:Name=\"{Name}\" />\n";
            str += " </StackPanel>\n";
            return str;
        }
        public string GetFillingFielsFromGeneral()
        {
            return $"{ValueToUIElement} = {ValueFromSQL};\n";
        }

        public string GetFillingGeneralFromFields()
        {
            return $"{ValueToSQL} = {ValueFromUIElement};\n";
        }

        void GetTypes()
        {
            if (!string.IsNullOrWhiteSpace(RefToType)) 
            {
                NameUIElement= $"ComboBox  SelectedValuePath = \"{IDRef}\" ";

                ValueToUIElement = $"{Name}.SelectedValue";
                ValueFromUIElement = $"(int){Name}.SelectedValue";

                ValueToSQL = $"general.{NameSQL}";
                ValueFromSQL = $"general.{NameSQL}";

                return;
            }

            if (Type.StartsWith("decimal") || Type.StartsWith("numeric"))
            {
                NameUIElement = "ctrl:DecimalUpDown Increment = \"1000\"";

                ValueToUIElement = $"{Name}.Value";
                ValueFromUIElement = $"{Name}.Value.Value";

                ValueToSQL = $"general.{NameSQL}";
                ValueFromSQL = $"general.{NameSQL}";
                return;
            }
            if (Type.StartsWith("int"))
            {
                NameUIElement = "ctrl:IntegerUpDown Increment = \"1\"";

                ValueToUIElement = $"{Name}.Value";
                ValueFromUIElement = $"{Name}.Value.Value";

                ValueToSQL = $"general.{NameSQL}";
                ValueFromSQL = $"general.{NameSQL}";
                return;
            }
            if (Type.StartsWith("time")) 
            {
                NameUIElement= "ctrl:TimePicker Format=\"Custom\" FormatString=\"HH: mm\" StartTime=\"00:00\" EndTime=\"23:59\"  TimeInterval=\"00:15\"";
                
                ValueToUIElement = $"{Name}.Value";
                ValueFromUIElement = $"new TimeSpan({Name}.Value.Value.Ticks)";

                ValueToSQL = $"general.{NameSQL}";
                ValueFromSQL = $"new DateTime(general.{NameSQL}.Ticks)";
                return;
            }
            if (Type.StartsWith("nvarchar(max)"))
            {
                NameUIElement= "TextBox TextWrapping=\"Wrap\" Height=\"60\" ";

                ValueToUIElement = $"{Name}.Text";
                ValueFromUIElement = $"{Name}.Text";

                ValueToSQL = $"general.{NameSQL}";
                ValueFromSQL = $"general.{NameSQL}";
                return;
            }
            if (Type.StartsWith("nvarchar")) 
            {
                NameUIElement= "TextBox";

                ValueToUIElement = $"{Name}.Text";
                ValueFromUIElement = $"{Name}.Text";

                ValueToSQL = $"general.{NameSQL}";
                ValueFromSQL = $"general.{NameSQL}";
                return;
            }


            

            if (Type.StartsWith("datetime2"))
            {
                NameUIElement = "ctrl:DateTimePicker Format=\"FullDateTime\"";

                ValueToUIElement = $"{Name}.Value";
                ValueFromUIElement = $"{Name}.Value.Value";

                ValueToSQL = $"general.{NameSQL}";
                ValueFromSQL = $"general.{NameSQL}";
                return;
            }
            if (Type.StartsWith("bit"))
            {
                NameUIElement = "CheckBox";

                ValueToUIElement = $"{Name}.IsChecked";
                ValueFromUIElement = $"{Name}.IsChecked.Value";

                ValueToSQL = $"general.{NameSQL}";
                ValueFromSQL = $"general.{NameSQL}";
                return;
            }

        }

    }
}
