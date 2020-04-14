using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVHelperNaPratica.Helpers
{
	public static class ByteArrayExtension
	{
		public static bool Save(this byte[] file, string fileName)
		{
			try
			{
				System.IO.FileStream _FileStream = new System.IO.FileStream(fileName, FileMode.Create, FileAccess.Write);

				_FileStream.Write(file, 0, file.Length);

				_FileStream.Close();

				return true;
			}
			catch (Exception _Exception)
			{
				Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
			}
			return false;
		}
	}
}
