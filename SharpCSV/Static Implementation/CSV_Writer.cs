using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SharpCSV.StaticImplementation
{
	/// <summary>
	/// Super primitive static class for writing CSV files.
	/// </summary>
	static class CSV_Writer
	{
		/// <summary>
		/// Writes the contents to a CSV file.
		/// </summary>
		/// <param name="path">The destination path.</param>
		/// <param name="contents">The contents you would like the CSV to contain.</param>
		/// <param name="seperator">The character which separates each element of the created CSV.</param>
		/// <returns>Boolean value representing the success of the write.</returns>
		public static bool WriteCSV(string path, IEnumerable<object[]> contents, char seperator = ',')
		{
			try
			{
				// We're going to need a writer to get started. I mean, how else do you write things?
				using (var writer = new StreamWriter(path))
				{
					// Cycle the provided contents.
					foreach (var row in contents)
					{
						// Create a container for our line.
						var rawRow = "";

						// Cycle the items in this row. ToString them and attach with he specified separator.
						foreach (var item in row)
						{
							rawRow += item.ToString() + seperator;
						}

						// Write out the cool new line.
						writer.WriteLine(rawRow);
					}
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}	
		}
	}
}
