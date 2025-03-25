using System.ComponentModel.DataAnnotations;

namespace AMIS.DTO
{
	public class CreateEmployeeDto
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Code { get; set; }
		public string? Sex { get; set; }
		public DateTime? Birthday { get; set; }
		[Required]
		public string Department { get; set; }
		public string? IdentificationCard { get; set; }
		public DateTime? DateOfIssue { get; set; }
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
