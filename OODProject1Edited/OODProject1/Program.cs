using System;

namespace OODProject1
{
    interface IStudent
    {
        string FirstName { set; get; }
        string LastName { set; get; }
        string FullName { set; get; }
        int Age { set; get; }
        int CreditHours { set; get; }
        Year Class { get; }
    }
    class Program
    {
        

        static void Main(string[] args)
        {
            Student student = new Student("Robert");
            //student.FirstName = "John";
            //student.LastName = "Smith";
            student.FullName = "Andrew Smith";
            string theName = student.FirstName;
            string theOther = student.LastName;
            Console.WriteLine("Hello " + student.FirstName + " " + student.LastName);
            Console.WriteLine("Your full name is " + student.FullName);
            Console.WriteLine("Your first name is " + student.FirstName);
            Console.WriteLine("Your last name is " + student.LastName);
            Console.WriteLine("The default method ToString for student is " + student);

            IShape[] shapes = new IShape[4];

            shapes[0] = new Triangle("triangle1", 4.5f, 78);
            shapes[1] = new Square("square1", 6.7f, 93);
            shapes[2] = new Triangle("triangle2", 5.6f, 45);
            shapes[3] = new Square("square2", 7.8f, 110);

            foreach(IShape shape in shapes)
            {
                Console.WriteLine("The name of the shape is " + shape.Name);
            }
        }
    }

    enum Year
    {
        Freshman,
        Sophomore,
        Junior,
        Senior
    }

    class Student : IStudent
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
        public int Age { set; get; }
        
        public string FullName {get { return this.FirstName + " " + this.LastName; }
            set
            {
                string[] parsedString;
                if (value.Contains(","))
                {
                    char[] separatorStrings = {  ',',' '};
                    parsedString = value.Split(separatorStrings);
                    Console.WriteLine("The number of tokens is " + parsedString.Length);
                    FirstName = parsedString[1].Trim();
                    LastName = parsedString[0].Trim();
                    //Console.WriteLine("The First Name is '" + FirstName + "'");
                }
                else
                {
                    parsedString = value.Split(" ");
                    FirstName = parsedString[0];
                    LastName = parsedString[1];
                }
            }
        }
       
        public int CreditHours { set; get; }
        public Year Class
        {
            get
            {
                /*
                if(CreditHours < 30)
                {
                    return Year.Freshman;
                }
                else if(CreditHours < 60)
                {
                    return Year.Sophomore;
                }
                else if(CreditHours < 90)
                {
                    return Year.Junior;
                }
                else
                {
                    return Year.Senior;
                }
                */
                return (Year)((int)Math.Clamp(CreditHours,0,119) / 30);
            }
        }

        public Student() : this("There is no First Name")
        {
        }

        public Student(string aFirstName) : this(aFirstName, "There is no Last Name")
        {
        }

        public Student(string aFirstName, string aLastName) : this(aFirstName, aLastName, 0)
        {
        }

        /**
         * Designated Constructor
         */
        public Student(string aFirstName, string aLastName, int theAge)
        {
            FirstName = aFirstName;
            LastName = aLastName;
            Age = theAge;
        }

        override
        public string ToString()
        {
            return FullName + ", age = " + Age;
        }
    }

}
