using Repository.Abstract;
using Repository.Concrete.Operations;

namespace Repository
{
    public static class Factory
    {
        public static IRepository GetFactory(string invariant)
        {
            switch (invariant)
            {
                case "incomedb":
                    return new IncomeRepository();
                case "expensedb":
                    return new ExpenseRepository();
                default:
                    return null;
            }
        }
    }
}
