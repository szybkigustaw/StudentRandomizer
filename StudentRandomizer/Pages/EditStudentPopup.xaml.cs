using CommunityToolkit.Maui.Views;
using StudentRandomizer.ViewModels;

namespace StudentRandomizer.Pages;

public partial class EditStudentPopup : ContentPage
{
	public EditStudentPopup(EditStudentPopupViewModel viewmodel)
	{
		InitializeComponent();
		this.BindingContext = viewmodel;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("///StudentsListPage");
    }
}