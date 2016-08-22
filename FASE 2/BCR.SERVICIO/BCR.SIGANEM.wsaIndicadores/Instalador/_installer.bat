@ECHO OFF
 
echo Instalando SIGANEM Windows Service...
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\InstallUtil /i ..\wsaIndicadores\BCR.SIGANEM.wsaIndicadores.exe
echo ---------------------------------------------------
echo Done.
pause
cls
echo Iniciando SIGANEM Windows Service...
NET START BCR.deSIGANEM.wsaIndicadores
echo ---------------------------------------------------
echo Done.
pause
