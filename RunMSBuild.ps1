    $MSDirectory = "C:\windows\Microsoft.Net\Framework64\v4.0.30319\msbuild.exe"
    $fileinfo = [System.IO.FileInfo]::new($MSDirectory)
    if(!$fileinfo.Exists)
    {
        Write-Error -Message "The executable msbuild.exe not found in $MSDirectory"
        Exit 3
    }
    Write-Host "Start Compilation."

    $ProjectDir = (Get-ChildItem -Recurse -Filter *.csproj).FullName
    $script = 
    Invoke-Expression "$MSDirectory $ProjectDir"