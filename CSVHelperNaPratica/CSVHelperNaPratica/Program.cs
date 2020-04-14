using CSVHelperNaPratica.Entities;
using CSVHelperNaPratica.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using CSVHelperNaPratica.Helpers;

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
				new Customer ( 
					id: 1,
					name: "Pedro",
					age: 26,
					birthDayDate: DateTime.Parse("12/09/1994")
				),
				new Customer (
					id: 2,
					name: "Julia",
					age: 30,
					birthDayDate: DateTime.Parse("12/09/1990")
				)
			};

			//var file = exportToCsv.GenerateCsvAsync(customers).GetAwaiter().GetResult();
			var bytearray = exportToCsv.GenerateByteArrayCsvAsync(customers).GetAwaiter().GetResult();

			bytearray.Save(@"C:\teste.csv");
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
