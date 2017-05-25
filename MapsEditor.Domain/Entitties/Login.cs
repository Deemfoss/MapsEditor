using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MapsEditor.Domain.Entitties
{
   public class Login
    {
        [Key]
      public  int id { get; set; }
        public string Name { get; set; }
      
        public string Password { get; set; }
    }
}
