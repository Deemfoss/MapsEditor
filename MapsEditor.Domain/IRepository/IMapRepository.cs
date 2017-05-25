using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsEditor.Domain.Concrete;

namespace MapsEditor.Domain.IRepository
{
   public class IMapRepository
    {

        private MapContext db = new MapContext();
        private EFMapRepository mapRepository;
        public EFMapRepository Maps
        {
            get
            {
                if (mapRepository == null)
                    mapRepository = new EFMapRepository(db);
                return mapRepository;
            }
        }

    }
}
