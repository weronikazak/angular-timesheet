using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.API.Data;
using TimeSheet.API.Dto;

namespace TimeSheet.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private ITimesheetRepository _repo;
        private IMapper _mapper;

        public ProjectsController(ITimesheetRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects() {
            var projects = await _repo.GetProjects();

            var projectsToReturn = _mapper.Map<IEnumerable<ProjectForListDto>>(projects);

            return Ok(projectsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id) {
            var project = await _repo.GetProject(id);

            var projectToReturn = _mapper.Map<ProjectForDetailedDto>(project);

            return Ok(projectToReturn);
        }
    }
}