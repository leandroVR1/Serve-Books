using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerBook.Models.Dtos;


namespace ServerBook.Services.Interfaces
{
    public interface IEmailRepository
    {
        public void SendEmail(EmailDto request);
    }
}