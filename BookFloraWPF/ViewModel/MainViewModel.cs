using System;
using System.Collections.Generic;
using BookFloraWPF.Helpers;
using GalaSoft.MvvmLight;
using BookFloraWPF.Model;
using GalaSoft.MvvmLight.CommandWpf;

namespace BookFloraWPF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;

        private List<TileSpecies> _listTileSpecies;
        private SpeciesSelected _speciesSelected;
        private RelayCommand _searchCommand;

        public RelayCommand SearchCommand
        {
            get
            {
                return _searchCommand ??
                       (_searchCommand =
                           new RelayCommand(
                               () =>
                               {
                                   _navigationService.NavigateTo(new Uri("/View/SearchPage.xaml", UriKind.Relative));
                               }));
            }
        }

        public List<TileSpecies> ListTileSpecies
        {
            get
            {
                return _listTileSpecies;
            }

            set { Set(() => ListTileSpecies, ref _listTileSpecies, value); }
        }

        public SpeciesSelected SpeciesSelected
        {
            get
            {
                return _speciesSelected;
            }

            set { Set(() => SpeciesSelected, ref _speciesSelected, value); }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    ListTileSpecies = item;
                });
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}