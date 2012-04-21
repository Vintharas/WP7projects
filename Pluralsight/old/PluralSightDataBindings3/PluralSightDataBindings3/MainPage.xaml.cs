using System;
using System.Collections.Generic;
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

namespace PluralSightDataBindings3
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            var car2 = new Vehicle()
                           {
                               Make = "Ford",
                               Model = "Focus",
                               Year = 1999,
                               Color = Colors.Yellow,
                               Engine = new Motor { HorsePower = 120, IsDiesel = true}
                           };
            this.DataContext = car2;
        }
    }

    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public Color Color { get; set; }
        public Motor Engine { get; set; }
    }

    public class Motor
    {
        public int HorsePower { get; set; }
        public bool IsDiesel { get; set; }
    }
}