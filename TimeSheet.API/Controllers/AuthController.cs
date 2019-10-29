using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TimeSheet.API.Data;
using TimeSheet.API.Dto;

namespace TimeSheet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private IAuthRepository _repo;
        private IMapper _mapper;

        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            _config = config;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost("register", Name="register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto){

            if (await _repo.UserExists(userForRegisterDto.Email))
                return BadRequest("Użytkownik już istnieje");

            var userToCreate = _mapper.Map<User>(userForRegisterDto);

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            var userToReturn = _mapper.Map<UserForDetailedDto>(createdUser);
            return Ok();
            //return CreatedAtRoute("GetUser", new {controller = "User", id=createdUser.UserId}, userToReturn);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody]UserForLoginDto userForLoginDto){
            //userForLoginDto.Username = userForLoginDto.Username.ToLower();

            var userFromRepo = await _repo.Login(userForLoginDto.Email, userForLoginDto.Password);
            
            if (userFromRepo == null)  
                return Unauthorized();

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Surname, userFromRepo.Surname)
            };

            //CREATE TOKEN

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}