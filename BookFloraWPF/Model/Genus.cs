using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace BookFloraWPF.Model
{
    public class Genus : ClassificationBase
    {
        private int _genusId;

        public int GenusId
        {
            get
            {
                return _genusId;
            }

            set { Set(() => GenusId, ref _genusId, value); }
        }

        public virtual List<Species> Specieses { get; set; }
        public virtual Family Family { get; set; }
        public int FamilyForeignKey { get; set; }
    }
}
