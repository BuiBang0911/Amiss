using AMIS.DTO;
using AMIS.Model;

namespace AMIS.Interface
{
	public interface IEmployeeRepository
	{
		Task<PaginationResponseDto<Employee>> GetAllAsync(PaginationRequestDto paginationRequestDto);
		Task<Employee?> GetByIdAsync(int id);
		Task<int> CreateAsync(Employee employee);
		Task<int> UpdateAsync(int id, Employee employee);
		Task<int> DeleteAsync(int id);
		Task<int> DuplicateAsync(int id);
		Task<PaginationResponseDto<Employee>> SearchEmployeesAsync(string code, PaginationRequestDto paginationRequestDto);
		Task<bool> isExistCode(string code);
	}
}
