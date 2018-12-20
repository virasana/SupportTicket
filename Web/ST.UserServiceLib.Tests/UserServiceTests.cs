using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ST.SharedHelpersLib.Exceptions;
using ST.SharedInterfacesLib;
using ST.SharedUserEntitiesLib;
using ST.UsersRepoLib;
using Xunit;

namespace ST.UserServiceLib.Tests
{
    public class UserServiceTests
    {
        public class TestEnvironment : ISTEnvironment
        {
            public string JWTSecret => "Blah";
        }

        [Fact]
        public void Signup_Adds_New_User()
        {
            var options = new DbContextOptionsBuilder<UsersDbContext>()
                .UseInMemoryDatabase(databaseName: "GetUsers_Returns_Users")
                .Options;


            // Run the test against one instance of the context
            using (var context = new UsersDbContext(options))
            {
                var newUser = new User()
                {
                    FirstName = "Bob",
                    LastName = "Smith",
                    Password = "password",
                    Token = "SecretToken!",
                    Username = "bsmith"
                };

                var service = new UserService<UsersRepo>(new TestEnvironment(), new UsersRepo(context));
                service.SignUp(newUser);
            }

            using (var context = new UsersDbContext(options))
            {
                Assert.Equal(1, context.Users.Count());
                context.Database.EnsureDeleted();
            }
        }


        [Fact]
        public void Duplicate_Signup_Throws_Exception()
        {
            var options = new DbContextOptionsBuilder<UsersDbContext>()
                .UseInMemoryDatabase(databaseName: "GetUsers_Returns_Users")
                .Options;


            // Run the test against one instance of the context
            using (var context = new UsersDbContext(options))
            {
                var newUser = new User()
                {
                    FirstName = "Bob",
                    LastName = "Smith",
                    Password = "password",
                    Token = "SecretToken!",
                    Username = "bsmith"
                };

                var service = new UserService<UsersRepo>(new TestEnvironment(), new UsersRepo(context));
                service.SignUp(newUser);

                Assert.Throws<SupportTicketUserAlreadyExistsException>(
                    () => service.SignUp(newUser));
                context.Database.EnsureDeleted();
            }
        }

    }
}
