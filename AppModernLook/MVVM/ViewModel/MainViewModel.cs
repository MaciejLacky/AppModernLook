using AppModernLook.Core;
using AppModernLook.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModernLook.MVVM.ViewModel
{
    internal class MainViewModel: ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public RelayCommand FeaturesViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public DiscoverViewModel DiscoverVM { get; set; }
        public FeaturesViewModel FeaturesVM { get; set; }

        private object _currentView;
        public object CurrentView 
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value; 
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            DiscoverVM = new DiscoverViewModel();
            FeaturesVM = new FeaturesViewModel();
            CurrentView = HomeVM;
            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });
            DiscoveryViewCommand = new RelayCommand(o =>
            {
                CurrentView = DiscoverVM;
            });
            FeaturesViewCommand = new RelayCommand(o =>
            {
                CurrentView = FeaturesVM;
            });
        }
    }
}
