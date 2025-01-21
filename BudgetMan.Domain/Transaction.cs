namespace BudgetMan.Domain
{
    public class Transaction
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Details { get; set; } 
        public decimal Amount { get; set; }
        public bool IsExpense { get; set; }

    }
}
