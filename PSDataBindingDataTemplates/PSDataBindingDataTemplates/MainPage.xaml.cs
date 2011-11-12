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

namespace PSDataBindingDataTemplates
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
            products = new ObservableCollection<Product>
                           {
                               product,
                               new Product {ProdName = "iPhone", QtyInStock = 100, UnitPrice = 700}
                           };
            productListBox.ItemsSource = products;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            product.QtyInStock--;
        }

        private void btnClickAddNewProduct(object sender, RoutedEventArgs e)
        {
            products.Add(new Product{ProdName = "New Product: " + DateTime.Now.Millisecond});
        }
    }

    public class Product : INotifyPropertyChanged
    {
        public string ProdName { get; set; }
        public double UnitPrice { get; set; }
        public int QtyInStock
        {
            get { return qtyInStock; }
            set
            {
                qtyInStock = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("QtyInStock"));
            }
        }
        private int qtyInStock;

        public event PropertyChangedEventHandler PropertyChanged;
    }

}