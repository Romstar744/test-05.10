using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3.Model;

namespace DataGrid.Contracts
{
	internal interface IPeopleStorage
	{
		Task<IReadOnlyCollection<Person>> GetAll();
		Task<Person> AddAsync(Person person);

		Task EditAsync(Person person);

		Task<bool> DeleteAsync(Guid id);
	}
}
