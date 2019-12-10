# name the installer
OutFile "FFBUnityInstaller.exe"

Name "FUMBBL"

Icon "..\..\Fumbbl.ico"

InstallDir "$PROGRAMFILES\FUMBBL"

Page directory
Page instfiles

Section "Install"
 
SetOutPath $INSTDIR

File /r "..\..\Builds\Windows\*.*"

# define uninstaller name
WriteUninstaller $INSTDIR\uninstaller.exe

CreateDirectory "$SMPROGRAMS\$(^Name)"
CreateShortCut "$SMPROGRAMS\$(^Name)\FFBClient.lnk" "$INSTDIR\FFBClient.exe"
CreateShortCut "$SMPROGRAMS\$(^Name)\uninstaller.lnk" "$INSTDIR\uninstaller.exe"

# default section end
SectionEnd

Section "Uninstall"
  
RMDIR /r "$INSTDIR"
RMDIR /r "$SMPROGRAMS\$(^Name)"

SectionEnd