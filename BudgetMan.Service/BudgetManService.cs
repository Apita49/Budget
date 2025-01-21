namespace BudgetMan.Service
{
    using Dao.Interface;
    using Domain;

    public class BudgetManService : IBudgetManService
    {
        private readonly IBudgetManDao _budgetManDao;
        public BudgetManService(IBudgetManDao injectedBudgetManDao)
        {
            _budgetManDao = injectedBudgetManDao;
        }

        /// <summary>
        /// BudgetMan Services for Controller
        /// </summary>
        /// <returns></returns>

        public PeriodModel GetActual()
        {
            PeriodModel response = _budgetManDao.GetActual();
            if (response is null){
                response = CreatePeriod();
            }
            return response;
        }

        /// <summary>
        /// Creates a new Period
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public PeriodModel CreatePeriod(PeriodModel? body = null)
        {
            if (body == null)
            {
                body = CreateDefaultPeriod();
            }
            return _budgetManDao.CreatePeriod(body);
        }

        private PeriodModel CreateDefaultPeriod()
        {
            PeriodModel period = new PeriodModel();
            period.Name = "Period";
            period.IsActual = true;
            period.Transactions = new List<Transaction>();
            period.StartDate = DateTime.Now;
            period.EndDate = period.StartDate.AddDays(30);
            return period;
        }
    }
}
