using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MapsEditor.Domain.Entitties
{
    public class Map
    {[Key]
     public int Id { get; set; }
        [Required(ErrorMessage = "Input Geojson")]
        public string Name { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Input Geojson")]
        public string Description { get; set; }
    }
}
