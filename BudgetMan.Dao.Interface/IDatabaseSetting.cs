namespace BudgetMan.Dao.Interface
{
    public interface IDatabaseSetting
    {
        string PeriodCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
