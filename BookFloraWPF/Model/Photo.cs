using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFloraWPF.Model
{
    public class Photo : ClassificationBase
    {
        private int _photoId;

        public int PhotoId
        {
            get
            {
                return _photoId;
            }

            set { Set(() => PhotoId, ref _photoId, value); }
        }

        public virtual Species Species { get; set; }
        public int SpeciesForeignKey { get; set; }

        public static bool IsExist(string name)
        {
            using (var db = new FloraModel())
            {
                try
                {
                    db.Photos.Single(p => p.Name == name);
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
                return db.Photos.Single(p => p.PhotoId == id) != null;
            }
        }

        public static Photo GetPhoto(string name)
        {
            using (var db = new FloraModel())
            {
                return db.Photos.Single(p => p.Name == name);
            }
        }

        public static Photo GetPhoto(int id)
        {
            using (var db = new FloraModel())
            {
                return db.Photos.Single(p => p.PhotoId == id);
            }
        }

        public static void Save(Photo photo)
        {
            using (var db = new FloraModel())
            {
                db.Photos.AddOrUpdate(photo);
                db.SaveChanges();
            }
        }
    }
}
