using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Member newMember = new Member("Adrian", "Ash", "0000000000", "helloworld");
            Tool newTool = new Tool("Jack Hammer", 5);

            Console.WriteLine(newMember);
            Console.WriteLine(newTool);
            Console.ReadLine();
        }
    }
}
