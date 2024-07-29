using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerBook.Models.Dtos
{
    public class UserRegisterDto
    {
        public string Name { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
    }
}