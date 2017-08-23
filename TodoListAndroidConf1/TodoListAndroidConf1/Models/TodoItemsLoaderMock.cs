using System.Collections.Generic;
using TodoListAndroidConf1.Models;

namespace TodoListAndroidConf1.ViewModels
{
    public class TodoItemsLoaderMock : ITodoItemsLoader
    {
        public IEnumerable<TodoItem> LoadItems()
        {
            yield return new TodoItem { Title = "Fazer Workshop Android Conf", Description = "Nenhuma por enquanto" };
            yield return new TodoItem { Title = "Apresentar Workshop Android Conf", Description = "Nenhuma agora" };
        }
    }
}
