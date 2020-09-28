namespace MyStringList
{
    public class Node
    {
        public Node(object data)
        {
            Data = data;
        }
        public object Data { get; set; }

        public Node Next { get; set; }
    }
}
