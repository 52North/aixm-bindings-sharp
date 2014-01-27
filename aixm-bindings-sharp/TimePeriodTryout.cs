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
using System.Threading;

namespace aixm_bindings_sharp
{
	class TimePeriodTryout
	{
        private string path;

        public TimePeriodTryout(string p)
        {
            this.path = p;
        }

		public void Test()
		{
            if (!Directory.Exists(this.path))
            {
                return;
            }

            string input = this.path + "\\timePeriod.xml";
            string output = this.path + "\\timePeriod-re-cs.xml";

			Console.WriteLine("TimePeriod roundtripping...!");
			
			GenericRoundtrip<TimePeriodType> rt = new GenericRoundtrip<TimePeriodType>();
			rt.DoRoundtrip(input, output);
			
			Console.WriteLine("Rondtrip complete! Took {0} ms", rt.ElapsedTime);
            Thread.Sleep(2000);
            

            string inputSlice = this.path + "\\airportHeliportTimeSlice.xml";
            string outputSlice = this.path + "\\airportHeliportTimeSlice-re-cs.xml";

			Console.WriteLine("navaidTimeSlice roundtripping...!");
			
			GenericRoundtrip<AirportHeliportTimeSliceType> rt2 = new GenericRoundtrip<AirportHeliportTimeSliceType>();
			rt2.DoRoundtrip(inputSlice, outputSlice);
			
			Console.WriteLine("Rondtrip complete! Took {0} ms", rt2.ElapsedTime);
            Thread.Sleep(2000);
            
            ExecuteProgrammaticDataSerialization();
		}
		
		private void ExecuteProgrammaticDataSerialization()
		{
			NavaidTimeSliceType type = new NavaidTimeSliceType();
			type.interpretation = aero.aixm.v51.interpretation.TEMPDELTA;
			type.validTime = new TimePrimitivePropertyType();
			TimePeriodType tp = new TimePeriodType();
			
			TimePositionType position = new TimePositionType();
			position.Value = "2011-01-13T12:00:00.000Z";
			tp.Item = position;
			tp.Item1 = position;
			
			type.validTime.AbstractTimePrimitive = tp;
			
			GenericRoundtrip<NavaidTimeSliceType> gr = new GenericRoundtrip<NavaidTimeSliceType>();
			string result = gr.Serialize(type);
			GenericRoundtrip<NavaidTimeSliceType>.WriteFileContents(result, this.path +"\\programmaticTimePeriod-re-cs.xml");
		}
		

    }
}
