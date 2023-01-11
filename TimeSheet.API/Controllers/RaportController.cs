using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.API.Data;
using TimeSheet.API.Models;

namespace TimeSheet.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RaportController : ControllerBase
    {
        private ITimesheetRepository _repo;
        private IMapper _mapper;

        public RaportController(ITimesheetRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRaports() {
            var raports = await _repo.GetProjects();

            return Ok(raports);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetRaportsForToday() {
            var todayRaports = await _repo.GetRaportsForToday();

            return Ok(todayRaports);
        }

        
        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetRaportsForProject(int projectId) {
            var raportsForProject = await _repo.GetRaportsForProject(projectId);

            return Ok(raportsForProject);
        }

        
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetRaportsForTodayForUser(int studentId) {
            var raportsForUser = await _repo.GetRaportsForTodayForUser(studentId);

            return Ok(raportsForUser);
        }

        [HttpDelete("{raportId}")]
        public async Task<IActionResult> DeleteRaport(int raportId) {
            var raport = await _repo.GetRaport(raportId);

            _repo.Delete<Raports>(raport);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Coś poszło nie tak");
        }

        [HttpPost]
        public async Task<IActionResult> AddRaport (Raports raport) {
            _repo.Add<Raports>(raport);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Cos poszlo nie tak podczas dodawania raportu");
        }
    }
}