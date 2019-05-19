dotnet build -c Release
if ($?) {
    dotnet ./ByteSerializationBenchmark/bin/Release/netcoreapp2.1/ByteSerializationBenchmark.dll
}