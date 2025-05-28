using Microsoft.Extensions.Options;
using SmartStocker.Models;

namespace SmartStocker.Abscrations
{
    public abstract class SmartStockerBaseService(IOptions<Connections> conn)
    {
        protected readonly string DefaultConnection = conn.Value.DefaultConnection;
    }
}
