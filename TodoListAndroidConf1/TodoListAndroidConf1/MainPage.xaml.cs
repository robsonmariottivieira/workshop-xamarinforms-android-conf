using TodoListAndroidConf1.ViewModels;
using Xamarin.Forms;

namespace TodoListAndroidConf1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var todoItemsViewModel = new TodoItemListViewModel(DependencyService.Get<ITodoItemsLoader>());
            this.BindingContext = todoItemsViewModel;

            todoItemsViewModel.Init();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView) sender).SelectedItem = null;
        }
    }
}
