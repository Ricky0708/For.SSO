using For.SSO.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace For.SSO.Services.Repository
{
    public static class RepositoryHelper
    {
        public static string connStr;
        public static IUnitOfWork GetUnitOfWork()
        {
            var unitOfWork = new EFUnitOfWork();
            //unitOfWork.ConnectionString = connStr;
            return unitOfWork;
        }
        public static IRepository<T> GetRepository<T>()
        {
            IRepository<T> repository = (IRepository<T>)Activator.CreateInstance(Assembly.GetExecutingAssembly().GetTypes().Single(p => p.Name == typeof(T).Name + "Repository"));
            //repository.GetType().GetProperty("UnitOfWork").SetValue(repository, GetUnitOfWork());
            repository.UnitOfWork = GetUnitOfWork();
            return repository;
        }

        public static IRepository<T> GetRepository<T>(IUnitOfWork unitOfWork)
        {
            IRepository<T> repository = (IRepository<T>)Activator.CreateInstance(Assembly.GetExecutingAssembly().GetTypes().Single(p => p.Name == typeof(T).Name + "Repository"));
            repository.UnitOfWork = unitOfWork;
            return repository;
        }
    }
}
