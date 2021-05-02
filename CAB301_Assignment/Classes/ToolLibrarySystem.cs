using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class ToolLibrarySystem : iToolLibrarySystem
    {
        private string[] categories;
        private string[][] toolTypes;

        private ToolCollection[] gardeningTools  = new ToolCollection[5];
        private ToolCollection[] flooringTools = new ToolCollection[6];
        private ToolCollection[] fencingTools = new ToolCollection[5];
        private ToolCollection[] measuringTools = new ToolCollection[6];
        private ToolCollection[] cleaningTools = new ToolCollection[6];
        private ToolCollection[] paintingTools = new ToolCollection[6];
        private ToolCollection[] electronicTools = new ToolCollection[5];
        private ToolCollection[] electricityTools = new ToolCollection[5];
        private ToolCollection[] automotiveTools = new ToolCollection[6];



        private MemberCollection membersOfLibrary = new MemberCollection();

        //Constructor
        public ToolLibrarySystem(string[] libraryCategories, string[][] libraryToolTypes)
        {
            //create all the ToolCollections needed for the Categories
            initialiseToolCollections();

            categories = libraryCategories;
            toolTypes = libraryToolTypes;


            membersOfLibrary.add(new Member("User", "Test", "1234156121", "0000"));
            //initialiseMenus();
        }
        

        public void add(Tool aTool)
        {
            throw new NotImplementedException();
        } 

        public void add(Tool aTool, int quantity)
        {
            throw new NotImplementedException();
        }

        public void add(Member aMember)
        {
            if (membersOfLibrary.search(aMember) != true)
            {
                membersOfLibrary.add(aMember);
            }
            else
            {
                Console.WriteLine("This memeber is already added");
            }
        }

        public void borrowTool(Member aMember, Tool aTool)
        {
            if (membersOfLibrary.search(aMember))
            {
                Member theMemeber = selectMemeber(aMember);
                theMemeber.addTool(aTool);
                //add the memeber to tool borrow list (need to find the tool first, different from the above aTool)
            }
        }


        public void delete(Tool aTool)
        {
            throw new NotImplementedException();
        }

        public void delete(Tool aTool, int quantity)
        {
            throw new NotImplementedException();
        }

        public void delete(Member aMember)
        {
            if(membersOfLibrary.search(aMember) == true)
            {
                membersOfLibrary.delete(aMember);
            }
            else
            {
                Console.WriteLine("Memeber does not exist");
            }
        }

        public void displayBorrowingTools(Member aMember)
        {
            aMember = selectMemeber(aMember);
            string[] borrowedTools = aMember.Tools;
            foreach(string element in borrowedTools)
            {
                if (!string.IsNullOrEmpty(element))
                {
                    Console.WriteLine(element);
                }
            }
        }

        /// <summary>
        /// Doesnt actually use the string parameter as it is not enough to determine  
        /// </summary>
        /// <param name="aToolType"></param>
        public void displayTools(string aToolType)
        {
            int cat = 0;
            int type = 0;
            Console.Clear();
            Console.WriteLine("Library System - Display Tools By Tool Type");
            Console.WriteLine("===========================================");
            selectFromOptions(ref cat, ref type);

            ToolCollection[] finalSelectedCategory = selectRightCategory(cat);
            int number = finalSelectedCategory[type].Number;
            Tool[] toolsFromSelected = finalSelectedCategory[type].toArray();

            Console.WriteLine();
            Console.WriteLine("List of Tools");
            Console.WriteLine("============================================================");
            if (number > 0)
            {
                Console.WriteLine("{0, -25} {1, -3} {2, -3}", "Tool Name", "Available", "Total");
                Console.WriteLine("============================================================");
                for(int i= 0; i > toolsFromSelected.Length; i++)
                {
                    Tool element = toolsFromSelected[i];
                    Console.WriteLine("{0, -25} {1, -3} {2, -3}", element.Name, element.AvailableQuantity, element.Quantity);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Tools in this Tool Type");
                Console.ResetColor();

            }
            Console.WriteLine("============================================================");
            Console.WriteLine();
            Console.Write("Hit any key to continue");
            Console.ReadKey();
        }


        public void displayTopTHree()
        {
            throw new NotImplementedException();
        }

        public string[] listTools(Member aMember)
        {

            throw new NotImplementedException();
        }

        public void returnTool(Member aMember, Tool aTool)
        {
            if (membersOfLibrary.search(aMember))
            {
                Member theMemeber = selectMemeber(aMember);
                theMemeber.deleteTool(aTool);
                //delete the memeber from tool borrowlist (need to find the tool first, different from the above aTool)
            }
        }


        //********PRIVATE METHODS ************//
        private Member selectMemeber(Member aMember)
        {
            Member[] arrayOfMember = membersOfLibrary.toArray();
            for (int i = 0; i < arrayOfMember.Length; i++)
            {
                if (arrayOfMember[i].CompareTo(aMember) == 0)
                {
                    return arrayOfMember[i];
                }
            }
            return null;
        }
        private void initialiseToolCollections()
        {
            for (int i = 0; i < 5; i++)
            {
                gardeningTools[i] = new ToolCollection();
                flooringTools[i] = new ToolCollection();
                fencingTools[i] = new ToolCollection();
                measuringTools[i] = new ToolCollection();
                cleaningTools[i] = new ToolCollection();
                paintingTools[i] = new ToolCollection();
                electronicTools[i] = new ToolCollection();
                electricityTools[i] = new ToolCollection();
                automotiveTools[i] = new ToolCollection();
            }
            flooringTools[5] = new ToolCollection();
            measuringTools[5] = new ToolCollection();
            cleaningTools[5] = new ToolCollection();
            paintingTools[5] = new ToolCollection();
            automotiveTools[5] = new ToolCollection();
        }

        private void selectFromOptions(ref int cat, ref int type)
        {
            //display categories
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, categories[i]);
            }
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine();
            Console.Write("Select a tool category: ");
            string selectedCategory = Console.ReadLine();
            while (!selectedCategory.Equals("0") & !selectedCategory.Equals("1") & !selectedCategory.Equals("2")
                & !selectedCategory.Equals("3") & !selectedCategory.Equals("4") & !selectedCategory.Equals("5")
                & !selectedCategory.Equals("6") & !selectedCategory.Equals("7") & !selectedCategory.Equals("8") & !selectedCategory.Equals("9"))
            {
                Console.WriteLine("Please enter a valid menu option");
                selectedCategory = Console.ReadLine();
            }


            //if option wasnt to return, display tool menu
            if (!selectedCategory.Equals("0"))
            {
                Console.WriteLine();
                Console.WriteLine("Tool Type List");
                Console.WriteLine("==============");
                int intSelectedCategory = Int32.Parse(selectedCategory);
                intSelectedCategory--;
                int numberOfToolTypes = toolTypes[intSelectedCategory].Length;
                for (int i = 0; i < numberOfToolTypes; i++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, toolTypes[intSelectedCategory][i]);
                }
                Console.WriteLine();
                Console.Write("Enter the tool type: ");
                string selectedToolType = Console.ReadLine();
                if (numberOfToolTypes == 6)
                {
                    while (!selectedToolType.Equals("1") & !selectedToolType.Equals("2") & !selectedToolType.Equals("3")
                        & !selectedToolType.Equals("4") & !selectedToolType.Equals("5") & !selectedToolType.Equals("6"))
                    {
                        Console.WriteLine("Please enter a valid menu option");
                        selectedCategory = Console.ReadLine();
                    }
                }
                else
                {
                    while (!selectedToolType.Equals("1") & !selectedToolType.Equals("2") & !selectedToolType.Equals("3")
                        & !selectedToolType.Equals("4") & !selectedToolType.Equals("5"))
                    {
                        Console.WriteLine("Please enter a valid menu option");
                        selectedCategory = Console.ReadLine();
                    }
                }
                int intSelectedToolType = Int32.Parse(selectedToolType);
                intSelectedToolType--;
                cat = intSelectedCategory;
                type = intSelectedToolType;
            }
        }

        private ToolCollection[] selectRightCategory(int intSelectedCategory)
        {
            switch (intSelectedCategory)
            {
                case 0:
                    return gardeningTools;
                case 1:
                    return flooringTools;
                case 2:
                    return fencingTools;
                case 3:
                    return measuringTools;
                case 4:
                    return cleaningTools;
                case 5:
                    return paintingTools;
                case 6:
                    return electronicTools;
                case 7:
                    return electricityTools;
                case 8:
                    return automotiveTools;
                default:
                    return gardeningTools;
            }
        }

    }

    /* ADD TOOLS LOGIC
    public void delete(Tool aTool)
    {
        for (int i = 0; i < toolArray.Length; i++)
        {
            if (toolArray[i] != null)
            {
                if (toolArray[i].Name.Equals(aTool.Name))
                {
                    if (toolArray[i].AvailableQuantity >= aTool.Quantity)
                    {
                        toolArray[i].Quantity -= aTool.Quantity;
                        toolArray[i].AvailableQuantity -= aTool.Quantity;
                    }
                    else
                    {
                        //this will be ToolCollectionName.delete(tool)
                        toolArray[i] = null;
                    }
                }
            }
        }
    }

    public void add(Tool aTool)
    {
        if (search(aTool) == true)
        {
            for (int i = 0; i < toolArray.Length; i++)
            {
                if (toolArray[i] != null)
                {
                    if (toolArray[i].Name.Equals(aTool.Name))
                    {
                        toolArray[i].Quantity += aTool.Quantity;
                        toolArray[i].AvailableQuantity += aTool.Quantity;
                    }
                }
            }
        }
        else
        {
            if (Number >= toolArray.Length)
            {
                dynamicArray();
            }
            for (int i = 0; i < toolArray.Length; i++)
            {
                if (toolArray[i] == null)
                {
                    //this will be ToolCollectionName.add(tool)
                    toolArray[i] = aTool;
                }
            }
            Number++;
        }
    }
    */





    /* UI IF I NEED TO DO HERE
        private void initialiseMenus()
        {
            string userSelection = "";
            string userFeedback = "";
            bool menuLoop = false;

            do
            {
                Console.Clear();
                menuLoop = false;
                userSelection = printMainMenu(ref userFeedback);


                if (userSelection.Equals("1"))
                {

                    Console.Clear();
                    userSelection = "";
                    displayStaffLogin(ref menuLoop, ref userFeedback);
                }
                else if (userSelection.Equals("2"))
                {

                    Console.Clear();
                    userSelection = "";
                    displayMemberLogin(ref menuLoop, ref userFeedback);

                }
            } while (menuLoop == true);



        }

        private void displayMemberLogin(ref bool menuLoop, ref string userFeedback)
        {
            Console.Clear();
            Console.WriteLine("Tool Library System - Member Login Page");
            Console.WriteLine("======================================");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Enter your member login ID: ");
            string username = Console.ReadLine();
            Console.Write("Enter your 4 digit PIN: ");
            string password = Console.ReadLine();
            Member[] members = membersOfLibrary.toArray();
            foreach (Member element in members)
            {
                string usernameCheck = element.LastName + element.FirstName;

                if (username.Equals(usernameCheck) & password.Equals(element.PIN))
                {
                    Console.Clear();
                    displayMemberMenu(ref menuLoop);
                }
                else
                {
                    userFeedback = "Incorrect Member Login";
                    menuLoop = true;
                }
            }
        }

        private void displayMemberMenu(ref bool menuLoop)
        {

            Console.WriteLine("Welcome to the Tool Library");
            Console.WriteLine();
            Console.WriteLine("========Member Menu========");
            Console.WriteLine("1. Display tools by category");
            Console.WriteLine("2. Borrow tool from library");
            Console.WriteLine("3. Return tool to library");
            Console.WriteLine("4. List tools on loan");
            Console.WriteLine("5. Display most frequently borrowed tools");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("=========================");
            Console.WriteLine();
            Console.Write("Please make a selection(1 - 5, or 0 to exit): ");
            string k = Console.ReadLine();
            while (!k.Equals("0") & !k.Equals("1") & !k.Equals("2")
                & !k.Equals("3") & !k.Equals("4") & !k.Equals("5") & !k.Equals("6"))
            {
                Console.WriteLine("Please enter a valid menu option");
                k = Console.ReadLine();
            }
            if (k.Equals("0"))
            {
                menuLoop = true;
            }
        }
        private void displayStaffLogin(ref bool menuLoop, ref string userFeedback)
        {

            Console.Clear();
            Console.WriteLine("Tool Library System - Staff Login Page");
            Console.WriteLine("======================================");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Enter staff login: ");
            string username = Console.ReadLine();
            Console.Write("Enter staff password: ");
            string password = Console.ReadLine();
            if (username.Equals("staff") & password.Equals("today123"))
            {
                Console.Clear();
                displayStaffMenu(ref menuLoop);
            }
            else
            {
                userFeedback = "Incorrect Staff Login";
                menuLoop = true;
            }
        }
        private void displayStaffMenu(ref bool menuLoop)
        {

            Console.WriteLine("Welcome to the Tool Library");
            Console.WriteLine();
            Console.WriteLine("========Staff Menu========");
            Console.WriteLine("1. Add a new tool");
            Console.WriteLine("2. Add new pieces of an existing tool");
            Console.WriteLine("3. Remove some pieces of a tool");
            Console.WriteLine("4. Register a new member");
            Console.WriteLine("5. Remove a member");
            Console.WriteLine("6. Show tools member has on loan");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("=========================");
            Console.WriteLine();
            Console.Write("Please make a selection(1 - 6, or 0 to exit): ");
            string k = Console.ReadLine();
            while (!k.Equals("0") & !k.Equals("1") & !k.Equals("2")
                & !k.Equals("3") & !k.Equals("4") & !k.Equals("5") & !k.Equals("6"))
            {
                Console.WriteLine("Please enter a valid menu option");
                k = Console.ReadLine();
            }
            if (k.Equals("0"))
            {
                menuLoop = true;
            }
        }
        private string printMainMenu(ref string userFeedback)
        {
            Console.WriteLine("Welcome to the Tool Library");
            Console.WriteLine();
            Console.WriteLine("========Main Menu========");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("=========================");
            Console.WriteLine();
            if(userFeedback.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(userFeedback);
                Console.ResetColor();
                userFeedback = "";


            }
            Console.Write("Please make a selection(1 - 2, or 0 to exit): ");
            string k = Console.ReadLine();
            while (!k.Equals("0") & !k.Equals("1") & !k.Equals("2"))
            {
                Console.WriteLine("Please enter a valid menu option");
                k = Console.ReadLine();
            }
            return k;
        }
        */
}
