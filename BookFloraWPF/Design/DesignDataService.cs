using System;
using System.Collections.Generic;
using BookFloraWPF.Model;

namespace BookFloraWPF.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<List<TileSpecies>, Exception> callback)
        {
            // Use this to create design time data
            var t = new TileSpecies {CommonName = "Ficus Ginseng", Binomial = "Ficus retusa"};
            var lt = new List<TileSpecies>();
            lt.Add(t);
            callback(lt, null);
        }

        public SpeciesSelected GetSpecies(string query)
        {
            throw new NotImplementedException();
        }

        public SpeciesSelected GetSpeciesByWiki(string adresse)
        {
            throw new NotImplementedException();
        }

        public Uri GetUriWiki(string query)
        {
            throw new NotImplementedException();
        }

        public void Save(SpeciesSelected speciesSelected)
        {
            throw new NotImplementedException();
        }
    }
}