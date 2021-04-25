using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class ToolLibrarySystem : iToolLibrarySystem
    {
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
            throw new NotImplementedException();
        }

        public void borrowTool(Member aMember, Tool aTool)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void displayBorrowingTools(Member aMember)
        {
            throw new NotImplementedException();
        }

        public void displayTools(string aToolType)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
    /*
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
