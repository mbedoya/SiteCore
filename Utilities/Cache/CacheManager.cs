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

        public void UpdateObject<T>(T value)
        {
            ObjectStore store = ObjectStore.GetInstance();
            store.UpdateObject(value);
        }

        public void RemoveObject<T>(int? id)
        {
            ObjectStore store = ObjectStore.GetInstance();
            store.RemoveObject<T>(id);
        }        

        /// <summary>
        /// Add Collection Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddObject<T>(string name, List<T> value) 
        {
            CollectionStore store = CollectionStore.GetInstance();
            store.AddCollection(name, value);
        }

        /// <summary>
        /// Get Collection Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<T> GetObject<T>(string name)
        {
            CollectionStore store = CollectionStore.GetInstance();
            return store.GetCollection<T>(name);
        }

        /// <summary>
        /// Remove Collection Object
        /// </summary>
        /// <param name="name"></param>
        public void RemoveObject(string name)
        {
            CollectionStore store = CollectionStore.GetInstance();
            store.RemoveCollection(name);
        }

        public List<CollectionItem> GetCollectionObjects()
        {
            return CollectionStore.GetInstance().Items;
        }
    }
}
