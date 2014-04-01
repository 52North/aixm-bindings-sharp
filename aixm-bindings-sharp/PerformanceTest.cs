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
 * User: matthes
 * Date: 01.04.2014
 * Time: 13:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using aero.aixm.v51;

namespace aixm_bindings_sharp
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class PerformanceTest
	{
		
		public static void Main(string[] args)
		{
			new PerformanceTest().Execute();
			Console.ReadLine();
		}
		
		private List<string> resources;
		
		public PerformanceTest()
		{
			resources = new List<string>();
			resources.Add("xml\\navaid1.xml");
			resources.Add("xml\\airspace1.xml");
			resources.Add("xml\\routesegment1.xml");
			resources.Add("xml\\airport1.xml");
		}
		
		public void Execute()
		{
			for (int i = 0; i < 25; i++) {
				foreach (string key in resources)
				{
					IGenericRoundtrip rt = ResolveRoundtrip(key);
					
					if (rt != null)
					{
						Stopwatch sw = new Stopwatch();
						sw.Start();
	
						rt.DoRoundtrip(key, key+".output");	
						
						sw.Stop();
						OutputCSV(key+ ", "+ sw.ElapsedMilliseconds);
					}
					
				}
			}
			
		}
		
		private void OutputCSV(String s)
		{
			Console.WriteLine(s);
		}
		
		private IGenericRoundtrip ResolveRoundtrip(string s)
		{
			if (s.Contains("navaid"))
			{
				return new GenericRoundtrip<NavaidType>();
			}
			
			if (s.Contains("airspace"))
			{
				return new GenericRoundtrip<AirspaceType>();
			}

			if (s.Contains("routesegment"))
			{
				return new GenericRoundtrip<RouteSegmentType>();
			}
			
			if (s.Contains("airport"))
			{
				return new GenericRoundtrip<AirportHeliportType>();
			}
			
			return null;
		}
	}
}
