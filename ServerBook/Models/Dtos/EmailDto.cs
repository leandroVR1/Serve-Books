using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerBook.Models.Dtos
{
    public class EmailDto
    {
        public string For {get; set; } = string.Empty;
        public string Subject {get; set; } = string.Empty;
        public string Content {get; set; } = string.Empty;
    }
}