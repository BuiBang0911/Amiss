using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AMIS.DTO
{
	public class PaginationRequestDto
	{
		private const int MaxPageSize = 100;

		public int PageNumber { get; set; } = 1;
		private int _pageSize = 10;

		public int PageSize
		{
			get => _pageSize;
			set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
		}
		[BindNever]
		public int Offset => (PageNumber - 1) * PageSize;

		public void Validate()
		{
			if (PageNumber < 1)
			{
				throw new ArgumentException("Page number must be greater than or equal to 1.");
			}

			if (PageSize < 1)
			{
				throw new ArgumentException("Page size must be greater than or equal to 1.");
			}
		}
	}
}
