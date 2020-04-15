using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_1
{
    class TestClass : object, IDisposable
    {
        
        public override string ToString() => GetType().Name;

        public override bool Equals(object obj)
        {
            Console.WriteLine($"Type is {obj.GetType()}");
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            Console.WriteLine("The hash code for the current object is ");
            return base.GetHashCode();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // some code
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~TestClass()
        {
            Dispose(false);
        }

    }
}