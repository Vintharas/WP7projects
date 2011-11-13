using System.Collections.ObjectModel;
using System.ComponentModel;
using TwitterClientPrototype.Model;

namespace TwitterClientPrototype.ViewModels
{
    public class TweetListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
        private ObservableCollection<Tweet> tweets;
        public ObservableCollection<Tweet> Tweets
        {
            get { return tweets; }
            set
            {
                if (tweets != value)
                {
                    tweets = value;
                    RaisePropertyChanged("Tweets");
                }
            }
        }

        private Tweet selectedTweet;
        public Tweet SelectedTweet
        {
            get { return selectedTweet; }
            set
            {
                if (selectedTweet != value)
                {
                    selectedTweet = value;
                    RaisePropertyChanged("SelectedTweet");
                }
            }
        }


        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void LoadData()
        {
            Tweets = new ObservableCollection<Tweet>
                         {
                             {new Tweet{ UserName = "@Jaime", Content = "I'm making a twitter client... no kidding...."}},
                             {new Tweet{ UserName = "@JohnDoe", Content = "Really? you're so cool..."}},
                             {new Tweet{ UserName =  "@JaneDoe", Content = "Really? Cause there are not enough twitter clients out there..."}}
                         };
        }
    }
}