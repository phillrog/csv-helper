using System;
using System.Collections.Generic;
using System.Text;

namespace CSVHelperNaPratica.Entities
{
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public DateTime BirthDayDate { get; set; }

		public Customer(int id, string name, int age, DateTime birthDayDate)
		{
			this.Id = id;
			this.Name = name;
			this.Age = age;
			this.BirthDayDate = birthDayDate;
		}
	}
}
