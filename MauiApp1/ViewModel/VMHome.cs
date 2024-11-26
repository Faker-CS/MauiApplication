using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.ViewModel
{
    public class VMHome : ObservableObject
    {
        public IRelayCommand GoPageCommand { get; set; }
        public IRelayCommand GoPageWeather { get; set; }

        public VMHome()
        {
            GoPageCommand = new AsyncRelayCommand(GoPage);
            GoPageWeather = new AsyncRelayCommand(GoWeather);
        }

        private async Task GoPage()
        {
            await Shell.Current.GoToAsync("//CalculPage");
            
        }
        private async Task GoWeather()
        {
            await Shell.Current.GoToAsync("//weatherPage");

        }
    }
}
