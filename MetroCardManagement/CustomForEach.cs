using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;


namespace MetroCardManagement
{
    public partial class CustomList<Type>:IEnumerable,IEnumerator
    {
        int position=-1;
        public IEnumerator GetEnumerator()
        {
            position=-1;
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            if(position<_count-1)
            {
                position++;
                return true;
            }
            return false;
        }
        public void Reset()
        {
            position=-1;
        }

       

       

        public object Current{get{return _array[position];}}
    }
}