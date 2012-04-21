using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace PSDataBindingsBindingToPOCOs
{
    
    public partial class MainPage : PhoneApplicationPage
    {
        private Product product;
        private ObservableCollection<Product> products;
 
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            product = new Product
                          {
                              ProdName = "WP7",
                              QtyInStock = 20,
                              UnitPrice = 399.99d
                          };
            ContentPanel.DataContext = product;
            // PRODUCT LIST
            products = new ObservableCollection<Product>
                           {
                               product,
                               new Product {ProdName = "IPhone", QtyInStock = 100, UnitPrice = 700},
                               new Product {ProdName = "Android", QtyInStock = 50, UnitPrice = 600}
                           };
            productListBox.ItemsSource = products;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            product.QtyInStock++;
            tblQty.Text = product.QtyInStock.ToString();
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            products.Add(new Product {ProdName = "New Product: " + DateTime.Now.Millisecond});
        }
        private void BindingValidationError(object sender, ValidationErrorEventArgs e)
        {
            var tb = sender as TextBox;
            if (e.Action == ValidationErrorEventAction.Added)
            {
                // new errors occured
                tb.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                // error fixed
                tb.ClearValue(TextBox.ForegroundProperty);
            }
        }
    }
    public class Product : INotifyPropertyChanged
    {
        public string ProdName { get; set; }
        public double UnitPrice { get; set; }
        public int QtyInStock { get { return qtyInStock; } 
            set
            {
                qtyInStock = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("QtyInStock"));
                    PropertyChanged(this, new PropertyChangedEventArgs("TotalValue"));
                }
            } }
        private int qtyInStock;
        public double TotalValue { get { return UnitPrice*QtyInStock; } }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}