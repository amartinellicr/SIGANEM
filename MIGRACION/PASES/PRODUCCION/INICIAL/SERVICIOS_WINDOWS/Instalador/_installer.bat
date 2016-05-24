@ECHO OFF
 
echo Instalando SIGANEM Windows Service...
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\InstallUtil /i E:\Servicios\SIGANEM\wsaIndicadores\BCR.SIGANEM.wsaIndicadores.exe
echo ---------------------------------------------------
echo Done.
pause
cls
echo Iniciando SIGANEM Windows Service...
NET START "SIGANEM Windows Service"
echo ---------------------------------------------------
echo Done.
pause
