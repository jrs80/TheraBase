

namespace TherapistDatabase.Models
{

    public enum GenderCategories { Male, Female, Nonbinary };
    public class Provider
    {

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialties { get; set; } //TODO: maybe make this a special type?
        //public bool Availability { get; set; }
        public int Age { get; set; }
        //public char Gender { get; set; }
        public GenderCategories Gender { get; set; }
        public Provider()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
            Specialties = "Unknown";
        }
    }
}
