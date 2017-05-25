using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MapsEditor.Domain.Entitties;
namespace MapsEditor.Domain.Concrete
{
   public class MapContext:DbContext
    {

        public DbSet<Map> Maps { get; set; }
        public DbSet<Login> Logins { get; set; }

    }
}
