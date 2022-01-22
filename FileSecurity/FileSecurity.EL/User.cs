using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSecurity.EL
{
    [Table("tblUsers")]
    public class User
    {
        [Key,Required,MinLength(10,ErrorMessage = "Minimum 10 karakter içermelidir.")]
        public string EMail { get; set; }
        [Required, MinLength(4,ErrorMessage = "Minimum 4 karakter içermelidir.")]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
