using FirstCruWebAPI.Models;

namespace FirstCruWebAPI.Repository
{
    public interface IEmployeeRepo
    {
        public Task<List<Employee>> GetEmployeeListAsync();
        public Task<IEnumerable<Employee>> GetEmployeeByIdAsync(int Id);
        public Task<int> AddEmployeeAsync(Employee Employee);
        public Task<int> UpdateEmployeeAsync(Employee Employee);
        public Task<int> DeleteEmployeeAsync(int Id);
    }
}
