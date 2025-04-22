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

REM Now run the app separately
echo Running the application...
dotnet run --project FinanceTrackerAPP/FinanceTrackerAPP.csproj -f net9.0-windows10.0.19041.0 --no-build
if %ERRORLEVEL% NEQ 0 (
    echo Run failed with error code %ERRORLEVEL%
    pause
    exit /b %ERRORLEVEL%
)

echo Application started successfully.
pause

dotnet workload update 