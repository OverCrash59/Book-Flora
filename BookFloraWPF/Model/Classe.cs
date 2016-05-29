using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFloraWPF.Model
{
    public class Classe : ClassificationBase
    {
        private int _classeId;

        public int ClasseId
        {
            get
            {
                return _classeId;
            }

            set { Set(() => ClasseId, ref _classeId, value); }
        }

        public virtual List<Order> Orders { get; set; }
        public virtual Phylum Phylum { get; set; }
        public int PhylumForeignKey { get; set; }

        public static bool IsExist(string name)
        {
            using (var db = new FloraModel())
            {
                try
                {
                    db.Classes.Single(p => p.Name == name);
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
                return db.Classes.Single(p => p.ClasseId == id) != null;
            }
        }

        public static Classe GetClasse(string name)
        {
            using (var db = new FloraModel())
            {
                return db.Classes.Single(p => p.Name == name);
            }
        }

        public static Classe GetClasse(int id)
        {
            using (var db = new FloraModel())
            {
                return db.Classes.Single(p => p.ClasseId == id);
            }
        }

        public static void Save(Classe classe)
        {
            using (var db = new FloraModel())
            {
                db.Classes.AddOrUpdate(classe);
                db.SaveChanges();
            }
        }
    }
}
