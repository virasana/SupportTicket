using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ST.SharedInterfacesLib;

namespace ST.Web.Services
{
    public class STEnvironment : ISTEnvironment
    {
        public string JWTSecret => Environment
            .GetEnvironmentVariable(App.Constants.JWTSecret);
    }
}
