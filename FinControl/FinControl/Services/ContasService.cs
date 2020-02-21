using System.Collections.Generic;
using FinControl.Configurations;
using FinControl.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinControl.Services
{
    public class ContasService
    {
        private readonly IMongoDatabase _database = null;

        public ContasService(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Contas> Contas
        {
            get
            {
                return _database.GetCollection<Contas>("Contas");
            }
        }

        public Contas Save(Contas conta)
        {
            Contas.InsertOne(conta);
            return conta;
        }

        public List<Contas> FindAll() =>
           Contas.Find(user => true).ToList();

        public Contas Find(string id) =>
        Contas.Find<Contas>(conta => conta.Id == id).FirstOrDefault();

        public void Update(string id, Contas contasIn)
        {
            Contas.ReplaceOne(user => user.Id == id, contasIn);
        }

        public void Remove(string id)
        {
            Contas.DeleteOne(user => user.Id == id);
        }
    }
}