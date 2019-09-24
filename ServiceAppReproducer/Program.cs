using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache.Query;
using Apache.Ignite.Core.Client;
using BusinnesModels;
using System;

namespace ServiceAppReproducer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Program p = new Program();
            p.IgniteOperations();
            Console.ReadKey();

        }

        public void IgniteOperations()
        {
            IgniteClientConfiguration _igniteClientConfiguration = new IgniteClientConfiguration
            {
                Endpoints = new string[] { "localhost" },
                SocketTimeout = TimeSpan.FromSeconds(30)
            };
            Student student = new Student { Department = "ece", Year = 2, Name = "ABC", RoleNumber = "12-abc" };
            Lecturer lect = new Lecturer { Name = "ABC-L", Id = "LET-1" };
            using (IIgniteClient client = Ignition.StartClient(_igniteClientConfiguration))
            {
                try
                {
                    var cache = client.GetCache<string, ICollege>("college-code-123");
                    //create student 
                    cache.Put(student.RoleNumber, student);
                    var sqlQuery = new SqlQuery(typeof(Student), "where Name = ?", "ABC");
                    var record = cache.Query(sqlQuery).GetAll();

                    //create lecturer
                    cache.Put(lect.Id, lect);
                    var lectRec = cache.Get(lect.Id);
                    //create lecturer table since cache configuration not able to change for existing cache
                    var sQuery = CreateTable();
                    cache.Query(sQuery);

                    var lsqlQuery = new SqlQuery(typeof(Lecturer), "where Name = ?", "ABC-L");
                    var lrecord = cache.Query(sqlQuery).GetAll();

                   
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
              
            }
        }

         
        public SqlFieldsQuery CreateTable()
        {
            string query = "CREATE TABLE Lecturer(Name varchar(55),Id varchar(55),Departments varchar(max),Address varchar(250),JoinDate varchar(50),PRIMARY KEY (Id)) WITH \"CACHE_NAME = college-code-123\"";
            SqlFieldsQuery squery = new SqlFieldsQuery(query);
            return squery;
        }
    }
}
