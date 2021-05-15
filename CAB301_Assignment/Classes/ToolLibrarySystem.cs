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

        /////////////////////////////////////////////////////start of finished

        /// <summary>
        /// Select a category and tool type to added a new tool too
        /// if the tool already exists, then it wont add
        /// </summary>
        /// <param name="aTool">a new tool object with name set to user input
        /// quantity is set by default to 1</param>
        public void add(Tool aTool)
        {
            int cat = 0;
            int type = 0;
            bool returnFlag = false;
            Console.Clear();
            Console.WriteLine("Library System - Select a category");
            Console.WriteLine("===========================================");
            Console.WriteLine();
            selectFromOptions(ref cat, ref type,ref returnFlag);
            Console.Clear();
            if (returnFlag == false)
            {
                ToolCollection[] finalSelectedCategory = selectRightCategory(cat);
                Tool[] toolsFromSelected = finalSelectedCategory[type].toArray();
                bool existingTool = false;
                for(int i = 0; i < toolsFromSelected.Length; i++)
                {
                    if (toolsFromSelected[i] != null)
                    {
                        if (toolsFromSelected[i].CompareTo(aTool) == 0)
                        {
                            existingTool = true;
                            i = toolsFromSelected.Length;
                        }
                    }
                }
                if (!existingTool)
                {
                    finalSelectedCategory[type].add(aTool);
                    Console.WriteLine();
                    Console.WriteLine("Tool successfully added");
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tool already exists in Tool Type");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Add Tool cancelled");
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.Write("Hit any key to return to menu");
            Console.ReadKey();
        }

        /// <summary>
        /// Creates a menu from which the user can select the tool and but much they would
        /// like to update the stock by
        /// </summary>
        /// <param name="aTool">empty and not used for the purpose of the program except to
        /// for matching to a tool already in the library</param>
        /// <param name="quantity">initally empty, the quantity is updated to the amount
        /// that the selected tools quality and AvailableQuantity qantity need to be updated by</param>
        public void add(Tool aTool, int quantity)
        {
            int cat = 0;
            int type = 0;
            bool returnFlag = false;
            Console.Clear();
            Console.WriteLine("Library System - Update Existing Tool Stock Level");
            Console.WriteLine("===========================================");
            Console.WriteLine();
            selectFromOptions(ref cat, ref type,ref returnFlag);
            Console.Clear();
            if (returnFlag == false)
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

                if (number != 0)
                {
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
                        Console.Write("Enter the quantity of stock added to library: ", number);
                        string j = Console.ReadLine();
                        bool quantitySuccess = Int32.TryParse(j, out quantity);

                        while (quantitySuccess == false | quantity <= 0 | quantity >= 100)
                        {
                            Console.WriteLine("Please enter a number (must be a number greater than 0 but less than 100)");
                            j = Console.ReadLine();
                            quantitySuccess = Int32.TryParse(j, out quantity);
                        }

                        Tool selectedTool = toolsFromSelected[selection];
                        selectedTool.Quantity += quantity;
                        selectedTool.AvailableQuantity += quantity;
                        Console.WriteLine();
                        Console.WriteLine("Tool Stock Updated");
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Add Tool cancelled");
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.Write("Hit any key to return to menu");
            Console.ReadKey();
        }

        /// <summary>
        /// Add a member to the system, verification logic done in UI to keep synchronicity
        /// between the 'registerMembers' (used for login) and 'membersOfLibrary' (storing user data)
        /// </summary>
        /// <param name="aMember">a complete member object that is added to 'membersOfLibrary'</param>
        public void add(Member aMember)
        {
            membersOfLibrary.add(aMember);
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

        /// <summary>
        /// Method not used as the option from the UI "Remove some pieces of a tool" uses the
        /// overloaded version 'delete(Tool aTool, int quantity)' instead, however it is still
        /// coded to work if needed
        /// </summary>
        /// <param name="aTool">Initially en empty tool that is populated in the menu system
        /// which is then used to select and delete the right item from the selected tool collection</param>
        public void delete(Tool aTool)
        {
            int cat = 0;
            int type = 0;
            bool returnFlag = false;
            Console.Clear();
            Console.WriteLine("Library System - Delete Tools from library ");
            Console.WriteLine("===========================================");
            Console.WriteLine();
            selectFromOptions(ref cat, ref type, ref returnFlag);
            Console.Clear();
            if (returnFlag == false)
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

                if (number != 0)
                {
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

                        if (selectedTool.GetBorrowers.Number == 0)
                        {
                            finalSelectedCategory[type].delete(selectedTool);
                            Console.WriteLine();
                            Console.WriteLine("Tool Deleted");
                            Console.WriteLine();
                        }
                        else
                        {
                            Member[] currentBorrowers = selectedTool.GetBorrowers.toArray();

                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Cannot delete while member's is borrowing");
                            for (int i = 0; i < currentBorrowers.Length; i++)
                            {
                                Console.WriteLine();
                                Console.WriteLine(" - " + currentBorrowers[i]);
                            }
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Delete Tools cancelled");
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.Write("Hit any key to return to menu");
            Console.ReadKey();
        }

        /// <summary>
        /// method used to delete tools or a quantity of tools from the library
        /// this method displays a menu from which the user selected the tool they would
        /// like to delete or decrease the stock of
        /// </summary>
        /// <param name="aTool">initally empty tool that becomes populated with the selected tool</param>
        /// <param name="quantity">the number in which the stock of the selected tool is to be decreased.
        /// Initally 0 however the user selects the number to be reduced by inside the menu system</param>
        public void delete(Tool aTool, int quantity)
        {
            int cat = 0;
            int type = 0;
            bool returnFlag = false;
            Console.Clear();
            Console.WriteLine("Library System - Delete Tools from library ");
            Console.WriteLine("===========================================");
            Console.WriteLine();
            selectFromOptions(ref cat, ref type, ref returnFlag);
            Console.Clear();
            if (returnFlag == false)
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

                if (number != 0)
                {
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
                        Console.Write("Enter the quantity of stock to be removed from library: ");
                        string j = Console.ReadLine();
                        bool quantitySuccess = Int32.TryParse(j, out quantity);

                        while (quantitySuccess == false | quantity > selectedTool.AvailableQuantity | quantity < 0)
                        {
                            if (quantitySuccess == false)
                            {
                                Console.WriteLine("Please enter a number");
                            }
                            else if (quantity > selectedTool.AvailableQuantity & quantity <= selectedTool.Quantity)
                            {
                                Member[] currentBorrowers = selectedTool.GetBorrowers.toArray();

                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Cannot delete while members are borrowing");
                                for (int i = 0; i < currentBorrowers.Length; i++)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(" - " + currentBorrowers[i]);
                                }
                                Console.ResetColor();
                                Console.WriteLine();
                                Console.WriteLine("Please enter a valued number (between 0 and {0} (the available quantity))", selectedTool.AvailableQuantity);
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valued number (between 0 and {0} (the available quantity))", selectedTool.AvailableQuantity);
                            }
                            j = Console.ReadLine();
                            quantitySuccess = Int32.TryParse(j, out quantity);
                        }
                        if (quantity == selectedTool.Quantity)
                        {
                            //finish this
                            finalSelectedCategory[type].delete(selectedTool);
                            Console.WriteLine();
                            Console.WriteLine("Tool Deleted");
                            Console.WriteLine();
                        } 
                        else
                        {
                            //finish this
                            selectedTool.Quantity -= quantity;
                            selectedTool.AvailableQuantity -= quantity;
                            Console.WriteLine();
                            Console.WriteLine("Tool Stock reduced by {0}", quantity);
                            Console.WriteLine();
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Delete Tools cancelled");
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.Write("Hit any key to return to menu");
            Console.ReadKey();
        }

        /// <summary>
        /// The UI object passes a member object that have no tools borrowed and 
        /// remove the member from the toollibrary
        /// </summary>
        /// <param name="aMember">the member object is passed in after it have been
        /// verified to have no borrowed tools. the memeber is then deleted from the
        /// 'membersOfLibrary' memberCollection</param>
        public void delete(Member aMember)
        {
            membersOfLibrary.delete(aMember);
        }

        /// <summary>
        /// currently used by the staff menu to display all the tools a select
        /// member has on loan. Staff have to select a member from a menu system.
        /// it then displays all the members borrowed tools
        /// </summary>
        /// <param name="aMember">Initally empty user which becomes a selected member when the staff
        /// selects a user for the menu</param>
        public void displayBorrowingTools(Member aMember)
        {
            if (membersOfLibrary.search(aMember))
            {
                Member theMember = selectMemeber(aMember);
                string[] borrowedTools = theMember.Tools;
                List<string> noNullTools = new List<string>();
                for (int i = 0; i < borrowedTools.Length; i++)
                {
                    if (borrowedTools[i] != null)
                    {
                        noNullTools.Add(borrowedTools[i]);
                    }
                }
                Console.Clear();
                Console.WriteLine("Library System - Display Borrowed Tools");
                Console.WriteLine("===========================================");
                if (noNullTools.Count > 0) {
                    foreach (string element in noNullTools)
                    {
                        if (!string.IsNullOrEmpty(element))
                        {
                            Console.WriteLine("\t"+element);
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Currently no tools borrowed");
                    Console.ResetColor();
                }
                
                Console.WriteLine("===========================================");
                Console.WriteLine();
            }
            Console.Write("Hit any key to return to menu");
            Console.ReadKey();
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
        /////////////////////////////////////////////////////end of finished
        
        //****************\\
        public void displayTopTHree()
        {
            Console.Clear();
            Console.WriteLine("Most Frequently Borrowed Tools");
            Console.WriteLine("===========================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Coming Soon");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.Write("Hit any key to return to menu");
            Console.ReadKey();
        }



        /////////////////////////////////////////////////////start of finished
        /// <summary>
        /// returns a string array of all the tools a logged in user is currently holding.
        /// This method is used in the member menu to display member tools and displayBorrowingTools is used in the staff menu
        /// </summary>
        /// <param name="aMember">The UI passes the currently logged in member which is used 
        /// to match to a member in the tool library system</param>
        /// <returns>an array of all the names of tools a member is borrowing</returns>
        public string[] listTools(Member aMember)
        {
            string[] borrowedTools = new string[0];

            if (membersOfLibrary.search(aMember))
            {
                Member theMemeber = selectMemeber(aMember);
                borrowedTools = theMemeber.Tools;
            }
            return borrowedTools;
        }

        /// <summary>
        /// Allows members to return one of the tool that they are currently holding. This increase the availabl equantity of the tool
        /// </summary>
        /// <param name="aMember">The UI passes the currently logged in member which is used 
        /// to match to a member in the tool library system</param>
        /// <param name="aTool">The Tool is initally empty but then updated when the member selects a tool
        /// from the Category and Tool Type menu system</param>
        public void returnTool(Member aMember, Tool aTool)
        {
            if (membersOfLibrary.search(aMember))
            {
                Member theMemeber = selectMemeber(aMember);
                string[] borrowedTools = theMemeber.Tools;
                Console.Clear();
                Console.WriteLine("Library System - Display Borrowed Tools to return");
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
        /////////////////////////////////////////////////////end of finished



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

}
