using System;
using System.Collections;
using System.Collections.Generic;
using ITEA_Collections.Common;
namespace ITEA_Collections.Generics
{
    public class IteaGenericCollection<T> : IEnumerable<T>, IBaseGenericCollectionUsing<T>
    {
        public T[] collection;
        private int count = 0;

        public IteaGenericCollection()
        {
            collection = new T[128];
        }


        #region IBaseGenericCollectionUsing
        public void Add(T ts)
        {
            collection[count] = ts;
            count++;
        }

        public void AddMany(T[] ts)
        {
            foreach (T item in ts) 
                Add(item);
        }

        public T GetByID(int index)
        {
            return collection[index];
        }

        public void RemoveByID(int index)
        {
            collection[index] = default(T);
        }

        public T[] GetAll()
        {
            return collection;
        }

        public void Clear()
        {
            Array.Clear(collection, 0, collection.Length);
        }

        public void ShowAll()
        {
            collection.ShowAll();
        }
        #endregion

        #region IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            //T[] arrayToReturn = new T[128];
            //foreach (var item in collection)
            //{
            //    for (int i = 0; i < 128; i++)
            //        arrayToReturn[i] = item;
            //}
            return GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        #endregion
    }
}
