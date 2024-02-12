using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoListTestApp.DTO.AppUsers;
using ToDoListTestApp.Entity;
using ToDoListTestApp.Helper;
using ToDoListTestApp.Repository.IRepository;
using ToDoListTestApp.Service.IService;

namespace ToDoListTestApp.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly IRepository<AppUser> _repository;
        private readonly UserManager<AppUser> _userManager;

        public TokenService(IConfiguration config, IRepository<AppUser> repository, UserManager<AppUser> userManager)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
            _repository = repository;
            _userManager = userManager;
        }

        public Responce<TokenDto> CreateToken(AppUser user, TokenDto tokenDto)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Email, user.Email),
                    new(ClaimTypes.GivenName, user.FirstName + " " + user.LastName)
                };

                var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = creds,
                };


                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenResult = tokenHandler.WriteToken(token);
                if (tokenResult is null) {
                    List<string> errors = new()
                    {
                        "Token was not created"
                    };

                    return new Responce<TokenDto>(new(), false, "Failed", errors);
                }

                return new Responce<TokenDto>(new()
                {
                    Token = tokenResult
                }, true, "Created");

            }
            catch (Exception)
            {

                List<string> errors = new()
                {
                        "Sever error"
                };

                return new Responce<TokenDto>(new(), false, "Failed", errors); ;
            }
        }
    }
}
