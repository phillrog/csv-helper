using CSVHelperNaPratica.Entities;
using CSVHelperNaPratica.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CSVHelper
{
	class Program
	{
		private static IServiceProvider _serviceProvider;

		static void Main(string[] args)
		{
			RegisterServices();
			var exportToCsv = _serviceProvider.GetService<IExportToCsv>();

			
			Console.WriteLine("Exportar para csv");

			var customers = new List<Customer>
			{
				new Customer { 
					Id = 1,
					Name = "Pedro",
					Age = 26,
					BirthDayDate = DateTime.Parse("12/09/1994")
				},
				new Customer {
					Id = 2,
					Name = "Julia",
					Age = 30,
					BirthDayDate = DateTime.Parse("12/09/1990")
				}
			};

			//var file = exportToCsv.GenerateCsvAsync(customers).GetAwaiter().GetResult();
			var bytearray = exportToCsv.GenerateByteArrayCsvAsync(customers).GetAwaiter().GetResult();

			DisposeServices();

		}
		
		private static void RegisterServices()
		{
			var collection = new ServiceCollection();
			collection.AddScoped<IExportToCsv, ExportToCsv>();
			
			_serviceProvider = collection.BuildServiceProvider();
		}

		private static void DisposeServices()
		{
			if (_serviceProvider == null)
			{
				return;
			}
			if (_serviceProvider is IDisposable)
			{
				((IDisposable)_serviceProvider).Dispose();
			}
		}
	}
}
