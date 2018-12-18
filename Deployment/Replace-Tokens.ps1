param(
    [Parameter(Mandatory=$true)][string]$filePath,
    [Parameter(Mandatory=$true)][string]$secrets   
)

Write-Host -Fore Yellow "Replacing Tokens";
    
$fileContents = [IO.File]::ReadAllText($filePath)

$theSecrets = $secrets |ConvertFrom-JSON 
    
#foreach($theEnv in (Get-ChildItem env:* | sort-object Name)){
#    if($theEnv.Name.StartsWith($tokensStartingWith))
#    {
#        Write-Host -Fore Yellow "Updating: $($theEnv.Name)=$($theEnv.Value)"
#        $fileContents = $fileContents.Replace("`${$($theEnv.Name)}", $theEnv.Value)
#    }
#}


foreach($theSecret in $theSecrets.PSObject.Properties){
    Write-Host -Fore Yellow "Updating: $($theSecret.Name)=$($theSecret.Value)"
    $fileContents = $fileContents.Replace("`${$($theSecret.Name)}", $theSecret.Value)
}

$fileContents

#$fileContents | Out-File -Encoding utf8 -filePath $filePath | Out-Null
#Write-Host -Fore Yellow $fileContents

