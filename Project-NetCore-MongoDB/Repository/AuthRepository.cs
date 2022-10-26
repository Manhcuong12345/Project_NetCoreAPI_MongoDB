using Project_NetCore_MongoDB.Repository.Interface;
using Project_NetCore_MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Project_NetCore_MongoDB.Dto;
using Project_NetCore_MongoDB.Common;
using MongoDB.Bson;
using DnsClient;

namespace Project_NetCore_MongoDB.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMongoCollection<Users> _collection;
        private readonly DbConfiguration _settings;
        public AuthRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<Users>("user");
        }

        public async Task<Users> CreateAsync(Users user)
        {
            await _collection.InsertOneAsync(user).ConfigureAwait(false);
            return user;
        }

        public Task<List<Users>> GetAllAsync()
        {
            return _collection.Find(c => true).ToListAsync();
        }

        //public Task<Users> LoginUser(string email,string password)
        public Task<Users> LoginUser(string email)
        {
            //string result = "";
            // var filter = Builders<Users>.Filter.Eq("name", name);
            // var results = _collection.Find(filter).ToList().First();

            //var builder = Builders<Users>.Filter;
            ///var filter = builder.Eq("Name", name);
            //if (BCrypt.Net.BCrypt.Verify(password, results.Password))
            //{
            //     result = results.Name;
            //  }

            // return _collection.Find(result).FirstOrDefaultAsync();
            // }

            return _collection.Find(x => x.Email == email).FirstOrDefaultAsync();

            //return _collection.Find(filter).FirstOrDefaultAsync();
            // var data = _collection.Find(x => x.Email == user.Email);

            //bool isVaild = BCrypt.Net.BCrypt.Verify(user.Pa);

            //var filter = Builders<Users>.Filter.
            //And(Builders<Users>.Filter.Eq(x => x.Email == user.Email));



        }
    }
    }
