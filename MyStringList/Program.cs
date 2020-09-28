using System;
using System.Collections;

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
            string header = shoppingList.Peek();
            Console.WriteLine(header);

            Console.WriteLine(shoppingList[3]);
        }
    }

    public class Node
    {
        public Node(string data)
        {
            Data = data;
        }
        public string Data { get; set; }

        public Node Next { get; set; }
    }

    public class MyStackList : IEnumerable
    {
        Node head;
        int count;

        public string this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new InvalidOperationException("Unknown index");
                int i = 0;
                foreach (var item in this)
                {
                    if (i == index) return item.ToString();
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

        public void Push(string item)
        {
            Node node = new Node(item);
            node.Next = head;
            head = node;
            count++;
        }
        public string Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is emplty");
            Node temp = head;
            head = head.Next;
            count--;
            return temp.Data;
        }
        public string Peek()
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
