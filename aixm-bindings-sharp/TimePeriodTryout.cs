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
using System.Xml;
using System.Xml.Serialization;

using aero.aixm.v51;

namespace aixm_bindings_sharp
{
	class TimePeriodTryout
	{
		public static void test(string[] args)
		{
			if (args == null || args.Length != 2) {
				throw new Exception("Input and Output file path's required.");
			}
			
			Console.WriteLine("TimePeriod roundtripping...!");
			
			String content = readFileContents(args[0]);
			
			String rt = roundtrip(content);
			
			writeFileContents(rt, args[1]);
			
			Console.WriteLine("Rondtrip complete!");
			Console.ReadLine();
		}
		
		private static String roundtrip(String input) {
			XmlSerializer deserial = new XmlSerializer(typeof(TimePeriodType));
			TimePeriodType obj = (TimePeriodType) deserial.Deserialize(new StringReader(input));
			
			StringWriter textWriter = new StringWriter();

			deserial.Serialize(textWriter, obj);
			return textWriter.ToString();
		}
		
		private static String readFileContents(String path) {
			return File.ReadAllText(path);
		}
		
		private static void writeFileContents(String content, String path) {
			File.WriteAllText(path, content);
		}
	}
}
