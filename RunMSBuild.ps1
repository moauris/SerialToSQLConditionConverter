    $MSDirectory = "C:\windows\Microsoft.Net\Framework64\v4.0.30319\msbuild.exe"
    $fileinfo = [System.IO.FileInfo]::new($MSDirectory)
    if(!$fileinfo.Exists)
    {
        Write-Error -Message "The executable msbuild.exe not found in $MSDirectory"
        Return 3
    }
    Write-Host "Start Compilation."

    $ProjectDir = (Get-ChildItem -Recurse -Filter *.csproj).FullName
    $command = "$MSDirectory $ProjectDir"
    $promptmessage = "Will execute Compile command `r`n $command `r`n Press [Y] to continue, [N] to exit"

    $key = Read-Host -Prompt $promptmessage
    if($key -ne 'y')
    {
        Write-Host "Exiting..."
        Return 0
    }
    
    Invoke-Expression $command
