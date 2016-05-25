using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AndenMonumentApp.Model
{
   public class HjaelpeKlasse
   {
       private static HttpClient client;

       public static HttpClient Client
       {
           get { return client; }
       }

       public HjaelpeKlasse()
       {
           
       }

       public static void Forbindelse()
       {
           try
           {
               const string serverUrl = "http://100metergruppen.database.windows.net";
               HttpClientHandler handler = new HttpClientHandler();
               handler.UseDefaultCredentials = true;
               client = new HttpClient(handler);
               client.BaseAddress = new Uri(serverUrl);
               client.DefaultRequestHeaders.Clear();
               client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           }
           catch (Exception)
           {
               
           }
       }
   }
}
