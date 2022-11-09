using System;
using System.Collections.Generic;

namespace Assignment0
{
    interface IDesign
    {
        Designer Designer { set; get; }
        string Name { set; get; }
        DesignType DesignType { get;}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    enum DesignType
    {
        ComputerSchematic,
        BluePrint
    }


    class Designer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        private List<DesignType> types; //list to store designtypes
        private List<IDesign> designs;  //list to store designs

        Designer():this("no last name")
        {

        }

        Designer(string lastName) :this(lastName, "No first name")
        {

        }

        //designated constructor
        Designer(string lastName, string firstName)
        {
            LastName = lastName;
            FirstName = firstName;
            types = new List<DesignType>();
            designs = new List<IDesign>();
        }


        public void AddDesignType(DesignType type)
        {
            //method to add design
            types.Add(type);
        }

        public void addDesign(IDesign design)
        {
            if(types.Contains(design.DesignType))
            {
                designs.Add(design);
            }
        }

        public List<DesignType> getTypes()
        {
            return new List<DesignType>(types);
        }

        public List<IDesign> getDesigns()
        {
            return new List<IDesign>(designs);
        }

        override
        public string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
    class ComputerSchematic : IDesign
    {
        public Designer Designer { set; get; }
        public string Name { set; get; }
        public DesignType DesignType 
        { get 
            {
                return DesignType.ComputerSchematic;

            } 
        }
        int NumberOfChips { get; set; }

        public ComputerSchematic(): this("No Name")
        {

        }
        public ComputerSchematic(string name): this(name, 1)
        {

        }
        public ComputerSchematic(string name, int numberOfChips ): this(name, numberOfChips, null)
        {

        }
        //Desginated Contructor
        public ComputerSchematic(string name, int numberOfChips, Designer designer)
        {
            Name = name;
            Designer = designer;
            NumberOfChips = numberOfChips;
        }

       
        public string ToString()
        {
            return Name + " width " + NumberOfChips + " chips.";
        }
    }
    class Blueprint : IDesign
    {
        public Designer Designer { set; get; }
        public string Name { set; get; }
        public DesignType DesignType
        {
            get
            {
                return DesignType.BluePrint;

            }
        }

        public float Width { get; set; }
        public float Height { get; set; }

        public Blueprint() : this("No Name")
        {

        }
        public Blueprint(string name) : this(name, 1, 1)
        {

        }
        public Blueprint(string name, float width, float height) : this(name, width, height, null)
        {

        }
        /**
         * Designated Constructor
         */
        public Blueprint(string name, float width, float height, Designer designer)
        {
            Name = name;
            Width = width;
            Height = height;
            Designer = designer;
        }
        override
        public string ToString()
        {
            return Name + "Height = " + Height + "Width = " + Width;
        }
    }
}
