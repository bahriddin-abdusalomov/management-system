using Domain.Entities;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEmplyeeRepository
    {
        public Task CreateEmplyeeAsync(EmplyeeDtos company);
        public Task<Employee> GetEmplyeeByIdAsync(Guid CompanyId);
        public Task<List<Employee>> GetAllAsync();

        public Task DeleteEmplyee(Guid employeeId);
    }
}
