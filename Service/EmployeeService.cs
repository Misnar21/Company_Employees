using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	internal sealed class EmployeeService : IEmployeeService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;
		public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}

		public EmployeeDTO CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDTO employeeForCreation, bool trackChanges)
		{
			Company company = _repository.CompanyRepository.GetCompany(companyId, trackChanges);

			if (company is null) throw new CompanyNotFoundException(companyId);
			
			Employee employeeEntity = _mapper.Map<Employee>(employeeForCreation);
			_repository.EmployeeRepository.CreateEmployeeForCompany(companyId, employeeEntity);
			_repository.Save();

			return _mapper.Map<EmployeeDTO>(employeeEntity);
		}

		public IEnumerable<EmployeeDTO> GetEmployees(Guid companyId, bool trackChanges)
		{
			var company = _repository.CompanyRepository.GetCompany(companyId, trackChanges);

			if (company == null)
				throw new CompanyNotFoundException(companyId);

			var employeesFromDb = _repository.EmployeeRepository.GetEmployees(companyId,trackChanges);
			var employeesDto = _mapper.Map<IEnumerable<EmployeeDTO>>(employeesFromDb);

			return employeesDto;
		}
	}
}
