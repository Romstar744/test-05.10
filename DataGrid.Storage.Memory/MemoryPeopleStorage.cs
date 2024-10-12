using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WindowsFormsApp3.Model;
using WindowsFormsApp3.Models;

namespace DataGrid.Storage.Memory
{
	public class MemoryPeopleStorage : IPeopleStorage
	{
		private List<Person> people;

        public MemoryPeopleStorage()
        {
            people = new List<Person>();
        }

        public Task<Person> AddSync(Person person)
        {
            people.Add(person);
            return Task.FromResult(person);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var person = people.FirstOrDefault(x => x.Id == id);
            if (person != null)
            {
                people.Remove(person);
                return Task.FromResult(true)
            }

            return Task.FromResult(false);
        }

        public Task EditAsync(Person person)
        {
            var target = people.FirstOrDefault(x=>x.Id == person.Id);
			        
                    target.Name = person.Name,
                    target.Gender = person.Male,
                    target.Birthday = person.Birthday,
                    target.AvgGrade = person.AvgGrade,
                    target.Dept = person.Dept,
                    target.Expelled = person.Expelled

		}
        public Task<IReadOnlyCollection<Person>> GetAllAsync()
        {

        }
    }
}
