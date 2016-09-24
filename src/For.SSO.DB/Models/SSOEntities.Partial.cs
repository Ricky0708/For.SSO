using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For.SSO.DB.Models
{
    public partial class SSOEntities
    {
        public SSOEntities(DbConnection conn):base(conn,true)
        {

        }
    }
}
