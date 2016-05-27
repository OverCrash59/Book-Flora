using System;
using System.Collections.Generic;
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
    }
}
