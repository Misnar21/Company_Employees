﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Repository
{
	public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
	{
		public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

		// Utiliza el metodo Generico de RepositoryBase, Del ID se va a encargar EFCore
		public void CreateCompany(Company company) => Create(company);

		public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
			FindAll(trackChanges)
				.OrderBy(c => c.Name)
				.ToList();

		public Company GetCompany(Guid id, bool trackChanges) =>
			FindByCondition(c => c.Id.Equals(id), trackChanges)
				.SingleOrDefault();
	}
}
