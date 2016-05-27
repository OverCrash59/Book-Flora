using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace BookFloraWPF.Model
{
    public abstract class ClassificationBase : ObservableObject
    {
        private string _name;
        private string _url;
        private bool _isDirty;

        public string Name
        {
            get
            {
                return _name;
            }

            set { Set(() => Name, ref _name, value); }
        }

        public string Url
        {
            get
            {
                return _url;
            }

            set { Set(() => Url, ref _url, value); }
        }

        public bool IsDirty
        {
            get
            {
                return _isDirty;
            }

            set { Set(() => IsDirty, ref _isDirty, value); }
        }
    }
}
