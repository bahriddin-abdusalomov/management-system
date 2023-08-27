using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Services.DataContext;
using Services.Dtos;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EmplyeeRepository : IEmplyeeRepository
    {
        private readonly AppDbContext contexts;

        public EmplyeeRepository(AppDbContext contexts)
        {
            this.contexts = contexts;
        }

        public async Task CreateEmplyeeAsync(EmplyeeDtos company)
        {
            var newEmplyee = new Employee()
            {
                Id = new Guid(),
                Email = company.Email,
                FirstName = company.FirstName,
                LastName = company.LastName,
                Phone = company.Phone,
                CompanyId = company.CompanyId,
            };

            await contexts.Employees.AddAsync(newEmplyee);
            await contexts.SaveChangesAsync();

        }

        public async Task DeleteEmplyee(Guid employeeId)
        {
            var employee = await contexts.Employees.FirstOrDefaultAsync(X => X.Id == employeeId);

            contexts.Employees.Remove(employee);
            await contexts.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var employees = await contexts.Employees.Where(x => x.CompanyId == x.Company.Id).ToListAsync();

            return employees;
        }

        public async Task<Employee> GetEmplyeeByIdAsync(Guid CompanyId)
        {
            var emmplyee = await contexts.Employees.FirstOrDefaultAsync(x => x.Id == CompanyId);

            return emmplyee;
        }
    }
}
