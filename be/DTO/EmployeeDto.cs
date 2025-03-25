using System.ComponentModel.DataAnnotations;

namespace AMIS.DTO
{
	public class EmployeeDto
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string Code { get; set; }
		public string? Sex { get; set; }
		public DateOnly? Birthday { get; set; }
		public string Department { get; set; }
		public string? IdentificationCard { get; set; }
		public DateOnly? DateOfIssue { get; set; }
		public string? PlaceOfIssue { get; set; }
		public string? Position { get; set; }
		public string? Address { get; set; }
		public string? AccountNumber { get; set; }
		public string? PhoneNumber { get; set; }
		public string? LandlineNumber { get; set; }
		public string? Email { get; set; }
		public string? BankName { get; set; }
		public string? BankBranch { get; set; }
	}
}
