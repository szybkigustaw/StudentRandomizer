using StudentRandomizer.ViewModels;

namespace StudentRandomizer.Pages;

public partial class RandomizerPage : ContentPage
{
	public RandomizerPage(RandomizerPageViewModel viewmodel)
	{
		InitializeComponent();
		this.BindingContext = viewmodel;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("///MainPage");
    }
        public async void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if(selectedIndex != -1)
            {
                (this.BindingContext as RandomizerPageViewModel).SelectedClass = (this.BindingContext as RandomizerPageViewModel).ClassesList[selectedIndex];
                var navigationParameter = new Dictionary<string, object>
                {
                    {"ClassId", (this.BindingContext as RandomizerPageViewModel).SelectedClass.Id}
                };

                await Shell.Current.GoToAsync("///RollStudentPage", navigationParameter);
            }
        }
}