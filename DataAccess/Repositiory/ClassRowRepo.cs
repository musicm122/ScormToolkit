using DataAccess.Contract;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositiory
{
    public class ClassRowRepo : ICrud<CourseRow>
    {
        public ClassRowRepo(SQLite.SQLiteConnection connection)
        {
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseRow> GetAll()
        {
            throw new NotImplementedException();
        }

        public CourseRow GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(CourseRow row)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(CourseRow row)
        {
            throw new NotImplementedException();
        }
    }
}
