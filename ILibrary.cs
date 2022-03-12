namespace Library
{
    public interface ILibrary
    {
        public void Register(Reader reader);
        public LibBook? IssueBook(string name, string author, Reader reader);
        public void ReceiveBook(LibBook book, Reader reader);
    }
}
