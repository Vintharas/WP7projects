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
using TwitterClientPrototype.Concretes;
using TwitterClientPrototype.Model;
using TwitterClientPrototype.ViewModels;
using TwitterClientPrototype.Helpers;

namespace TwitterClientPrototype
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly Twitter Twitter;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Twitter = new Twitter();
            App.TweetListVM = new TweetListViewModel();
            this.DataContext = App.TweetListVM;
            App.TweetListVM.LoadData();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            Twitter.RefreshTweets(RefreshTweets);
        }

        private void RefreshTweets(IEnumerable<Tweet> tweets )
        {
            App.TweetListVM.Tweets.Add(tweets);
        }
    }
}