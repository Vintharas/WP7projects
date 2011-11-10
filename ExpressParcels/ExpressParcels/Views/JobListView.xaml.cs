﻿using System;
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
using ExpressParcels.ViewModels;
using Microsoft.Phone.Controls;

namespace ExpressParcels.Views
{
    public partial class JobListView : PhoneApplicationPage
    {
        public JobListView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            App.JobListVM = new JobListViewModel();
            DataContext = App.JobListVM;

            App.JobListVM.LoadData();
        }

        private void lbJobs_Selectionchanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb.SelectedIndex == -1)
                return;
            NavigationService.Navigate(new Uri("/Views/JobDetailsView.xaml", UriKind.Relative));
            lb.SelectedIndex = -1;
        }
    }
}