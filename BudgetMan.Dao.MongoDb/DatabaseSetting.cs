namespace BudgetMan.Dao.MongoDb
{
    using Interface;
    public class DatabaseSetting : IDatabaseSetting
    {
        public string PeriodCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
