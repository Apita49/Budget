namespace BudgetMan.Dao.Interface
{
    using MongoDB.Driver;
    using MongoDb.Domain;
    public interface IDatabaseContext
    {
        IMongoCollection<PeriodDto> BudgetMan { get; }
    }
}