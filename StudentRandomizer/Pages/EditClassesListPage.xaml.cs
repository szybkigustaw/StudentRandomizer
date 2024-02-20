using CommunityToolkit.Maui.Views;
using StudentRandomizer.ViewModels;
using StudentRandomizer.Popups;

namespace StudentRandomizer.Pages;

public partial class EditClassesListPage : ContentPage
{
	private AddClassPopup addClassPopup;
	public EditClassesListPage(AddClassPopup addClassPopup, ClassesViewModel model)
	{
		InitializeComponent();
		this.addClassPopup = addClassPopup;
		this.BindingContext = model;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await this.Navigation.PushModalAsync(addClassPopup);
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("///MainPage");
    }
}