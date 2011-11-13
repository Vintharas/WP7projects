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

namespace PluralsightDataBinding2
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class CustomClass
    {
        public Ellipse MyEllipse { get { return ellipse; } }
        private Ellipse ellipse = new Ellipse {Fill = new SolidColorBrush(Colors.White)};
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public Brush MyBrush
        {
            get
            {
                return new SolidColorBrush(
                    Color.FromArgb(255, (byte)R, (byte)G, (byte)B));
            }
        }}
}