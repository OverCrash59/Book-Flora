using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Data.Entity.Migrations;

namespace BookFloraWPF.Model
{
    public class Order : ClassificationBase
    {
        private int _orderId;

        public int OrderId
        {
            get
            {
                return _orderId;
            }

            set { Set(() => OrderId, ref _orderId, value); }
        }

        public virtual List<Family> Families { get; set; }
        public virtual Classe Classe { get; set; }
        public int ClasseForeignKey { get; set; }

        public static bool IsExist(string name)
        {
            using (var db = new FloraModel())
            {
                try
                {
                    db.Orders.Single(p => p.Name == name);
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
                return db.Orders.Single(p => p.OrderId == id) != null;
            }
        }

        public static Order GetOrder(string name)
        {
            using (var db = new FloraModel())
            {
                return db.Orders.Single(p => p.Name == name);
            }
        }

        public static Order GetOrder(int id)
        {
            using (var db = new FloraModel())
            {
                return db.Orders.Single(p => p.OrderId == id);
            }
        }

        public static void Save(Order order)
        {
            using (var db = new FloraModel())
            {
                db.Orders.AddOrUpdate(order);
                db.SaveChanges();
            }
        }
    }
}
