using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Contracts.Models
{
	public class PeopleStats
	{
		int Count { get; }

		int FemaleCount { get; }

		int MailCount { get; }

		int ExpelledCount { get; }

		int DeptCount { get; }

		decimal AverageRate { get; }
	}
}
