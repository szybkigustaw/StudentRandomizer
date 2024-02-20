using CommunityToolkit.Maui.Views;
using StudentRandomizer.ViewModels;
using StudentRandomizer.Popups;
using StudentRandomizer.Models.Collections;

namespace StudentRandomizer.Pages;

public partial class EditStudentsListPage : ContentPage
{
	public AddStudentPopup studentPopup;
	public EditStudentsListPage(StudentsViewModel viewmodel, AddStudentPopup studentPopup)
	{ 
		InitializeComponent();
		this.BindingContext = viewmodel;
		this.studentPopup = studentPopup;
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await this.Navigation.PushModalAsync(studentPopup);
	}

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("///MainPage");
    }
}