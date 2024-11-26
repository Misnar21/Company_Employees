using AutoMapper;
using Shared.DTOs;

namespace CompanyEmployees
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// Mapea las propiedades de Company a CompanyDTO por el nombre. En caso de que el nombre
			// no corresponda, se tiene que utilziar ForCtorParam.
			CreateMap<Company, CompanyDTO>()
				.ForMember(c => c.FullAddress,
				opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

			CreateMap<Employee, EmployeeDTO>();

			CreateMap<CompanyForCreationDTO, Company>();
		}
	}
}
