using AMIS.DTO;
using AMIS.Interface;
using AMIS.Mapper;
using AMIS.Model;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AMIS.Service
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IEmployeeRepository _repository;

		public EmployeeService(IEmployeeRepository repository)
		{
			_repository = repository;
		}

		public async Task<int> CreateAsync(CreateEmployeeDto createEmployeeDto)
		{
			var employee = await _repository.CreateAsync(createEmployeeDto.CreateEmployeeDtoToEmployee());
			return employee;
		}

		public async Task<int> DeleteAsync(int id)
		{
			var employee = await _repository.DeleteAsync(id);
			return employee;
		}

		public async Task<PaginationResponseDto<EmployeeDto>> GetAllAsync(PaginationRequestDto paginationRequestDto)
		{
			var employees = await _repository.GetAllAsync(paginationRequestDto);
			return new PaginationResponseDto<EmployeeDto>
			{
				PageNumber = employees.PageNumber,
				PageSize = employees.PageSize,
				TotalRecords = employees.TotalRecords,
				TotalPages = employees.TotalPages,
				Data = employees.Data.Select(x => x.ToEmployeeDto()).ToArray()
			};
		}

		public async Task<EmployeeDto> GetByIdAsync(int id)
		{
			var employee = await _repository.GetByIdAsync(id);
			return employee.ToEmployeeDto();
		}

		public async Task<int> UpdateAsync(int id, CreateEmployeeDto createEmployeeDto)
		{
			var employee = await _repository.UpdateAsync(id, createEmployeeDto.CreateEmployeeDtoToEmployee());
			return employee;
		}

		public async Task<int> DuplicateAsync(int id)
		{
			var employee = await _repository.DuplicateAsync(id);
			return employee;
		}

		public async Task<PaginationResponseDto<EmployeeDto>> SearchEmployeesAsync(string code, PaginationRequestDto paginationRequestDto)
		{
			var employees = await _repository.SearchEmployeesAsync(code, paginationRequestDto);
			return new PaginationResponseDto<EmployeeDto>
			{
				PageNumber = employees.PageNumber,
				PageSize = employees.PageSize,
				TotalRecords = employees.TotalRecords,
				TotalPages = employees.TotalPages,
				Data = employees.Data.Select(x => x.ToEmployeeDto()).ToArray()
			};
		}

		public Task<bool> isExistCode(string code)
		{
			return _repository.isExistCode(code);
		}
	}
}
