using System;


namespace privateconstructorex

{

    using System;

    namespace privateconstructorex

    {

        public class Student

        {

            private Student(out string name, out int age)

            {

                name = "Swaroopa";

                age = 22;

                Console.WriteLine("Private constructor");

            }



            public static Student Create(out string name, out int age)

            {

                return new Student(out name, out age);

            }

        }

        class Privateconst

        {

            static void Main()

            {

                string myName;

                int myAge;

                Student s = Student.Create(out myName, out myAge);

                Console.WriteLine("From out parameters:");

                Console.WriteLine($"Name: {myName}");

                Console.WriteLine($"Age: {myAge}");

            }

        }

    }

}

