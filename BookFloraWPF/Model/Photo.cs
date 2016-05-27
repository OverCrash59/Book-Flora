using System;
using System.Collections.Generic;
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
    }
}
