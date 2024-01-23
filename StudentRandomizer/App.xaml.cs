using StudentRandomizer.Services;

namespace StudentRandomizer
{
    public partial class App : Application
    {
        private StartupService _startupService;
        public App(StartupService startupService)
        {
            InitializeComponent();
            _startupService = startupService;
            _startupService.LoadData();
            MainPage = new AppShell();
        }
    }
}
