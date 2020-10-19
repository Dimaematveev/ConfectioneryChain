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
        }
        public string RusName { get; set; }
        public string Name { get; set; }
        public string NameSQL { get; set; }
        public string Type { get; set; }
        
        

        public string GetWPF()
        {
            string str = "";
            str += "<StackPanel Orientation=\"Vertical\">\n";
            str += $"<Label> {RusName}:</Label>\n";
            str += $"<{GetTypes()} x:Name=\"{Name}\" />\n";
            str += " </StackPanel>\n";
            return str;
        }

        string GetTypes()
        {
            if (Type.StartsWith("decimal") || Type.StartsWith("numeric")) 
            {
                return "ctrl:DecimalUpDown Increment = \"1000\"";
            }
            if (Type.StartsWith("time")) 
            {
                return "ctrl:TimePicker Format=\"Custom\" FormatString=\"HH: mm\" StartTime=\"00:00\" EndTime=\"23:59\"  TimeInterval=\"00:15\"";
            }
            if (Type.StartsWith("nvarchar(max)"))
            {
                return "ctrl:TimePicker Format=\"Custom\" FormatString=\"HH: mm\" StartTime=\"00:00\" EndTime=\"23:59\"  TimeInterval=\"00:15\"";
            }
            if (Type.StartsWith("nvarchar")) 
            {
                return "TextBox";
            }


            return "TextBox";
        }

    }
}
