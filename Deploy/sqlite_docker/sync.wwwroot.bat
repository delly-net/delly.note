@echo off
echo Sync wwwroot files ...
del /F /S /Q .\files\wwwroot\*
xcopy ..\..\Mvc\Universal\Delly.Note.Page\wwwroot .\files\wwwroot /S /E
echo Done
pause