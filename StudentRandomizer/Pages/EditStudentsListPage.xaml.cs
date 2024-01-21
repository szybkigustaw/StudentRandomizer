using StudentRandomizer.ViewModels;

namespace StudentRandomizer.Pages;

public partial class EditStudentsListPage : ContentPage
{
	private StudentsViewModel _viewmodel;
	public EditStudentsListPage()
	{
		InitializeComponent();
		_viewmodel = this.Handler.MauiContext.Services.GetService<StudentsViewModel>();
		this.BindingContext = _viewmodel;
	}
}