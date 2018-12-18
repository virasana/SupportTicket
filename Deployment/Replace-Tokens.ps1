param(
    [Parameter(Mandatory=$true)][string]$filePath,
    [Parameter(Mandatory=$true)][string]$secrets,   
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


# Iterate secrets - VSTS won't pass these 
#      into the environment - we need to use $secrets
$theSecrets = $secrets | ConvertFrom-JSON 
foreach($theSecret in $theSecrets.PSObject.Properties){
    Write-Host -Fore Yellow "Updating: $($theSecret.Name)=$($theSecret.Value)"
    $fileContents = $fileContents.Replace("`${$($theSecret.Name)}", $theSecret.Value)
}

$fileContents

#$fileContents | Out-File -Encoding utf8 -filePath $filePath | Out-Null
#Write-Host -Fore Yellow $fileContents

