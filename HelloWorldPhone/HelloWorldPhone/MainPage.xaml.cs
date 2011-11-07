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

namespace HelloWorldPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            theStatus.Text = "hello from code!";
            theStatus.MouseLeftButtonUp += new MouseButtonEventHandler(theStatus_MouseLeftButtonUp);
        }

        private void theStatus_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            theStatus.Text = "Status was tapped";
        }
    }
}