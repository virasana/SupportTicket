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
        private readonly UsersDbContext _context;

        public UsersRepo(UsersDbContext context)
        {
            _context = context;
            Initialise();
        }

        public void Initialise()
        {
            MigrateDb();
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
            var result = EfHelpers.Execute(
                _context, 
                "Could not get users from the database", 
                ctx =>
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
            EfHelpers.Execute(_context, "Could not add user to the database.", 
                ctx =>
            {
                ctx.Users.Add(user);
                ctx.SaveChanges();
                return user;
            });
        }

            private bool UserExists(User user)
        {
            return GetUser(user.Username) != null;
        }

        private User GetUser(string userName)
        {
            var result = EfHelpers.Execute(_context,
                "Could not get user from the database",
            ctx => {
                var theUser = ctx.Users.FirstOrDefault(u =>
                    u.Username.Equals(userName));

                return theUser;
            });

            return result;
        }

        private void SeedDatabase()
        {
            EfHelpers.Execute(_context,
                "Could not seed users database", ctx =>
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
                    return user;
                });
        }

        private void MigrateDb()
        {
            EfHelpers.Execute<object,UsersDbContext>(
                _context,
                "Could not migrate database.  Database operation failed.",
                ctx =>
                {
                    ctx.Database.Migrate();
                    return null;
                });
        }

        public User GetUserMatching(string userName, string password)
        {
            var result = EfHelpers.Execute(_context, 
                $"Could not get user matching {userName}. The database operation failed.",
                ctx =>
                {
                    return ctx.Users.FirstOrDefault(user =>
                        user.Username.Equals(userName)
                        && user.Password.Equals(password));
                });
            return result;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var result = EfHelpers.Execute(
                _context,
                "Could not get all users.  The database operation failed.",
                ctx =>
                {
                    var users = _context.Users.Select(u =>
                        new User()
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Username = u.Username
                        }
                    );
                    return users;
                });
            return result;
        }
    }
}
