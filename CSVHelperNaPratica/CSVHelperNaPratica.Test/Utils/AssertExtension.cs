using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSVHelperNaPratica.Test.Utils
{
	public static class AssertExtension
	{
		public static void WithMessageAsync(this Task<Exception> exception, string mensagem)
		{
			if (exception.Result.Message.Contains(mensagem))
				Assert.True(true);
			else
				Assert.False(true, $"Esperava a mensagem '{mensagem}'");
		}
	}
}
