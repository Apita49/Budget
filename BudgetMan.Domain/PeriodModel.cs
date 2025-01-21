namespace BudgetMan.Domain
{
    public class PeriodModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsActual { get; set; }
        public decimal InitialAmount { get; set; }
        public decimal ActualAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}