using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SharpCSV.StaticImplementation
{
	/// <summary>
	/// Super primitive static class for reading CSV files.
	/// </summary>
	public class CSV_Reader
	{
		/// <summary>
		/// Reads the contents of a CSV file, it will also include the header.
		/// </summary>
		/// <param name="path">The path to the CSV file.</param>
		/// <param name="separator">The separator character found in the CSV.</param>
		/// <returns>A list of arrays that contain the lines of the specified CSV.</returns>
		public static List<object[]> ReadCSV(string path, char separator)
		{
			List<object[]> contents = new List<object[]>();

			// As all good readings start, with the entrance of a reader.
			using (var reader = new StreamReader(path))
			{
				// Are we at the end? No? Keep going!
				while (!reader.EndOfStream)
				{
					// Grab the line and split it.
					var line = reader.ReadLine();
					var splitLine = line.Split(separator);
					contents.Add(splitLine);
				}
			}

			return contents;
		}
	}
}
