param(
    [Parameter(Mandatory=$true)][string]$filePath,
    [string]$secrets = "",   
    [Parameter(Mandatory=$true)][string]$tokensStartingWith       
)

Write-Host -Fore Yellow "Replacing Tokens";
    
$fileContents = [IO.File]::ReadAllText($filePath)

# Iterate Environment Variables
foreach($theEnv in (Get-ChildItem env:* | sort-object Name)){
    if($theEnv.Name.StartsWith($tokensStartingWith))
    {
        Write-Host -Fore Yellow "Updating: $($theEnv.Name)=$($theEnv.Value)"
        $fileContents = $fileContents.Replace("`${$($theEnv.Name)}", $theEnv.Value)
    }
}


if($secrets -ne ""){
    $theSecrets = $secrets | ConvertFrom-JSON 
    foreach($theSecret in $theSecrets.PSObject.Properties){
        Write-Host -Fore Yellow "Updating Secret: $($theSecret.Name)"
        $fileContents = $fileContents.Replace("`${$($theSecret.Name)}", $theSecret.Value)
    }
    
    $fileContents | Out-File -Encoding utf8 -filePath $filePath | Out-Null
}

Write-Host -Fore Yellow $fileContents