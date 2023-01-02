using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TarefaApiDapper.Data
{
    public class TarefaContext
    {
        public delegate Task<IDbConnection> GetConnection();
    }
}