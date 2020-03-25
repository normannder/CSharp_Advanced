using System;
using System.Collections;
using System.Collections.Generic;

namespace ITEA_Collections.Generics
{
    public class IteaGenericEnumerator<T> : IEnumerator<T>
    {
        public T[] collection;
        
        private int currentIndex = -1;

        #region IEnumerator
        public T Current { get; }

        object IEnumerator.Current 
        { 
            get 
            { 
                return collection[currentIndex]; 
            } 
        }

        protected IteaGenericEnumerator() { }

        public IteaGenericEnumerator(T[] incomeCollection)
        {
            this.collection = incomeCollection;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool MoveNext()
        {
            Console.Beep();
            currentIndex++;
            return currentIndex < collection.Length && collection[currentIndex] != null;
        }

        public void Reset()
        {
            Console.Beep();
            currentIndex = -1;
        }
        #endregion
    }
}
