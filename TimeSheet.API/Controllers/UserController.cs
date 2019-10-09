using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.API.Data;
using TimeSheet.API.Dto;
using TimeSheet.API.Helpers;

namespace TimeSheet.API.Controllers
{
    // [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ITimesheetRepository _repo;
        private IMapper _mapper;

        public UserController(ITimesheetRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery]UserParams userParams){
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var userFromRepo = await _repo.GetUser(currentUserId);
            userParams.UserId = currentUserId;

            var users = await _repo.GetUsers(userParams);
            
            var usersToRetrun = _mapper.Map<IEnumerable<UserForListDto>>(users);

            Response.AddPagination(users.CurrentPage, users.PageSize,
                users.TotalCount, users.TotalPages);

            return Ok(usersToRetrun);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id){
            var user = await _repo.GetUser(id);
            var userToRetrun = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToRetrun);
        }

        [HttpPut("{id}", Name = "GetUser")]
        public async Task<IActionResult> UpdateUser(int id, UserForUpdateDto userForUpdateDto) {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var user = await _repo.GetUser(id);
            _mapper.Map(userForUpdateDto, user);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Wystapil blad podczas aktualizowania uzytkownika.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id) {
            var user = _repo.GetUser(id);

            _repo.Delete(user);

            if (await _repo.SaveAll()) {
                return CreatedAtAction("GetUsers", new {});
            }

            throw new Exception("Cos poszlo nie tak podczas usuwania uzytkownika");
        }
    }
}