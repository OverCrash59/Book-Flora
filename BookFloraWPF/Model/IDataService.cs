using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookFloraWPF.Model
{
    public interface IDataService
    {
        void GetData(Action<List<TileSpecies>, Exception> callback);

        SpeciesSelected GetSpecies(string query);

        Uri GetUriWiki(string query);

        SpeciesSelected GetSpeciesByWiki(string adresse);

        void Save(SpeciesSelected speciesSelected);
    }
}
