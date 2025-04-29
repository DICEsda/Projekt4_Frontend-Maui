@echo off
echo Building and running FinanceTrackerAPP for Windows...
cd FinanceTrackerAPP

REM Build the solution first
dotnet build FinanceTrackerAPP.sln -f net9.0-windows10.0.19041.0
if %ERRORLEVEL% NEQ 0 (
    echo Build failed with error code %ERRORLEVEL%
    pause
    exit /b %ERRORLEVEL%
)

echo Build succeeded
echo Running the application...

REM Launch the executable directly instead of using dotnet run
set APP_PATH=FinanceTrackerAPP\bin\Debug\net9.0-windows10.0.19041.0\win10-x64\
cd %APP_PATH%
start FinanceTrackerAPP.exe
if %ERRORLEVEL% NEQ 0 (
    echo Run failed with error code %ERRORLEVEL%
    pause
    exit /b %ERRORLEVEL%
)

echo Application started successfully.
cd ..\..\..\..\..
pause

dotnet workload update 