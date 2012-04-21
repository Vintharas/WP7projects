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

namespace PSDataBindingsTwoWayPart2
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            // now the binding is updated as the textbox text is changed
            var exp = tb.GetBindingExpression(TextBox.TextProperty);
            exp.UpdateSource();
        }
    }
}