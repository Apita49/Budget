namespace BudgetMan.Dao.MongoDb
{
    using Domain;
    using Interface;
    using BudgetMan.Domain;
    using MongoDB.Driver;
    using System.Linq;

    public class BudgetManDao : IBudgetManDao
    {
        private readonly IDatabaseContext _context;
        public BudgetManDao(IDatabaseSetting injectedSettings)
        {
            _context = new DatabaseContext(injectedSettings);
        }

        /// <summary>
        /// GetActual Period, only for admin
        /// </summary>
        /// <returns></returns>
        public PeriodModel? GetActual()
        {
            PeriodDto period = _context.BudgetMan.Find(period => period.IsActual).FirstOrDefault();
            return period == null ? null : BudgetManMapper.CreatePeriod(period);
        }

        /// <summary>
        /// Service - CreatePeriod()
        /// </summary>
        /// <returns></returns>
        public PeriodModel CreatePeriod(PeriodModel body)
        {
            PeriodDto periodDto = BudgetManMapper.CreatePeriod(body);
            _context.BudgetMan.InsertOne(periodDto);
            return BudgetManMapper.CreatePeriod(periodDto);
        }
    }
}
