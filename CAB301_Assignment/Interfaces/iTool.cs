using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    //The specification of Tool ADT
    interface iTool
    {

        string Name // get and set the name of this tool
        {
            get;
            set;
        }

        int Quantity //get and set the quantity of this tool
        {
            get;
            set;
        }

        int AvailableQuantity //get and set the quantity of this tool currently available to lend
        {
            get;
            set;
        }

        int NoBorrowings //get and set the number of times that this tool has been borrowed
        {
            get;
            set;
        }

        iMemberCollection GetBorrowers  //get all the members who are currently holding this tool
        {
            get;
        }

        void addBorrower(iMember aMember); //add a member to the borrower list

        void deleteBorrower(iMember aMember); //delte a member from the borrower list

        override string ToString(); //return a string containning the name and the available quantity quantity this tool 

    }

}
