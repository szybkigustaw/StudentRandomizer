using StudentRandomizer.Services;

namespace StudentRandomizer.Pages
{
    public partial class MainPage : ContentPage
    {
        public LuckyNumberService LuckyNumberService { get; set; }

        public MainPage(LuckyNumberService luckyNumber)
        {
            InitializeComponent();
            LuckyNumberService = luckyNumber;
            this.LuckyNumber.Text = LuckyNumberService.LuckyNumber.ToString();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///RandomizerPage");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///StudentsListPage");
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///ClassesListPage");
        }
    }

}
