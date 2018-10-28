using System;

namespace OMPhoenix.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        OMPhoenixContext Init();
    }
}
