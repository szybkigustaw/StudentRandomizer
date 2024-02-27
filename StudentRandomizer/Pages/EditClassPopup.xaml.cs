using CommunityToolkit.Maui.Views;
using StudentRandomizer.ViewModels;
using System.Diagnostics;

namespace StudentRandomizer.Pages;

public partial class EditClassPopup : ContentPage
{

	public EditClassPopup(EditClassPopupViewModel viewmodel)
	{
		InitializeComponent();
		this.BindingContext = viewmodel;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("///ClassesListPage");
    }
}