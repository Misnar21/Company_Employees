using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
	public record CompanyDTO
	{
		public Guid Id { get; init; }
		public string? Name { get; init; }
		public string? FullAddress { get; init; }
	}

	public record CompanyForCreationDTO(string name, string Address, string Country);
}
