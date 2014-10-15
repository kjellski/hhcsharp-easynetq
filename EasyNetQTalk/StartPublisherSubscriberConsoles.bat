@echo off
rem Subscriber
cd EasyNetQTalk.ConsoleSubscriber\bin\Debug
start EasyNetQTalk.ConsoleSubscriber.exe

cd ..\..\..

rem Publisher
cd EasyNetQTalk.ConsolePublisher\bin\Debug
start EasyNetQTalk.ConsolePublisher.exe

exit