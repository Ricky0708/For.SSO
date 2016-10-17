using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For.Authentication
{
    public class UserManager
    {
        private HttpContext _context;

        public UserManager(IHttpContextAccessor accessor)
        {
            _context = accessor.HttpContext;
        }


    }
}
