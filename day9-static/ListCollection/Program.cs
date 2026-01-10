 using System;
using System.Collections;
using System.Diagnostics;
namespace ListCollection
{
   public class GenericCustomization
    {
        public GenericCustomization()
        {
        }
        public void Example()
        {
            List<string> names = new List<string>();
        }

    }

    public class MyCollection : IList 
    {
        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public object this[int index]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool IsFixedSize
        {
            get { return false; }
        }
        public int Count
        {
            get { throw new NotImplementedException(); }
        }
        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericCustomization gc = new GenericCustomization();
            gc.Example();

        }
    }
}