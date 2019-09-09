using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebService.Models
{
    public class ExceptionsModel
    {
        public static void TodoIsNullCheck(Dictionary<int, ToDoItem> todo)
        {
            if (todo == null)
            {
                throw new Exception("Todos is null");
            }
        }

        public static void TodoExistsCheck(Dictionary<int, ToDoItem> todo, int id)
        {

            if (todo.ContainsKey(id) == false)
            {
                throw new Exception("Todo doesn't exist");
            }
        }

        public static void TodoIdCheck(int id, ToDoItem value)
        {
            if (id != value.Id)
            {
                throw new Exception("Id and Todo Id do not match.");
            }
        }

        //public static void TodoIsNull()
        //{
        //    throw new Exception("Todos is null");
        //}

        //public static void TodosDoesNotExist()
        //{
        //    throw new Exception("Todo doesn't exist");
        //}
    }
}
