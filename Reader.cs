namespace Library
{
    public abstract class Reader : Person
    {
        protected Reader(string firstName, string lastName, string registration, string passport = "Undefined")
            : base(firstName, lastName, registration, passport)
        {
        }
        public abstract void Register(ILibrary library);
        public abstract LibBook? TakeBook(string name, string author);
        public abstract void ReturnBook(LibBook book);
    }
}
