using MauiApp1.ViewModel;

namespace MauiApp1.View;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        BindingContext = new VMHome();
    }
}