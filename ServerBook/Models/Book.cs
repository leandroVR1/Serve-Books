using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerBook.Models
{
    public class Book
    {
        public int Id {get; set;}
        public string? Title {get; set;}
        public int AuthorId {get; set;}
        public int GenderId {get; set;}
        public DateTime PublicationDate {get; set;}
        public int NumberCopiesAvailable {get; set;}
    }
    
}