using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinControl.Configurations;
using FinControl.Models;
using MongoDB.Driver;


namespace FinControl.Services
{
    public class UsuariosService
    {

        private readonly IMongoCollection<Usuarios> usuarioRepository;

        public UsuariosService(IFinControlDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            usuarioRepository = database.GetCollection<Usuarios>(settings.FinControlCollectionName);
        }

        public List<Usuarios> Get() =>
           usuarioRepository.Find(user => true).ToList();

        public Usuarios Get(string id) =>
            usuarioRepository.Find<Usuarios>(user => user.Id == id).FirstOrDefault();

        public Usuarios Create(Usuarios user)
        {
            usuarioRepository.InsertOne(user);
            return user;
        }

        public void Update(string id, Usuarios userIn) =>
            usuarioRepository.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(Usuarios userIn) =>
            usuarioRepository.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            usuarioRepository.DeleteOne(user => user.Id == id);
        
    }
}
