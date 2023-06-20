; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "MusicShop"
#define MyAppVersion "3.13"
#define MyAppExeName "MusicShopDesktopApp.exe"
#define MyAppAssocName MyAppName + ""
#define MyAppAssocExt ".myp"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{703CBB20-0541-4A67-B146-AADFF604ABD0}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
DefaultDirName=D:\RiderProjects\Diplom\MusicShopDesktopApp\{#MyAppName}
ChangesAssociations=yes
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputDir=D:\RiderProjects\Diplom\MusicShopDesktopApp
OutputBaseFilename=MusicShop
SetupIconFile=D:\RiderProjects\Diplom\MusicShopDesktopApp\MusicShopDesktopApp\Resources\Logotip.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\RiderProjects\Diplom\MusicShopDesktopApp\MusicShopDesktopApp\bin\Debug\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\RiderProjects\Diplom\MusicShopDesktopApp\MusicShopDesktopApp\bin\Debug\FileManegerJson.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\RiderProjects\Diplom\MusicShopDesktopApp\MusicShopDesktopApp\bin\Debug\FileManegerJson.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\RiderProjects\Diplom\MusicShopDesktopApp\MusicShopDesktopApp\bin\Debug\FileManegerJson.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\RiderProjects\Diplom\MusicShopDesktopApp\MusicShopDesktopApp\bin\Debug\Microsoft.Bcl.AsyncInterfaces.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\RiderProjects\Diplom\MusicShopDesktopApp\MusicShopDesktopApp\bin\Debug\MusicShopDesktopApp.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\RiderProjects\Diplom\MusicShopDesktopApp\MusicShopDesktopApp\bin\Debug\MusicShopDesktopApp.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\RiderProjects\Diplom\MusicShopDesktopApp\MusicShopDesktopApp\bin\Debug\System.Buffers.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\RiderProjects\Diplom\MusicShopDesktopApp\MusicShopDesktopApp\bin\Debug\System.Memory.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\RiderProjects\Diplom\MusicShopDesktopApp\MusicShopDesktopApp\bin\Debug\System.Numerics.Vectors.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\RiderProjects\Diplom\MusicShopDesktopApp\MusicShopDesktopApp\bin\Debug\System.Text.Encodings.Web.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\RiderProjects\Diplom\MusicShopDesktopApp\MusicShopDesktopApp\bin\Debug\System.Text.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\RiderProjects\Diplom\MusicShopDesktopApp\MusicShopDesktopApp\bin\Debug\System.Threading.Tasks.Extensions.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

