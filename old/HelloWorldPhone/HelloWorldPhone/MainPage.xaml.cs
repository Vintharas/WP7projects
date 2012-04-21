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
using Microsoft.Phone.Tasks;

namespace HelloWorldPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        EmailAddressChooserTask emailChooser = new EmailAddressChooserTask();

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            theStatus.Text = "hello from code!";
            theStatus.MouseLeftButtonUp += new MouseButtonEventHandler(theStatus_MouseLeftButtonUp);
            theEllipse.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(theEllipse_ManipulationDelta);
            theEllipse.MouseLeftButtonUp += new MouseButtonEventHandler(theEllipse_MouseLeftButtonUp);
            emailChooser.Completed += new EventHandler<EmailResult>(emailChooser_Completed);
        }

        private void emailChooser_Completed(object sender, EmailResult e)
        {
            MessageBox.Show(e.Email);
        }

        private void theEllipse_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //SearchTask task = new SearchTask();
            //task.SearchQuery = "Windows Phone";
            //task.Show();
            emailChooser.Show();
        }

        private void theEllipse_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            // As a manipulation is executed (drag or resize), this is called
            theMover.X = e.CumulativeManipulation.Translation.X;
            theMover.Y = e.CumulativeManipulation.Translation.Y;
        }

        private void theStatus_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            theStatus.Text = "Status was tapped";
        }
    }
}