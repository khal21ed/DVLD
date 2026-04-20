using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess
{
    internal class clsDataAccessSettings
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["DVLDConnectionString"].ConnectionString;
    }
}
