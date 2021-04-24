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

        public Tool(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
            //default AvailableQuantity is the total quantity
            AvailableQuantity = quantity;
            //default there are no borrowings
            NoBorrowings = 0;
        }

        public MemberCollection GetBorrowers { get; }

        public void addBorrower(Member aMember)
        {
            GetBorrowers.add(aMember);
        }

        public void deleteBorrower(Member aMember)
        {
            GetBorrowers.delete(aMember);
        }
        public override string ToString()
        {
            string returnStatement = String.Format("Name: {0}\nAvailable Quantity: {1}", Name, Quantity);
            return returnStatement;
        }
    }
}
