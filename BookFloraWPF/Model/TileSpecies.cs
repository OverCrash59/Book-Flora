using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace BookFloraWPF.Model
{
    public class TileSpecies : ObservableObject
    {
        private int _speciesId;
        private int _photoId;
        private string _commonName;
        private string _binomial;
        private string _photoUrl;

        public int SpeciesId
        {
            get
            {
                return _speciesId;
            }

            set { Set(() => SpeciesId, ref _speciesId, value); }
        }

        public int PhotoId
        {
            get
            {
                return _photoId;
            }

            set
            {
                Set(()=>PhotoId, ref _photoId, value);
            }
        }

        public string CommonName
        {
            get
            {
                return _commonName;
            }

            set { Set(() => CommonName, ref _commonName, value); }
        }

        public string Binomial
        {
            get
            {
                return _binomial;
            }

            set { Set(() => Binomial, ref _binomial, value); }
        }

        public string PhotoUrl
        {
            get
            {
                return _photoUrl;
            }

            set { Set(() => PhotoUrl, ref _photoUrl, value); }
        }
    }
}
