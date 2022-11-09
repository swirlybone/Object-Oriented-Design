using System;

namespace Assignment0
{
    interface IDesign
    {
        string Designer { set; get; }
        string DesignName { set; get; }
        Type Class { get;}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    enum Type
    {
        ComputerSchematic,
        BluePrint
    }


    class TheDesigner
    {
        private string _firstName;
        public string FirstName
        {
            set
            {
                _firstName = value;
            }
            get
            {
                return _firstName;
            }
        }
        public string LastName { set; get; }
        public string Designs { set; get; }

        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
            set
            {
                string[] parsedString;
                if (value.Contains(","))
                {
                    char[] separatorStrings = { ',', ' ' };
                    parsedString = value.Split(separatorStrings);
                    Console.WriteLine("The number of tokens is " + parsedString.Length);
                    FirstName = parsedString[1].Trim();
                    LastName = parsedString[0].Trim();
                }
                else
                {
                    parsedString = value.Split(" ");
                    FirstName = parsedString[0];
                    LastName = parsedString[1];
                }
            }
        }

        public string TypeDesigns { set; get; }
        public string DesignerDesigned { set; get; }

        /**
         * Designated Constructor
         */
        public TheDesigner(string aFirstName, string aLastName, string aTypeDesigns, string aDesignerDesigned)
        {
            FirstName = aFirstName;
            LastName = aLastName;
            TypeDesigns = aTypeDesigns;
            DesignerDesigned = aDesignerDesigned;
            
        }
        override
        public string ToString()
        {
            return "First Name: " + FirstName  + "Last Name:  " + LastName + "Designs Designers can design: " + 
                TypeDesigns + "Designs Designers have designed: " + DesignerDesigned;
        }

    }
    class ComputerSchematic : IDesign
    {
        private string _designer;
        public string Designer
        {
            set 
            {
                _designer = value;
            }
            get 
            {
                return _designer;
            }
        }
        public string DesignName { set; get; }
      
        public Type Class { get; }
        public int Circuits { set; get; }

        public ComputerSchematic(string aDesigner, string aDesignName, int aCircuits)
        {
            Designer = aDesigner;
            DesignName= aDesignName;
        }
        override
        public string ToString()
        {
            return "Designer: " + Designer + "Design Name " + DesignName + "Number of Circuits: " + Circuits;
        }
    }
    class BluePrint : IDesign
    {
        private string _designer;
        public string Designer
        {
            set
            {
                _designer = value;
            }
            get
            {
                return _designer;
            }
        }
        public string DesignName { set; get; }

        public Type Class { get; }
        public int Height { set; get; }
        public int Width { set; get; }


        /**
         * Designated Constructor
         */
        public BluePrint(string aDesignName, int aHeight, int aWidth)
        {
            DesignName = aDesignName;
            Height = aHeight;
            Width = aWidth;
        }
        override
        public string ToString()
        {
            return "Height: " + Height + "Width " + Width;
        }
    }
}
