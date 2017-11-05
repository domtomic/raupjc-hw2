using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Assignment2
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems.
    /// </summary>
    public class TodoRepository : ITodoRepository
    {
        /// <summary>
        /// Repository does not fetch todoItems from the actual database,
        /// it uses in memory storage for this excersise .
        /// </summary>
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            _inMemoryTodoDatabase = initialDbState ?? new GenericList<TodoItem>();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(item => item.Id.Equals(todoId));
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                throw new DuplicateTodoItemException(todoItem.Id);
            }
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public bool Remove(Guid todoId)
        {
            TodoItem varItem = Get(todoId);
            return varItem != null && _inMemoryTodoDatabase.Remove(varItem);
        }

        public TodoItem Update(TodoItem todoItem)
        {
            if (!_inMemoryTodoDatabase.Contains(todoItem))
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
            TodoItem varItem = Get(todoItem.Id) ?? throw new ArgumentNullException();
            varItem.Text = todoItem.Text;
            return varItem;
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem varItem = Get(todoId);
            return varItem != null && varItem.MarkAsCompleted();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(item => item.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(item => item.IsCompleted.Equals(false)).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(item => item.IsCompleted).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }
    }

    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException(Guid todoItemId) : base("duplicate id: " + todoItemId) {}
    }
}
