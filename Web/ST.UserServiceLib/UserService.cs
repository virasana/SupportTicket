using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ST.SharedInterfacesLib;
using ST.SharedUserEntitiesLib;


namespace ST.UserServiceLib
{
    public class UserService<TUsersRepo> :
        IUserService<ISTUsersRepo> where TUsersRepo: ISTUsersRepo
    {
        private readonly ISTUsersRepo _usersRepo;
        private readonly string _jwtSecret;

        public UserService(ISTEnvironment stEnvironment, TUsersRepo usersRepo)
        {
            _usersRepo = usersRepo;
            _jwtSecret = stEnvironment.JWTSecret;
        }

        public User Authenticate(string username, string password)
        {
            var user = _usersRepo.GetUserMatching(username, password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            // TODO get secret from environment variable
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return _usersRepo.GetAllUsers();
        }

        public User SignUp(User user)
        {
            return _usersRepo.SignUp(user);
        }

        public User Get(int id)
        {
            return _usersRepo.Get(id);
        }
    }
}