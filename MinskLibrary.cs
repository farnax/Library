namespace Library
{
    using System;
    using System.Collections.Generic;

    public class MinskLibrary : ILibrary
    {
        protected readonly List<Librarian> librarians = new();
        static readonly List<RegisteredReader> readers = new();
        static readonly List<LibBook> books = new();

        static int readerId = 1;
        static int isbn = 1;
        public static int ReaderId
        {
            get => readerId;
            set => readerId = value;

        }

        public static int Isbn
        {
            get => isbn;
            set => isbn = value;

        }

        public void HireLibratian(Employee person)
        {
            person.available = true;
            this.librarians.Add(person);
        }

        public void DismissLibrarian(Employee person)
        {
            try
            {
                var found = this.librarians.Find(librarian => librarian.Passport == person.Passport);
                if (found is null)
                {
                    throw new Exception("Librarian not found");
                }
                this.librarians.Remove(found);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

         protected Librarian FindLibrarian()
        {
            var found = this.librarians.Find(librarian => librarian.available);

            if (found is null)
            {
                throw new Exception("No librarians available");
            }
            else
            {
                return found;
            }
        }

        public void AddBook(Book book)
        {
            try
            {
                var found = FindLibrarian();
                LibBook libBook = new(book, Isbn);
                found.AddBook(books, libBook);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DisposeBook(int isbn)
        {
            try
            {
                var found = FindLibrarian();
                found.DisposeBook(books, isbn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public List<LibBook> ExhibitBooks()
        {
            return books.FindAll(book => book.available);
        }

        public void Register(Reader reader)
        {
            try
            {
                var found = FindLibrarian();

                found.RegisterReader(reader, readers, ReaderId);
                ReaderId += 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public LibBook? IssueBook(string name, string author, Reader reader)
        {
            try
            {
                var librarian = FindLibrarian();
                var registered = librarian.FindReader(readers, reader);
                var exhibitedBooks = ExhibitBooks();
                return librarian.IssueBook(exhibitedBooks, name, author, registered);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public void ReceiveBook(LibBook book, Reader reader)
        {
            try
            {
                var librarian = FindLibrarian();
                var registered = librarian.FindReader(readers, reader);
                librarian.ReceiveBook(book, registered);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public List<LibBook>? ViewReadersBook(Reader reader)
        {
            try
            {
                var librarian = FindLibrarian();
                var registered = librarian.FindReader(readers, reader);
                return librarian.ViewReadersBook(registered);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

    }
}
