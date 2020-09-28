using System;
using System.Collections;
using System.ComponentModel;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {

            MyStackList shoppingList = new MyStackList();
            shoppingList.Push("Bread");
            shoppingList.Push("Butter");
            shoppingList.Push("Tea");
            shoppingList.Push("Coffee");
            shoppingList.Push("Sugar");

            foreach (var item in shoppingList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            object header = shoppingList.Peek();
            Console.WriteLine(header);

            Console.WriteLine(shoppingList[3]);

        }
    }

    public class Node
    {
        public Node(object data)
        {
            Data = data;
        }
        public object Data { get; set; }

        public Node Next { get; set; }
    }

    public class MyStackList : IEnumerable
    {
        Node head;
        int count;

        public object this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException("Unknown index");
                int i = 0;
                foreach (var item in this)
                {
                    if (i == index) return item;
                    i++;
                }
                return this[index];
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
