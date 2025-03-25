using AMIS.DTO;
using AMIS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMIS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeService _employeeService;
		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] PaginationRequestDto paginationRequestDto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			if (paginationRequestDto == null)
				return BadRequest("PaginationRequestDto is null");
			var employees = await _employeeService.GetAllAsync(paginationRequestDto);
			return Ok(employees);
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetById([FromRoute]int id)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState); ;
			var employee = await _employeeService.GetByIdAsync(id);
			if (employee == null) return NotFound(new { Message = $"Not found with id = {id}" });
			return Ok(employee);
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateEmployeeDto employeeDto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState); ;
			var e = await _employeeService.CreateAsync(employeeDto);
			if (e == -1) return BadRequest(new { Message = $"Code is already exist" });
			return Ok(e);
		}
		[HttpPut]
		[Route("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateEmployeeDto employeeDto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState); ;
			var e = await _employeeService.UpdateAsync(id, employeeDto);
			if (e == 0) return NotFound(new { Message = $"Not found with id = {id}" });
			return Ok(e);
		}
		[HttpDelete]
		[Route("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState); ;
			var e = await _employeeService.DeleteAsync(id);
			if (e == 0) return NotFound(new { Message = $"Not found with id = {id}" });
			return Ok(e);
		}
		[HttpPost]
		[Route("{id:int}")]
		public async Task<IActionResult> Duplicate([FromRoute] int id)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState); ;
			var e = await _employeeService.DuplicateAsync(id);
			if(e == 0) return NotFound(new { Message = $"Not found with id = {id}" });
			return Ok(e);
		}
		[HttpGet("search")]
		public async Task<IActionResult> SearchEmployees([FromQuery] string? code, [FromQuery] PaginationRequestDto paginationRequestDto)
		{
			if (!ModelState.IsValid) return BadRequest();
			var employees = await _employeeService.SearchEmployeesAsync(code, paginationRequestDto);
			return Ok(employees);
		}

		[HttpGet("isExistCode/{code}")]	
		public async Task<IActionResult> isExistCode([FromRoute]  string? code)
		{
			if (!ModelState.IsValid) return BadRequest();
			var check = await _employeeService.isExistCode(code);
			return Ok(check);
		}

	}
}
