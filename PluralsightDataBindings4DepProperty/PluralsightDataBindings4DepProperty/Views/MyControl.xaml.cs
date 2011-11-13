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

namespace PluralsightDataBindings4DepProperty.Views
{
    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
        }

        public SolidColorBrush Fill
        {
            get { return (SolidColorBrush) GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill",
                                        typeof (SolidColorBrush),
                                        typeof (MyControl),
                                        new PropertyMetadata(new SolidColorBrush(Colors.Blue)));
    }
}
