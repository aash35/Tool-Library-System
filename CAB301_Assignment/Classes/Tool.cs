using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Tool : iTool, IComparable<Tool>
    {
        private string name;
        private int quantity;
        private int availablequantity;
        private int noborrowings;
        private MemberCollection members = new MemberCollection();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public int AvailableQuantity
        {
            get { return availablequantity; }
            set { availablequantity = value; }
        }
        public int NoBorrowings
        {
            get { return noborrowings; }
            set { noborrowings = value; } 
        }
        public MemberCollection GetBorrowers
        {
            get { return members; }
        }

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
                members.add(aMember);
                NoBorrowings++;
                AvailableQuantity--;
            }
        }

        public void deleteBorrower(Member aMember)
        {
            members.delete(aMember);
            AvailableQuantity++;
        }

        public override string ToString()
        {
            string returnStatement = String.Format("Name: {0}\nAvailable Quantity: {1}", Name, AvailableQuantity);
            return returnStatement;
        }

        public int CompareTo(Tool other)
        {
            if (this.name.CompareTo(other.name) < 0)
            {
                return -1;
            }
            else if (this.name.CompareTo(other.name) == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
