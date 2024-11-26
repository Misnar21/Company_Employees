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
	internal sealed class CompanyService : ICompanyService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;
		public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}

		public CompanyDTO CreateCompany(CompanyForCreationDTO company)
		{
			Company companyEntity = _mapper.Map<Company>(company);

			_repository.CompanyRepository.CreateCompany(companyEntity);
			_repository.Save();

			return _mapper.Map<CompanyDTO>(companyEntity);
		}

		public IEnumerable<CompanyDTO> GetAllCompanies(bool trackChanges)
		{
				var companies = _repository.CompanyRepository.GetAllCompanies(trackChanges);

				// Mappeo con el automapper.
				var companiesDTO = _mapper.Map<IEnumerable<CompanyDTO>>(companies);
				return companiesDTO;

				// Mappeando a mano sin el automapper.
				//var companiesDTO = companies
				//	.Select(c =>
				//		new CompanyDTO(c.Id,
				//					   c.Name ?? "",
				//					   String.Join(' ', c.Address, c.Country))
				//	).ToList();

		}

		public CompanyDTO GetCompany(Guid id, bool trackChanges)
		{
			Company company = _repository.CompanyRepository.GetCompany(id, trackChanges);

			if (company == null)
				throw new CompanyNotFoundException(id);

			CompanyDTO companyDTO = _mapper.Map<CompanyDTO>(company);

			return companyDTO;
		}
	}
}
