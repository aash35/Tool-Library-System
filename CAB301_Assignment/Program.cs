using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Member newMember1;
            Member newMember2;
            Member newMember3;
            Member newMember4;
            Member newMember5;

            MemberCollection collection;

            Tool newTool1;
            Tool newTool2;
            Tool newTool3;
            Tool newTool4;

            toolTest();
            membersTest();
            collectionTest();;


            

            //Console.WriteLine(newTool);
            Console.ReadLine();



            void membersTest()
            {
                //create members
                newMember1 = new Member("Adrian", "Ash", "0000000000", "helloworld");
                newMember2 = new Member("Adrian", "Cash", "0000000000", "helloworld");
                newMember3 = new Member("Lora", "Ash", "0000000000", "helloworld");
                newMember4 = new Member("Lora", "Ash", "0000000000", "helloworld");
                newMember5 = new Member("Bdrian", "Abh", "0000000000", "helloworld");

                newMember1.addTool(newTool1);
                newMember1.addTool(newTool1);

                newMember1.deleteTool(newTool1);

            }

            void collectionTest()
            {
                collection = new MemberCollection();

                //add members
                collection.add(newMember1);
                collection.add(newMember2);
                collection.add(newMember3);
                collection.add(newMember5);

                //delete members
                collection.delete(newMember3);

                //to array method
                Member[] arrayMembers = collection.toArray();
                foreach (Member element in arrayMembers)
                {
                    Console.WriteLine(element);

                }


            }
            void toolTest()
            {
                newTool1 = new Tool("Jack Hammer", 5);
                newTool2 = new Tool("Hammer", 5);
                newTool3 = new Tool("Jack Saw", 5);
                newTool4 = new Tool("Scissors", 5);
            }

        }

        
    }
}
