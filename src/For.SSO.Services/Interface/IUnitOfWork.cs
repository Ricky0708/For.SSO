using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For.SSO.Services.Interface
{
    public interface IUnitOfWork
    {
        DbContext Context { get; set; }
        void Commit();
        bool LazyLoadingEnabled { get; set; }
        bool ProxyCreationEnabled { get; set; }
        string ConnectionString { get; set; }
    }
}
