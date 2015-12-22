using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_CSharp
{
    public struct IndexedChar
    {
        public String Char { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        
        public int Direction { get; set; }
    }

    class Snake<S>
    {
        public ElemS<S> First { get; private set; }
        public ElemS<S> Last
        {
            get
            {
                if (First == null)
                    return null;
                ElemS<S> last = First;
                while (last.Next != null)
                    last = last.Next;
                return last;
            }
        }
        
        public void Add(S element)
        {
            if (First == null)
                First = new ElemS<S> { Value = element };
            else
            {
                ElemS<S> last = Last;
                last.Next = new ElemS<S> { Value = element, Previous = last };
            }
        }
        
        public ElemS<S> GetElement(int index)
        {
            ElemS<S> temp = First;
            for(int i = 1; i<=index; i++)
            {
                if (temp == null)
                    return null;
                temp = temp.Next;
            }
            return temp;
        }
        
        public void Insert(S element, int index)
        {
            if(index == 0)
            {
                if (First == null)
                    First = new ElemS<S> { Value = element };
                else
                {
                    ElemS<S> temp = First;
                    First = new ElemS<S> { Next = temp, Value = element };
                    temp.Previous = First;
                }
            }
            else
            {
                ElemS<S> elementAtIndex = GetElement(index);
                if (elementAtIndex == null)
                    Add(element);
                else
                {
                    ElemS<S> previous = elementAtIndex.Previous;
                    ElemS<S> temp = previous.Next;
                    previous.Next = new ElemS<S> { Value = element, Previous = previous, Next = temp };
                    temp.Previous = previous.Next;
                }
            }
        }
        
         
    }
    class ElemS<S>
    {
        public ElemS<S> Previous { get; set; }
        public ElemS<S> Next { get; set; }
        public S Value { get; set; }
    }
}
