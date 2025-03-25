using AMIS.DTO;
using AMIS.Model;
using System;

namespace AMIS.Mapper
{
	public static class EmployeeMapper
	{
		public static EmployeeDto ToEmployeeDto(this Employee employee) {

			return new EmployeeDto
			{
				Id = employee.Id,
				Name = employee.Name,
				Sex = employee.Sex,
				Birthday = string.IsNullOrEmpty(employee.Birthday?.ToString())
				? default
				: DateOnly.FromDateTime(employee.Birthday.Value),
				IdentificationCard = employee.IdentificationCard,
				Position = employee.Position,
				AccountNumber = employee.AccountNumber,
				BankBranch = employee.BankBranch,
				BankName = employee.BankName,
				DateOfIssue = string.IsNullOrEmpty(employee.DateOfIssue?.ToString())
				? default
				: DateOnly.FromDateTime(employee.DateOfIssue.Value),
				Department = employee.Department,
				Address = employee.Address,
				PhoneNumber = employee.PhoneNumber,	
				PlaceOfIssue = employee.PlaceOfIssue,
				LandlineNumber = employee.LandlineNumber,
				Email = employee.Email,
				Code = employee.Code,
			};
		}

		public static Employee CreateEmployeeDtoToEmployee(this CreateEmployeeDto employee)
		{
			Console.WriteLine(employee.Birthday);
			var _birthday = employee.Birthday.HasValue ? employee.Birthday : null;
			var _dateOfIssue = employee.DateOfIssue.HasValue ? employee.DateOfIssue : null;

			return new Employee
			{
				Name = employee.Name,
				Sex = employee.Sex,
				Birthday = employee.Birthday.HasValue ? employee.Birthday : null,
				Position = employee.Position,
				AccountNumber = employee.AccountNumber,
				BankBranch = employee.BankBranch,
				BankName = employee.BankName,
				DateOfIssue = employee.DateOfIssue.HasValue ? employee.DateOfIssue : null,
				Department = employee.Department,
				Address = employee.Address,
				PhoneNumber = employee.PhoneNumber,
				PlaceOfIssue = employee.PlaceOfIssue,
				LandlineNumber = employee.LandlineNumber,
				Email = employee.Email,
				Code = employee.Code,
			};
		}
	}
}
