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

        //might not need these two
        private string[] categories;
        private string[][] toolTypes;
        private Member loginUser = null;

        public UI(ToolLibrarySystem toolLibrarySystem, string[] categoryStrings, string[][] toolTypeStrings )
        {
            systemLibrary = toolLibrarySystem;
            
            //might not need these two
            categories = categoryStrings;
            toolTypes = toolTypeStrings;

            //need to add to systemLibrary too
            registerMembers.add(new Member("user","user","12321","0000"));

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
            foreach(Member element in members)
            {
                string usernameCheck = element.LastName + element.FirstName;

                if (username.Equals(usernameCheck) & password.Equals(element.PIN))
                {
                    loginUser = element;
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

                }
                else if (k.Equals("5"))
                {

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
                else
                {
                    staffMenuLoop = true;

                }

            } while (staffMenuLoop == true);

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
