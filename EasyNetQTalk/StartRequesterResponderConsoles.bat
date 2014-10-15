@echo off
rem Responder
cd EasyNetQTalk.ConsoleResponder\bin\Debug
start EasyNetQTalk.ConsoleResponder.exe

cd ..\..\..

rem Requester
cd EasyNetQTalk.ConsoleRequester\bin\Debug
start EasyNetQTalk.ConsoleRequester.exe

exit