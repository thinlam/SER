using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using BuildingBlocks.CrossCutting.Exceptions;
using BuildingBlocks.CrossCutting.Factories;

namespace BuildingBlocks.Persistence.Factories;

public class DbConnectionFactory(IConfiguration configuration) : IDbConnectionFactory
{
    public IDbConnection CreateConnection(string name = "DefaultConnection")
    {
        var connStr = configuration.GetConnectionString(name)
                      ?? throw new ManagedException($"Connection string '{name}' not found.");
        return new SqlConnection(connStr);
    }
}