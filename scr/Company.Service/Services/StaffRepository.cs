using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.DataContext;
using Services.Dtos;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Services.Services
{
    public class StaffRepository : IStaffRepository
    {
        private readonly AppDbContext contexts;

        public StaffRepository(AppDbContext contexts)
        {
            this.contexts = contexts;
        }
        public async Task AddEmployeesToStaff(Guid staffId, List<Guid> employees)
        {
            var staff = await contexts.Staffs.FirstOrDefaultAsync(s => s.Id == staffId);

            if (staff is not null)
            {
                foreach (var i in employees)
                {
                    var employee = await contexts.Employees.
                        FirstOrDefaultAsync(e => e.Id == i);

                    staff.Employess.Add(employee);
                    await contexts.SaveChangesAsync();

                }


            }
        }
        public async Task CreateStaffAsync(StaffDtos staff)
        {
            await contexts.Staffs.AddAsync(staff.Adapt<Staff>());
            await contexts.SaveChangesAsync();
        }

        public async Task DeleteStaff(Guid StaffId)
        {
            var staff = contexts.Staffs.FirstOrDefault(x => x.Id == StaffId);

            contexts.Staffs.Remove(staff);
            await contexts.SaveChangesAsync();
        }

        public async Task<List<Staff>> GetAllAsync()
        {
            var staffs = await contexts.Staffs.Include(x => x.Employess).AsNoTracking().ToListAsync();

            return staffs;
        }

        public async Task<List<Employee>> GetAllEmplyeesByStaffId(Guid staffId)
        {
            var staff = await contexts.Staffs.Include(x => x.Employess).FirstOrDefaultAsync(x => x.Id == staffId);

            return staff.Employess.ToList();
        }

        public async Task<Staff> GetStaffById(Guid staffId)
        {
            var staff = await contexts.Staffs.FirstOrDefaultAsync(x => x.Id == staffId);

            return staff;
        }
    }
}
