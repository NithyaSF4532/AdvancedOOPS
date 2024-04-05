

using System;
using System.Collections.Generic;
using System.Data.Common;

namespace List_DataStructures
{
    public partial class CustomList<Type>
    {
        private int _count;
        private int _capacity;
        public int Count { get { return _count; } }
        public int Capacity { get { return _capacity; } }
        private Type[] _array;
        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        public CustomList()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];

        }
        public CustomList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }

        public void Add(Type element)
        {
            if (_count == _capacity)
            {
                GrowSize();
            }
            _array[_count] = element;
            _count++;
        }
        void GrowSize()
        {
            _capacity = _capacity * 2;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;

        }
        public void AddRange(CustomList<Type> elements)
        {
            _capacity = _count + elements.Count + 4;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            int k = 0;
            for (int i = _count; i < _count + elements.Count; i++)
            {
                temp[i] = elements[k];
                k++;
            }
            _array = temp;
            _count = _count + elements.Count;
        }

        public bool Contains(Type element)
        {
            bool flag = false;
            foreach (Type data in _array)
            {

                if (data.Equals(element))
                {
                    flag = true;
                    break;
                }
            }
            return flag;

        }

        public int IndexOf(Type element)
        {
            int index = -1;
            for (int i = 0; i < _count; i++)
            {
                if (element.Equals(_array[i]))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        //6-2
        //1,2,3,4,5
        //1,2,6,3,4,5

        public void Insert(int position, Type element)
        {
            _capacity = _capacity + 1 + 4;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count+1; i++)
            {
                if (i < position)
                {
                    temp[i] = _array[i];

                }
                else if (i == position)
                {
                    temp[i] = element;
                }
                else
                {
                    temp[i] = _array[i - 1];
                }
            }
            _count++;
            _array = temp;

        }
    //7,8,9
    //1,2,3,4,5
    //1,2,7,8,9,3,4,5
        public void InsertRange(int position, CustomList<Type> elements)
        {
            _capacity=_count+elements.Count+4;
            Type []temp=new Type[_capacity];
            for(int i=0;i<position;i++)
            {
                temp[i]=_array[i];
            }
            int j=0;
            for(int i=position;i<position+elements.Count;i++)
            {
                 temp[i]=elements[j];
                 j++;
            }
            int k=position;
            for(int i=position+elements.Count;i<_count+elements.Count;i++)
            {
                temp[i]=_array[k];
                k++;
            }
            _array=temp;
            _count=_count+elements.Count;
        }

        //1,2,3,4,5
        //1,2,4,5
        public void RemoveAt(int position)
        {
            for(int i=0;i<_count-1;i++)
            {
                if(i>=position)
                {
                    _array[i]=_array[i+1];
                }
            }
            _count--;
        } 

        public bool Remove(Type element)
        {
           int position=IndexOf(element);
           for(int i=0;i<_count;i++)
           {
              if(position>=0)
              {
                 RemoveAt(position);
                 return true;
              }
           }
           return false;
        }

        public void Reverse()
        {
            Type []temp=new Type[_capacity];
            int j=0;
            for(int i=_count-1;i>=0;i--)
            {
                temp[j]=_array[i];
                j++;
            }
            _array=temp;
        }
    }
}