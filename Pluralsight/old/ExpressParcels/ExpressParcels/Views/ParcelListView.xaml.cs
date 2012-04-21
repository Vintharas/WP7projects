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

namespace ExpressParcels.Views
{
    public partial class ParcelListView : PhoneApplicationPage
    {
        public ParcelListView()
        {
            InitializeComponent();
            DataContext = App.JobListVM.SelectedJob;
        }
    }
}