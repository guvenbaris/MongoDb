using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DapperDataAccess.DataAccess.Concrete;
using Domain.Entities;
using MongoDataAccess.DataAccess.Concrete;

namespace DataCreate
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Read User.json 

            JsonDataHelper<UserModel> dateHelper = new JsonDataHelper<UserModel>();

            var users = dateHelper.ReadJsonFile("User.json");

            //Dapper Repository configuration
            DpUserRepository dapperRepository = new DpUserRepository(new SqlConnection("Server=.; Database=choredb;Trusted_Connection=True;"));


            //We just have 1000 record but we need to 1.000.000 record so we will repeat all record  1000 times and we will add to db
            //for (int i = 0; i < 900; i++)
            //{
            //    foreach (var user in users)
            //    {
            //        await dapperRepository.Create(user);
            //    }
            //}


            //Mongo Repository configuration
            MongoUserRepository mongoRepository = new MongoUserRepository();

            //for (int i = 0; i < 900; i++)
            //{
            //    foreach (var user in users)
            //    {
            //        await mongoRepository.Create(user);
            //    }

            //    Console.WriteLine("1000 added");
            //}

            Console.WriteLine("Added");
        }

    }
}
