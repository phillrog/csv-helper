using CSVHelperNaPratica.Services;
using Moq;
using System;
using Xunit;

namespace CSVHelperNaPratica.Test
{
	public class ExportToCsvTest
	{
		private readonly IExportToCsv _exportToCsv;

		public ExportToCsvTest()
		{
			var _exportToCsv = new ExportToCsv();
		}

		[Fact]
		public void Deve_Verificar_Se_Tem_Modelo()
		{
			_exportToCsv.GenerateByteArrayCsvAsync();
		}
	}
}
