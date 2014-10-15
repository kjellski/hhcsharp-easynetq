@echo off
rem Receiver
cd EasyNetQTalk.ConsoleReceiver\bin\Debug
start EasyNetQTalk.ConsoleReceiver.exe

cd ..\..\..

rem Sender
cd EasyNetQTalk.ConsoleSender\bin\Debug
start EasyNetQTalk.ConsoleSender.exe

exit