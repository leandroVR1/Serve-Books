using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerBook.Models
{
    public class Loan
    {
        public int Id {get; set;}
        public string? Description {get; set;}
        public int BookId {get; set;}
        public int UserId {get; set;}
        public DateTime DeliveryDate {get; set;}
        public DateTime DateLoan {get; set;}
    }
}