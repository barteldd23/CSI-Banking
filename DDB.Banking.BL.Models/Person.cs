namespace DDB.Banking.BL.Models
{
    public class Person
    {
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public String FullName { get { return FirstName + " " + LastName; }  }
        public int Age { get{ return DateTime.Now.Subtract(BirthDate).Days / 365; } }
    }
}