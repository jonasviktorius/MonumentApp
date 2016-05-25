using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using MonumentApp.Model;
using Newtonsoft.Json;

namespace MonumentApp.Persistency
{
    class FacadeLag
    {
        const string ServerUrl = "http://localhost:16042/";
        HttpClientHandler handler;

        public FacadeLag()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }

        public IEnumerable<MonumentOversigt> GetMonumenter()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //try
                //{
                    var response = client.GetAsync("api/MonumentOversigts").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string monumentListJson = response.Content.ReadAsStringAsync().Result;
                        IEnumerable<MonumentOversigt> monumentList =
                            JsonConvert.DeserializeObject<IEnumerable<MonumentOversigt>>(monumentListJson);
                        return monumentList;
                    }

                //}
                //catch (Exception ex)
                //{
                //    new MessageDialog(ex.Message);
                //}
                return null;

            }

        }

        public void SamletOversigt(int id)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //try
                //{
                var response = client.GetAsync("api/SamletOversigts/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string monumentListJson = response.Content.ReadAsStringAsync().Result;
                    List<object> list =
                        JsonConvert.DeserializeObject<List<object>>(monumentListJson);
                    // Her skal de i rækkefølge som i den SamletOversigtsController er i, og ligges ind
                    // og bliver lagt ind i en liste på webservicen og her bliver de så taget ud igen.
                    // 
                    StaticObjects.SelectedMonumenter = (MonumentOversigt) list[0];



                }

               
            }

        }

        public void SaveMonument(MonumentOversigt monumentOversigt)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(monumentOversigt);
                    var response =
                        client.PostAsync("api/MonumentOversigts",
                            new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                }
                catch (Exception ex)
                {
                    //new MessageDialog(ex.Message).ShowAsync();
                }
            }

        }

        public MonumentOversigt HentMonument(int id)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //try
                //{
                var response = client.GetAsync("api/MonumentOversigts/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string monumentListJson = response.Content.ReadAsStringAsync().Result;
                    MonumentOversigt monumentList =
                        JsonConvert.DeserializeObject<MonumentOversigt>(monumentListJson);
                    return monumentList;
                }

                //}
                //catch (Exception ex)
                //{
                //    new MessageDialog(ex.Message);
                //}
                return null;

            }
        }

        public void SavePlacering(PlaceringsTyper selectedPlaceringsTyper)
        {
           
        }
    }
}