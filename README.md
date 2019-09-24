# ignitereproducer

# projects 
* IgniteReproducerServer,BusinnesModels and ServiceAppReproducer
* Refer BusinnesModels project to  IgniteReproducerServer and ServiceAppReproducer  once import into visualstudio



Steps:
1.Start IgniteReproducerServer its will create cache


```
 static void Main(string[] args)
        {
            try
            {
                IgniteServer server = new IgniteServer();
                server.StartServerAsync().GetAwaiter().GetResult();
                //Create Cache
                server.CreateCacheAsync("college-code-123").GetAwaiter().GetResult();//for this we use thick client
                Thread.Sleep(Timeout.Infinite);
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
           

        }
    }
 ```


2.Insert Studdent record from ServiceAppReproducer

3. Stop ignite server

   * UnComment  from IgniteReproducerServer.Server.IgniteServer.GetQueryEntities method
```
var lectquery = new QueryEntity(typeof(string), typeof(Lecturer))
            {
                Indexes = new List<QueryIndex>() {
                 new QueryIndex( new string[]{ "Id"})
               }
            };
```
   * start server 
   
   
4.Run ServiceAppReproducer will get error
![Exception](https://user-images.githubusercontent.com/34210823/65499251-f4a1ec00-deda-11e9-8cff-272aa17715db.png)

