using CsvHelper;
using CsvHelper.Configuration;
using CSVHelperNaPratica.CsvMapps;
using CSVHelperNaPratica.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CSVHelperNaPratica.Services
{
	public class ExportToCsv : IExportToCsv
	{
		public async Task<byte[]> GenerateByteArrayCsvAsync(List<Customer> data)
		{
			if (data == null || data.Count == 0) throw new Exception(Resource.TheNumberOfCustomersIsInvalid);
			using (var memoryStream = new MemoryStream())
			{
				using (var streamWriter = new StreamWriter(memoryStream))
				using (var csv = new CsvWriter(streamWriter, new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";", Encoding = Encoding.UTF8, }))
				{
					csv.Configuration.RegisterClassMap<CustomerCsvMap>();
					await csv.WriteRecordsAsync(data);
				}

				return memoryStream.ToArray();
			}
		}

		public async Task<string> GenerateCsvAsync(List<Customer> data)
		{
			if (data == null || data.Count == 0) throw new Exception(Resource.TheNumberOfCustomersIsInvalid);
			string pathTemp = Path.Combine(Path.GetTempPath(), "clientes-csv");
			if (!Directory.Exists(pathTemp))
				Directory.CreateDirectory(pathTemp);

			var tempFilePath = Path.Combine(pathTemp, $"Clientes-Que-Pagaram-{DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss")}.csv");
			using (var writer = new StreamWriter(tempFilePath))
			using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";", Encoding = Encoding.UTF8, }))
			{
				csv.Configuration.RegisterClassMap<CustomerCsvMap>();
				await csv.WriteRecordsAsync(data);
			}

			return tempFilePath;
		}

	}
}
