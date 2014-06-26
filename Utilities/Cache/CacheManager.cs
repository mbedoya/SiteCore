using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.Cache
{
    public class CacheManager
    {
        private static CacheManager instance;

        public static CacheManager GetInstance()
        {
            if (instance == null)
            {
                instance = new CacheManager();
            }

            return instance;
        }

        public T GetObject<T> (int? id){
            ObjectStore store = ObjectStore.GetInstance();
            return store.GetObject<T>(id);
        }

        public T AddObject<T>(T value)
        {
            ObjectStore store = ObjectStore.GetInstance();
            store.AddObject(value);
            return default(T);
        }
    }
}
