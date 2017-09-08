using Dashboard.Interfaces;
using Dashboard.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard.Infrastructure
{
    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            //Create the bindings
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ITasksListRepository>().To<TasksListRepository>();
            kernel.Bind<ICardRepository>().To<CardRepository>();
            return kernel;
        }
    }
}