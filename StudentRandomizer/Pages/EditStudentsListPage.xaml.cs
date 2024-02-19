using StudentRandomizer.ViewModels;

namespace StudentRandomizer.Pages;

public partial class EditStudentsListPage : ContentPage
{
	public EditStudentsListPage(StudentsViewModel viewmodel)
	{ 
		InitializeComponent();
		this.BindingContext = viewmodel;
	}
}