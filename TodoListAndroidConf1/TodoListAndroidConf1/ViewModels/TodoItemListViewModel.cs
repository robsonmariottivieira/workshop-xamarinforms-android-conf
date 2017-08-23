using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TodoListAndroidConf1.Annotations;
using TodoListAndroidConf1.Models;
using Xamarin.Forms;

namespace TodoListAndroidConf1.ViewModels
{
    public class NewTodoItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        private string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class TodoItemListViewModel : INotifyPropertyChanged
    {
        private readonly ITodoItemsLoader itemsLoader;
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<TodoItem> items;
        public ObservableCollection<TodoItem> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        private NewTodoItemViewModel newTodoItem;
        public NewTodoItemViewModel NewTodoItem
        {
            get => newTodoItem;
            set
            {
                newTodoItem = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddNewTodoCommand { get; set; }

        public TodoItemListViewModel(ITodoItemsLoader itemsLoader)
        {
            this.itemsLoader = itemsLoader;
            AddNewTodoCommand = new Command(parameter =>
            {
                var newTodoItemParamemter = (NewTodoItemViewModel)parameter;
                Items.Add(new TodoItem { Description = newTodoItemParamemter.Description, Title = newTodoItemParamemter.Title });
                NewTodoItem = new NewTodoItemViewModel();
            });
        }

        public void Init()
        {
            Items = new ObservableCollection<TodoItem>(itemsLoader.LoadItems());
            NewTodoItem = new NewTodoItemViewModel();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TodoItemViewModel : TodoItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand MarkAsCompeltedCommand { get; set; }

        public TodoItemViewModel()
        {
            MarkAsCompeltedCommand = new Command((parameter) =>
            {
                var todoItemViewModelParameter = (TodoItemViewModel)parameter;
                todoItemViewModelParameter.Completed = !todoItemViewModelParameter.Completed;
            });
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


    public interface ITodoItemsLoader
    {
        IEnumerable<TodoItem> LoadItems();
    }

    public class TodoItemsLoaderMock : ITodoItemsLoader
    {
        public IEnumerable<TodoItem> LoadItems()
        {
            yield return new TodoItem { Title = "Fazer Workshop Android Conf", Description = "Nenhuma por enquanto" };
            yield return new TodoItem { Title = "Apresentar Workshop Android Conf", Description = "Nenhuma agora" };
        }
    }
}
