﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface IEmployeeRepository
	{
		IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);

		void CreateEmployeeForCompany(Guid companyId, Employee employee);
	}
}
