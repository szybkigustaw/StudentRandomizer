namespace StudentRandomizer.Views;

public partial class StudentView : ContentView
{
	public static readonly BindableProperty StudentFirstNameProperty = BindableProperty.Create(
		nameof(StudentFirstName),
		typeof(string),
		typeof(StudentView)
		);

	public static readonly BindableProperty StudentLastNameProperty = BindableProperty.Create(
		nameof(StudentLastName),
		typeof(string),
		typeof(StudentView)
		);

	public static readonly BindableProperty StudentClassNameProperty = BindableProperty.Create(
		nameof(StudentClassName),
		typeof(string),
		typeof(StudentView)
		);

	public static readonly BindableProperty StudentIsPresentProperty = BindableProperty.Create(
		nameof(StudentIsPresent),
		typeof(bool),
		typeof(StudentView)
		);

	public string StudentFirstName 
	{
		get => (string)GetValue(StudentFirstNameProperty);
		set => SetValue(StudentFirstNameProperty, value);
	}
	public string StudentLastName 
	{
		get => (string)GetValue(StudentLastNameProperty);
		set => SetValue(StudentLastNameProperty, value);
	}
	public string StudentClassName 
	{
		get => (string)GetValue(StudentClassNameProperty);
		set => SetValue(StudentClassNameProperty, value);
	}
	public bool StudentIsPresent 
	{
		get => (bool)GetValue(StudentIsPresentProperty);
		set => SetValue(StudentIsPresentProperty, value);
	}

	public string StudentFullName
	{
		get => String.Concat(StudentFirstName, " ", StudentLastName);
	}
	public StudentView()
	{
		InitializeComponent();
	}
}