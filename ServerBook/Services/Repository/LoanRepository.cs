using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerBook.Data;
using ServerBook.Models;
using ServerBook.Services;

namespace ServerBook.Services
{
    public class LoanRepository : ILoanRepository
    {

        private readonly BaseContext _context;
        public LoanRepository(BaseContext context){
            _context = context;
        } 
        public void CreateLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
        }
    }
}