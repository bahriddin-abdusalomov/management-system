using Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Services.DataContext;
using Services.Dtos;
using Services.Interfaces;

namespace Services.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext contexts;
        public CompanyRepository(AppDbContext contexts)
        {
            this.contexts = contexts;
        }
        public async Task CreateCompanyAsync(CreateCompanyDto company)
        {
            var company1 = new Company()
            {
                Address = company.Address,
                Email = company.Email,
                Name = company.Name,
                Id = new Guid(),
                Phone = company.Phone,
            };
            await contexts.Companies.AddAsync(company1);
            await contexts.SaveChangesAsync();

            //var res = Mapper.Map<Company>(company);

            //await contexts.Companies.AddAsync(res);
            //await contexts.SaveChangesAsync();
        }

        public async Task<List<Company>> GetAllAsync()
        {
            var companies = await contexts.Companies.AsNoTracking().ToListAsync();

            return companies;
        }

        public async Task<Company> GetCompanyByIdAsync(Guid companyId)
        {
            var company = await contexts.Companies.FirstOrDefaultAsync(x => x.Id == companyId);

            return company;
        }

        public async Task UpdateCompany(Guid companyId, string companyName)
        {
            var company = await contexts.Companies.FirstOrDefaultAsync(x => x.Id == companyId);

            company.Name = companyName;

            contexts.Companies.Update(company);
            await contexts.SaveChangesAsync();
        }
    }
}