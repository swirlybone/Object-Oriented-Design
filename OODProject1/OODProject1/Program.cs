using System;

namespace OODProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Robert");
            //student.FirstName = "Robert";
            //student.LastName = "Plimrose";
            string theName = student.FirstName;
            string theOther = student.LastName;
            Console.WriteLine("Hello " + student.FirstName + " " + student.LastName);
        }
    }

    class Student
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

        public Student() : this("No First Name")
        {
        }

        public Student(string aFirstName) : this(aFirstName, "No Last Name")
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
    }

}
