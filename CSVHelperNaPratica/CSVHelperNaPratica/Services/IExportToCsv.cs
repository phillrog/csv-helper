using CSVHelperNaPratica.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSVHelperNaPratica.Services
{
	public interface IExportToCsv
	{
		Task<string> GenerateCsvAsync(List<Customer> data);
		Task<byte[]> GenerateByteArrayCsvAsync(List<Customer> data);
	}
}
