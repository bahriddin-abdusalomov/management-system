using Demo.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.Extensions.Options;
using Services.Dtos;
using Services.Interfaces;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IConfiguration _configuration;
        public CompaniesController(ICompanyRepository companyRepository, IConfiguration configuration)
        {
            this.companyRepository = companyRepository;
            _configuration = configuration;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromForm]CreateCompanyDto company)
        {
            await companyRepository.CreateCompanyAsync(company);

            return Ok("Created");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await companyRepository.GetAllAsync();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid companyId)
        {
            var company = await companyRepository.GetCompanyByIdAsync(companyId);

            return Ok(company);
        }

        [HttpPatch("UpdateCompanyName")]
        public async Task<IActionResult> UpdateCompanyName(Guid companyId,string companyName)
        {
            await  companyRepository.UpdateCompany(companyId,companyName);

            return  Ok("Updated");
        }
    }
}
