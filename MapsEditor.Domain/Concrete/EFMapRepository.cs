using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsEditor.Domain.IRepository;
using MapsEditor.Domain.Concrete;
using MapsEditor.Domain.Entitties;
using System.Data.Entity;

namespace MapsEditor.Domain.Concrete
{
    public class EFMapRepository:IRepository<Map>
    {

        private MapContext db;

        public EFMapRepository(MapContext context)
        {
            this.db = context;
        }

        public Map Get(int id)
        {

            return db.Maps.Find(id);
        }

        public void Create(Map map)
        {
            db.Maps.Add(map);
        }

        public void Update(Map map)
        {

            db.Entry(map).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Map map = db.Maps.Find(id);
            if (map != null)
                db.Maps.Remove(map);
        }


        public IEnumerable <Map> Search(string Name)
        {

            return db.Maps.Where(n => n.Name == Name).ToList();

        }


        public IEnumerable<Map> Find(string Name)
        {

            return db.Maps.Where(n => n.UserName == Name).ToList();

        }

        public void Save()
        {
            db.SaveChanges();
        }

    }

}

