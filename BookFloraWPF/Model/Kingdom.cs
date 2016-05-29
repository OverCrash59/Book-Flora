using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFloraWPF.Model
{
    public class Kingdom : ClassificationBase
    {
        private int _kingdomId;

        public int KingdomId
        {
            get
            {
                return _kingdomId;
            }

            set { Set(() => KingdomId, ref _kingdomId, value); }
        }

        public virtual List<Phylum> Phylums { get; set; }

        public static bool IsExist(string name)
        {
            using (var db = new FloraModel())
            {
                try
                {
                    db.Kingdoms.Single(k => k.Name == name);
                    return true;
                }
                catch (Exception)
                {
                    db.Kingdoms.Add(new Kingdom { Name = name });
                    db.SaveChanges();
                    return false;
                }
            }
        }

        public static bool IsExist(int id)
        {
            using (var db = new FloraModel())
            {
                return db.Kingdoms.Single(k => k.KingdomId == id) != null;
            }

        }

        public static Kingdom GetKingdom(string name)
        {
            using (var db = new FloraModel())
            {
                return db.Kingdoms.Single(k => k.Name == name);
            }
        }

        public static Kingdom GetKingdom(int id)
        {
            using (var db = new FloraModel())
            {
                return db.Kingdoms.Single(k => k.KingdomId == id);
            }
        }

        public static void SaveKingdom(Kingdom kingdom)
        {
            using (var db = new FloraModel())
            {
                db.Kingdoms.AddOrUpdate(kingdom);
                db.SaveChanges();
            }
        }
    }
}
