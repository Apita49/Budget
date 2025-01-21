namespace BudgetMan.Dao.Interface
{
    using Domain;
    public interface IBudgetManDao
    {

        /// <summary>
        /// Service - GetActual()
        /// </summary>
        /// <returns></returns>
        PeriodModel? GetActual();
        /// <summary>
        /// Service - CreatePeriod()
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        PeriodModel CreatePeriod(PeriodModel body);
    }
}
