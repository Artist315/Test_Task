
set /p name=enter migration name:
dotnet ef migrations add %name%   --startup-project  ../MasterData.App --verbose
pause