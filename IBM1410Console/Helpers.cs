/* 
 *  COPYRIGHT 2020, 2021, 2022 Jay R. Jaeger
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  (file COPYING.txt) along with this program.  
 *  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace IBM1410Console
{
    internal class Helpers
    {

        internal static List<string> getComPorts() {
            List<string> comPorts = new List<string>();
            string pattern = @"^USB.*\((?<portname>COM.*)\)";
            using (var searcher = new System.Management.ManagementObjectSearcher(
                "root\\CIMV2", "SELECT * FROM Win32_PnPEntity")) {
                foreach (ManagementObject queryObj in searcher.Get()) {
                    if (queryObj["Caption"] != null) {
                        string s = queryObj["Caption"].ToString();
                        if (s.Contains("(COM") && s.Contains("USB")) {
                            Debug.WriteLine("Checking port: " + s);                                            
                        }
                        foreach (Match match in Regex.Matches(s,pattern)) {
                            string port = match.Groups["portname"].ToString();
                            Debug.WriteLine("Found USB Serial port: " + port);
                            comPorts.Add(port);
                        }
                    }
                }
            }
            return comPorts;
        }
    }
}
