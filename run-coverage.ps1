#!/usr/bin/env pwsh

$testProject = ".\tests\UnitTest\UnitTest.csproj"

Write-Host "Executando testes e coletando cobertura..."
dotnet test $testProject --collect:"XPlat Code Coverage"

if ($LASTEXITCODE -ne 0) {
    Write-Host "Erro ao executar os testes. Verifique a saída para detalhes." -ForegroundColor Red
    exit $LASTEXITCODE
}

$coverageFile = ".\tests\UnitTest\TestResults\*\coverage.cobertura.xml"

Write-Host "Gerando relatório de cobertura em HTML..."
reportgenerator -reports:$coverageFile -targetdir:coveragereport -reporttypes:Html

if (Test-Path "coveragereport/index.html") {
    Write-Host "Relatório de cobertura gerado com sucesso. Abrindo no navegador..."
    Start-Process coveragereport/index.html
} else {
    Write-Host "Erro ao gerar o relatório de cobertura. Verifique se o ReportGenerator está instalado e se o arquivo de cobertura existe." -ForegroundColor Red
    exit 1
}