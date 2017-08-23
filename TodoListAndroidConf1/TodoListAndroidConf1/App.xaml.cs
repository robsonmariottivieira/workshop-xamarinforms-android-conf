using TodoListAndroidConf1.ViewModels;
using Xamarin.Forms;

namespace TodoListAndroidConf1
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<ITodoItemsLoader, TodoItemsLoaderMock>();

            InitializeComponent();

            MainPage = new NavigationPage(new TodoListAndroidConf1.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
