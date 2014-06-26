using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.Cache
{
    public class ObjectStore
    {
        private static ObjectStore instance;

        public static ObjectStore GetInstance()
        {
            if (instance == null)
            {
                instance = new ObjectStore();
            }

            return instance;
        }

        private List<object> items;
        public List<object> Items
        {
            get { return items; }            
        }

        public ObjectStore()
        {
            items = new List<object>();
        }

        //Create Header and Add First Child
        private void CreateStoreItem<T>(T value)
        {
            StoreItem<T> item = new StoreItem<T>();            
            item.AddObject(value);

            items.Add(item);
        }

        public void AddObject<T>(T value)
        {            
            StoreItem<T> storeItem = null; 

            //Find Type in Headers
            foreach (var item in items)
            {
                if(item.GetType() == typeof(StoreItem<T>))
                {
                    storeItem = (StoreItem<T>)item;               
                    break;
                }
            }

            if (storeItem != null)
            {
                storeItem.AddObject(value);
            }
            else
            {
                CreateStoreItem(value);
            }
        }

        public bool ObjectExists<T>(int? id)
        {
            StoreItem<T> storeItem = null;

            //Find Type in Headers
            foreach (var item in items)
            {
                if (item.GetType() == typeof(StoreItem<T>))
                {
                    storeItem = (StoreItem<T>)item;
                    break;
                }
            }

            if (storeItem != null)
            {
                return storeItem.FindObject(id) != null;
            }
            else
            {
                return false;
            }
        }

        public T GetObject<T>(int? id)
        {
            StoreItem<T> storeItem = null;

            //Find Type in Headers
            foreach (var item in items)
            {
                if (item.GetType() == typeof(StoreItem<T>))
                {
                    storeItem = (StoreItem<T>)item;
                    break;
                }
            }

            if (storeItem != null)
            {
                return storeItem.FindObject(id);
            }
            else
            {
                return default(T);
            }
        }
    }
}
