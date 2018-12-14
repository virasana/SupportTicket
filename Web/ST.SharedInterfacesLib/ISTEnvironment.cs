using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SharedInterfacesLib
{
    public interface ISTEnvironment
    {
        string JWTSecret { get; }
    }
}
