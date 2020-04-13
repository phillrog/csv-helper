

using CsvHelper.Configuration;
using CSVHelperNaPratica.Entities;

namespace CSVHelperNaPratica.CsvMapps
{
	public class CustomerCsvMap : ClassMap<Customer>
	{
		public CustomerCsvMap()
		{
			Map(c => c.Id).Name("ID").NameIndex(0);
			Map(c => c.Name).Name("NOME").NameIndex(1);
			Map(c => c.Age).Name("IDADE").NameIndex(2);
			Map(c => c.BirthDayDate).Name("DATA DE NASCIMENTO").NameIndex(3);
		}		
	}
}
