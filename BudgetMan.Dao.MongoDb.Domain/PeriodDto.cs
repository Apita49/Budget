namespace BudgetMan.Dao.MongoDb.Domain
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;
    using System;
    using System.Collections.Generic;
    using BudgetMan.Domain;

    public class PeriodDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsActual { get; set; }
        public decimal InitialAmount{ get; set; }
        public decimal ActualAmount{ get; set; }
        public decimal FinalAmount{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
