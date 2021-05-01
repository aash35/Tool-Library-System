using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] categories = { "Gardening tools", "Flooring Tools",
                "Fencing Tools", "Measuring Tools", "Cleaning Tools",
                "Painting Tools", "Electronic Tools", "Electricity Tools", "Automotive Tools" };

            string[] GardeningTools = { "Line Trimmers", "Lawn Mowers",
                "Hand Tools", "Wheelbarrows", "Garden Power Tools" };

            string[] FlooringTools = { "Scrapers", "Floor Lasers", "Floor Levelling Tools",
                "Floor Levelling Materials", "Floor Hand Tools", "Tiling Tools" };

            string[] FencingTools = { "Hand Tools", "Electric Fencing",
                "Steel Fencing Tools", "Power Tools", "Fencing Accessories" };

            string[] MeasuringTools = { "Distance Tools", "Laser Measurer",
                "Measuring Jugs", "Temperature & Humidity Tools", "Levelling Tools", "Markers" };

            string[] CleaningTools = { "Draining", "Car Cleaning",
                "Vacuum", "Pressure Cleaners", "Pool Cleaning", "Floor Cleaning" };

            string[] PaintingTools = { "Sanding Tools", "Brushes",
                "Rollers", "Paint Removal Tools", "Paint Scrapers", "Sprayers" };

            string[] ElectronicTools = { "Voltage Tester", "Oscilloscopes",
                "Thermal Imaging", "Data Test Tool", "Insulation Testers" };

            string[] ElectricityTools = { "Test Equipment", "Safety Equipment",
                "Basic Hand tools", "Circuit Protection", "Cable Tools" };

            string[] AutomotiveTools = { "Jacks", "Air Compressors",
                "Battery Chargers", "Socket Tools", "Braking", "Drivetrain" };

            string[][] toolTypes =
            {
                GardeningTools, FlooringTools, FencingTools, MeasuringTools, CleaningTools, 
                PaintingTools, ElectronicTools, ElectricityTools, AutomotiveTools
            };

            UI userInterface = new UI();

            Console.WriteLine(toolTypes[1][1]);
            Console.WriteLine(toolTypes[3][5]);
            Console.WriteLine(toolTypes[2][2]);
            Console.WriteLine(toolTypes[3][1]);
            Console.WriteLine(toolTypes[1][3]);
            Console.WriteLine(toolTypes[7][2]);















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
