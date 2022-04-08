; Forgery NSIS Installer
; ---------------------

; Installer Info
Name "Forgery"
OutFile "Forgery.Editor.{version}.exe"
InstallDir "$PROGRAMFILES\Forgery Editor"
InstallDirRegKey HKLM "Software\Forgery\Editor" "InstallDir"
RequestExecutionLevel admin

; Version Info
VIProductVersion "{version}"
VIAddVersionKey "FileVersion" "{version}"
VIAddVersionKey "ProductName" "Forgery Editor"
VIAddVersionKey "FileDescription" "Installer for Forgery Editor"
VIAddVersionKey "LegalCopyright" "http://logic-and-trick.com 2018"

; Ensure Admin Rights
!include LogicLib.nsh

Function .onInit
    UserInfo::GetAccountType
    pop $0
    ${If} $0 != "admin" ;Require admin rights on NT4+
        MessageBox mb_iconstop "Administrator rights required!" /SD IDOK
        SetErrorLevel 740 ;ERROR_ELEVATION_REQUIRED
        Quit
    ${EndIf}
FunctionEnd

; Installer Pages

Page components
Page directory
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

; Installer Sections

Section "Forgery Editor"
    IfSilent 0 +2 ; Silent mode: Forgery has executed the installer for an update
        Sleep 2000 ; Make sure the program has shut down...
    
    SectionIn RO
    SetOutPath $INSTDIR

    ; Purge junk from old installs
    Delete "$INSTDIR\*.dll"
    Delete "$INSTDIR\*.pdb"
    Delete "$INSTDIR\Forgery.Editor.Elevate.exe"
    Delete "$INSTDIR\Forgery.Editor.Updater.exe"
    Delete "$INSTDIR\UpdateSources.txt"

    File /r "Build\*"
    
    WriteRegStr HKLM "Software\Forgery\Editor" "InstallDir" "$INSTDIR"
    WriteRegStr HKLM "Software\Forgery\Editor" "Version" "{version}"
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ForgeryEditor" "DisplayName" "Forgery Editor"
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ForgeryEditor" "UninstallString" '"$INSTDIR\Uninstall.exe"'
    WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ForgeryEditor" "NoModify" 1
    WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ForgeryEditor" "NoRepair" 1
    WriteUninstaller "Uninstall.exe"
SectionEnd

Section "Start Menu Shortcuts"
    IfSilent 0 +2
        Goto end ; Silent update: Don't redo shortcuts
        
    SetShellVarContext all
    CreateDirectory "$SMPROGRAMS\Forgery Editor"
    CreateShortCut "$SMPROGRAMS\Forgery Editor\Uninstall.lnk" "$INSTDIR\Uninstall.exe" "" "$INSTDIR\Uninstall.exe" 0
    CreateShortCut "$SMPROGRAMS\Forgery Editor\Forgery Editor.lnk" "$INSTDIR\Forgery.Editor.exe" "" "$INSTDIR\Forgery.Editor.exe" 0

    end:
SectionEnd

Section "Desktop Shortcut"
    IfSilent 0 +2
        Goto end ; Silent update: Don't redo shortcuts
    
    SetShellVarContext all
    CreateShortCut "$DESKTOP\Forgery Editor.lnk" "$INSTDIR\Forgery.Editor.exe" "" "$INSTDIR\Forgery.Editor.exe" 0
    
    end:
SectionEnd

Section "Run Forgery After Installation"
    SetAutoClose true
    Exec "$INSTDIR\Forgery.Editor.exe"
SectionEnd

; Uninstall

Section "Uninstall"

  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ForgeryEditor"
  DeleteRegKey HKLM "Software\Forgery\Editor"

  SetShellVarContext all
  Delete "$SMPROGRAMS\Forgery Editor\*.*"
  Delete "$DESKTOP\Forgery Editor.lnk"

  RMDir /r "$SMPROGRAMS\Forgery Editor"
  RMDir /r "$INSTDIR"

SectionEnd