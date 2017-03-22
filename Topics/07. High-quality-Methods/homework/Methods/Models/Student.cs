using System;

namespace Task_1._Quality_Methods.Models
{
    public class Student
    {
        public Student(string first, string last, string bd, string other)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Birthday = bd;
            this.OtherInfo = other;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string OtherInfo { get; }

        public string Birthday { get; }

        public bool IsOlderThan(Student otherStudent)
        {
            var firstDate = DateTime.Parse(this.Birthday);
            var secondDate = DateTime.Parse(otherStudent.Birthday);
            var now = DateTime.Today;
            var firstAge = now.Year - firstDate.Year;
            var secondAge = now.Year - secondDate.Year;
            var isOlder = firstAge > secondAge;
            return isOlder;
        }
    }
}
