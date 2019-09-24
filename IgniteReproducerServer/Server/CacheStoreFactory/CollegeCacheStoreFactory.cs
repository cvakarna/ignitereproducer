using Apache.Ignite.Core.Cache.Store;
using Apache.Ignite.Core.Common;
using BusinnesModels;
using IgniteReproducerServer.Server.CacheStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteReproducerServer.Server.CacheStoreFactory
{
    public class CollegeCacheStoreFactory : IFactory<ICacheStore<string, ICollege>>
    {
        public ICacheStore<string, ICollege> CreateInstance()
        {
            return new CollegeCacheStore();
        }
    }
}
