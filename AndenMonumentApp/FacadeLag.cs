using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using AndenMonumentApp.Model;
using Newtonsoft.Json;

namespace AndenMonumentApp
{
    class FacadeLag<T>
    {

        public static void GemDB(string api, object objekt)
        {
            HjaelpeKlasse.Client.PostAsJsonAsync(api + "/", objekt);
        }

        public static async Task<List<T>> LoadDB(string api)
        {
            var response = HjaelpeKlasse.Client.GetAsync(api).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<IEnumerable<T>>().Result.ToList();
            }
            return null;
        }

        //const string ServerUrl = "http://100metergruppen.database.windows.net";
        //HttpClientHandler handler;

        //public FacadeLag()
        //{
        //    handler = new HttpClientHandler();
        //    handler.UseDefaultCredentials = true;
        //}

        //public IEnumerable<Monument> GetMonumenter()
        //{
        //    using (var client = new HttpClient(handler))
        //    {
        //        client.BaseAddress = new Uri(ServerUrl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        try
        //        {
        //            var response = client.GetAsync("api/Monumenter").Result;

        //            if (response.IsSuccessStatusCode)
        //            {
        //                string monumentListJson = response.Content.ReadAsStringAsync().Result;
        //                IEnumerable<Monument> monumentList =
        //                    JsonConvert.DeserializeObject<IEnumerable<Monument>>(monumentListJson);
        //                return monumentList;
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            new MessageDialog(ex.Message);
        //        }
        //        return null;

        //    }

        //}

        //public void SaveMonument(Monument monument)
        //{
        //    using (var client = new HttpClient(handler))
        //    {
        //        client.BaseAddress = new Uri("100metergruppen.database.windows.net");
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        try
        //        {
        //            string postBody = JsonConvert.SerializeObject(monument);
        //            var response =
        //                client.PostAsync("api/Monumenter",
        //                    new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
        //        }
        //        catch (Exception)
        //        {
        //            //new MessageDialog(ex.Message).ShowAsync();
        //        }
        //    }

        //}
    }
}
