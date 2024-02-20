using CommunityToolkit.Maui.Views;
using StudentRandomizer.ViewModels;

namespace StudentRandomizer.Popups;

public partial class AddClassPopup : ContentPage
{
	public AddClassPopup(AddClassPopupViewModel viewmodel)
	{
		InitializeComponent();
		this.BindingContext = viewmodel;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await this.Navigation.PopModalAsync();
    }
}