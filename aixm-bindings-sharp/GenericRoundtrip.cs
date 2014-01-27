/*
 * Copyright (C) 2013
 * by 52 North Initiative for Geospatial Open Source Software GmbH
 *
 * Contact: Andreas Wytzisk
 * 52 North Initiative for Geospatial Open Source Software GmbH
 * Martin-Luther-King-Weg 24
 * 48155 Muenster, Germany
 * info@52north.org
 *
 * This program is free software; you can redistribute and/or modify it under
 * the terms of the GNU General Public License version 2 as published by the
 * Free Software Foundation.
 *
 * This program is distributed WITHOUT ANY WARRANTY; even without the implied
 * WARRANTY OF MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program (see gnu-gpl v2.txt). If not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA or
 * visit the Free Software Foundation web page, http://www.fsf.org.
 */
 
/*
 * Created by SharpDevelop.
 * User: matthes rieke
 * Date: 16.12.2013
 * Time: 13:30
 * 
 */
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

using aero.aixm.v51;
using System.Diagnostics;

namespace aixm_bindings_sharp
{
	class GenericRoundtrip<T>
	{
		private long elapsedTime;
		private XmlSerializer deserial;
		
		public long ElapsedTime {
			get { return elapsedTime; }
			set { elapsedTime = value; }
		}
		
		public GenericRoundtrip()
		{
			deserial = new XmlSerializer(typeof(T));
		}

		public string DoRoundtrip(string inputPath)
		{
			return DoRoundtrip(inputPath, null);
		}
		
		public string DoRoundtrip(string inputPath, string outputPath)
		{
			string input = ReadFileContents(inputPath);

			string result = Execute(input);
			
			if (outputPath != null)
			{
				WriteFileContents(result, outputPath);
			}
			
			return result;
		}
		
		public string Execute(string input)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();

			T obj = this.DeSerialize(input);
			
			string result = this.Serialize(obj);
			sw.Stop();
			this.elapsedTime = sw.ElapsedMilliseconds;
			
			return result;
		}
		
		public T DeSerialize(string input)
		{
			return (T) deserial.Deserialize(new StringReader(input));
		}
		
		public string Serialize(T obj)
		{
			StringWriter textWriter = new StringWriter();

			deserial.Serialize(textWriter, obj);
			
			string result = textWriter.ToString();
			return result;
		}
		
		public static string ReadFileContents(string path)
		{
			return File.ReadAllText(path);
		}
		
		public static void WriteFileContents(string content, string path)
		{
			File.WriteAllText(path, content);
		}

		
    }
}
