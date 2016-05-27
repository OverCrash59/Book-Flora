using System;
using System.Collections.Generic;
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
    }
}
