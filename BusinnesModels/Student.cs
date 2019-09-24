using Apache.Ignite.Core.Cache.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinnesModels
{
    public class Student:ICollege
    {
        [QuerySqlField]
        public string  Name { get; set; }
        [QuerySqlField]
        public string Department { get; set; }
        [QuerySqlField]
        public string RoleNumber { get; set; }
        [QuerySqlField]
        public string Section { get; set; }
        [QuerySqlField]
        public int Year { get; set; }

        [QuerySqlField]
        public string JoinDate { get; set; }



    }
}
