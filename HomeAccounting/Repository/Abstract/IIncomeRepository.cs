using Models.Entities;
using System.Collections.Generic;

namespace Repository.Abstract
{
    interface IIncomeRepository
    {
        void Insert(Income income);
        void Delete(long Id);
        void Update(Income income);
        List<Income> GetAll();
        Income GetByID(long id);
    }
}
