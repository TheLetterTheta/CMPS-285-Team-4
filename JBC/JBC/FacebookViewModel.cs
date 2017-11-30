using Android.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JBC
{
    public class FacebookViewModel : INotifyPropertyChanged
    {/*
        public event PropertyChangedEventHandler PropertyChanged;
        private const string Url = "https://graph.facebook.com/jbcpumkincenter?fields=feed.limit(5){message,picture}&key=value&access_token=119750732037000|8d7508c4f936eb4d70f1e198f194a21f";
        
        private ObservableCollection<Data> _accountItems;
        //public ObservableCollection<Data> AccountItems { get; } = new ObservableCollection<Data>();
        public ObservableCollection<Data> AccountItems
        {
            get { return _accountItems; }
            set
            {
                _accountItems = value;
                OnPropertyChanged();
            }
        }
        
        public async Task GetAccountItemsAsync()
        {
            //var postId = new ObservableCollection<string>();
            try
            {
                var client = new HttpClient();
                var json = await client.GetStringAsync(Url);
                
                var response = JsonConvert.DeserializeObject<List<Data>>(json);
                var items = response.Feed.Data;
                //_accountItems = new ObservableCollection<Data>(response);
                //itemsListView.ItemsSource = _accountItems;

                foreach (var item in _accountItems)

                    /*
                    var fbItem = new Data
                    {
                        Message = item.Message
                        //postId.Add(item.Value<string>("picture"));
                        //postId.Add(item.Value<JObject>("data")?.Value<string>("id"));
                        //FacebookItems = await GetDataDetailsAsync(postId);
                    };
                    *//*
                    AccountItems.Add(item);
                    
                
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            
        }
        

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
     */


        private string Url = "https://graph.facebook.com/jbcpumkincenter?fields=feed.limit(10)%7Bmessage,picture,created_time%7D&key=value&access_token=119750732037000%7C8d7508c4f936eb4d70f1e198f194a21f";

        private List<Data> _facebookItems;

        public List<Data> FacebookItems
        {
            get { return _facebookItems; }
            set
            {
                if (value != null)
                {
                    _facebookItems = value;
                    OnPropertyChanged();
                }
            }
        }

        public FacebookViewModel()
        {
            InitDataAsync();

        }

        public async Task InitDataAsync()
        {

            FacebookItems = await GetPostIdsAsync();

            //var videoIds = await GetVideoIdsFromPlaylistAsync();
        }


        /*
        private async Task<List<string>> GetPostIdsAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(Url);

            var postId = new List<string>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                JObject response2 = response.Value<JObject>("feed");

                var items = response2.Value<JArray>("data");

                foreach (var item in items)
                {
                    postId.Add(item.Value<string>("message"));
                    //postId.Add(item.Value<JObject>("data")?.Value<string>("id"));
                }

               // FacebookItems = await GetDataDetailsAsync(postId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return postId;
        }
        */

        private async Task<List<Data>> GetPostIdsAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(Url);

            var postId = new List<Data>();

            try
            {
                var response = JsonConvert.DeserializeObject<RootObject>(json);
                var items = response.Feed.Data;
                foreach (var item in items)
                {
                    if (item.Message != null)
                    {
                        /*
                        var message = item.Message;
                        var picture = item.Picture;
                        var created_time = GetNewString(item.Created_Time);
                        */
                        var fbItem = new Data
                        {

                            Message = item.Message,
                            Picture = item.Picture,
                            Created_Time = GetNewString(item.Created_Time),
                            
                        };

                        postId.Add(fbItem);
                     
                    };
                };
                //FacebookItems = await GetDataDetailsAsync(postId);

                /*

                JObject response2 = response.Value<JObject>("feed");

                var items = response2.Value<JArray>("data");

                foreach (var item in items)
                {
                    var fbItem = new RootObject
                    {
                        Message = item.Value<string>("message"),
                        //postId.Add(item.Value<string>("picture"));
                        //postId.Add(item.Value<JObject>("data")?.Value<string>("id"));
                        //FacebookItems = await GetDataDetailsAsync(postId);
                    };
                    postId.Add(fbItem);
                }*/
                //return postId;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return postId;
        }
        /*
        private async Task<List<RootObject>> GetDataDetailsAsync(List<string> postId)
        {

            var postIdsString = "";
            foreach (var s in postId)
            {
                postIdsString += s + ",";
            }
            var facebookItems = new List<RootObject>();
            try
            {
                var items = postIdsString;
                foreach (var item in items)
                {
                    var fbItem = new Data
                    {
                        Message = item.Message
                       // Message = item.Value<string>("message"),
                        //postId.Add(item.Value<string>("picture"));
                        //postId.Add(item.Value<JObject>("data")?.Value<string>("id"));
                        //FacebookItems = await GetDataDetailsAsync(postId);
                    };
                    return facebookItems;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return facebookItems;
        }
        */

        // The example displays the following output:
        //       is
        private string GetNewString(string s)         
        {
            String value = s;
            int startIndex = 5;
            int length = 5;
            String substring = value.Substring(startIndex, length);
            String datestring = "Date Posted: " + substring;
            return datestring;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


