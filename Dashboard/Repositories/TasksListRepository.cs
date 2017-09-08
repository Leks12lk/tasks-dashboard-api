using Dashboard.Interfaces;
using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard.Repositories
{
    public class TasksListRepository : ITasksListRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<TasksList> GeAllLists()
        {
            var lists = db.TasksList;
            return lists;
        }
        public IQueryable<TasksList> GetUserLists(string userId)
        {
            var lists = db.TasksList.Where(item => item.UserId == userId);
            return lists;
        }

        public int AddList(TasksList list)
        {
            db.TasksList.Add(list);
            db.SaveChanges();
            return list.Id;
        }
         

        public void DeleteList(int id)
        {
            var list = db.TasksList.Find(id);
            db.TasksList.Remove(list);
            db.SaveChanges();
        }
    }
}