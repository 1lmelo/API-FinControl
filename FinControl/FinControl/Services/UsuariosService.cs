using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinControl.Configurations;
using FinControl.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace FinControl.Services
{
    public class UsuariosService
    {

        private static Random random = new Random();

        private readonly IMongoDatabase _database = null;

        public UsuariosService(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Usuarios> Usuarios
        {
            get
            {
                return _database.GetCollection<Usuarios>("Usuarios");
            }
        }

        public List<Usuarios> FindAll() =>
           Usuarios.Find(user => true).ToList();

        public Usuarios Find(string id) =>
            Usuarios.Find<Usuarios>(user => user.Id == id).FirstOrDefault();

        public Usuarios Save(Usuarios user)
        {
            Usuarios.InsertOne(user);
            return user;
        }

        public void Update(string id, Usuarios userIn)
        {
            Usuarios.ReplaceOne(user => user.Id == id, userIn);
        }

        public void Remove(Usuarios userIn)
        {
            Usuarios.DeleteOne(user => user.Id == userIn.Id);
        }

        public void Remove(string id)
        {
            Usuarios.DeleteOne(user => user.Id == id);
        }
    
    }
}
