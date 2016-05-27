using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

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
    }
}
