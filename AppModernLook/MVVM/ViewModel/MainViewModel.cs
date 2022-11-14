using AppModernLook.Core;
using AppModernLook.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppModernLook.MVVM.ViewModel
{
    internal class MainViewModel: ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public RelayCommand FeaturesViewCommand { get; set; }
        public RelayCommand CloseViewCommand { get; set; }
        public RelayCommand MinimalizeViewCommand { get; set; }
        public RelayCommand ResizeViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public DiscoverViewModel DiscoverVM { get; set; }
        public FeaturesViewModel FeaturesVM { get; set; }
        public object resized { get; set; }

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
            CloseViewCommand = new RelayCommand(o =>
            {
               ((Window)o).Close();
            });
            MinimalizeViewCommand = new RelayCommand(o =>
            {
                ((Window)o).WindowState = WindowState.Minimized;
            });
            ResizeViewCommand = new RelayCommand(o =>
            {
               ((Window)o).WindowState = CanResize(((Window)o).WindowState);
              
            });
        }

        private WindowState CanResize(WindowState windowState)
        {
            
            if (windowState == WindowState.Maximized) return WindowState.Normal;
            return WindowState.Maximized;

        }
    }
}
