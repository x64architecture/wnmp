Wnmp Build Instructions
=======================

Prerequisites
=============
+ Visual Studio Express 2013
+ Visual Studio Express 2012 (if you want to build CertGen)
+ NUnit 2.6.3 (if you want to build the tests)
+ Inno Setup 5.5.5
+ Git for Windows
 
Building Wnmp
=============
1. Get the Wnmp source code
    * git clone https://github.com/wnmp/wnmp.git

2. Open the VS2012 x86 Native Tools Command Prompt then run the following command:
    * msbuild (where you cloned wnmp to)/Wnmp/Wnmp.csproj /p:Configuration=Release

Building The Installer
======================
1. First download the latest release of Wnmp (Wnmp-XXXX.exe)
2. Install it to C:\Wnmp
3. Delete unins000.exe and unins000.dat
4. Copy the Wnmp.exe compiled from the Building Wnmp section to C:\Wnmp\Wnmp.exe
5. Add Inno Setup to your path
6. Then run issc "C:\Wnmp\contrib\Wnmp Installer.iss"
7. Done! The output executable should be located at C:\Wnmp Output
