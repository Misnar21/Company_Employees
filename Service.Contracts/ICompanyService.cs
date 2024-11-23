using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace Service.Contracts
{
	public interface ICompanyService
	{
		IEnumerable<CompanyDTO> GetAllCompanies(bool trackChanges);
		CompanyDTO GetCompany(Guid id, bool trackChanges);
	}
}
