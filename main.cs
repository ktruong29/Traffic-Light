//****************************************************************************************************************************
//Program name: "Fibonacci Number Computing System".  This programs accepts a non-negative integer from the user and then    *
//outputs the Fibonacci number corresponding to that integer.                                                                *
//Copyright (C) 2017  Floyd Holliday                                                                                         *
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License  *
//version 3 as published by the Free Software Foundation.                                                                    *
//This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied         *
//warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.     *
//A copy of the GNU General Public License v3 is available here:  <https://www.gnu.org/licenses/>.                           *
//****************************************************************************************************************************
/******************************************************************************
 *Author:  Kien Truong
 *Program: Traffic signal
 ******************************************************************************/
using System;
using System.Windows.Forms;  //Needed for "Application" on next to last line of Main
public class TrafficMain
{  static void Main(string[] args)
   {
      TrafficSignal trafficApp = new TrafficSignal();
      Application.Run(trafficApp);
      System.Console.WriteLine("Main method will now shutdown.");
   }//End of Main
}//End of TrafficMain
