using For.SSO.DB.Models;
using For.SSO.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace For.SSO.Services.Repository
{
    public class AccountRepository : EFRepository<Account>, IAccountRepository
    {
        public IEnumerable<Account> GetList()
        {
            return base.All().Where(p=>p.ErrorLoginTimes == 5);
        }
    }
    public interface IAccountRepository : IRepository<Account>
    {
        IEnumerable<Account> GetList();
    }
}
