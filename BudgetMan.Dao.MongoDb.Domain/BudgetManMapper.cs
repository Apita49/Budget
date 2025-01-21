namespace BudgetMan.Dao.MongoDb.Domain
{
    using BudgetMan.Domain;
    public class BudgetManMapper
    {
        public static PeriodModel CreatePeriod(PeriodDto period)
        {
            return new PeriodModel()
            {
                Id = period.Id,
                Name = period.Name,
                IsActual = period.IsActual,
                InitialAmount = period.InitialAmount,
                ActualAmount = period.ActualAmount,
                FinalAmount = period.FinalAmount,
                StartDate = period.StartDate,
                EndDate = period.EndDate,
                Transactions = period.Transactions
            };
        }

        public static PeriodDto CreatePeriod(PeriodModel period)
        {
            return new PeriodDto()
            {
                Id = period.Id,
                Name = period.Name,
                IsActual = period.IsActual,
                InitialAmount = period.InitialAmount,
                ActualAmount = period.ActualAmount,
                FinalAmount = period.FinalAmount,
                StartDate = period.StartDate,
                EndDate = period.EndDate,
                Transactions = period.Transactions
            };
        }
    }
}
