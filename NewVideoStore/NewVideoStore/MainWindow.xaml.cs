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
using System.Data.Objects;
using System.Data.Entity.Core.Objects;
using System.Data;

namespace NewVideoStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VideoData1Entities dataEntities = new VideoData1Entities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, SelectionChangedEventArgs e)
        {
            dataGrid1.ItemsSource = dataEntities.Products
            .Include("ProductCategory")
            .Where(p => p.Color == "Red")
            .OrderBy(p => p.ListPrice)
            .Select(p => new { p.Name, p.Color, CategoryName = p.ProductCategory.Name, p.ListPrice })
            .ToList();

        }
    }
}
