namespace Library
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Registration { get; set; }
        public string Passport { get; set; }

        protected Person(string firstName, string lastName, string registration, string passport = "Undefined")
        {
            FirstName = firstName;
            LastName = lastName;
            Registration = registration;
            Passport = passport;
        }
    }
}
