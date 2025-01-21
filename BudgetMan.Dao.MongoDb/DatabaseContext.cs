namespace BudgetMan.Dao.MongoDb
{
    using Interface;
    using Domain;
    using MongoDB.Driver;
    public class DatabaseContext : IDatabaseContext
    {
        public DatabaseContext(IDatabaseSetting injectedSetting)
        {
            var client = new MongoClient(injectedSetting.ConnectionString);
            var database = client.GetDatabase(injectedSetting.DatabaseName);
            this.BudgetMan = database.GetCollection<PeriodDto>(injectedSetting.PeriodCollectionName);
        }
        public IMongoCollection<PeriodDto> BudgetMan { get; }
    }
}
