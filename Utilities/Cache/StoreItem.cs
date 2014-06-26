using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.Cache
{
    public class StoreItem<T>
    {        
        private List<T> Objects { get; set; }

        public StoreItem(){
            Objects = new List<T>();
        }

        //Gets the Index where new Object must be inserted
        private int FindNearIdex(int? id)
        {
            if (Objects.Count == 0)
            {
                return 0;
            }
            else
            {
                if (Objects.Count == 1)
                {
                    if (Convert.ToInt32(Objects[0].ToString()) < id)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            
            int index = Objects.Count / 2;
            int nextIndex = 0;
            decimal interval = Convert.ToDecimal(index) / 2;

            while (true)
            {
                if (Objects[index].Equals(id))
                {
                    return index;
                }
                else
                {
                    if (Convert.ToInt32(Objects[index].ToString()) > id)
                    {
                        nextIndex = Convert.ToInt32(index - interval);
                    }
                    else
                    {
                        nextIndex = Convert.ToInt32(index + interval);
                    }
                }

                if (nextIndex == index)
                {                    
                    break;
                }

                index = nextIndex;

                if(index + 1 > Objects.Count)
                {                    
                    break;
                }

                interval = interval / 2;
                if (interval < 1) 
                {
                    interval = 1;
                }
            }

            return index;
        }

        //Get the index of an object
        private int FindIndex(int? id)
        {
            if (Objects.Count == 0)
            {
                return -1;
            }            

            int index = Objects.Count / 2;
            int nextIndex = index;
            decimal interval = Convert.ToDecimal(index) / 2;

            while (true)
            {
                if (Objects[index].Equals(id))
                {
                    return index;
                }
                else
                {
                    if (Convert.ToInt32(Objects[index].ToString()) > id)
                    {
                        nextIndex = Convert.ToInt32(index - interval);
                    }
                    else
                    {
                        nextIndex = Convert.ToInt32(index + interval);
                    }
                }

                if (nextIndex == index)
                {
                    break;
                }

                index = nextIndex;

                if (index + 1 > Objects.Count)
                {
                    break;
                }

                interval = interval / 2;

                if (interval < 1)
                {
                    interval = 1;
                }
            }

            return -1;
        }

        public void AddObject(T value)
        {
            int nearIndex = FindNearIdex(Convert.ToInt32(value.ToString()));
            Objects.Insert(nearIndex, value);            
        }

        public T FindObject(int? id)
        {
            int objectIndex = FindIndex(id);
            if (objectIndex >= 0)
            {
                return Objects[objectIndex];
            }
            else
            {
                return default(T);
            }
            
        }
    }
}
