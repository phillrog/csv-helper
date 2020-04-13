using Bogus;
using CSVHelperNaPratica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSVHelperNaPratica.Test.Builders
{
	public class CustomerBuilder
	{
		private readonly Faker _faker = new Faker();

		protected Customer Customer { get; set; }
		private int _id { get; set; }
		private string _name { get; set; }
		private int _age { get; set; }
		private DateTime _birthDayDate { get; set; }

		public  CustomerBuilder()
		{
			_faker = new Faker();

			_id = _faker.Person.Random.Int();
			_name = _faker.Person.FullName.Trim();
			_birthDayDate = _faker.Person.DateOfBirth;
			_age = DateTime.Now.Year - _birthDayDate.Year;
		}

		public static CustomerBuilder Novo()
		{
			return new CustomerBuilder();
		}

		public CustomerBuilder ComNumeroIndetificado(int id)
		{
			_id = id;
			return this;
		}

		public CustomerBuilder ComNome(string nome)
		{
			_name = nome;
			return this;
		}

		public CustomerBuilder ComIdade(int idade)
		{
			_age = idade;
			return this;
		}

		public CustomerBuilder ComDataDeNascimento(DateTime dataNasc)
		{
			_birthDayDate = dataNasc;

			return this;
		}

		public Customer Build()
		{
			var customer = new Customer(_id, _name, _age, _birthDayDate);

			return customer;
		}

		public List<Customer> BuildList(int totalEntities = 10)
		{
			var range = Enumerable.Range(0, totalEntities);
			var listCustomer = new List<Customer>();

			foreach (var num in range)
			{
				var id = _faker.Person.Random.Int();
				var name = _faker.Person.FullName.Trim();
				var birthDayDate = _faker.Person.DateOfBirth;
				var age = DateTime.Now.Year - _birthDayDate.Year;
				var customer = new Customer(id, name, age, birthDayDate);

				listCustomer.Add(customer);
			};

			return listCustomer;
		}
	}
}
