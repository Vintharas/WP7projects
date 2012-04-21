using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Xml;
using TwitterClientPrototype.Model;
using Newtonsoft.Json;

namespace TwitterClientPrototype.Concretes
{
    public class Twitter
    {
        private readonly WebClient wc;
        private string requestString =
            "https://api.twitter.com/1/statuses/public_timeline.json?count=10&include_entities=true";

        // Ctor
        public Twitter()
        {
            // Create the WebClient and associate a handler with the OpenReadCompleted event.
            wc = new WebClient();
            wc.OpenReadCompleted += wc_OpenReadCompleted;
        }

        public void RefreshTweets(Action<IEnumerable<Tweet>> updateTweets)
        {
            CallToWebService();
        }

        // Call the topic service at the Bing search site.

        private void CallToWebService()
        {
            // Call the OpenReadAsyc to make a get request, passing the url with the selected search string.
            wc.OpenReadAsync(new Uri(requestString));
        }

        private void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            string json = @"{
                              ""Name"": ""Apple"",
                              ""Expiry"": ""\/Date(1230375600000+1300)\/"",
                              ""Price"": 3.99,
                              ""Sizes"": [
                                ""Small"",
                                ""Medium"",
                                ""Large""
                              ]
                            }";

            var product = JsonConvert.DeserializeObject<Product>(json);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            CallToWebService();
        }

    }

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

}