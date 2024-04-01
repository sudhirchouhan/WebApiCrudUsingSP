using FirstCruWebAPI.Data;
using FirstCruWebAPI.Models;
using FirstCruWebAPI.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FirstCruWebAPI.Services
{
    public class EmployeeService : IEmployeeRepo
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddEmployeeAsync(Employee Employee)
        {
            var parameter=new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EmployeeName",Employee.EmployeeName));
            parameter.Add(new SqlParameter("@EmployeeDescription",Employee.EmployeeDescription));
            parameter.Add(new SqlParameter("@EmployeeSalary", Employee.EmployeeSalary));
            parameter.Add(new SqlParameter("@YearOfService", Employee.YearOfService));
            var result = await Task.Run(()=>_dbContext.Database.
            ExecuteSqlRawAsync(@"exec AddNewEmployee @EmployeeName,@EmployeeDescription,@EmployeeSalary,@YearOfService",parameter.ToArray()));
            return result;
        }

        public async Task<int> DeleteEmployeeAsync(int Id)
        {
            return await Task.Run(()=>_dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteEmployeeByID {Id}"));
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByIdAsync(int Id)
        {
            var param=new SqlParameter("@EmployeeId",Id);
            var empDetails = await Task.Run(()=>
             _dbContext.Employees.FromSqlRaw(@"exec GetEmployeeByID @EmployeeId",param).ToListAsync());
            return empDetails;
        }

        public async Task<List<Employee>> GetEmployeeListAsync()
        {
           return await _dbContext.Employees.FromSqlRaw<Employee>("GetEmployeeList").ToListAsync();
        }

        public async Task<int> UpdateEmployeeAsync(Employee Employee)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EmployeeId", Employee.EmployeeId));
            parameter.Add(new SqlParameter("@EmployeeName", Employee.EmployeeName));
            parameter.Add(new SqlParameter("@EmployeeDescription", Employee.EmployeeDescription));
            parameter.Add(new SqlParameter("@EmployeeSalary", Employee.EmployeeSalary));
            parameter.Add(new SqlParameter("@YearOfService", Employee.YearOfService));
            var result = await Task.Run(() => _dbContext.Database.
            ExecuteSqlRawAsync(@"exec UpdateEmployee @EmployeeId,@EmployeeName,@EmployeeDescription,@EmployeeSalary,@YearOfService", 
            parameter.ToArray()));
            return result;
        }
    }
}
