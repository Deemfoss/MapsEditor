using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MapsEditor.Domain.Models
{
    public class MapModel
    {
     public int Id { get; set; }
   [Required(ErrorMessage ="Input Name")]
       public string Name { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Input Geojson")]
        public string Description { get; set; }
    }
}
