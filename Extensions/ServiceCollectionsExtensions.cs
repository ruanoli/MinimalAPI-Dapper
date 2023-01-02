using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static TarefaApiDapper.Data.TarefaContext;

namespace TarefaApiDapper.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddScoped<GetConnection>(x => 
            async () =>
            {
                var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                return connection;
            });

            return builder;
        }
    }
}