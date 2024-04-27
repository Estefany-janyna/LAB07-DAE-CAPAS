using Business;
using Entity;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Semana07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PersonBusiness business = new PersonBusiness();
            dgPeople.ItemsSource = business.Get();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            ProductBusiness business = new ProductBusiness();
            dgPeople.ItemsSource = business.Get();
        }

        // En tu clase MainWindow
        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            string productName = txtProductName.Text;
            ProductBusiness business = new ProductBusiness();
            dgPeople.ItemsSource = business.SearchByName(productName);
        }


    }


}