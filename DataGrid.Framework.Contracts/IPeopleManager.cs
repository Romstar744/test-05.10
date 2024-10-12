using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3;

namespace DataGrid.Contracts
{
	/// <summary>
	/// dkfdskfkds
	/// </summary>
	public interface IPeopleManager
	{
		/// <summary>
		/// Возвращает список Person
		/// </summary>
		/// <returns></returns>
		Task<IReadOnlyCollection<Person>> GetAll();
		Task<Person> Add(Person person);

		Task EditAsync (Person person);

		Task<bool> DeleteAsync (Guid id);

		Task<IPeopleManager> GetAllAsync ();
	}
}
