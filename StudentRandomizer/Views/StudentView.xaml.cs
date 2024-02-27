using StudentRandomizer.Models.Collections;
using StudentRandomizer.Popups;

namespace StudentRandomizer.Views;

public partial class StudentView : ContentView
{
	public static readonly BindableProperty IndexNumberProperty = BindableProperty.Create(
		nameof(IndexNumber),
		typeof(int),
		typeof(StudentView)
		);
	public static readonly BindableProperty FirstNameProperty = BindableProperty.Create(
		nameof(FirstName),
		typeof(string),
		typeof(StudentView)
		);

	public static readonly BindableProperty LastNameProperty = BindableProperty.Create(
		nameof(LastName),
		typeof(string),
		typeof(StudentView)
		);

	public static readonly BindableProperty ClassNameProperty = BindableProperty.Create(
		nameof(ClassName),
		typeof(string),
		typeof(StudentView)
		);

	public static readonly BindableProperty StudentIdProperty = BindableProperty.Create(
		nameof(StudentId),
		typeof(Guid),
		typeof(StudentView)
		);

	public static readonly BindableProperty IsPresentProperty = BindableProperty.Create(
		nameof(IsPresent),
		typeof(bool),
		typeof(StudentView)
		);

	public int IndexNumber
	{
		get => (int)GetValue(IndexNumberProperty);
		set => SetValue(IndexNumberProperty, value);
	}
	public string FirstName 
	{
		get => (string)GetValue(FirstNameProperty);
		set => SetValue(FirstNameProperty, value);
	}
	public string LastName 
	{
		get => (string)GetValue(LastNameProperty);
		set => SetValue(LastNameProperty, value);
	}
	public string ClassName
	{
		get => (string)GetValue(ClassNameProperty);
		set => SetValue(ClassNameProperty, value);
	}
	public Guid StudentId
	{
		get => (Guid)GetValue(StudentIdProperty);
		set => SetValue(StudentIdProperty, value);
	}
	public bool IsPresent 
	{
		get => (bool)GetValue(IsPresentProperty);
		set => SetValue(IsPresentProperty, value);
	}
	public StudentView()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		var navigationParameter = new Dictionary<string, object>
		{
			{"FirstName", FirstName },
			{"LastName", LastName },
			{"ClassName", ClassName },
			{"StudentId", StudentId },
			{"IsPresent", IsPresent }
		};

		await Shell.Current.GoToAsync("///EditStudent", navigationParameter);
    }
}