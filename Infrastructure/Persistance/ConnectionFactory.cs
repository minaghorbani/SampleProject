using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public static class ConnectionFactory
    {
        public static string GetConnectionString()
        {
            return "Server=DESKTOP-L35V6LG;Database=CookSteps2;User ID=Mina;Password=Dapa123456";
        }
    }
}
