using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerBook.Models.Dtos
{
    public class UserRegisterDto
    {
        public required string Name { get; set; }
        public required string PassWord { get; set; }
        public required string Email { get; set; }
        public User ConvertirARegisterDto(UserRegisterDto userRegisterDto){
            return  new(){
                Name = userRegisterDto.Name,
                Password = userRegisterDto.PassWord,
                Email  = userRegisterDto.Email
            };
        }
    }
}