using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCSV
{
	class Utilities
	{
		internal static bool DoesFileExist(string path)
		{
			return System.IO.File.Exists(path);
		}
	}
}
