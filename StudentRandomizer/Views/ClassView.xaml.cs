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
}