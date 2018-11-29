param(
    [Parameter(Mandatory=$true)][string]$filePath,
    [Parameter(Mandatory=$true)][string]$tokensStartingWith
)

Write-Host -Fore Yellow "Replacing Tokens";
    
$fileContents = [IO.File]::ReadAllText($filePath)

    
foreach($theEnv in (Get-ChildItem env:* | sort-object Name)){
    if($theEnv.Name.StartsWith($tokensStartingWith))
    {
        Write-Host -Fore Yellow "Updating: $($theEnv.Name)=$($theEnv.Value)"
        $fileContents = $fileContents.Replace("`${$($theEnv.Name)}", $theEnv.Value)
    }
}

$fileContents | Out-File -Encoding utf8 -filePath $filePath | Out-Null
Write-Host -Fore Yellow $fileContents

