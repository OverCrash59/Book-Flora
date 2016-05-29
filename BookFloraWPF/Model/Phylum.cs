using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFloraWPF.Model
{
    public class Phylum : ClassificationBase
    {
        private int _phylumId;

        public int PhylumId
        {
            get
            {
                return _phylumId;
            }

            set { Set(() => PhylumId, ref _phylumId, value); }
        }

        public virtual List<Classe> Classes { get; set; }
        public virtual Kingdom Kingdom { get; set; }
        public int KingdomForeignKey { get; set; }

        public static bool IsExist(string name)
        {
            using (var db = new FloraModel())
            {
                try
                {
                    db.Phylums.Single(p => p.Name == name);
                    return true;
                }
                catch (InvalidOperationException)
                {
                    return false;
                }

            }
        }

        public static bool IsExist(int id)
        {
            using (var db = new FloraModel())
            {
                return db.Phylums.Single(p => p.PhylumId == id) != null;
            }
        }

        public static Phylum GetPhylum(string name)
        {
            using (var db = new FloraModel())
            {
                return db.Phylums.Single(p => p.Name == name);
            }
        }

        public static Phylum GetPhylum(int id)
        {
            using (var db = new FloraModel())
            {
                return db.Phylums.Single(p => p.PhylumId == id);
            }
        }

        public static void Save(Phylum phylum)
        {
            using (var db = new FloraModel())
            {
                db.Phylums.AddOrUpdate(phylum);
                db.SaveChanges();
            }
        }
    }
}
