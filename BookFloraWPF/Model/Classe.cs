using System;
using System.Collections.Generic;
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
    }
}
