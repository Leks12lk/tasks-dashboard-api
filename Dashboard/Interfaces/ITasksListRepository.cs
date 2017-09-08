using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Interfaces
{
    public interface ITasksListRepository
    {
        IQueryable<TasksList> GetUserLists(string userId);
        IQueryable<TasksList> GeAllLists();
        int AddList(TasksList list);
        void DeleteList(int id);
    }
}
