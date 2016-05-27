using System;
using System.Collections.Generic;
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
    }
}
