using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDataStructures
{
    public class MyLinkedList<T> 
    {
        public MyNode? Head;
        public MyNode? Tail; // Will be null until we have at 2 items
        public class MyNode
        {
            public MyNode(T value)
            {
                Value = value;
                NextNode = null;
            }
            public T? Value { get; set; }
            public MyNode? NextNode { get; set; }

        }

        public void AddFront(T newValue)
        {
            var newNode = new MyNode(newValue);
            newNode.NextNode = Head;
            // Make sure Last node is updated if needed
            Tail = Tail is null ? Head : Tail; 
            Head = newNode;

        }

        public void AddBack(T newValue)
        {
            var newNode = new MyNode(newValue);
            newNode.NextNode = null; //Just being explicit here i.e. null == last
            // Now check to see if the head is null or Head is equal to last
            if (Head is null)
            {
                Head = newNode;
                Tail = null;
                
            }
            else if (Tail is null)
            {
                Head.NextNode = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.NextNode = newNode;
                Tail = newNode;   
            }


            //(Head, Tail) = Head == Tail ? (newNode, newNode) : (Head, newNode);

        }

        public int Count()
        {
            var n = Head;
            // if head is null bung out otherwise add 1 to counter so that we always have 1
            var counter = Head is null ? 0 : 1;
            while (n?.NextNode != null)
            {
                counter++;
                n = n.NextNode;
            }
            return counter;
        }

        public T[] ToArray()
        {
            var arraySize = this.Count();
            var array = new T[arraySize];
            // Now for the logic
            var next = Head;
            var counter = 0;
            while (next is not null)
            {
                if (next.Value is null)
                    break;
                array[counter] = next.Value;

                next = next.NextNode;
                counter++;
            }

            return array;
        }

        public void PrintValues()
        {
            var next = Head;

            while (next is not null)
            {
                if (next.Value is null)
                    break;
                Console.WriteLine(next.Value);

            }
        }

        
    }
}
