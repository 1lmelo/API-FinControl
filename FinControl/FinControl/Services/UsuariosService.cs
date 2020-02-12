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
        private static Random random = new Random();


        public UsuariosService(IFinControlDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            usuarioRepository = database.GetCollection<Usuarios>(settings.FinControlCollectionName);
        }

        public List<Usuarios> FindAll() =>
           usuarioRepository.Find(user => true).ToList();

        public Usuarios Find(string id) =>
            usuarioRepository.Find<Usuarios>(user => user.Id == id).FirstOrDefault();

        public Usuarios Save(Usuarios user)
        {
            user.Id = GetRandomHexNumber(24);
            usuarioRepository.InsertOne(user);
            return user;
        }

        public void Update(string id, Usuarios userIn) 
        {
            usuarioRepository.ReplaceOne(user => user.Id == id, userIn);
        }

        public void Remove(Usuarios userIn)
        {
            usuarioRepository.DeleteOne(user => user.Id == userIn.Id);
        }

        public void Remove(string id)
        {
            usuarioRepository.DeleteOne(user => user.Id == id);
        }
        private static string GetRandomHexNumber(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }

    }
}
