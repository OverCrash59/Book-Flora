using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace BookFloraWPF.Helpers
{
    public class NavigationService : INavigationService
    {
        private NavigationWindow _mainFrame;
        public void GoBack()
        {
            if (EnsureMainFrame() && _mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }
        }

        public void NavigateTo(Uri uri)
        {
            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(uri);
            }
        }

        private bool EnsureMainFrame()
        {
            if (_mainFrame != null)
            {
                return true;
            }

            _mainFrame = Application.Current.MainWindow as NavigationWindow;
            return _mainFrame != null;
        }
    }
}
