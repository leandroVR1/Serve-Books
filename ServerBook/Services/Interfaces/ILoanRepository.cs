using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerBook.Models;

namespace ServerBook.Services
{
    public interface ILoanRepository
    {
        void CreateLoan(Loan loan);
    }
}