#!/usr/bin/env pwsh
# Deploy Berries Paradise Web to Hostinger Subdomain
$keyFile = "C:\Users\USER\.ssh\chambapp-work-pc"
$server = "u291776795@217.21.76.75"
$port = 65002
$remoteRoot = "/home/u291776795/domains/chambapp.com.mx/public_html/berrys"

Write-Host "=== Deploying Berries Paradise Web to berrys.chambapp.com.mx ===" -ForegroundColor Cyan

# 0. Clean and Publish
Write-Host "Running dotnet clean..." -ForegroundColor Yellow
dotnet clean "src\BerriesParadise.Web\BerriesParadise.Web.csproj" -c Release

Write-Host "Running dotnet build..." -ForegroundColor Yellow
dotnet build "src\BerriesParadise.Web\BerriesParadise.Web.csproj" -c Release

Write-Host "Running dotnet publish..." -ForegroundColor Yellow
if (Test-Path "publish_out") { Remove-Item -Recurse -Force "publish_out" }
dotnet publish "src\BerriesParadise.Web\BerriesParadise.Web.csproj" -c Release -o "publish_out"

# Prepare un-fingerprinted runtime aliases for static hosting
Write-Host "Preparing runtime aliases in _framework..." -ForegroundColor Yellow
$latestDotnet = Get-ChildItem "publish_out\wwwroot\_framework\dotnet.*.js" | Where-Object { $_.Name -match '^dotnet\.[a-z0-9]+\.js$' } | Sort-Object LastWriteTime -Descending | Select-Object -First 1
if ($latestDotnet) {
    Copy-Item $latestDotnet.FullName "publish_out\wwwroot\_framework\dotnet.js" -Force
    Write-Host "Mapped $($latestDotnet.Name) -> dotnet.js" -ForegroundColor Green
}

$latestNativeJs = Get-ChildItem "publish_out\wwwroot\_framework\dotnet.native.*.js" | Where-Object { $_.Name -match '^dotnet\.native\.[a-z0-9]+\.js$' } | Sort-Object LastWriteTime -Descending | Select-Object -First 1
if ($latestNativeJs) {
    Copy-Item $latestNativeJs.FullName "publish_out\wwwroot\_framework\dotnet.native.js" -Force
}

$latestRuntimeJs = Get-ChildItem "publish_out\wwwroot\_framework\dotnet.runtime.*.js" | Where-Object { $_.Name -match '^dotnet\.runtime\.[a-z0-9]+\.js$' } | Sort-Object LastWriteTime -Descending | Select-Object -First 1
if ($latestRuntimeJs) {
    Copy-Item $latestRuntimeJs.FullName "publish_out\wwwroot\_framework\dotnet.runtime.js" -Force
}

$latestNativeWasm = Get-ChildItem "publish_out\wwwroot\_framework\dotnet.native.*.wasm" | Where-Object { $_.Name -match '^dotnet\.native\.[a-z0-9]+\.wasm$' } | Sort-Object LastWriteTime -Descending | Select-Object -First 1
if ($latestNativeWasm) {
    Copy-Item $latestNativeWasm.FullName "publish_out\wwwroot\_framework\dotnet.native.wasm" -Force
}

# 1. Upload .htaccess
Write-Host "Uploading .htaccess..." -ForegroundColor Yellow
if (Test-Path "publish_out\wwwroot\.htaccess") {
    scp -i $keyFile -P $port -o StrictHostKeyChecking=no `
        "publish_out\wwwroot\.htaccess" `
        "${server}:${remoteRoot}/.htaccess"
}

# 2. Upload CSS
Write-Host "Uploading CSS files..." -ForegroundColor Yellow
scp -i $keyFile -P $port -o StrictHostKeyChecking=no `
    "publish_out\wwwroot\css\paradise.css" `
    "${server}:${remoteRoot}/css/paradise.css"
scp -i $keyFile -P $port -o StrictHostKeyChecking=no `
    "publish_out\wwwroot\BerriesParadise.Web.styles.css" `
    "${server}:${remoteRoot}/BerriesParadise.Web.styles.css"

# 3. Upload JS
Write-Host "Uploading JS files..." -ForegroundColor Yellow
scp -i $keyFile -P $port -o StrictHostKeyChecking=no `
    "publish_out\wwwroot\js\hero-parallax.js" `
    "${server}:${remoteRoot}/js/hero-parallax.js"

# 4. Upload index.html
Write-Host "Uploading index.html..." -ForegroundColor Yellow
scp -i $keyFile -P $port -o StrictHostKeyChecking=no `
    "publish_out\wwwroot\index.html" `
    "${server}:${remoteRoot}/index.html"

# 4.1 Upload presence images
Write-Host "Uploading presence section assets..." -ForegroundColor Yellow
if (Test-Path "publish_out\wwwroot\images\hero_cinematic_landscape.jpg") {
    scp -i $keyFile -P $port -o StrictHostKeyChecking=no `
        "publish_out\wwwroot\images\hero_cinematic_landscape.jpg" `
        "${server}:${remoteRoot}/images/hero_cinematic_landscape.jpg"
}
if (Test-Path "publish_out\wwwroot\images\hero-berry-cluster-transparent.png") {
    scp -i $keyFile -P $port -o StrictHostKeyChecking=no `
        "publish_out\wwwroot\images\hero-berry-cluster-transparent.png" `
        "${server}:${remoteRoot}/images/hero-berry-cluster-transparent.png"
}

# 5. Clean remote _framework and unpack fresh bundle
Write-Host "Packaging and uploading fresh _framework..." -ForegroundColor Yellow
tar -czf framework_bundle.tar.gz -C "publish_out\wwwroot" _framework
scp -i $keyFile -P $port -o StrictHostKeyChecking=no `
    framework_bundle.tar.gz `
    "${server}:${remoteRoot}/framework_bundle.tar.gz"

ssh -i $keyFile -p $port -o StrictHostKeyChecking=no $server `
    "rm -rf ${remoteRoot}/_framework/* && cd ${remoteRoot} && tar -xzf framework_bundle.tar.gz && rm -f framework_bundle.tar.gz"

Remove-Item -Force -ErrorAction SilentlyContinue framework_bundle.tar.gz

Write-Host "=== Deployment successfully completed! ===" -ForegroundColor Green
Write-Host "URL: https://berrys.chambapp.com.mx" -ForegroundColor Cyan
