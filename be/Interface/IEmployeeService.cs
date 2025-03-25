using AMIS.DTO;
using AMIS.Model;

namespace AMIS.Interface
{
	public interface IEmployeeService
	{
		Task<PaginationResponseDto<EmployeeDto>> GetAllAsync(PaginationRequestDto paginationRequestDto);
		Task<EmployeeDto?> GetByIdAsync(int id);
		Task<int> CreateAsync(CreateEmployeeDto readingPassageDto);
		Task<int> UpdateAsync(int id, CreateEmployeeDto readingPassageDto);
		Task<int> DeleteAsync(int id);
		Task<int> DuplicateAsync(int id);
		Task<PaginationResponseDto<EmployeeDto>> SearchEmployeesAsync(string code, PaginationRequestDto paginationRequestDto);
		Task<bool> isExistCode(string code);


	}
}
