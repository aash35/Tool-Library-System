using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    interface iToolLibrarySystem
    {
        void add(iTool aTool); // add a new tool to the system

        void add(iTool aTool, int quantity); //add new pieces of an existing tool to the system

        void delete(iTool aTool); //delte a given tool from the system

        void delete(iTool aTool, int quantity); //remove some pieces of a tool from the system

        void add(iMember aMember); //add a new memeber to the system

        void delete(iMember aMember); //delete a member from the system

        void displayBorrowingTools(iMember aMember); //given a member, display all the tools that the member are currently renting


        void displayTools(string aToolType); // display all the tools of a tool type selected by a member

        void borrowTool(iMember aMember, iTool aTool); //a member borrows a tool from the tool library

        void returnTool(iMember aMember, iTool aTool); //a member return a tool to the tool library

        string[] listTools(iMember aMember); //get a list of tools that are currently held by a given member

        void displayTopTHree(); //Display top three most frequently borrowed tools by the members in the descending order by the number of times each tool has been borrowed.

    }
}
