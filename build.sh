#!/bin/bash
#/*******************************************************************************
# *Author: Kien Truong
# *Program: Traffic signal
#******************************************************************************/

echo First remove old binary files
rm *.dll
rm *.exe

echo View the list of source files
ls -l

echo Compile FlashingRedLightInterface.cs to create the file: FlashingRedLightInterface.dll
mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:TrafficSignal.dll TrafficSignal.cs

echo Compile main.cs and link the previously created dll file to create an executable file.
mcs -r:System -r:System.Windows.Forms -r:TrafficSignal.dll -out:Traffic.exe main.cs

echo View the list of files in the current folder
ls -l

echo Run the Traffic program.
./Traffic.exe

echo The script has terminated.
