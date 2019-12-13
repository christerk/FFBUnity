# name the installer
OutFile "FUMBBL FFB Installer.exe"

Name "FUMBBL"
Icon "..\..\Fumbbl.ico"

InstallDir "$PROGRAMFILES\$(^Name)"

Page directory
Page instfiles

Section "Install"
 
SetOutPath $INSTDIR

File /r "..\..\Builds\Windows\*.*"

# define uninstaller name
WriteUninstaller $INSTDIR\uninstaller.exe

CreateDirectory "$SMPROGRAMS\$(^Name)"
CreateShortCut "$SMPROGRAMS\$(^Name)\FFBClient.lnk" "$INSTDIR\FUMBBL FFB.exe"
CreateShortCut "$SMPROGRAMS\$(^Name)\uninstaller.lnk" "$INSTDIR\uninstaller.exe"

# default section end
SectionEnd

Section "Uninstall"
  
RMDIR /r "$INSTDIR"
RMDIR /r "$SMPROGRAMS\$(^Name)"

SectionEnd