namespace Library
{
    public class ReaderChild : Reader
    {
        private ILibrary? library;
        public ReaderChild(string firstName, string lastName, string registration) 
            : base(firstName, lastName, registration)
        {
        }

        public override void Register(ILibrary library)
        {
            library.Register(this);
            this.library = library;
        }

        public override LibBook? TakeBook(string name, string author)
        {
            if (library is null) return null;
            return this.library.IssueBook(name, author, this);
        }

        public override void ReturnBook(LibBook book)
        {
            if (library is null) return;
            this.library.ReceiveBook(book, this);
        }

    }
}
