namespace Library
{
    using System;
    using System.Collections.Generic;

    public class Employee : Librarian
    {
        public Employee(string firstName, string lastName, string registration, string passport)
            :base(firstName, lastName, registration, passport)  
        {

        }

        static private LibBook FindBook(List<LibBook> books, string name, string author)
        {   
            var found = books.Find(book => book.name == name & book.author == author);

            if (found is null)
            {
                throw new Exception("Book is not found");
            }
            else
            {
                return found;
            }
        }

        public override void AddBook(List<LibBook> books, LibBook book)
        {
            books.Add(book);
        }

        public override void DisposeBook(List<LibBook> books, int isbn)
        {
            var found = books.Find(book => book.isbn == isbn);

            if (found is null)
            {
                throw new Exception("Book is not found");
            } else
            {
                books.Remove(found);
            }
        }

        public override LibBook? IssueBook(List<LibBook> books, string name, string author, RegisteredReader reader)
        {
            try
            {
                var found = FindBook(books, name, author);
                reader.AddToTaken(found);
                found.available = false;
                return found;
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public override void ReceiveBook(LibBook book, RegisteredReader reader)
        {
            try
            {
                reader.RemoveFromTaken(book);
                book.available = true;
            } catch (Exception)
            {
                throw;
            }
        }

        public override void RegisterReader(Reader person, List<RegisteredReader> readers, int id)
        {
            RegisteredReader reader = new(person, id);
            readers.Add(reader);
        }

        public override RegisteredReader FindReader(List<RegisteredReader> readers, Reader reader)
        {
            var found = readers.Find(registered => registered.FirstName == reader.FirstName &
            registered.LastName == reader.LastName &
            registered.Registration == reader.Registration);

            if (found is null)
            {
                throw new Exception("Person is not registered");
            }
            else
            {
                return found;
            }
        }

        public override List<LibBook> ViewReadersBook(RegisteredReader reader)
        {
            return reader.ShowTaken();
        }
    }
}
