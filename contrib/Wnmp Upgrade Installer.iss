;Wnmp Upgrade Installer Script
;Inno Setup http://www.jrsoftware.org/isdl.php#stable

#define Name "Wnmp"
#define Version "2.0.2.5"
#define Publisher "Kurt Cancemi"
#define URL "http://wnmp.x64architecture.com"
#define ExeName "Wnmp.exe"
#define Year "2013"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{44CF85C5-C9D2-435F-941B-75597AA9A6FB}
AppName={#Name}
AppVersion={#Version}
AppVerName={#Name} {#Version}
AppPublisher={#Publisher}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}
AppContact=kurt@x64Architecture.com
DefaultDirName={sd}\{#Name}
SourceDir=..\
VersionInfoDescription=Wnmp Upgrade Installer (version {#VERSION})
VersionInfoCopyright=Copyright 2012-{#Year} Kurt Cancemi
VersionInfoCompany=Kurt Cancemi
DefaultGroupName={#Name}
LicenseFile=license.txt
InfoAfterFile=contrib\postinstall.txt
OutputBaseFilename=Wnmp Upgrade Installer {#Version} 
OutputDir=../Wnmp Output
SetupIconFile=contrib\logo.ico
Compression=lzma2
InternalCompressLevel=max
SolidCompression=yes
PrivilegesRequired=none
DirExistsWarning=no

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "Wnmp.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "*"; Excludes: "conf\*, html\index.php, html\favicon.ico, logs\*, mariadb\data\*, php\php.ini, temp\*, mariadb\mysql-test\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"
Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#Name}"; Filename: "{app}\{#ExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#ExeName}"; Description: "{cm:LaunchProgram,{#StringChange(Name, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
Filename: "{app}\contrib\ReadMe.html"; Description: "View the ReadMe.html"; Flags: postinstall shellexec skipifsilent