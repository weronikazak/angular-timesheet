using System.Collections.Generic;
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
    public class CompanyController : ControllerBase
    {
        private ITimesheetRepository _repo;
        private IMapper _mapper;

        public CompanyController(ITimesheetRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies() {
            var companies = await _repo.GetCompanies();

            //var companiesToReturn = _mapper.Map<IEnumerable<CompanyForListDto>>(companies);

            return Ok(companies);
        }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetCompany(int id){
        //     var company = await _repo.GetCompany(id);

        //     var co
        // }
    }
}