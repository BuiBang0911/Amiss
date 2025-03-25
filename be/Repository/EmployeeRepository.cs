using AMIS.Data;
using AMIS.DTO;
using AMIS.Interface;
using AMIS.Model;
using Microsoft.AspNetCore.Mvc;

namespace AMIS.Repository
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly DataContext _context;

		public EmployeeRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<int> CreateAsync(Employee employee)
		{
			var newcode = "";
			if (employee.Code == "")
			{
				var maxcode = await _context.ExecuteScalarAsync<int>("SELECT MAX(CAST(SUBSTRING(Code, 5) AS UNSIGNED)) FROM Employees;");
				newcode = $"NV-{(maxcode + 1):D4}";
			} else newcode = employee.Code;
			var check = await _context.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Employees WHERE Code = @newcode;", new { newcode = newcode});
			if (check > 0) 
			{
				return -1;
			}
			var parameters = new
			{
				employee.Name,
				employee.Sex,
				employee.Birthday,
				employee.IdentificationCard,
				employee.Position,
				employee.AccountNumber,
				employee.BankBranch,
				employee.BankName,
				employee.DateOfIssue,
				employee.Department,
				employee.Address,
				employee.PhoneNumber,
				employee.PlaceOfIssue,
				employee.LandlineNumber,
				employee.Email,
				newcode
			};
			var newemployee = await _context.InsertAsync(@"INSERT INTO 
				Employees (Code, Name, Sex, Birthday, IdentificationCard, Position, AccountNumber, BankBranch, BankName, Email, PhoneNumber, PlaceOfIssue, LandlineNumber, DateOfIssue, Department, Address) 
				VALUES (@newcode, @Name, @Sex, @Birthday, @IdentificationCard, @Position, @AccountNumber, @BankBranch, @BankName, @Email, @PhoneNumber, @PlaceOfIssue, @LandlineNumber, @DateOfIssue, @Department, @Address)", parameters);
			return newemployee;
		}

		public async Task<int> DeleteAsync(int employee)
		{
			return await _context.DeleteAsync("DELETE FROM Employees WHERE Id = @Id", new { Id = employee });
		}

		public async Task<PaginationResponseDto<Employee>> GetAllAsync(PaginationRequestDto paginationRequestDto)
		{
			string sql = @"
                SELECT * 
                FROM Employees
                ORDER BY id
				LIMIT @PageSize
				OFFSET @Offset";
			var employees = await _context.QueryAsync<Employee>(sql, new
			{
				PageSize = paginationRequestDto.PageSize,
				Offset = paginationRequestDto.Offset,
			});
			string countSql = "SELECT COUNT(*) FROM Employees";
			int totalRecords = await _context.ExecuteScalarAsync<int>(countSql);
			return new PaginationResponseDto<Employee>
			{
				PageNumber = paginationRequestDto.PageNumber,
				PageSize = paginationRequestDto.PageSize,
				TotalRecords = totalRecords,
				TotalPages = (int)Math.Ceiling((double)totalRecords / paginationRequestDto.PageSize),
				Data = employees
			};
		}

		public async Task<Employee> GetByIdAsync(int id)
		{
			return await _context.QuerySingleAsync<Employee>("SELECT * FROM Employees WHERE Id = @Id", new { Id = id });
		}

		public async Task<int> UpdateAsync(int id, Employee employee)
		{
			var parameters = new
			{
				employee.Name,
				employee.Sex,
				employee.Birthday,
				employee.IdentificationCard,
				employee.Position,
				employee.AccountNumber,
				employee.BankBranch,
				employee.BankName,
				employee.DateOfIssue,
				employee.Department,
				employee.Address,
				employee.PhoneNumber,
				employee.PlaceOfIssue,
				employee.LandlineNumber,
				employee.Email,
				id  
			};
			return await _context.UpdateAsync(@"UPDATE Employees SET 
					Name = @Name, 
					Sex = @Sex, 
					Birthday = @Birthday, 
					IdentificationCard = @IdentificationCard, 
					Position = @Position, 
					AccountNumber = @AccountNumber, 
					BankBranch = @BankBranch, 
					BankName = @BankName,
					Email = @Email,
					PhoneNumber = @PhoneNumber, 
					PlaceOfIssue = @PlaceOfIssue, 
					LandlineNumber = @LandlineNumber, 
					DateOfIssue = @DateOfIssue, 
					Department = @Department, 
					Address = @Address
					WHERE Id = @id", 
					parameters);
		}
		public async Task<int> DuplicateAsync(int id)
		{
			var employee = await GetByIdAsync(id);
			return await CreateAsync(employee);

		}

		public async Task<PaginationResponseDto<Employee>> SearchEmployeesAsync(string str, PaginationRequestDto paginationRequestDto)
		{
			string sql = @"
						SELECT *
						FROM Employees
						WHERE 
							(@str IS NULL OR Code LIKE CONCAT('%', @str, '%'))
							OR (@str IS NULL OR Name LIKE CONCAT('%', @str, '%'))
						ORDER BY Id
						LIMIT @PageSize 
						OFFSET @Offset";

			string countSql = @"
						SELECT COUNT(*)
						FROM Employees
						WHERE 
							(@str IS NULL OR Code LIKE CONCAT('%', @str, '%'))
							OR (@str IS NULL OR Name LIKE CONCAT('%', @str, '%'))";
			int totalRecords = await _context.ExecuteScalarAsync<int>(countSql, new {str = str});
			var employees = await _context.QueryAsync<Employee>(sql, new
			{
				str = str,
				PageSize = paginationRequestDto.PageSize,
				Offset = paginationRequestDto.Offset
			});
			return new PaginationResponseDto<Employee>
			{
				PageNumber = paginationRequestDto.PageNumber,
				PageSize = paginationRequestDto.PageSize,
				TotalRecords = totalRecords,
				TotalPages = (int)Math.Ceiling((double)totalRecords / paginationRequestDto.PageSize),
				Data = employees
			};
		}

		public async Task<bool> isExistCode(string code)
		{
			var check = await _context.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Employees WHERE Code = @newcode;", new { newcode = code });
			if (check > 0)
			{
				return true;
			}
			return false;
		}
	}
}
