;Wnmp Upgrade Installer Script
;Inno Setup http://www.jrsoftware.org/isdl.php#stable

#define Name "Wnmp"
#define Version "2.0.12"
#define Publisher "Kurt Cancemi"
#define URL "http://wnmp.x64architecture.com"
#define ExeName "Wnmp.exe"
#define Year "2014"

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
OutputBaseFilename=Wnmp-Upgrade-Installer-{#Version} 
OutputDir=../Wnmp Output
SetupIconFile=contrib\logo.ico
Compression=lzma2
InternalCompressLevel=max
SolidCompression=yes
PrivilegesRequired=none
DirExistsWarning=no
RestartIfNeededByRun=no

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "Wnmp.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "*"; Excludes: "logs\*, mariadb\data\*, mariadb\mysql-test\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "../vc_2008_sp1_redist_x86.exe"; DestDir: {tmp}; Flags: deleteafterinstall
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"
Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#Name}"; Filename: "{app}\{#ExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#ExeName}"; Description: "{cm:LaunchProgram,{#StringChange(Name, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
Filename: "{app}\contrib\ReadMe.html"; Description: "View the ReadMe.html"; Flags: postinstall shellexec skipifsilent unchecked
Filename: "{tmp}\vc_2008_sp1_redist_x86.exe"; Check: VC2008RedistNeedsInstall
Filename: "http://getwnmp.org/"; Flags: shellexec runasoriginaluser postinstall unchecked; Description: "View Wnmp Website";
Filename: "http://getwnmp.org/contributing/"; Flags: shellexec runasoriginaluser postinstall; Description: "Make a contribution to Wnmp";

[Code]
#IFDEF UNICODE
  #DEFINE AW "W"
#ELSE
  #DEFINE AW "A"
#ENDIF
type
  INSTALLSTATE = Longint;
const
  INSTALLSTATE_INVALIDARG = -2;  // An invalid parameter was passed to the function.
  INSTALLSTATE_UNKNOWN = -1;     // The product is neither advertised or installed.
  INSTALLSTATE_ADVERTISED = 1;   // The product is advertised but not installed.
  INSTALLSTATE_ABSENT = 2;       // The product is installed for a different user.
  INSTALLSTATE_DEFAULT = 5;      // The product is installed for the current user.

  VC_2008_SP1_REDIST_X86 = '{9A25302D-30C0-39D9-BD6F-21E6EC160475}';

function MsiQueryProductState(szProduct: string): INSTALLSTATE; 
  external 'MsiQueryProductState{#AW}@msi.dll stdcall';

function VCVersionInstalled(const ProductID: string): Boolean;
begin
  Result := MsiQueryProductState(ProductID) = INSTALLSTATE_DEFAULT;
end;

function VC2008RedistNeedsInstall: Boolean;
begin
  Result := not (VCVersionInstalled(VC_2008_SP1_REDIST_X86));
end;