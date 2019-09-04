using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.API.Data;
using AutoMapper;
using TimeSheet.API.Dto;
using System.Collections.Generic;

namespace TimeSheet.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ITimesheetRepository _repo;
        private IMapper _mapper;

        public UsersController(ITimesheetRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(){
            var users = await _repo.GetUsers();

            var usersToRetrun = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(usersToRetrun);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id){
            var user = await _repo.GetUser(id);

            var userToRetrun = _mapper.Map<User, UserForListDto>(user);

            return Ok(userToRetrun);
        }
    }
}