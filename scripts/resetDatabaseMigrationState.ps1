$rootPath = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition
$rootPath = Resolve-Path -Path $rootPath\.. 
Set-Location $rootPath
  
$migrationsPath = Join-Path -Path $rootPath -ChildPath "src/Homesite.Infrastructure/Persistence/Migrations" 
$webPath = Join-Path -Path $rootPath -ChildPath "src/Homesite.Web"
$infrastructurePath = Join-Path -Path $rootPath -ChildPath "src/Homesite.Infrastructure"

#Remove the migration files
Remove-Item $migrationsPath\* -Include *.cs

#Remove the database
Remove-Item $webPath\app.db
Remove-Item $webPath\app.db-shm
Remove-Item $webPath\app.db-wal


dotnet ef database update --project $infrastructurePath --startup-project $webPath
dotnet ef migrations add "InitialMigration" --project $infrastructurePath --startup-project $webPath --output-dir $migrationsPath


