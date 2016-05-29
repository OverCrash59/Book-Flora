using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BookFloraWPF.Helpers;
using BookFloraWPF.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace BookFloraWPF.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;

        private SpeciesSelected _speciesSelected;
        private Visibility _webVisibility;
        private Visibility _sheetVisibility;

        private Uri _navigateUri;

        public RelayCommand<string> SearchOnWikiCommand { get; private set; }

        public RelayCommand<string> AddFromWikiCommand { get; private set; }

        public RelayCommand SaveToDbCommand => new RelayCommand(SaveToDb);

        private void SaveToDb()
        {
            _dataService.Save(SpeciesSelected);
            _navigationService.NavigateTo(new Uri("/View/DefaultPage.xaml", UriKind.Relative));
        }

        public SpeciesSelected SpeciesSelected
        {
            get
            {
                return _speciesSelected;
            }

            set { Set(() => SpeciesSelected, ref _speciesSelected, value); }
        }

        public Uri NavigateUri
        {
            get
            {
                return _navigateUri;
            }

            set { Set(() => NavigateUri, ref _navigateUri, value); }
        }

        public Visibility WebVisibility
        {
            get
            {
                return _webVisibility;
            }

            set { Set(() => WebVisibility, ref _webVisibility, value); }
        }

        public Visibility SheetVisibility
        {
            get
            {
                return _sheetVisibility;
            }

            set { Set(() => SheetVisibility, ref _sheetVisibility, value); }
        }

        public SearchViewModel(IDataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
            WebVisibility = Visibility.Hidden;
            SheetVisibility = Visibility.Hidden;
            SearchOnWikiCommand = new RelayCommand<string>(SearchOnWiki);
            AddFromWikiCommand = new RelayCommand<string>(AddFromWiki);
        }

        private void AddFromWiki(string parameter)
        {
            SpeciesSelected = _dataService.GetSpeciesByWiki(parameter);
            WebVisibility = Visibility.Hidden;
            SheetVisibility = Visibility.Visible;
        }

        private void SearchOnWiki(string parameter)
        {
            if ((SpeciesSelected = _dataService.GetSpecies(parameter)) == null)
            {
                NavigateUri = _dataService.GetUriWiki(parameter);
                Messenger.Default.Send(NavigateUri);
                WebVisibility = Visibility.Visible;
                SheetVisibility = Visibility.Hidden;
            }
            else
            {
                SheetVisibility = Visibility.Visible;
                WebVisibility = Visibility.Hidden;
            }
        }

    }
}
