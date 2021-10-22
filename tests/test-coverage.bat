rmdir CoverageResults /s /q

dotnet test ^
/p:CollectCoverage=true ^
/p:CoverletOutput=../tests/CoverageResults/ ^
/p:MergeWith="../tests/CoverageResults/coverage.json" ^
/p:CoverletOutputFormat=\"cobertura,json,opencover\" ^
/p:ExcludeByFile=\"**/Program.cs,**/IServiceCollectionExtension.cs,**/Startup.cs,**/Worker.cs\" ^
-m:1 ^
..\

reportgenerator ^
-reports:".\CoverageResults\coverage.cobertura.xml" ^
-targetdir:".\CoverageResults\Report" ^
-reporttypes:Html;HTMLSummary

start "" ".\CoverageResults\Report\index.html"

pause