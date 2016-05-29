using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFloraWPF.Helpers
{
    public interface INavigationService
    {
        void GoBack();
        void NavigateTo(Uri uri);
    }
}
