using Apache.Ignite.Core.Cache.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinnesModels
{
    public class Lecturer:ICollege
    {
        [QuerySqlField]
        public string Name { get; set; }

        [QuerySqlField]
        public string Id { get; set; }
        [QuerySqlField]
        public List<string> Departments { get; set; }

        [QuerySqlField]
        public string Address { get; set; }

        [QuerySqlField]
        public string JoinDate { get; set; }



    }
}
