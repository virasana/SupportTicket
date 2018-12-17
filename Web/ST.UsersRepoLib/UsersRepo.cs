using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ST.SharedHelpersLib.Extensions;
using ST.SharedInterfacesLib;
using ST.SharedUserEntitiesLib;

namespace ST.UsersRepoLib
{
    public class UsersRepo : ISTUsersRepo
    {
        private static string _connectionString;

        public void Initialise(string connectionString)
        {
            _connectionString = connectionString;
            MigrateDb(connectionString);
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            using (var ctx = new UsersDbContext(_connectionString))
            {
                var user = new User()
                {
                    FirstName = "Joe",
                    LastName = "Soap",
                    Password = "test",
                    Username = "test",
                    Token = string.Empty
                };

                ctx.Users.AddOrUpdate(user);

                ctx.SaveChanges();
            }
        }

        private static void MigrateDb(string connectionString)
        {
            using (var context = new UsersDbContext(connectionString))
            {
                context.Database.Migrate();
            }
        }

        public User GetUserMatching(string userName, string password)
        {
            using (var ctx = new UsersDbContext(_connectionString))
            {
                return ctx.Users.FirstOrDefault(user =>
                    user.Username.Equals(userName)
                    && user.Password.Equals(password));
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var ctx = new UsersDbContext(_connectionString))
            {
                var result = ctx.Users.Select(u =>
                    new User()
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Username = u.Username
                    }
                );
                return result;
            }
        }
    }
}
