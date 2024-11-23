using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
	public abstract class NotFoundException : Exception
	{
		protected NotFoundException(string message) : base(message) { }
	}

	public sealed class CompanyNotFoundException : NotFoundException
	{
		public CompanyNotFoundException(Guid id)
			: base($"The company with the id {id} doesnt exist.") { }
	}
}
