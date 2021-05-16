using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class UI
    {
        private ToolLibrarySystem systemLibrary;
        private MemberCollection registerMembers = new MemberCollection();
        private Member loginUser = null;

        //might not need these two
        private string[] categories;
        private string[][] toolTypes;

        public UI(ToolLibrarySystem toolLibrarySystem, string[] categoryStrings, string[][] toolTypeStrings )
        {
            systemLibrary = toolLibrarySystem;
            
            //might not need these two
            categories = categoryStrings;
            toolTypes = toolTypeStrings;

            //need to add to systemLibrary too
            registerMembers.add(new Member("a","a","12321","0000"));
            registerMembers.add(new Member("b", "b", "12321", "0000"));

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
            Member[] members = registerMembers.toArray();
            if(members.Length == 0)
            {
                menuLoop = true;
                userFeedback = "Incorrect Member Login";
            }
            for(int i = 0; i < members.Length; i++)
            {
                string usernameCheck = members[i].LastName + members[i].FirstName;

                if (username.Equals(usernameCheck) & password.Equals(members[i].PIN))
                {
                    loginUser = members[i];
                    displayMemberMenu(ref menuLoop);
                    userFeedback = "";
                    i = members.Length;
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
            bool memberMenuLoop = false;
            do
            {
                Console.Clear();
                memberMenuLoop = false;

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
                    & !k.Equals("3") & !k.Equals("4") & !k.Equals("5"))
                {
                    Console.WriteLine("Please enter a valid menu option");
                    k = Console.ReadLine();
                }
                if (k.Equals("0"))
                {
                    loginUser = null;
                    menuLoop = true;
                }
                else if (k.Equals("1"))
                {
                    string dataTypeString = "";
                    systemLibrary.displayTools(dataTypeString);
                    memberMenuLoop = true;

                }
                else if (k.Equals("2"))
                {
                    Tool aTool = new Tool("empty", 0);
                    systemLibrary.borrowTool(loginUser, aTool);
                    memberMenuLoop = true;
                }
                else if (k.Equals("3"))
                {
                    Tool aTool = new Tool("empty", 0);
                    systemLibrary.returnTool(loginUser, aTool);
                    memberMenuLoop = true;
                }
                else if (k.Equals("4"))
                {
                    string[] borrowedTools = systemLibrary.listTools(loginUser);
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
                    if (noNullTools.Count > 0)
                    {
                        foreach (string element in noNullTools)
                        {
                            if (!string.IsNullOrEmpty(element))
                            {
                                Console.WriteLine("\t" + element);
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

                    Console.Write("Hit any key to return to menu");
                    Console.ReadKey();

                    memberMenuLoop = true;

                }
                else if (k.Equals("5"))
                {
                    systemLibrary.displayTopTHree();
                    memberMenuLoop = true;
                }

            } while (memberMenuLoop == true);

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

            bool staffMenuLoop = false;
            do
            {
                Console.Clear();
                staffMenuLoop = false;

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
                else if (k.Equals("1"))
                {
                    Tool aTool = new Tool("Empty", 1);
                    Console.Clear();
                    Console.WriteLine("Library System - Add Tool");
                    Console.WriteLine("===========================================");
                    Console.WriteLine();
                    Console.Write("Enter the name of the new Tool (0 to exit): ");
                    string name = Console.ReadLine();
                    while (name.Equals(""))
                    {
                        Console.WriteLine("Please enter a valid name or option");
                        name = Console.ReadLine();
                    }
                    if (!name.Equals("0"))
                    {
                        aTool.Name = name;
                        systemLibrary.add(aTool);
                    }
                    staffMenuLoop = true;

                }
                else if (k.Equals("2"))
                {
                    Tool aTool = new Tool("Empty", 1);
                    int quantity = 0;
                    systemLibrary.add(aTool, quantity);
                    staffMenuLoop = true;
                }
                else if (k.Equals("3"))
                {
                    Tool aTool = new Tool("Empty", 1);
                    int quantity = 0;
                    systemLibrary.delete(aTool, quantity);
                    staffMenuLoop = true;
                }
                else if (k.Equals("4"))
                {
                    Console.Clear();
                    Console.WriteLine("Library System - Add New Member");
                    Console.WriteLine("===========================================");
                    Console.WriteLine();
                    Console.Write("Enter the first name of the new member (blank to exit): ");
                    string firstName = Console.ReadLine();
                    if (!firstName.Equals(""))
                    {
                        Console.WriteLine();
                        Console.Write("Enter the last name of the new member: ");
                        string lastName = Console.ReadLine();

                        Console.WriteLine();
                        Console.Write("Enter the phone number of the new member (no spaces and no calling code): ");
                        string phoneNumber = Console.ReadLine();
                        int phoneCheck;
                        bool phoneSuccess = Int32.TryParse(phoneNumber, out phoneCheck);

                        while (phoneSuccess == false | phoneNumber.Length != 10)
                        {
                            Console.WriteLine("Please enter a valid phone number (10 digits long, no area code)");
                            phoneNumber = Console.ReadLine();
                            phoneSuccess = Int32.TryParse(phoneNumber, out phoneCheck);
                        }

                        Console.WriteLine();
                        Console.Write("Enter the four digit pin of the new member: ");
                        string memberPin = Console.ReadLine();
                        int pinCheck;
                        bool pinSuccess = Int32.TryParse(memberPin, out pinCheck);

                        while (pinSuccess == false | memberPin.Length != 4)
                        {
                            Console.WriteLine("Please enter a valid PIN (4 digits long)");
                            memberPin = Console.ReadLine();
                            pinSuccess = Int32.TryParse(memberPin, out pinCheck);
                        }

                        Console.WriteLine();
                        Console.Write("Confirm new member (y/n): ");
                        string confirmChar = Console.ReadLine();
                        while (!(confirmChar.Equals("Y")| confirmChar.Equals("N") | confirmChar.Equals("y") | confirmChar.Equals("n")))
                        {
                            Console.WriteLine("Please enter a valid option (y/n)");
                            confirmChar = Console.ReadLine();
                        }
                        if (confirmChar.Equals("y") | confirmChar.Equals("Y"))
                        {
                            Member newMember = new Member(firstName, lastName, phoneNumber, memberPin);
                            bool searchMembers = registerMembers.search(newMember);
                            if(searchMembers == false)
                            {
                                registerMembers.add(newMember);
                                systemLibrary.add(newMember);
                                Console.WriteLine();
                                Console.WriteLine("New Member Added");
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Member already in system");
                                Console.ResetColor();
                                Console.WriteLine();
                            }
                        }
                        
                    }
                    Console.Write("Hit any key to return to menu");
                    Console.ReadKey();
                    staffMenuLoop = true;
                }
                else if (k.Equals("5"))
                {
                    Console.Clear();
                    Console.WriteLine("Library System - Remove a Member");
                    Console.WriteLine("===========================================");
                    Console.WriteLine();
                    int numberOfBorrowed = 0;
                    Member targetMember = displayAndSelectMember(ref numberOfBorrowed);

                    if(targetMember != null)
                    {
                        if (!(numberOfBorrowed > 0))
                        {

                            systemLibrary.delete(targetMember);
                            registerMembers.delete(targetMember);
                            Console.WriteLine();
                            Console.WriteLine("Member Removed");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Member is currently borrowing tools (cant remove until all items are returned)");
                            Console.ResetColor();
                            Console.WriteLine();
                        }

                    }
                    Console.Write("Hit any key to return to menu");
                    Console.ReadKey();
                    staffMenuLoop = true;
                }
                else if (k.Equals("6"))
                {
                    Console.Clear();
                    Console.WriteLine("Library System - Remove a Member");
                    Console.WriteLine("===========================================");
                    Console.WriteLine();
                    int numberOfBorrowed = 0;
                    Member targetMember = displayAndSelectMember(ref numberOfBorrowed);

                    if (targetMember != null)
                    {
                        systemLibrary.displayBorrowingTools(targetMember);
                    }
                    staffMenuLoop = true;
                }

            } while (staffMenuLoop == true);

        }

        private Member displayAndSelectMember(ref int numberOfBorrowed)
        {
            Member[] arrayRegisteredMember = registerMembers.toArray();
            List<int> parallelBorrowNumbers = new List<int>(); 
            int borrowCount = 0;
            if(arrayRegisteredMember.Length > 0)
            {

                for (int i = 0; i < arrayRegisteredMember.Length; i++)
                {
                    string[] toolsBorrowed = systemLibrary.listTools(arrayRegisteredMember[i]);
                    foreach (string element in toolsBorrowed)
                    {
                        if (element != null)
                        {
                            borrowCount++;
                        }
                    }

                    Console.WriteLine("{0}. {1} {2}, {3}, Number of tools on loan ({4})", i + 1, arrayRegisteredMember[i].FirstName, arrayRegisteredMember[i].LastName, arrayRegisteredMember[i].ContactNumber, borrowCount);
                    parallelBorrowNumbers.Add(borrowCount);
                    borrowCount = 0;
                }

                Console.WriteLine();
                Console.WriteLine("===========================================");
                Console.WriteLine();
                if (parallelBorrowNumbers.Count() == 1)
                {
                    Console.Write("Please make a selection( 1 , or 0 to exit): ");
                }
                else
                {
                    Console.Write("Please make a selection(1 - {0}, or 0 to exit): ", parallelBorrowNumbers.Count());
                }
                string k = Console.ReadLine();
                int selection;
                bool success = Int32.TryParse(k, out selection);
                while (success == false | selection > parallelBorrowNumbers.Count() | selection < 0)
                {
                    Console.WriteLine("Please enter a valid menu option");
                    k = Console.ReadLine();
                    success = Int32.TryParse(k, out selection);
                }
                if (selection != 0)
                {
                    selection--;
                    numberOfBorrowed = parallelBorrowNumbers[selection];
                    return arrayRegisteredMember[selection];
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No members to select");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("===========================================");
            }
            return null;

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
            if (userFeedback.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(userFeedback);
                Console.ResetColor();
                Console.WriteLine();
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
    }
}
