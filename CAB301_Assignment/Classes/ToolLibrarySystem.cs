using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class ToolLibrarySystem : iToolLibrarySystem
    {
        private ToolCollection[] gardeningTools  = new ToolCollection[5];
        private ToolCollection[] flooringTools = new ToolCollection[6];
        private ToolCollection[] fencingTools = new ToolCollection[5];
        private ToolCollection[] measuringTools = new ToolCollection[6];
        private ToolCollection[] cleaningTools = new ToolCollection[6];
        private ToolCollection[] paintingTools = new ToolCollection[6];
        private ToolCollection[] electronicTools = new ToolCollection[5];
        private ToolCollection[] electricityTools = new ToolCollection[5];
        private ToolCollection[] automotiveTools = new ToolCollection[6];



        private MemberCollection membersOfLibrary { get; } = new MemberCollection();

        //Constructor
        public ToolLibrarySystem()
        {
            //create all the ToolCollections needed for the Categories
            initialiseToolCollections();

        }

        private void initialiseToolCollections()
        {
            for(int i = 0;i < 5; i++)
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
            flooringTools[6] = new ToolCollection();
            measuringTools[6] = new ToolCollection();
            cleaningTools[6] = new ToolCollection();
            paintingTools[6] = new ToolCollection();
            automotiveTools[6] = new ToolCollection();
        }

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
