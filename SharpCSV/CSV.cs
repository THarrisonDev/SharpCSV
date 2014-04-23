using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SharpCSV
{

	/// <summary>
	/// The CSV class is used to Open, Manipulate, and Save data in memory. 
	/// </summary>
	/// <author> Timothy R. Harrison </author>
	/// <creation>04/12/2014</creation>
	public class CSV
	{
		private string _path;
		private string[] _header;
		private List<string[]> _contents;
		private char[] _seperator;
		private bool _hasHeader;

		public CSV(string path, bool header, bool loadContents = false)
		{
			// Assign our Path.
			_path = path;
			_hasHeader = header;

			// If we are told to load from the top then we will load now.
			if (loadContents)
			{
				load();
			}
		}

		private void Load()
		{
			// Validate that the file exists.
			if (!Utilities.DoesFileExist(_path))
			{

			}

			// Create a StreamReader to the file.
			using (var reader = new StreamReader(_path))
			{
				bool headerRead = false;

				while (!reader.EndOfStream)
				{

					// Read a line in.
					var raw = reader.ReadLine();

					// Split the line based on our separator.
					var content = raw.Split(_seperator);

					// Check if we need to log this line as the Header;
					if (_hasHeader && !headerRead)
					{
						_header = content;
						headerRead = true;
					}
					else
					{
						// Add our row to the Contents.
						_contents.Add(content);
					}
				}
			}
		}

		private void Save()
		{
			// Create a new StreamWriter.
			using (var writer = new StreamWriter(_path))
			{
				// Loop through the Contents and add them to the file.
				writer.WriteLine(_header);

				foreach (var row in _contents)
				{
					writer.WriteLine(row, );
				}

				writer.Flush();
				writer.Close();
			}
		}
	}
}
