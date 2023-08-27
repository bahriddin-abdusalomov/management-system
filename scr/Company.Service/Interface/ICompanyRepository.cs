using Domain.Entities;
using Services.Dtos;

namespace Services.Interfaces
{
    public interface ICompanyRepository
    {
        public Task CreateCompanyAsync(CreateCompanyDto company);
        public Task<Company> GetCompanyByIdAsync(Guid CompanyId);
        public Task<List<Company>> GetAllAsync();
        public Task UpdateCompany(Guid companyId,string companyName);
    }
}
