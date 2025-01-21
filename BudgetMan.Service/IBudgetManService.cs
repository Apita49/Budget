namespace BudgetMan.Service
{
    using Domain;
    public interface IBudgetManService
    {
        /// <summary>
        /// Services for BudgetMan Controller
        /// </summary>
        /// <returns></returns>
        ///
        PeriodModel GetActual();
    }
}