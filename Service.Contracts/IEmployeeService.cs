using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
	public interface IEmployeeService
	{
		IEnumerable<EmployeeDTO> GetEmployees(Guid companyId, bool trackChanges);
		EmployeeDTO CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDTO employee, bool trackChanges);
	}
}
