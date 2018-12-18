using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.Web.Services
{
    public static class App
    {
        public static class Constants
        {
            // Note these constants must be prefixed as below - tight coupling to deployment process
            // Need to update docker-compose yaml files for dev
            // And tokenise the yaml files in Development folder for K8s deployments
            // Secrets will be injected at deployment time if the prefix is SUPPORT_TICKET_DEPLOY

            public const string ConnStringSupportTicket = "SUPPORT_TICKET_DEPLOY_DB_CONN_STRING";
            public const string ConnStringAuth = "SUPPORT_TICKET_DEPLOY_DB_CONN_STRING_AUTH";
            public const string JWTSecret = "SUPPORT_TICKET_DEPLOY_JWT_SECRET";
            public const string AssemblyUsersRepoLib = "ST.UsersRepoLib";
        }
    }
}
