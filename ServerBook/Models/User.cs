using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerBook.Models
{
    public class User
    {
        public int Id {get; set;}
        public String? Name {get; set;}
        public String? Email {get; set;}
        public String? Password {get; set;}
        public int RoleId {get; set;}
        public Role Role { get; set; }

    }
}