using DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRUD
{
    public class WriterCRUD
    {
        private LibraryDatabaseEntities DbContext;

        private WriterCRUD()
        {
            DbContext = new LibraryDatabaseEntities();
        }

        public List<Writer> GetAllWriters()
        {
            return this.DbContext.Writers.ToList();
        }

        public Writer GetWriter(int writerId)
        {
            return this.DbContext.Writers.Where(p => p.Id == writerId).FirstOrDefault();
        }

        public bool CreateWriter(Writer writerItem)
        {
            bool status;

            try
            {
                this.DbContext.Writers.Add(writerItem);
                this.DbContext.SaveChanges();
                status = true;
            }

            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool UpdateWriter(Writer writerItem)
        {
            bool status;

            try
            {
                Writer writer = this.DbContext.Writers.Where(p => p.Id == writerItem.Id).FirstOrDefault();
                if (writer != null)
                {
                    writer.Id = writerItem.Id;
                    writer.FirstName = writerItem.FirstName;
                    writer.LastName = writerItem.LastName;
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool DeleteBook(int writerId)
        {
            bool status;
            try
            {
                Writer writer = this.DbContext.Writers.Where(p => p.Id == writerId).SingleOrDefault();
                if (writer != null)
                {
                    this.DbContext.Writers.Remove(writer);
                    this.DbContext.SaveChanges();
                }
                status = true;
            }

            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
