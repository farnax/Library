namespace Library
{
    using System.Collections.Generic;
    abstract public class Librarian : Person
    {
        public bool available = false;
        protected Librarian(string firstName, string lastName, string registration, string passport)
            : base(firstName, lastName, registration, passport) {}
        public abstract void AddBook(List<LibBook> books, LibBook book);
        public abstract void DisposeBook(List<LibBook> books, int isbn);
        public abstract LibBook? IssueBook(List<LibBook> books, string name, string author, RegisteredReader reader);
        public abstract void ReceiveBook(LibBook book, RegisteredReader reader);
        public abstract void RegisterReader(Reader person, List<RegisteredReader> readers, int id);
        public abstract RegisteredReader FindReader(List<RegisteredReader> readers, Reader reader);
        public abstract List<LibBook> ViewReadersBook(RegisteredReader reader);
    }
}
