using Domain.Entities;
using Services.Dtos;

namespace Services.Interfaces
{
    public interface IStaffRepository
    {
        public Task CreateStaffAsync(StaffDtos staff);
        public Task<Staff> GetStaffById(Guid staffId);
        public Task DeleteStaff(Guid StaffId);
        public Task<List<Staff>> GetAllAsync();
        public Task<List<Employee>> GetAllEmplyeesByStaffId(Guid staffId);
        public Task AddEmployeesToStaff(Guid staffId, List<Guid> employees);
    }
}