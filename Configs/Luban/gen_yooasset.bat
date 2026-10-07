@echo off
setlocal

set "PROJECT_ROOT=%~dp0..\.."
set "LUBAN_DLL=%PROJECT_ROOT%\Tools\Luban\Luban.dll"

dotnet "%LUBAN_DLL%" ^
    --conf "%~dp0luban.conf" ^
    -t client ^
    -c cs-simple-json ^
    -d json ^
    -x "outputCodeDir=%PROJECT_ROOT%\Assets\Experiments\Luban\Generated" ^
    -x "outputDataDir=%PROJECT_ROOT%\Assets\Experiments\YooAsset\LubanData"

if errorlevel 1 (
    echo Generation failed. Check the errors above.
    pause
    exit /b 1
)

echo Generation succeeded.
pause