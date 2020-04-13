using CSVHelperNaPratica.Entities;
using CSVHelperNaPratica.Services;
using CSVHelperNaPratica.Test.Builders;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using CSVHelperNaPratica.Test.Utils;
using System.IO;

namespace CSVHelperNaPratica.Test
{
	public class ExportToCsvTest
	{
		private readonly IExportToCsv _exportToCsv;
		private Customer _customer;

		public ExportToCsvTest()
		{
			_exportToCsv = new ExportToCsv();
			_customer = CustomerBuilder.Novo().Build();
		}

		[Fact]
		public void Deve_Verificar_Se_Tem_Modelo_Quando_Exportar_Byte_Array()
		{
			var _cutomerVazio = new List<Customer>();

			Assert.ThrowsAsync<Exception>(() => _exportToCsv.GenerateByteArrayCsvAsync(_cutomerVazio)).WithMessageAsync(Resource.TheNumberOfCustomersIsInvalid);
		}

		[Fact]
		public void Deve_Verificar_Se_Tem_Modelo_Quando_Exportar_Gerar_Arquivo()
		{
			var _cutomerVazio = new List<Customer>();

			Assert.ThrowsAsync<Exception>(() => _exportToCsv.GenerateCsvAsync(_cutomerVazio)).WithMessageAsync(Resource.TheNumberOfCustomersIsInvalid);
		}

		[Fact]
		public void Deve_Gerar_Arquivo_Csv()
		{
			var cutomers = CustomerBuilder.Novo().BuildList();

			var tempPathCsv = _exportToCsv.GenerateCsvAsync(cutomers).Result;

			Assert.True(File.Exists(tempPathCsv));
		}

		[Fact]
		public void Deve_Gerar_Csv_Em_Byte_Array()
		{
			var cutomers = CustomerBuilder.Novo().BuildList();

			var byteArray = _exportToCsv.GenerateByteArrayCsvAsync(cutomers).Result;

			Assert.True(byteArray.Length > 0);
		}
	}
}
