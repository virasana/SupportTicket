param(
    [Parameter(Mandatory=$true)][string]$filePath,
    [string]$secrets = "",   
    [Parameter(Mandatory=$true)][string]$tokensStartingWith       
)

function base64Encode
{
    param(
    [Parameter(Mandatory=$true)][string]$encodedString
    )
    
    $theBytes = [System.Text.Encoding]::Utf8.GetBytes($encodedString)
    $result =[Convert]::ToBase64String($theBytes)
    return $result
}


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

$fileContentsDisplay = $fileContents

if($secrets -ne ""){
    $theSecrets = $secrets | ConvertFrom-JSON 
    foreach($theSecret in $theSecrets.PSObject.Properties){
        Write-Host -Fore Yellow "Updating Secret: $($theSecret.Name)"
        $fileContents = $fileContents.Replace("`${$($theSecret.Name)}", (base64encode -encodedString $theSecret.Value))
        $fileContentsDisplay = $fileContentsDisplay.Replace("`${$($theSecret.Name)}", "********")
    }
}

#$fileContents | Out-File -Encoding utf8 -filePath $filePath | Out-Null
Write-Host -Fore Yellow $fileContentsDisplay