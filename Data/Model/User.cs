using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Въведете валидно потребителско име!")]
        public string Username { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage ="Моля въведете паролата си!")]
        public string Password { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

    }
}
