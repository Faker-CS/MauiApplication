using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public class VMCalcul : ObservableObject
    {
        private IRelayCommand GoHomeCommand {  get; set; }

        public VMCalcul()
        {
            GoHomeCommand = new AsyncRelayCommand(GoHome);
        }
        private async Task GoHome()
        {
            await Shell.Current.GoToAsync("//HomePage");

        }
    }
}
