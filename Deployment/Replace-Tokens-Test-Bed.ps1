cls
& $PSScriptRoot/Replace-Tokens.ps1 `
            -filePath (Join-Path -Path $PSScriptRoot -ChildPath "test.yaml") `
            -secrets `
"
{
'SUPPORT_TICKET_DEPLOY_DB_CONN_STRING_AUTH':  '$secret1',
'SUPPORT_TICKET_DEPLOY_JWT_SECRET':  '$secret2',
'SUPPORT_TICKET_DEPLOY_DB_SA_PASSWORD':  '$secret3',
'SUPPORT_TICKET_DEPLOY_DB_CONN_STRING':  '$secret4'
}
"
