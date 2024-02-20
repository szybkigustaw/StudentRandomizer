using StudentRandomizer.Models.Collections;
using StudentRandomizer.Popups;

namespace StudentRandomizer.Views;

public partial class StudentView : ContentView
{
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

	public static readonly BindableProperty ClassIdProperty = BindableProperty.Create(
		nameof(ClassId),
		typeof(Guid),
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
	public Guid ClassId
	{
		get => (Guid)GetValue(ClassIdProperty);
		set => SetValue(ClassIdProperty, value);
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
}