using StudentRandomizer.Services;
using System.Diagnostics;

namespace StudentRandomizer
{
    public partial class App : Application
    {
        private StartupService _startupService;
        public App(StartupService startupService)
        {
            InitializeComponent();
            _startupService = startupService;
            try
            {
                _startupService.LoadData();
            }
            catch (Exception ex) 
            {
#if DEBUG
                Debug.WriteLine(ex.Message);
#endif
            }
            MainPage = new AppShell();
        }
    }
}
