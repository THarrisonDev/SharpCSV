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
		private char _separator;
		private bool _hasHeader;

		public string[] Header 
		{
			get { return _header; }
			set { _header = value; }
		}

		public CSV(string path, char seperator, bool header, bool loadContents = false)
		{
			// Assign our Path.
			_path = path;
			_hasHeader = header;
			_separator = seperator;

			_contents = new List<string[]>();

			// If we are told to load from the top then we will load now.
			if (loadContents)
			{
				Load();
			}
		}

		/// <summary>
		/// Gets a row of data from the files contents.
		/// </summary>
		/// <param name="index"></param>
		public string[] Row(int index)
		{
			return _contents[index];
		}

		/// <summary>
		/// Get the string values contained in the specified column.
		/// </summary>
		/// <param name="header"></param>
		/// <param name="columnNum"></param>
		/// <returns></returns>
		public List<string> Column(int columnNum = 0, string header = "")
		{
			var values = new List<string>();

			// If they gave us the header name we will use it to find the index.
			if (!String.IsNullOrEmpty(header))
			{
				columnNum = Array.IndexOf(_header, header);
			}

			// Cycle the content.
			foreach (var row in _contents)
			{
				values.Add(row[columnNum]);
			}

			return values;
		}

		#region IO
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
					var content = raw.Split(_separator);

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
				if (_hasHeader)
				{
					writer.WriteLine(_header);
				}
				writer.WriteLine(_header);

				foreach (var row in _contents)
				{
					writer.WriteLine(row);
				}

				writer.Flush();
				writer.Close();
			}
		}
		#endregion
	}
}
