using Autodesk.Revit.DB;
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

namespace SMKWindowsPF
{
    /// <summary>
    /// Lógica de interacción para SMKViewer.xaml
    /// </summary>
    public partial class SMKViewer : Window
    {

        public Document document;
        public SMKViewer(Document doc)
        {
            document = doc;

            InitializeComponent();

            DisplayTreeViewItem();
        }

        public void DisplayTreeViewItem()
        {
            SortedDictionary<string, TreeViewItem> WallTypeDictionary = new SortedDictionary<string, TreeViewItem>();

            List<string> wallTypeNames = new List<string>();

            List<Element> elements = new FilteredElementCollector(document).OfCategory(BuiltInCategory.OST_Walls).WhereElementIsElementType().ToList();

            ///

            foreach(Element element in elements)
            {
                WallType walltype = element as WallType;

                wallTypeNames.Add(walltype.Name);
            }
            ////
            ///
            foreach(string walltypeName in wallTypeNames.Distinct().OrderBy(name => name).ToList())
            {
                TreeViewItem wallTypeItem = new TreeViewItem() { Header = walltypeName };
                WallTypeDictionary[walltypeName] = wallTypeItem;

                VIEWLIST.Items.Add(wallTypeItem);
            }

            ////
            ///

            foreach(Element element in elements)
            {
                WallType walltype = element as WallType;

                string WALLName = walltype.FamilyName;

                string WALLTypename = walltype.Name.ToString();

                TreeViewItem viewItem = new TreeViewItem() { Header = WALLName };
                WallTypeDictionary[WALLTypename].Items.Add(viewItem);
            }

        }
    }
}
