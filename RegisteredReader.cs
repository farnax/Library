namespace Library
{
    using System;
    using System.Collections.Generic;

    public class RegisteredReader : Person
    {
        public int id;

        private readonly List<LibBook> takenBooks = new();

        public RegisteredReader(Reader person, int id)
            :base(person.FirstName, person.LastName, person.Registration, person.Passport)
        {
            this.id = id;
        }

        public void AddToTaken(LibBook book)
        {
             takenBooks.Add(book);
        }

        public void RemoveFromTaken(LibBook book)
        {
            var found = takenBooks.Find(taken => taken.isbn == book.isbn);

            if (found is null)
            {
                throw new Exception("This book does not belong to this library");
            }
            else
            {
                takenBooks.Remove(found);
            }
        }

        public List<LibBook> ShowTaken()
        {
            return takenBooks;
        }
    }
}
