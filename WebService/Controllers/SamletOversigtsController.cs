using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebService;

namespace WebService.Controllers
{
    public class SamletOversigtsController : ApiController
    {
        private MonumentContext db = new MonumentContext();

      

        // GET: api/SamletOversigts/5
        [ResponseType(typeof(MonumentOversigt))]
        public List<object> GetMonumentOversigt(int id)
        {
            PostNrTabel postNrTabel = db.PostNrTabel.Find(id);
            MonumentOversigt monumentOversigt = db.MonumentOversigt.Find(id);
            PlaceringsTyper placeringsTyper = db.PlaceringsTyper.Find(id);
            MonumentTyper monumentTyper = db.MonumentTyper.Find(id);
            MaterialeTyper materialeTyper = db.MaterialeTyper.Find(id);


            // Alle tabeller skal i rækkefølge her, så de bliver samlet med alle de 
            //informationer de har
            List<object> objects = new List<object>(10)
            {
                postNrTabel,
                monumentOversigt,
                placeringsTyper,
                monumentTyper,
                materialeTyper
            };


            return objects;
        }

        
    }
}