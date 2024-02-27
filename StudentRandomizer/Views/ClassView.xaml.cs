using StudentRandomizer.Popups;
using StudentRandomizer.ViewModels;

namespace StudentRandomizer.Views;

public partial class ClassView : ContentView
{
	public static BindableProperty ClassNameProperty = BindableProperty.Create(
			nameof(ClassName),
			typeof(string),
			typeof(ClassView), null);

	public string ClassName { get => (string)GetValue(ClassNameProperty); set => SetValue(ClassNameProperty, value); }

	public ClassView()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		var navigationParameter = new Dictionary<string, object>
		{
			{"classname", ClassName }
		};

		await Shell.Current.GoToAsync($"///EditClass", navigationParameter);
    }
}