using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace PluralsightDataBinding3DataBindingInCode
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            var customer = new Customer
                               {
                                   CompanyName = "Techfox Systems",
                                   SalesPercent = 15,
                                   LogoPath = "/Images/TechfoxSystems.png"
                               };
            Binding binding;

            binding = new Binding {Source = customer, Path = new PropertyPath("LogoPath")};
            imgLogo.SetBinding(Image.SourceProperty, binding);
            binding = new Binding {Source = customer, Path = new PropertyPath("CompanyName")};
            companyTextBlock.SetBinding(TextBlock.TextProperty, binding);
            binding = new Binding {Source = customer, Path = new PropertyPath("SalesPercent")};
            BindingOperations.SetBinding(target: salesTextBlock,
                                         dp: TextBlock.TextProperty, binding: binding);

            binding = new Binding{ElementName = "salesTextBlock", Path = new PropertyPath("Text")};
            salesSlider.SetBinding(Slider.ValueProperty, binding);
        }
    }

    public class Customer
    {
        public String CompanyName { get; set; }
        public double SalesPercent { get; set; }
        public string LogoPath { get; set; }
    }
}