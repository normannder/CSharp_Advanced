using System;
using System.Collections;
using System.Collections.Generic;

namespace ITEA_Collections.Generics
{
    public class IteaGenericCollection<T> : IEnumerable<T>, IBaseGenericCollectionUsing<T>
    {
        public IteaGenericCollection<T> collection;

        #region IBaseGenericCollectionUsing
        public void Add(T ts)
        {
            collection.Add(ts);
        }

        public void AddMany(T[] ts)
        {
            collection.AddMany(ts);
        }

        public void Clear()
        {
            collection.Clear();
        }

        public T[] GetAll()
        {
            return collection.GetAll();
        }

        public T GetByID(int index)
        {
            return collection.GetByID(index);
        }

        public void RemoveByID(int index)
        {
            collection.RemoveByID(index);
        }

        public void ShowAll()
        {
            collection.ShowAll();
        }
        #endregion

        #region IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            return new IteaGenericEnumerator<T>(collection.GetAll());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
