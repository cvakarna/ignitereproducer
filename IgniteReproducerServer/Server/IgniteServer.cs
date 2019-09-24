using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Cluster;
using BusinnesModels;
using IgniteReproducerServer.Server.CacheStoreFactory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IgniteReproducerServer.Server
{
    public class IgniteServer
    {

        public IIgnite _ignite;
        private Task ConnectAsync(string configPath) //IgniteConfiguration configuration
        {
            if (string.IsNullOrEmpty(configPath)) //configuration
                throw new ArgumentNullException("Config file name is Empty!!!"); //nameof(configuration)

            try
            {
              
                 this._ignite = Ignition.Start("D:\\projects\\R&D\\IgniteReproducerServer\\Server\\server-config.xml"); //configuration
                                                                                                                           // Activate the cluster.
                // This is required only if the cluster is still inactive.
                this._ignite.GetCluster().SetActive(true);
                     IEnumerable<IClusterNode> nodes = this._ignite.GetCluster().ForServers().GetNodes();
                    this._ignite.GetCluster().SetBaselineTopology(nodes);

            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Exception:: " + ex.ToString(),
                    "\nStackTrace:: " + ex.StackTrace + "\nInnerException:: " + ex.InnerException);
                throw;
            }

            return Task.CompletedTask;
        }

        public async Task StartServerAsync()
        {
            try
            {
                await ConnectAsync("server-config.xml");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CreateCacheAsync(string cacheName)
        {
            if (cacheName != null)
            {
                var cacheConfig = await CreateCacheConfigurationAsync(cacheName);
                var cache = this._ignite.GetOrCreateCache<string, ICollege>(cacheConfig);
            }
        }

        private async Task<CacheConfiguration> CreateCacheConfigurationAsync(string cacheName)
        {
            CacheConfiguration cacheConfig = null;

            var queryList = await GetQueryEntities();
            if (this._ignite != null)
            {
                cacheConfig = new CacheConfiguration
                {
                    Name = cacheName,
                    CacheStoreFactory = new CollegeCacheStoreFactory(),
                    ReadThrough = true,
                    WriteThrough = true,
                    WriteBehindEnabled=true,
                    QueryEntities = queryList,
                    
                };
            }
            else
            {
                throw new Exception("Server not yet started......");
            }
            return cacheConfig;
        }

        private async Task<List<QueryEntity>> GetQueryEntities()
        {
            var studentquery = new QueryEntity(typeof(string), typeof(Student))
            {
                Indexes = new List<QueryIndex>() {
                 new QueryIndex( new string[]{ "Year"})
               }
            };
            var lectquery = new QueryEntity(typeof(string), typeof(Lecturer))
            {
                Indexes = new List<QueryIndex>() {
                 new QueryIndex( new string[]{ "Id"})
               }
            };
            var queryList = new List<QueryEntity> { studentquery };
            return queryList;
        }
    }
}
