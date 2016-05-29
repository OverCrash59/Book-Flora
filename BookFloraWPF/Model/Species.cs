using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.Linq;
using GalaSoft.MvvmLight;

namespace BookFloraWPF.Model
{
    /// <summary>
    /// Flore's species
    /// </summary>
    public class Species : ObservableObject
    {
        private int _speciesId;
        private string _commonName;
        private string _binomialName;
        private string _urlWiki;
        private string _description;
        private string _flower;
        private string _leaf;
        private string _fruit;
        private string _laugh;
        private string _use;
        private string _annotation;
        private bool _isDirty;

        [Key]
        public int SpeciesId
        {
            get
            {
                return _speciesId;
            }

            set
            {
                if (Set(() => SpeciesId, ref _speciesId, value))
                {
                    IsDirty = true;
                }
            }
        }

        public string CommonName
        {
            get
            {
                return _commonName;
            }

            set {
                if (Set(() => CommonName, ref _commonName, value))
                {
                    IsDirty = true;
                }
            }
        }

        public string BinomialName
        {
            get
            {
                return _binomialName;
            }

            set
            {
                if (Set(() => BinomialName, ref _binomialName, value))
                {
                    IsDirty = true;
                }
            }
        }

        public string UrlWiki
        {
            get
            {
                return _urlWiki;
            }

            set
            {
                if (Set(() => UrlWiki, ref _urlWiki, value))
                {
                    IsDirty = true;
                }
            }
        }

        public string Flower
        {
            get
            {
                return _flower;
            }

            set
            {
                if (Set(() => Flower, ref _flower, value))
                {
                    IsDirty = true;
                }
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set { Set(() => Description, ref _description, value); }
        }

        public string Leaf
        {
            get
            {
                return _leaf;
            }

            set { Set(() => Leaf, ref _leaf, value); }
        }

        public string Fruit
        {
            get
            {
                return _fruit;
            }

            set { Set(() => Fruit, ref _fruit, value); }
        }

        public string Laugh
        {
            get
            {
                return _laugh;
            }

            set { Set(() => Laugh, ref _laugh, value); }
        }

        public string Use
        {
            get
            {
                return _use;
            }

            set { Set(() => Use, ref _use, value); }
        }

        public string Annotation
        {
            get
            {
                return _annotation;
            }

            set { Set(() => Annotation, ref _annotation, value); }
        }

        public virtual List<Photo> Photos { get; set; }
        public virtual Genus Genus { get; set; }
        public int GenusForeignKey { get; set; }

        
        public bool IsDirty
        {
            get
            {
                return _isDirty;
            }

            set { Set(() => IsDirty, ref _isDirty, value); }
        }

        public static bool IsExist(string name)
        {
            using (var db = new FloraModel())
            {
                try
                {
                    db.Specieses.Single(p => p.BinomialName == name);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool IsExist(int id)
        {
            using (var db = new FloraModel())
            {
                return db.Specieses.Single(p => p.SpeciesId == id) != null;
            }
        }

        public static Species GetSpecies(string name)
        {
            using (var db = new FloraModel())
            {
                return db.Specieses.Single(p => p.BinomialName == name);
            }
        }

        public static Species GetSpecies(int id)
        {
            using (var db = new FloraModel())
            {
                return db.Specieses.Single(p => p.SpeciesId == id);
            }
        }

        public static void Save(Species species)
        {
            using (var db = new FloraModel())
            {
                db.Specieses.AddOrUpdate(species);
                db.SaveChanges();
            }
        }
    }
}
