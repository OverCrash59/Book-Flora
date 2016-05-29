using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFloraWPF.Model
{
    public class Family : ClassificationBase
    {
        private int _familyId;

        public int FamilyId
        {
            get
            {
                return _familyId;
            }

            set { Set(() => FamilyId, ref _familyId, value); }
        }

        public virtual List<Genus> Genera { get; set; }
        public virtual Order Order { get; set; }
        public int OrderForeignKey { get; set; }

        public static bool IsExist(string name)
        {
            using (var db = new FloraModel())
            {
                try
                {
                    db.Families.Single(p => p.Name == name);
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
                return db.Families.Single(p => p.FamilyId == id) != null;
            }
        }

        public static Family GetFamily(string name)
        {
            using (var db = new FloraModel())
            {
                return db.Families.Single(p => p.Name == name);
            }
        }

        public static Family GetFamily(int id)
        {
            using (var db = new FloraModel())
            {
                return db.Families.Single(p => p.FamilyId == id);
            }
        }

        public static void Save(Family family)
        {
            using (var db = new FloraModel())
            {
                db.Families.AddOrUpdate(family);
                db.SaveChanges();
            }
        }
    }
}
