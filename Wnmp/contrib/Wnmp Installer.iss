; Wnmp iss
#define MyAppName "Wnmp"
#define MyAppVersion "4.0.0"
#define MyAppPublisher "Kurt Cancemi"
#define MyAppURL "https://wnmp.x64architecture.com"
#define MyAppExeName "Wnmp.exe"
#define Year "2021"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{44CF85C5-C9D2-435F-941B-75597AA9A6FB}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
SignTool=tools
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
OutputDir=../WnmpOutput
OutputBaseFilename=Wnmp-{#MyAppVersion}
SetupIconFile=../src/Wnmp/logo.ico
Compression=lzma2
LZMADictionarySize=24000
LZMANumBlockThreads=8
LZMAUseSeparateProcess=yes
SolidCompression=false
RestartIfNeededByRun=false
PrivilegesRequired=admin
DirExistsWarning=no

[Languages]
Name: english; MessagesFile: compiler:Default.isl

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked

[Files]
Source: conf\fastcgi.conf; DestDir: {app}\conf; Flags: ignoreversion
Source: conf\fastcgi_params; DestDir: {app}\conf; Flags: ignoreversion
Source: conf\koi-utf; DestDir: {app}\conf; Flags: ignoreversion
Source: conf\koi-win; DestDir: {app}\conf; Flags: ignoreversion
Source: conf\mime.types; DestDir: {app}\conf; Flags: ignoreversion
Source: conf\nginx.conf; DestDir: {app}\conf; Flags: ignoreversion
Source: conf\php_processes.conf; DestDir: {app}\conf; Flags: ignoreversion
Source: conf\scgi_params; DestDir: {app}\conf; Flags: ignoreversion
Source: conf\uwsgi_params; DestDir: {app}\conf; Flags: ignoreversion
Source: conf\win-utf; DestDir: {app}\conf; Flags: ignoreversion
Source: contrib\*; DestDir: {app}\contrib; Flags: ignoreversion recursesubdirs createallsubdirs
Source: docs\*; DestDir: {app}\docs; Flags: ignoreversion recursesubdirs createallsubdirs
Source: html\*; DestDir: {app}\html; Flags: ignoreversion recursesubdirs createallsubdirs
Source: html\index.php; DestDir: {app}\html; Flags: ignoreversion onlyifdoesntexist
Source: logs\*; Excludes: ".gitignore"; DestDir: {app}\logs; Flags: ignoreversion recursesubdirs createallsubdirs
Source: mariadb\bin\*; Excludes: ".gitignore"; DestDir: {app}\mariadb\bin; Flags: ignoreversion
Source: mariadb\include\*; Excludes: ".gitignore"; DestDir: {app}\mariadb\include; Flags: ignoreversion recursesubdirs createallsubdirs
Source: mariadb\lib\*; Excludes: ".gitignore"; DestDir: {app}\mariadb\data; Flags: ignoreversion recursesubdirs createallsubdirs
Source: mariadb\share\*; Excludes: ".gitignore"; DestDir: {app}\mariadb\share; Flags: ignoreversion recursesubdirs createallsubdirs
Source: php\*; DestDir: {app}\php; Flags: ignoreversion recursesubdirs createallsubdirs
Source: temp\*; DestDir: {app}\temp; Flags: ignoreversion recursesubdirs createallsubdirs
Source: nginx.exe; DestDir: {app}; Flags: ignoreversion
Source: readme.txt; DestDir: {app}; Flags: ignoreversion
Source: "VC_redist.x64.exe"; DestDir: {tmp}; Flags: ignoreversion deleteafterinstall
Source: Wnmp.exe; DestDir: {app}; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: {group}\{#MyAppName}; Filename: {app}\{#MyAppExeName}
Name: {group}\{cm:UninstallProgram,{#MyAppName}}; Filename: {uninstallexe}
Name: {commondesktop}\{#MyAppName}; Filename: {app}\{#MyAppExeName}; Tasks: desktopicon

[Run]
Filename: {app}\{#MyAppExeName}; Description: {cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}; Flags: nowait postinstall shellexec
Filename: "{tmp}\VC_redist.x64.exe"; Parameters: "/install /passive /norestart"
Filename: iexplore.exe; Parameters: "https://wnmp.x64architecture.com"; Verb: open; Flags: shellexec runasoriginaluser