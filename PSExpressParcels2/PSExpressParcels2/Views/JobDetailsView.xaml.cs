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

namespace PSExpressParcels2.Views
{
    public partial class JobDetailsView : PhoneApplicationPage
    {
        public JobDetailsView()
        {
            InitializeComponent();
            DataContext = App.JobListVM.SelectedJob;
        }

        private void btn_Parcels(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/ParcelListView.xaml", UriKind.Relative));
        }
    }
}