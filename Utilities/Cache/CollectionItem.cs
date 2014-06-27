using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.Cache
{
    public class CollectionItem
    {
        private string name;
        public string Name
        {
            get { return name; }            
        }
        private List<int> keys;

        public void AddObject<T>(string name, List<T> value)
        {
            this.name = name;
            this.keys = new List<int>();

            ObjectStore objectStore = ObjectStore.GetInstance();

            foreach (var item in value)
            {
                //if the object is not in store, then add it
                if (objectStore.GetObject<T>(Convert.ToInt32(item.ToString())) == null)
                {
                    objectStore.AddObject<T>(item);
                }
                keys.Add(Convert.ToInt32(item.ToString()));
            }
        }

        public List<T> GetObject<T>()
        {
            List<T> objects = new List<T>();

            //if keys are not found in store then remove them
            List<int> keysToRemove = new List<int>();

            foreach (var item in keys)
	        {
                T storeItem = ObjectStore.GetInstance().GetObject<T>(item);
                if (storeItem != null)
                {
                    objects.Add(storeItem);
                }
                else
                {
                    keysToRemove.Add(item);
                }
	        }

            //Remove Items that are not in store
            foreach (var item in keysToRemove)
            {
                keys.Remove(item);
            }

            return objects;
        }
    }
}
