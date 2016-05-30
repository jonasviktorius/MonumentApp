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
using MonumentApp.Model.Binding;
using Newtonsoft.Json;

namespace MonumentApp.Persistency
{
    public class FacadeLag
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
                try
                {
                    var response = client.GetAsync("api/MonumentOversigts").Result;

                if (response.IsSuccessStatusCode)
                {
                    string monumentListJson = response.Content.ReadAsStringAsync().Result;
                    IEnumerable<MonumentOversigt> monumentList =
                        JsonConvert.DeserializeObject<IEnumerable<MonumentOversigt>>(monumentListJson);
                    return monumentList;
                }

            }
                catch (Exception ex)
            {
                new MessageDialog(ex.Message + "Der skete en fejl da monumenterne skulle vises");
            }
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
                    StaticObjects.SelectedPostNr = (PostNrTabel)list[0];
                    StaticObjects.SelectedMonumenter = (MonumentOversigt)list[1];
                    StaticObjects.SelectedPlaceringsTyper = (PlaceringsTyper)list[2];
                    StaticObjects.SelectedMonumentTyper = (MonumentTyper)list[3];
                    StaticObjects.SelectedMaterialeTyper = (MaterialeTyper)list[4];
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

                    new MessageDialog(ex.Message + "Der skete en fejl, da monumentet skulle gemmes").ShowAsync();
                }
            }
        }

        public void SaveMonumentv2(MonumentOversigt monumentOversigt, PlaceringsTyper placeringsTyper, MonumentTyper monumentTyper, MaterialeTyper materialeTyper)
        {
            var monumentBinding = new MonumentBinding
            {
                Adresse = monumentOversigt.Adresse,
                Bevaringsværdi = monumentOversigt.Bevaringsværdi,
                Bygning = placeringsTyper.Bygning,
                Jord = placeringsTyper.Jord,
                Facade = placeringsTyper.Facade,
                Navn = monumentOversigt.Navn,
                Note = monumentOversigt.Note,
                PostNr = monumentOversigt.PostNr,
                Skulptur = monumentTyper.Skulptur,
                Sokkel = monumentTyper.Sokkel,
                Relief = monumentTyper.Relief,
                Vandkunst = monumentTyper.Vandkunst,
                // materialetype af sten
                Granit = materialeTyper.Granit,
                Marmor = materialeTyper.Marmor,
                Sandsten = materialeTyper.Sandsten,
                Kalksten = materialeTyper.Kalksten,
                // materialetype af metal
                Bronze = materialeTyper.Bronze,
                Cortenstål = materialeTyper.Cortenstål,
                BemaletStål = materialeTyper.BemaletStål,
                Aluminium = materialeTyper.Aluminium,
                Jern = materialeTyper.Jern,
                AndetMetal = materialeTyper.AndetMetal,
                // andet materialetype
                Trae = materialeTyper.Trae,
                Tegl = materialeTyper.Tegl,
                Beton = materialeTyper.Beton,
                AndetMateriale = materialeTyper.AndetMateriale

            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(monumentBinding);
                    var response =
                        client.PostAsync("api/v2/opretmonument",
                            new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message + "Der skete en fejl, da monumentet skulle gemmes").ShowAsync();
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
                try
                {
                    var response = client.GetAsync("api/MonumentOversigts/" + id).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string monumentListJson = response.Content.ReadAsStringAsync().Result;
                        MonumentOversigt monumentList =
                            JsonConvert.DeserializeObject<MonumentOversigt>(monumentListJson);
                        return monumentList;
                    }

                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message + "Der var fejl ved at hente monumenterne");
                }
                return null;
            }
        }
        public void SavePlacering(PlaceringsTyper selectedPlaceringsTyper)
        {
            using (var c = new HttpClient())
            {
                c.BaseAddress = new Uri(ServerUrl);
                string postBody = JsonConvert.SerializeObject(selectedPlaceringsTyper);
                var response =
                        c.PostAsync("api/PostPlaceringsTyper2",
                            new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
            }


            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(selectedPlaceringsTyper);
                    var response =
                        client.PostAsync("api/PostPlaceringsTyper2",
                            new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message + "Der skete en fejl, da placeringen skulle gemmes").ShowAsync();
                }
            }
        }

        public void SaveMonumentTyper(MonumentTyper selectedMonumentTyper)
        {
            {
                using (var c = new HttpClient())
                {
                    c.BaseAddress = new Uri(ServerUrl);
                    string postBody = JsonConvert.SerializeObject(selectedMonumentTyper);
                    var response =
                        c.PostAsync("api/PostMonumentTyper2",
                            new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                }
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(ServerUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    try
                    {
                        string postBody = JsonConvert.SerializeObject(selectedMonumentTyper);
                        var response =
                            client.PostAsync("api/PostMonumentTyper2",
                                new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                    }
                    catch (Exception ex)
                    {

                        new MessageDialog(ex.Message + "Der skete en fejl, da typen skulle gemmes").ShowAsync();
                    }
                }
            }
        }

        public void SaveMaterialeTyper(MaterialeTyper selectedMaterialeTyper)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(selectedMaterialeTyper);
                    var response =
                        client.PostAsync("api/MaterialeTyper",
                            new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message + "Der skete en fejl, da materiale typerne skulle gemmes").ShowAsync();
                }
            }
        }

        public void GemSkade(MonumentOversigt monumentOversigt, SkadeOversigt skadeOversigt)
        {
            var monumentBinding = new MonumentBinding
            {
               Navn = monumentOversigt.Navn,
               Adresse =  monumentOversigt.Adresse,
               PostNr =  monumentOversigt.PostNr,
               Bevaringsværdi = monumentOversigt.Bevaringsværdi,
               

            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(monumentBinding);
                    var response =
                        client.PostAsync("api/v2/opretskade",
                            new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message + "Der skete en fejl, da skaden skulle gemmes").ShowAsync();
                }
            }
        }

    }

}