using System.Collections.Generic;

namespace Repository.Abstract
{
    public interface IRepository
    {
        void Insert(object item);
        void Delete(long Id);
        void Update(object item);
        List<object> GetAll();
        List<object> GetByFilter(int month, int year);
        object GetByID(long id);
    }
}
