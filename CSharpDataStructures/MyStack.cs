using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDataStructures
{

    public class MyStack<T>
    {
        public T?[] Stack { get; private set; }
        public int MaxStackIndex { get; private set; }
        public int Head { get; private set; } 
        public MyStack(int stackSize)
        {
            Stack = new T[stackSize];
            MaxStackIndex = stackSize - 1;
            Head = -1; // Initally we are not in the first  i.e 0 index (only when we do our first push
        }

        public T? Pop()
        {
            var any = AnyStackItems();
            if (!any)
                throw new ArgumentOutOfRangeException("Stack is empty, Why did you try access me man!!!!");

            var returnVal = Stack[Head];
            Head--; 

            return returnVal;
            
        }

        public void Push(T? pushValue)
        {
            if (Head == MaxStackIndex)
                throw new ArgumentOutOfRangeException($"Stack is full bra. You have reached your max size {MaxStackIndex + 1}");
            
            Head = Head + 1;
            Stack[Head] = pushValue;
            
            
        }

        public bool IsEmpty()
        {
            return !AnyStackItems();
        }

        public T? Peek()
        {
            return AnyStackItems() switch
            {
                false => throw new ArgumentOutOfRangeException("Stack is empty, Why did you try access me man!!!!"),
                true => Stack[Head] 
            };
        }

        public bool AnyStackItems()
        {
            return Head switch
            {
                < 0 => false,
                _ => true
            };
        }


    }
}
