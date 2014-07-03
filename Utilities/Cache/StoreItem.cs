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
        private int FindInsertIdex(int? id)
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
            double interval = Convert.ToDouble(index) / 2;

            if(interval < 1){
                interval = 1;
            }

            while (interval >= 0.5)
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
            }

            if (index <= Objects.Count - 1)
            {
                if (id > Convert.ToInt32(Objects[index].ToString()))
                {
                    return index + 1;
                }
                else
                {
                    if (index > 0 && id < Convert.ToInt32(Objects[index].ToString()) && id < Convert.ToInt32(Objects[index - 1].ToString()))
                    {
                        return index - 1;
                    }
                    else
                    {
                        return index;
                    }

                }
            }
            else
            {
                return index;
            }
            
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
            double interval = Convert.ToDouble(index) / 2;

            if (interval < 1)
            {
                interval = 1;
            }

            while (interval > 0.5)
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
            }

            if (index > 0)
            {
                if (index + 1 <= Objects.Count && id == Convert.ToInt32(Objects[index].ToString()))
                {
                    return index;
                }
                else
                {
                    if (index > 0 && id == Convert.ToInt32(Objects[index - 1].ToString()))
                    {
                        return index - 1;
                    }
                    else
                    {
                        if (index <= Objects.Count - 2 && id == Convert.ToInt32(Objects[index + 1].ToString()))
                        {
                            return index + 1;
                        }
                    }

                }
            }          

            return -1;
        }

        public void AddObject(T value)
        {
            int insertIndex = FindInsertIdex(Convert.ToInt32(value.ToString()));
            Objects.Insert(insertIndex, value);            
        }

        public void UpdateObject(T value)
        {
            int objectIndex = FindIndex(Convert.ToInt32(value.ToString()));
            if (objectIndex >= 0)
            {
                Objects[objectIndex] = value;
            }
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

        public void RemoveObject(int? id)
        {
            int objectIndex = FindIndex(id);
            if (objectIndex >= 0)
            {
                Objects.RemoveAt(objectIndex);
            }
        }
    }
}
