using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Tool : iTool
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int NoBorrowings { get; set; }
        public MemberCollection GetBorrowers { get; }

        public Tool(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
            //default AvailableQuantity is the total quantity
            AvailableQuantity = quantity;
            //default there are no borrowings
            NoBorrowings = 0;
        }


        public void addBorrower(Member aMember)
        {
            if(AvailableQuantity > 0)
            {
                GetBorrowers.add(aMember);
                NoBorrowings++;
                AvailableQuantity--;
            }
            else
            {
                string message = "None available to borrow";
            }
        }

        public void deleteBorrower(Member aMember)
        {
            GetBorrowers.delete(aMember);
            AvailableQuantity++;
        }
        public override string ToString()
        {
            string returnStatement = String.Format("Name: {0}\nAvailable Quantity: {1}", Name, AvailableQuantity);
            return returnStatement;
        }
    }
}
