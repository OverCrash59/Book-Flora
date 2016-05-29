using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace BookFloraWPF.Model
{
    public class Genus : ClassificationBase
    {
        private int _genusId;

        public int GenusId
        {
            get
            {
                return _genusId;
            }

            set { Set(() => GenusId, ref _genusId, value); }
        }

        public virtual List<Species> Specieses { get; set; }
        public virtual Family Family { get; set; }
        public int FamilyForeignKey { get; set; }

        public static bool IsExist(string name)
        {
            using (var db = new FloraModel())
            {
                try
                {
                    db.Genera.Single(p => p.Name == name);
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
                return db.Genera.Single(p => p.GenusId == id) != null;
            }
        }

        public static Genus GetGenus(string name)
        {
            using (var db = new FloraModel())
            {
                return db.Genera.Single(p => p.Name == name);
            }
        }

        public static Genus GetGenus(int id)
        {
            using (var db = new FloraModel())
            {
                return db.Genera.Single(p => p.GenusId == id);
            }
        }

        public static void Save(Genus genus)
        {
            using (var db = new FloraModel())
            {
                db.Genera.AddOrUpdate(genus);
                db.SaveChanges();
            }
        }
    }
}
