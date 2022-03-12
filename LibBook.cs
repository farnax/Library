namespace Library
{
    public class LibBook : Book
    {
        public int isbn;
        public bool available = true;

        public LibBook(Book book, int isbn)
            :base(book.name, book.author)
        {
         
            this.isbn = isbn;
        }
    }
}
