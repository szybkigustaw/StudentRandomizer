using StudentRandomizer.ViewModels;

namespace StudentRandomizer.Pages;

public partial class RollStudentsPage : ContentPage
{
	public RollStudentsPage(RollStudentsPageViewModel viewmodel)
	{
		InitializeComponent();
		this.BindingContext = viewmodel;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("///RandomizerPage");
    }
}