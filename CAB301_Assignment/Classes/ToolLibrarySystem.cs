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

            //Testing Purposes
            membersOfLibrary.add(new Member("user", "user", "12321", "0000"));
            testTools();
        }

        

        //important to make it so if the method is called by itself it works
        //split into two sections
        //Part 1: the ui and creating the object
        //Part 2: Placing the object
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

        /// <summary>
        /// Allows members to select a tool to borrow from the library. Selected through Category
        /// and Tool Type menus. If the member is allowed to borrow the tool and there are tool avaible
        /// the member is added to the tools borrowing memberCollection and the tool is added to the members borrowed tool array
        /// </summary>
        /// <param name="aMember">The UI passes the currently logged in member which is used 
        /// to match to a member in the tool library system</param>
        /// <param name="aTool">The Tool is initally empty but then updated when the member selects a tool
        /// from the Category and Tool Type menu system</param>
        public void borrowTool(Member aMember, Tool aTool)
        {
            if (membersOfLibrary.search(aMember))
            {
                int cat = 0;
                int type = 0;
                bool returnFlag = false;
                Console.Clear();
                Console.WriteLine("Library System - Display Tools By Tool Type");
                Console.WriteLine("===========================================");
                selectFromOptions(ref cat, ref type, ref returnFlag);
                if(returnFlag == false)
                {
                    ToolCollection[] finalSelectedCategory = selectRightCategory(cat);
                    int number = finalSelectedCategory[type].Number;
                    Tool[] toolsFromSelected = finalSelectedCategory[type].toArray();


                    Console.Clear();
                    Console.WriteLine("List of Tools");
                    Console.WriteLine("============================================================");
                    displayTools(number, toolsFromSelected);
                    Console.WriteLine("============================================================");
                    Console.WriteLine();
                    //if there are no tools in the tool category return
                    if (number == 0)
                    {
                        Console.Write("Hit any key to return to menu");
                        Console.ReadKey();
                    }
                    //else make selection and add to memeber tools and borrowed tools memeberCollection
                    else
                    {
                        Member theMemeber = selectMemeber(aMember);
                        Console.Write("Please make a selection(1 - {0}, or 0 to exit): ", number);
                        string k = Console.ReadLine();
                        int selection;
                        bool success = Int32.TryParse(k, out selection);

                        while (success == false | selection > number | selection < 0)
                        {
                            Console.WriteLine("Please enter a valid menu option");
                            k = Console.ReadLine();
                            success = Int32.TryParse(k, out selection);
                        }
                        if (selection != 0)
                        {
                            selection--;

                            Tool selectedTool = toolsFromSelected[selection];
                            bool flag = true;
                            for (int i = 0; i < theMemeber.Tools.Length; i++)
                            {
                                if (theMemeber.Tools[i] == null)
                                {
                                    flag = false;
                                    if (selectedTool.AvailableQuantity > 0)
                                    {
                                        theMemeber.addTool(selectedTool);
                                        selectedTool.addBorrower(theMemeber);
                                        Console.WriteLine();
                                        Console.WriteLine("Borrowed {0} from the library", selectedTool.Name);
                                        Console.WriteLine();

                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("No more tools available");
                                        Console.ResetColor();
                                    }
                                    i = theMemeber.Tools.Length;
                                }
                            }
                            if (flag == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A Member can only borrow 3 tools at a time");
                                Console.ResetColor();
                            }
                            Console.Write("Hit any key to return to menu");
                            Console.ReadKey();
                        }
                    }
                }
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
        /// Displays an menu that allows a user to select the category and tool type that they would
        /// like the list of tools from
        /// </summary>
        /// <param name="aToolType">An empty tool type that isnt used due to parallel 
        /// string arrays and tool type arrays</param>
        public void displayTools(string aToolType)
        {
            int cat = 0;
            int type = 0;
            bool returnFlag = false;
            Console.Clear();
            Console.WriteLine("Library System - Display Tools By Tool Type");
            Console.WriteLine("===========================================");
            selectFromOptions(ref cat, ref type, ref returnFlag);
            if(returnFlag == false)
            {
                ToolCollection[] finalSelectedCategory = selectRightCategory(cat);
                int number = finalSelectedCategory[type].Number;
                Tool[] toolsFromSelected = finalSelectedCategory[type].toArray();
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("List of Tools");
                Console.WriteLine("============================================================");
                displayTools(number, toolsFromSelected);
                Console.WriteLine("============================================================");
                Console.WriteLine();
                Console.Write("Hit any key to continue");
                Console.ReadKey();
            }
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
                string[] borrowedTools = theMemeber.Tools;
                Console.Clear();
                Console.WriteLine("Library System - Display Borrowed Tools");
                Console.WriteLine("===========================================");

                List<string> noNullTools = new List<string>();
                //ensure that null values in a Members Tool array dont mess with counting
                //i.e ["ToolName2",null,"ToolName2"] will have ToolName2 labeled as three
                for (int i = 0; i < borrowedTools.Length; i++)
                {
                    if(borrowedTools[i] != null)
                    {
                        noNullTools.Add(borrowedTools[i]);
                    }
                }

                if (noNullTools.Count() > 0)
                {
                    for (int i = 0; i < noNullTools.Count(); i++)
                    {
                        Console.WriteLine("{0}. {1}", i + 1, noNullTools[i]);
                    }
                    Console.WriteLine("===========================================");
                    Console.WriteLine();
                    if (noNullTools.Count() == 1)
                    {
                        Console.Write("Please make a selection( 1 , or 0 to exit): ");
                    }
                    else
                    {
                        Console.Write("Please make a selection(1 - {0}, or 0 to exit): ", noNullTools.Count());
                    }
                    string k = Console.ReadLine();
                    int selection;
                    bool success = Int32.TryParse(k, out selection);
                    while (success == false | selection > noNullTools.Count() | selection < 0)
                    {
                        Console.WriteLine("Please enter a valid menu option");
                        k = Console.ReadLine();
                        success = Int32.TryParse(k, out selection);
                    }
                    if (selection != 0)
                    {
                        selection--;

                        string selectedTool = noNullTools[selection];
                        Tool foundTool = fullLibraryToolNameSearch(selectedTool);
                        theMemeber.deleteTool(foundTool);
                        foundTool.deleteBorrower(theMemeber);

                        Console.WriteLine();
                        Console.WriteLine("Returned {0} to the library", foundTool.Name);
                        Console.WriteLine();
                        Console.Write("Hit any key to return to menu");
                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Currently no tools borrowed");
                    Console.ResetColor();
                    Console.WriteLine("===========================================");
                    Console.WriteLine();
                    Console.Write("Hit any key to return to menu");
                    Console.ReadKey();
                }

                //theMemeber.deleteTool(aTool);
                //delete the memeber from tool borrowlist (need to find the tool first, different from the above aTool)
            }
        }




        //********PRIVATE METHODS ************//
        private Tool fullLibraryToolNameSearch(string Tool)
        {
            List<ToolCollection[]> allCategories = new List<ToolCollection[]>();
            allCategories.Add(gardeningTools);
            allCategories.Add(flooringTools);
            allCategories.Add(fencingTools);
            allCategories.Add(measuringTools);
            allCategories.Add(cleaningTools);
            allCategories.Add(paintingTools);
            allCategories.Add(electronicTools);
            allCategories.Add(electricityTools);
            allCategories.Add(automotiveTools);
            Tool aTool = new Tool(Tool, 0);
            for(int i = 0; i < allCategories.Count(); i++)
            {
                for(int j = 0; j < allCategories[i].Length; j++)
                {
                    Tool[] arrayToolType = allCategories[i][j].toArray();
                    for (int k = 0; k < arrayToolType.Length; k++) {
                        if(arrayToolType[k] != null)
                        {
                            if (arrayToolType[k].CompareTo(aTool) == 0)
                            {
                                return arrayToolType[k];
                            }
                        }
                    }
                }
            }
            return null;
        }
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

        private void displayTools(int number, Tool[] toolsFromSelected)
        {
            if (number > 0)
            {
                Console.WriteLine("\t{0, -25} {1, -10} {2, -10}", "Tool Name", "Available", "Total");
                Console.WriteLine("============================================================");
                for (int i = 0; i < toolsFromSelected.Length; i++)
                {
                    if (toolsFromSelected[i] != null)
                    {
                        Tool element = toolsFromSelected[i];
                        Console.WriteLine("\t{0}. {1, -25} {2, -10} {3, -10}",i+1, element.Name, element.AvailableQuantity, element.Quantity);
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Tools in this Tool Type");
                Console.ResetColor();
            }
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

        private void selectFromOptions(ref int cat, ref int type, ref bool returnFlag)
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
                        selectedToolType = Console.ReadLine();
                    }
                }
                else
                {
                    while (!selectedToolType.Equals("1") & !selectedToolType.Equals("2") & !selectedToolType.Equals("3")
                        & !selectedToolType.Equals("4") & !selectedToolType.Equals("5"))
                    {
                        Console.WriteLine("Please enter a valid menu option");
                        selectedToolType = Console.ReadLine();
                    }
                }
                int intSelectedToolType = Int32.Parse(selectedToolType);
                intSelectedToolType--;
                cat = intSelectedCategory;
                type = intSelectedToolType;
            } else
            {
                returnFlag = true;
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

        private void testTools()
        {
            gardeningTools[0].add(new Tool("Straight Cutter 52", 5));
            gardeningTools[0].add(new Tool("Straight Cutter 53", 2));
            gardeningTools[0].add(new Tool("Straight Cutter 54", 3));

            gardeningTools[1].add(new Tool("Green Machine", 5));
            gardeningTools[1].add(new Tool("Stew", 5));
            gardeningTools[1].add(new Tool("Grass Muncher", 5));
            gardeningTools[1].add(new Tool("Qmungus", 5));

            gardeningTools[2].add(new Tool("Cutters", 5));
            gardeningTools[2].add(new Tool("Picker", 5));
            gardeningTools[2].add(new Tool("Stick Lifta", 5));
            gardeningTools[2].add(new Tool("Lawn Cleaner", 5));

            gardeningTools[3].add(new Tool("Wheelbarrow of Power", 5));
            gardeningTools[3].add(new Tool("Wheelbarrow of Speed", 5));
            gardeningTools[3].add(new Tool("Wheelbarrow of Knowledge", 5));
            gardeningTools[3].add(new Tool("Wheelbarrow of Agility", 5));

            gardeningTools[4].add(new Tool("Power Leaf", 5));
            gardeningTools[4].add(new Tool("Power Power", 5));
            gardeningTools[4].add(new Tool("Power Cutter", 5));
            gardeningTools[4].add(new Tool("Power Hole", 5));

            flooringTools[0].add(new Tool("King Scraper", 5));
            flooringTools[0].add(new Tool("Queen Scraper", 2));
            flooringTools[0].add(new Tool("Prince Scraper", 3));

            flooringTools[1].add(new Tool("Looping Laser", 5));
            flooringTools[1].add(new Tool("Lazy Laser", 5));
            flooringTools[1].add(new Tool("Lucky Laser", 5));
            flooringTools[1].add(new Tool("Looper Laser", 5));

            flooringTools[2].add(new Tool("Level", 5));
            flooringTools[2].add(new Tool("Leveler", 5));
            flooringTools[2].add(new Tool("ReLeveler", 5));
            flooringTools[2].add(new Tool("LeadReLeaver", 5));

            flooringTools[3].add(new Tool("Level Powder", 5));
            flooringTools[3].add(new Tool("Leveler Powder", 5));
            flooringTools[3].add(new Tool("ReLeveler Powder", 5));
            flooringTools[3].add(new Tool("LeadReLeaver Powder", 5));

            flooringTools[4].add(new Tool("Hand Floor", 5));
            flooringTools[4].add(new Tool("Hand Tool for Floor", 5));
            flooringTools[4].add(new Tool("Tool for Hand Flooring", 5));
            flooringTools[4].add(new Tool("Flooring for Hand Tools", 5));

            flooringTools[5].add(new Tool("Best Tiling Tool", 5));
            flooringTools[5].add(new Tool("Number One Tiling Tool", 5));
            flooringTools[5].add(new Tool("Unbeatable Tiling Tool", 5));
            flooringTools[5].add(new Tool("King Tiling Tool", 5));
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


}
