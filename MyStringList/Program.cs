using System;

namespace MyStringList
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
}
