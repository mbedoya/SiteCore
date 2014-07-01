using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.Cache
{
    public class CollectionStore
    {
        private static CollectionStore instance;

        public static CollectionStore GetInstance()
        {
            if (instance == null)
            {
                instance = new CollectionStore();
            }

            return instance;
        }

        private List<CollectionItem> items;
        public List<CollectionItem> Items
        {
            get { return items; }
        }

        public CollectionStore()
        {
            items = new List<CollectionItem>(); 
        }        

        public void AddCollection<T>(string name, List<T> value)
        {
            CollectionItem item = new CollectionItem();
            item.AddObject<T>(name, value);

            items.Add(item);
        }

        public List<T> GetCollection<T>(string name)
        {
            CollectionItem item = items.Find(x => x.Name == name);

            if (item != null)
            {
                return item.GetObject<T>();
            }

            return default(List<T>);
        }

        public void RemoveCollection(string name)
        {
            CollectionItem item = items.Find(x => x.Name == name);

            if (item != null)
            {
                items.Remove(item);
            }
        }
    }
}
