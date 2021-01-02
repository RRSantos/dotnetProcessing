@echo off
dotnet build src\dotnetProcessing\dotnetProcessing.sln
pushd  tests\dotnetProcessingManualTest\bin\Debug\netcoreapp3.1\
dotnetProcessingManualTest.exe 
popd 

