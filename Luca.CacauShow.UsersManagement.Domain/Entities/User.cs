using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucas.CacauShow.UsersManagement.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public string Password { get; set; }
    }
}
