using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MonumentApp.Model;

namespace MonumentApp.Persistency
{
    class FacadeLag
    {
        const string ServerUrl = "http://100metergruppen.database.windows.net";
        HttpClientHandler handler;

        public FacadeLag()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }

        public IEnumerable<Monument> GetMonumenter()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Monumenter").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var monumentList = response.Content.ReadAsAsync<IEnumerable<Monument>>().Result;
                        return monumentList.toList();
                    }

                }

            }
        }
    }
}
