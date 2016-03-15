; Wnmp iss
#define MyAppName "Wnmp"
#define MyAppVersion "2.2.3"
#define MyAppPublisher "Kurt Cancemi"
#define MyAppURL "https://www.getwnmp.org"
#define MyAppExeName "Wnmp.exe"
#define Year "2016"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{44CF85C5-C9D2-435F-941B-75597AA9A6FB}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={sd}\{#MyAppName}
SourceDir=..\
DefaultGroupName={#MyAppName}
VersionInfoDescription=Wnmp (version {#MyAppVersion})
VersionInfoCopyright=Copyright 2012-{#Year} Kurt Cancemi
VersionInfoCompany=Kurt Cancemi
LicenseFile=docs\Wnmp.LICENSE
InfoBeforeFile=
InfoAfterFile=contrib\postinstall.txt
OutputDir=../Wnmp Output
OutputBaseFilename=Wnmp-{#MyAppVersion}
SetupIconFile=contrib\logo.ico
Compression=lzma2
LZMADictionarySize=24000
LZMANumBlockThreads=8
SolidCompression=false
RestartIfNeededByRun=false
PrivilegesRequired=admin
DirExistsWarning=no

[Languages]
Name: english; MessagesFile: compiler:Default.isl

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked

[Files]
Source: Wnmp.exe; DestDir: {app}; Flags: ignoreversion
Source: bin\*; DestDir: {app}\bin; Flags: ignoreversion recursesubdirs createallsubdirs
Source: conf\*; DestDir: {app}\conf; Flags: ignoreversion recursesubdirs createallsubdirs
Source: contrib\*; DestDir: {app}\contrib; Flags: ignoreversion recursesubdirs createallsubdirs
Source: docs\*; DestDir: {app}\docs; Flags: ignoreversion recursesubdirs createallsubdirs
Source: html\*; DestDir: {app}\html; Flags: ignoreversion recursesubdirs createallsubdirs
Source: html\index.php; DestDir: {app}\html; Flags: ignoreversion onlyifdoesntexist
Source: logs\*; DestDir: {app}\logs; Flags: ignoreversion recursesubdirs createallsubdirs
Source: mariadb\bin\*; DestDir: {app}\mariadb\bin; Flags: ignoreversion recursesubdirs createallsubdirs
Source: mariadb\data\*; DestDir: {app}\mariadb\data; Flags: ignoreversion recursesubdirs createallsubdirs
Source: mariadb\share\*; DestDir: {app}\mariadb\share; Flags: ignoreversion recursesubdirs createallsubdirs
Source: mariadb\my.ini; DestDir: {app}\mariadb; Flags: ignoreversion
Source: php\*; DestDir: {app}\php; Flags: ignoreversion recursesubdirs createallsubdirs
Source: temp\*; DestDir: {app}\temp; Flags: ignoreversion recursesubdirs createallsubdirs
Source: changelog.txt; DestDir: {app}; Flags: ignoreversion
Source: nginx.exe; DestDir: {app}; Flags: ignoreversion
Source: readme.txt; DestDir: {app}; Flags: ignoreversion
Source: "vc_redist.x86.exe"; DestDir: {tmp}; Flags: deleteafterinstall
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: {group}\{#MyAppName}; Filename: {app}\{#MyAppExeName}
Name: {group}\{cm:UninstallProgram,{#MyAppName}}; Filename: {uninstallexe}
Name: {commondesktop}\{#MyAppName}; Filename: {app}\{#MyAppExeName}; Tasks: desktopicon

[Run]
Filename: {app}\{#MyAppExeName}; Description: {cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}; Flags: nowait postinstall shellexec
Filename: "{tmp}\vc_redist.x86.exe"; Parameters: "/install /passive /norestart"