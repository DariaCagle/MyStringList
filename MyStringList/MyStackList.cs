using System;
using System.Collections;

namespace MyStringList
{
    public class MyStackList : IEnumerable
    {
        Node head;
        int count;

        public object this[int index]
        {
            get
            {
                if (index >= Count && index < 0)
                    throw new IndexOutOfRangeException("Unknown index");
                int i = 0;
                object result = null;
                foreach (var item in this)
                {
                    if (i == index) 
                    { 
                        result = item; 
                        break; 
                    }
                    i++;
                }
                return result;
            }
        }

        public bool IsEmpty
        {
            get { return count == 0; }
        }
        public int Count
        {
            get { return count; }
        }

        public void Push(object item)
        {
            Node node = new Node(item);
            node.Next = head;
            head = node;
            count++;
        }
        public object Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is emplty");
            Node previous = head;
            head = head.Next;
            count--;
            return previous.Data;
        }
        public object Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");
            return head.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
