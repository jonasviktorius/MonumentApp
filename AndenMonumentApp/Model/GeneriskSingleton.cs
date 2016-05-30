using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndenMonumentApp.Model
{
    public class GeneriskSingleton<T>
    {
        private static GeneriskSingleton<T> _instance;
        private ObservableCollection<T> _collection;
        private GeneriskSingleton()
        {
            _collection = new ObservableCollection<T>();
            LoadGenerisk();
        }

        /// <summary>
        /// Collection Property
        /// </summary>
        public ObservableCollection<T> Collection
        {
            get { return _collection; }
            set { _collection = value; }
        }

        /// <summary>
        /// Instance metoden der definere singleton
        /// </summary>
        /// <returns>
        /// _instance som er et objekt af GeneriskSingleton
        /// </returns>
        public static GeneriskSingleton<T> Instance()
        {
            if (_instance == null)
            {
                _instance = new GeneriskSingleton<T>();
            }
            return _instance;
        }
        /// <summary>
        /// Generisk load-metode
        /// </summary>
        public void LoadGenerisk()
        {
            var query = FacadeLag<T>.LoadDB("api/" + typeof(T).Name + "s").Result;
            foreach (var item in query)
            {
                Collection.Add(item);
            }
        }
    }
}