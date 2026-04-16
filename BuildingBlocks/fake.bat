@echo off
:: Fake Data Generator
:: Usage: fake.bat [module] <entity> [count] [options]
:: Examples:
::   fake.bat kh 5
::   fake.bat QLHD cv 3 --direct
::   fake.bat QLHD kh 1 --duan-id 08DE8B11-66A0-889C-687A-7B2360037372

dotnet run --project tests\QLHD.Tests\FakeDataTool\FakeDataTool.csproj -- %*
