using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace BookFloraWPF.Model
{
     public class SpeciesSelected : ObservableObject
     {
         private Species _species;
         private Photo _photo;
         private Genus _genus;
         private Family _family;
         private Order _order;
         private Classe _classe;
         private Phylum _phylum;
         private Kingdom _kingdom;

        public Species Species
        {
            get
            {
                return _species;
            }

            set { Set(() => Species, ref _species, value); }
        }

        public Photo Photo
        {
            get
            {
                return _photo;
            }

            set { Set(() => Photo, ref _photo, value); }
        }

        public Genus Genus
        {
            get
            {
                return _genus;
            }

            set { Set(() => Genus, ref _genus, value); }
        }

        public Family Family
        {
            get
            {
                return _family;
            }

            set { Set(() => Family, ref _family, value); }
        }

        public Order Order
        {
            get
            {
                return _order;
            }

            set { Set(() => Order, ref _order, value); }
        }

        public Classe Classe
        {
            get
            {
                return _classe;
            }

            set { Set(() => Classe, ref _classe, value); }
        }

        public Phylum Phylum
        {
            get
            {
                return _phylum;
            }

            set { Set(() => Phylum, ref _phylum, value); }
        }

        public Kingdom Kingdom
        {
            get
            {
                return _kingdom;
            }

            set { Set(() => Kingdom, ref _kingdom, value); }
        }
    }
}
