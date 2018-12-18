cls
& $PSScriptRoot/Replace-Tokens.ps1 `
            -filePath (Join-Path -Path $PSScriptRoot -ChildPath "test.yaml") `
            -secrets `
@"
{
'SUPPORT_TICKET_DEPLOY_DB_CONN_STRING_AUTH':  'SomeDbAuthConnString',
'SUPPORT_TICKET_DEPLOY_JWT_SECRET':  'SomeJwtSecret',
'SUPPORT_TICKET_DEPLOY_DB_SA_PASSWORD':  'SomedbSaPassword',
'SUPPORT_TICKET_DEPLOY_DB_CONN_STRING':  'SomeDbConnString'
}
"@
