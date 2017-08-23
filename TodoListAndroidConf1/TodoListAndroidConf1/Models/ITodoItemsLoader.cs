using System.Collections.Generic;

namespace TodoListAndroidConf1.Models
{
    public interface ITodoItemsLoader
    {
        IEnumerable<TodoItem> LoadItems();
    }
}
