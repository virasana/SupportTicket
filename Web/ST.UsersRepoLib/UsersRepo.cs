using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ST.SharedHelpersLib.EntityFramework;
using ST.SharedHelpersLib.Exceptions;
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

        public User SignUp(User user)
        {
            if (UserExists(user))
            {
                throw new SupportTicketUserAlreadyExistsException();
            }

            AddUser(user);

            var result = GetUser(user.Username);
            result = ClearUserSecrets(result);
            return result;
        }

        public User Get(int id)
        {
            var result = EfHelpers.Execute<UsersDbContext, User>(
                _connectionString, ctx =>
                {
                    var theUser = ctx.Users.FirstOrDefault(u => u.Id.Equals(id));
                    theUser = ClearUserSecrets(theUser);
                    return theUser;
                });
            return result;
        }

        private User ClearUserSecrets(User user)
        {
            user.Password = null;
            user.Token = "";
            return user;
        }

        private void AddUser(User user)
        {
            try
            {
                using (var ctx = new UsersDbContext(_connectionString))
                {
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new SupportTicketApplicationException("Could not add user to the database.", 
                    new SupportTicketDatabaseException(ex));
            }
        }

            private bool UserExists(User user)
        {
            return GetUser(user.Username) != null;
        }

        private static User GetUser(string userName)
        {
            var result = EfHelpers.Execute<UsersDbContext, User>(_connectionString,
            ctx => {
                var theUser = ctx.Users.FirstOrDefault(u =>
                    u.Username.Equals(userName));

                return theUser;
            });

            return result;
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
