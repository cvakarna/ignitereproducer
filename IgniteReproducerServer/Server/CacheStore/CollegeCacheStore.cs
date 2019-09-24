using Apache.Ignite.Core.Cache.Store;
using BusinnesModels;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace IgniteReproducerServer.Server.CacheStore
{
    public class CollegeCacheStore : ICacheStore<string, ICollege>
    {
        ConcurrentDictionary<string, ICollege> _collegeDic = null;
        int count = 0;
        public CollegeCacheStore()
        {
            this._collegeDic = new ConcurrentDictionary<string, ICollege>();
        }
        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public ICollege Load(string key)
        {
            return this._collegeDic.GetValueOrDefault(key);
        }

        public IEnumerable<KeyValuePair<string, ICollege>> LoadAll(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public void LoadCache(Action<string, ICollege> act, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void SessionEnd(bool commit)
        {
            //throw new NotImplementedException();`
        }

        public void Write(string key, ICollege val)
        {
            try
            {

                this._collegeDic.TryAdd(key, val);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void WriteAll(IEnumerable<KeyValuePair<string, ICollege>> entries)
        {
            try
            {
                foreach(var entry in entries)
                {
                    this._collegeDic.TryAdd(entry.Key, entry.Value);
                    Console.WriteLine("Added Into Dictionary:::::"+this.count++);
                }
               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
