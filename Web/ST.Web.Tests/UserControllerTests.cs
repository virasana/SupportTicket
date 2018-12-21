using System;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using ST.SharedHelpersLib.Exceptions;
using ST.SharedInterfacesLib;
using ST.SharedUserEntitiesLib;
using ST.UsersRepoLib;
using ST.UserServiceLib;
using ST.Web.Controllers.ApiControllers;
using Xunit;

namespace ST.Web.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public void SignUpReturnsCorrectResultTypeWithUser()
        {
            var fakeUsersService = A.Fake<IUserService<ISTUsersRepo>>();

            var newUser = new User()
            {
                FirstName = "Bob",
                LastName = "Smith",
                Password = "password",
                Token = "SecretToken!",
                Username = "bsmith"
            };

            A.CallTo(() => fakeUsersService.SignUp(newUser)).Returns(newUser);

            var usersController = new UsersController(fakeUsersService);

            var result = usersController.SignUp(newUser);

            Assert.IsType<CreatedAtRouteResult>(result);
            Assert.Equal(newUser, ((CreatedAtRouteResult)result).Value);
        }

        [Fact]
        public void DuplicateSignUpReturnsBadRequest()
        {
            var fakeUsersService = A.Fake<IUserService<ISTUsersRepo>>();

            var newUser = new User()
            {
                FirstName = "Bob",
                LastName = "Smith",
                Password = "password",
                Token = "SecretToken!",
                Username = "bsmith"
            };

            var usersController = new UsersController(fakeUsersService);

            A.CallTo(() => fakeUsersService.SignUp(newUser)).Returns(newUser);
            usersController.SignUp(newUser);
            A.CallTo(() => fakeUsersService.SignUp(newUser)).Throws<SupportTicketUserAlreadyExistsException>();
            var result = usersController.SignUp(newUser);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }


}
