using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3.Model;

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
		IReadOnlyCollection<Person> GetAll();

		Person Add(Person person);

		void Edit (Person person);

		void Delete (Guid id);
	}
}
