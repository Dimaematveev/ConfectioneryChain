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
        List<Item> items;

        public MainWindow()
        {
            InitializeComponent();
            items = new List<Item>();
            Text.Document.Blocks.Clear();
            Text.Document.Blocks.Add(new Paragraph());

        }

        private void Pre_Click(object sender, RoutedEventArgs e)
        {
            string richText = new TextRange(Text.Document.ContentStart, Text.Document.ContentEnd).Text;
            richText = richText.Replace("\r", "");
            var varible = richText.Split('\n');
            foreach (var item in varible)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(new Item(item));
                }
                
            }

            string wpf= RetItemsWPF();
            NameWPF.Document.Blocks.Clear();
            NameWPF.Document.Blocks.Add(new Paragraph(new Run(wpf)));

            string clas = RetFillingField();
            clas +="\n\n";
            clas += RetNew();
            NameCLASS.Document.Blocks.Clear();
            NameCLASS.Document.Blocks.Add(new Paragraph(new Run(clas)));

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

        public string RetFillingField()
        {
            string str = "";
            str += "private void FillingFields(Confectionery str) {";
            foreach (var item in items)
            {
                str += item.GetFillingFields();
            }
            str += "}\n";
            return str;
        }
        public string RetNew()
        {
            string str = "";
            str += " private Confectionery New(){ \n var obj = new Confectionery{";
            foreach (var item in items)
            {
                str += item.GetNew();
            }
            str += "}; return obj; }\n";
            return str;
        }
    }

    public class Item
    {
        public Item(string all)
        {
            var items = all.Split('\t');
            if (items.Length!=4)
            {
                return;
            }
            RusName = items[0];
            Name = items[1];
            NameSQL = items[2];
            Type = items[3].ToLower();

            GetTypes();
        }
        public string RusName { get; set; }
        public string Name { get; set; }
        public string NameSQL { get; set; }
        public string Type { get; set; }
        
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
        public string GetFillingFields()
        {
            return $"{ValueToUIElement} = {ValueFromSQL};\n";
        }

        public string GetNew()
        {
            return $"{ValueToSQL} = {ValueFromUIElement};\n";
        }

        void GetTypes()
        {
            if (Type.StartsWith("decimal") || Type.StartsWith("numeric")) 
            {
                NameUIElement= "ctrl:DecimalUpDown Increment = \"1000\"";

                ValueToUIElement = $"{Name}.Value";
                ValueFromUIElement = $"{Name}.Value.Value";

                ValueToSQL = $"{NameSQL}";
                ValueFromSQL = $"str.{NameSQL}";
                return;
            }
            if (Type.StartsWith("time")) 
            {
                NameUIElement= "ctrl:TimePicker Format=\"Custom\" FormatString=\"HH: mm\" StartTime=\"00:00\" EndTime=\"23:59\"  TimeInterval=\"00:15\"";
                
                ValueToUIElement = $"{Name}.Value";
                ValueFromUIElement = $"new TimeSpan({Name}.Value.Value.Ticks)";

                ValueToSQL = $"{NameSQL}";
                ValueFromSQL = $" new DateTime(str.{NameSQL}.Ticks)";
                return;
            }
            if (Type.StartsWith("nvarchar(max)"))
            {
                NameUIElement= "TextBox TextWrapping=\"Wrap\" Height=\"60\" ";

                ValueToUIElement = $"{Name}.Text";
                ValueFromUIElement = $"{Name}.Text";

                ValueToSQL = $"{NameSQL}";
                ValueFromSQL = $"str.{NameSQL}";
                return;
            }
            if (Type.StartsWith("nvarchar")) 
            {
                NameUIElement= "TextBox";

                ValueToUIElement = $"{Name}.Text";
                ValueFromUIElement = $"{Name}.Text";

                ValueToSQL = $"{NameSQL}";
                ValueFromSQL = $"str.{NameSQL}";
                return;
            }


           
        }

    }
}
