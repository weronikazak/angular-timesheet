using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.API.Data;
using TimeSheet.API.Dto;
using System.Linq;
using System;

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

            var companiesToReturn = _mapper.Map<IEnumerable<CompanyForListDto>>(companies);

            return Ok(companiesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id) {
            var company = await _repo.GetCompany(id);

            // DO ZMIANY
            //var companyToReturn = _mapper.Map<CompanyForRegisterDto>(company);

            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(CompanyForRegisterDto companyForRegisterDto) {
            
            _repo.Add(companyForRegisterDto);

            if (await _repo.SaveAll()){
                var companyToReturn = _mapper.Map<CompanyForListDto>(companyForRegisterDto);
                return CreatedAtRoute("GetCompanies", companyToReturn);
            }

            throw new Exception("Coś popszło nie tak podczas tworzenia firmy");
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteCompany(int id) {
            var company = await _repo.GetCompany(id);

            _repo.Delete(company);

            if (await _repo.SaveAll()){
                return NoContent();
            }

            throw new Exception("Coś poszło nie tak podczas kasowania firmy");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id) {
            var company = _repo.GetCompany(id);

            _repo.Delete(company);

            if (await _repo.SaveAll())
                return CreatedAtAction("GetCompany", new { id = company.Id}, company);

            throw new Exception("Coś poszło nie tak podczas aktualizowania");
        }

        [HttpGet("{id}/projects")]
        public async Task<IActionResult> GetCompanyProjects(int id) {
            var company = await _repo.GetCompany(id);

            var projects = _repo.GetProjectsForCompany(company.Id);

            var projectsToReturn = _mapper.Map<ProjectForListDto>(projects);

            return Ok(projectsToReturn);

        }
    }
}