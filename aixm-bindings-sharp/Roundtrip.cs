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
	class Roundtrip
	{

//		public static void Main(string[] args)
//		{
//            TimePeriodTryout tpt = null;
//            string fileInput;
//            string fileOutput;
//			if (args == null || args.Length == 0) 
//            {
//				throw new Exception("Input and Output file path's required.");
//			}
//            else
//            {
//                if (args.Length == 1)
//                {
//                    if (Directory.Exists(args[0]))
//                    {
//                        fileInput = args[0] + "\\"+ "navaid.xml";
//                        fileOutput = args[0] + "\\" + "navaid-re-cs.xml";
//
//                        tpt = new TimePeriodTryout(args[0]);
//                    }
//                    else
//                    {
//                        throw new Exception("Input path is not a valid directory.");
//                    }
//                }
//                else if (args.Length == 2)
//                {
//                    fileInput = args[0];
//                    fileOutput = args[1];
//                }
//                else
//                {
//                    throw new Exception("Input path is not a valid directory.");
//                }
//            }
//			
//			Console.WriteLine("Navaid roundtripping...!");
//
//            Stopwatch sw = new Stopwatch();
//            
//            GenericRoundtrip<NavaidType> rt = new GenericRoundtrip<NavaidType>();
//            rt.DoRoundtrip(fileInput, fileOutput);
//			
//			Console.WriteLine("Rondtrip complete! Took {0} milliseconds.", rt.ElapsedTime);
//            Thread.Sleep(2000);
//
//            if (tpt != null)
//            {
//                tpt.Test();
//            }
//		}
		

    }
}
