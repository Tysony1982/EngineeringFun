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

        public T? this[int index] 
        {
            get
            {
                
                var node = GetNodeFromIndex(index);

                return node switch
                {
                    null => default(T),
                    _ => node.Value
                };



            }
            set
            {

                var listLength = this.Count() - 1;

                if (value == null)
                    return;
                else if (index == 0)
                {
                    this.AddFront(value);
                    return;
                }
                else if (index == -1 || index == listLength)
                {
                    this.AddBack(value);
                    return;
                }
                        
                
                    
                MyNode? entityBefore = index - 1 > listLength && index < 0
                                                    ? default(MyNode)
                                                    : GetNodeFromIndex(index - 1);
                MyNode? entityAfter = entityBefore?.NextNode;

                // Since the if statement above caters for both cases of either entityBefore or entityAfter being null
                // we can assume here if either are null we dont have a valid index range to work with
                if (entityAfter is not null && entityBefore is not null)
                {
                    var newNode = new MyNode(value);
                    newNode.NextNode = entityAfter;
                    entityBefore.NextNode = newNode;
                }
                else 
                    return;

                }
        }

        public void AddFront(T newValue)
        {
            if (newValue is null)
                return;
            var newNode = new MyNode(newValue);
            newNode.NextNode = Head;
            // Make sure Last node is updated if needed
            Tail = Tail is null ? Head : Tail; 
            Head = newNode;

        }

        public void AddBack(T newValue)
        {
            if (newValue is null)
                return;
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

        private MyNode? GetNodeFromIndex(int index)
        {
            IndexOutOfRange(index); // Will throw exception here if out of bounds

            var counter = 0;
            var next = Head;
            MyNode? entityAtIndex = default(MyNode);
            while (next is not null)
            {
                if (counter == index)
                {
                    entityAtIndex = next;
                    break;
                }
                counter++;
                next = next.NextNode;   
            }
            return entityAtIndex;
        }
        private bool IndexOutOfRange(int index)
        {
            if (index > (this.Count() - 1) || index < 0)
                throw new ArgumentOutOfRangeException($"index ({index}) is out of bounds - length of list is {this.Count()}");
            return true;
        }


    }
}
